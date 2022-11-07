import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { ArendeStatus, ByggrConfig, Visibility, createByggrConfig, deleteByggrConfig, updateByggrConfig } from '../../api/api';
import CheckboxInput from '../common/forms/CheckboxInput';
import CreatableSelectInput from '../common/forms/CreateableSelectInput';
import DateInput from '../common/forms/DateInput';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const tabOptions = [
  { value: 'Preview', label: 'Förhandsgranskning' },
  { value: 'Persons', label: 'Intressenter' }
];

const occurenceVisibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj sekretess' },
  { value: Visibility.Restrict, label: 'Visa förekomst' }
];

const statusOptions = [
  { value: ArendeStatus.Avslutat, label: ArendeStatus.Avslutat },
  { value: ArendeStatus.Pågende, label: ArendeStatus.Pågende },
  { value: ArendeStatus.Gallrat, label: ArendeStatus.Gallrat },
  { value: ArendeStatus.Makulerat, label: ArendeStatus.Makulerat }
];

export interface ByggrConfigFormProps {
  edit: boolean;
  formData: ByggrConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const ByggrConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: ByggrConfigFormProps) => {
  const minCaseStartDate = (edit && !!formData?.minCaseStartDate) ? (new Date(formData?.minCaseStartDate)).toLocaleDateString() : null;
  const diarieprefixes = edit ? formData?.diarieprefixes?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const documentTypes = edit ? formData?.documentTypes?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const occurenceTypes = edit ? formData?.occurenceTypes?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const personRoles = edit ? formData?.personRoles?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const statuses = edit ? formData?.statuses?.map((x) => ({ value: x, label: x })) ?? [] : [{ value: ArendeStatus.Makulerat, label: ArendeStatus.Makulerat }];

  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        tabs: formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })),
        hideConfidentialOccurences: formData?.hideConfidentialOccurences in Visibility ? { value: formData.hideConfidentialOccurences, label: occurenceVisibilityOptions.find((t) => t.value === formData.hideConfidentialOccurences)!.label } : [],
        minCaseStartDate,
        diarieprefixes,
        documentTypes,
        occurenceTypes,
        personRoles,
        statuses
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      tabs: edit ? formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })) : [],
      hideConfidentialOccurences: formData?.hideConfidentialOccurences in Visibility ? { value: formData.hideConfidentialOccurences, label: occurenceVisibilityOptions.find((t) => t.value === formData.hideConfidentialOccurences)!.label } : [],
      minCaseStartDate,
      diarieprefixes,
      documentTypes,
      occurenceTypes,
      personRoles,
      statuses
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.hideConfidentialOccurences = data.hideConfidentialOccurences?.value;
    data.diarieprefixes = data?.diarieprefixes?.map((x: any) => x.value);
    data.documentTypes = data?.documentTypes?.map((x: any) => x.value);
    data.hideDocumentsWithCommentMatching = data?.hideDocumentsWithCommentMatching || null;
    data.minCaseStartDate = data?.minCaseStartDate || null;
    data.occurenceTypes = data?.occurenceTypes?.map((x: any) => x.value);
    data.personRoles = data?.personRoles?.map((x: any) => x.value);
    data.tabs = data?.tabs?.map((x: any) => x.value);
    data.statuses = data?.statuses?.map((x: any) => x.value);

    if (edit) {
      data.id = formData.id;
      await updateByggrConfig(data);
    }
    else {
      data.id = undefined;
      await createByggrConfig(data);
    }

    fetchAll();
    hideActiveForm();
  };

  return (
    <>
      <h4>ByggR</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="name" label="Namn" required register={register} />
            <CreatableSelectInput control={control} name="documentTypes" label="Handlingstyper" isMulti register={register} options={documentTypes} />
            <CreatableSelectInput control={control} name="occurenceTypes" label="Händelsetyper" isMulti register={register} options={occurenceTypes} />
            <CreatableSelectInput control={control} name="personRoles" label="Roller" isMulti register={register} options={personRoles} />
            <SelectInput control={control} name="tabs" label="Flikar" isMulti register={register} options={tabOptions} />
            <CreatableSelectInput control={control} name="diarieprefixes" label="Diarier" isMulti register={register} options={diarieprefixes} />
            <CheckboxInput name="workingMaterial" label="Visa arbetsmaterial" register={register} />
            <SelectInput control={control} name="hideConfidentialOccurences" label="Sekretess på händelser" register={register} options={occurenceVisibilityOptions} />
            <TextInput name="hideDocumentsWithCommentMatching" label="Dölj handlingar med kommentar" register={register} />
            <CheckboxInput name="onlyActiveCases" label="Endast aktiva ärenden" register={register} />
            <CheckboxInput name="onlyCasesWithoutMainDecision" label="Endast ärenden utan huvudbeslut" register={register} />
            <DateInput name="minCaseStartDate" label="Tidigaste startdatum" register={register} />
            <SelectInput control={control} name="statuses" label="Statusar på ärenden att exkludera" isMulti register={register} options={statusOptions} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ms-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteByggrConfig(formData.id);
                  fetchAll();
                  hideActiveForm();
                }}
              >
                Ta bort
              </button>
            }
          </form>
        </div>
      </div>
    </>
  );
};

export default ByggrConfigForm;
