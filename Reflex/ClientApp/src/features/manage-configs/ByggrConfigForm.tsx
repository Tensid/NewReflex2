import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { ByggrConfig, createByggrConfig, deleteByggrConfig, updateByggrConfig } from '../../api/api';
import CheckboxInput from '../common/forms/CheckboxInput';
import CreatableSelectInput from '../common/forms/CreateableSelectInput';
import DateInput from '../common/forms/DateInput';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const tabOptions = [
  { value: 'Preview', label: 'Förhandsgranskning' },
  { value: 'Persons', label: 'Intressenter' }
];

export interface ByggrConfigFormProps {
  edit: boolean;
  formData: ByggrConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const ByggrConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: ByggrConfigFormProps) => {
  const minCaseStartDate = (edit && !!formData?.minCaseStartDate) ? (new Date(formData?.minCaseStartDate)).toLocaleDateString() : null;
  const diarieprefixes = edit ? formData?.diarieprefixes?.map((x: any) => ({ value: x, label: x })) ?? [] : [];

  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        tabs: formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })),
        minCaseStartDate,
        diarieprefixes
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      tabs: edit ? formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })) : [],
      minCaseStartDate,
      diarieprefixes
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.diarieprefixes = data?.diarieprefixes?.map((x: any) => x.value);
    data.documentTypes = data?.documentTypes.split(",") || null;;
    data.hideDocumentsWithCommentMatching = data?.hideDocumentsWithCommentMatching || null;
    data.minCaseStartDate = data?.minCaseStartDate || null;
    data.occurenceTypes = data?.occurenceTypes || null;
    data.personRoles = data?.personRoles.split(",") || null;
    data.tabs = data?.tabs?.map((x: any) => x.value);

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
            <TextInput name="documentTypes" label="Handlingstyper" register={register} />
            <TextInput name="occurenceTypes" label="Händelsetyper" register={register} />
            <TextInput name="personRoles" label="Roller" register={register} />
            <SelectInput control={control} name="tabs" label="Flikar" isMulti register={register} options={tabOptions} />
            <CreatableSelectInput control={control} name="diarieprefixes" label="Diarier" isMulti register={register} options={diarieprefixes} />
            <CheckboxInput name="workingMaterial" label="Visa arbetsmaterial" register={register} />
            <CheckboxInput name="hideCasesWithSecretOccurences" label="Dölj ärenden med sekretess" register={register} />
            <TextInput name="hideDocumentsWithCommentMatching" label="Dölj handlingar med kommentar" register={register} />
            <CheckboxInput name="onlyActiveCases" label="Endast aktiva ärenden" register={register} />
            <CheckboxInput name="onlyCasesWithoutMainDecision" label="Endast ärenden utan huvudbeslut" register={register} />
            <DateInput name="minCaseStartDate" label="Tidigaste startdatum (ÅÅÅÅ-MM-DD)" register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ml-2"
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
