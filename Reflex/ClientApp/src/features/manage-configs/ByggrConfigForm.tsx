import chroma from 'chroma-js';
import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { StylesConfig } from 'react-select/dist/declarations/src/styles';
import { ArendeStatus, ByggrConfig, SelectOption, Visibility, createByggrConfig, deleteByggrConfig, updateByggrConfig } from '../../api/api';
import CheckboxInput from '../common/forms/CheckboxInput';
import CreatableSelectInput from '../common/forms/CreateableSelectInput';
import DateInput from '../common/forms/DateInput';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const getColor = () => {
  return chroma("LightSlateGray");
};

const colourStyles: any = {
  option: (styles: any, { data, isDisabled, isFocused, isSelected }: any) => {
    if (data.active)
      return { ...styles };

    const color = getColor();
    return {
      ...styles,
      backgroundColor: isDisabled
        ? undefined
        : isSelected
          ? color.css()
          : isFocused
            ? color.alpha(0.1).css()
            : undefined,
      color: isDisabled
        ? '#ccc'
        : isSelected
          ? chroma.contrast(color, 'white') > 2
            ? 'white'
            : 'black'
          : color.css(),
      cursor: isDisabled ? 'not-allowed' : 'default',
      ':active': {
        ...styles[':active'],
        backgroundColor: !isDisabled
          ? isSelected
            ? color.css()
            : color.alpha(0.3).css()
          : undefined
      }
    };
  },
  multiValue: (styles: any, { data }: any) => {
    if (data.active)
      return { ...styles };
    const color = getColor();
    return {
      ...styles,
      backgroundColor: color.alpha(0.1).css()
    };
  },
  multiValueLabel: (styles: any, { data }: any) => {
    if (data.active)
      return { ...styles };
    const color = getColor();
    return {
      ...styles,
      color: color.css()
    };
  }
};

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
  documentTypeOptions: SelectOption[];
  roleOptions: SelectOption[];
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const ByggrConfigForm = ({ edit, formData, documentTypeOptions, roleOptions, fetchAll, hideActiveForm }: ByggrConfigFormProps) => {
  const minCaseStartDate = (edit && !!formData?.minCaseStartDate) ? (new Date(formData?.minCaseStartDate)).toLocaleDateString('sv-SE') : null;
  const diarieprefixes = edit ? formData?.diarieprefixes?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const hideCasesWithTextMatching = edit ? formData?.hideCasesWithTextMatching?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const hideOccurencesWithTextMatching = edit ? formData?.hideOccurencesWithTextMatching?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const hideDocumentsWithNoteTextMatching = edit ? formData?.hideDocumentsWithNoteTextMatching?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const documentTypes = edit ? formData?.documentTypes?.map((x) => ({ value: x, label: documentTypeOptions.find((t) => t.value === x)?.label, active: documentTypeOptions.find((t) => t.value === x)?.active })) ?? [] : [];
  const occurenceTypes = edit ? formData?.occurenceTypes?.map((x) => ({ value: x, label: x })) ?? [] : [];
  const personRoles = edit ? formData?.personRoles?.map((x) => ({ value: x, label: roleOptions.find((t) => t.value === x)?.label, active: roleOptions.find((t) => t.value === x)?.active })) ?? [] : [];
  const groupedPersonOptions: readonly any[] = [
    {
      label: 'Inaktiva roller',
      options: roleOptions.filter((x) => !x.active)
    }
  ];
  const activePersonRoles = roleOptions.filter((x) => x.active);

  const groupedDocumentTypeOptions: readonly any[] = [
    {
      label: 'Inaktiva handslingstyper',
      options: documentTypeOptions.filter((x) => !x.active)
    },
  ];
  const activedocumentTypeOptions = documentTypeOptions.filter((x) => x.active);

  const statuses = edit ? formData?.statuses?.map((x) => ({ value: x, label: x })) ?? [] : [{ value: ArendeStatus.Makulerat, label: ArendeStatus.Makulerat }];

  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        tabs: formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })),
        hideConfidentialOccurences: formData?.hideConfidentialOccurences in Visibility ? { value: formData.hideConfidentialOccurences, label: occurenceVisibilityOptions.find((t) => t.value === formData.hideConfidentialOccurences)!.label } : [],
        minCaseStartDate,
        diarieprefixes,
        hideCasesWithTextMatching,
        hideOccurencesWithTextMatching,
        hideDocumentsWithNoteTextMatching,
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
      hideCasesWithTextMatching,
      hideOccurencesWithTextMatching,
      hideDocumentsWithNoteTextMatching,
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
    data.hideCasesWithTextMatching = data?.hideCasesWithTextMatching?.map((x: any) => x.value);
    data.hideOccurencesWithTextMatching = data?.hideOccurencesWithTextMatching?.map((x: any) => x.value);
    data.hideDocumentsWithNoteTextMatching = data?.hideDocumentsWithNoteTextMatching?.map((x: any) => x.value);
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
            <SelectInput control={control} name="documentTypes" label="Handlingstyper att exkludera" isMulti isSearchable register={register} options={[...activedocumentTypeOptions, ...groupedDocumentTypeOptions]} styles={colourStyles} />
            <CreatableSelectInput control={control} name="occurenceTypes" label="Händelsetyper att exkludera" isMulti register={register} options={occurenceTypes} />
            <SelectInput control={control} name="personRoles" label="Roller att exkludera" isMulti isSearchable register={register} options={[...activePersonRoles, ...groupedPersonOptions]} styles={colourStyles} />
            <SelectInput control={control} name="tabs" label="Flikar" isMulti register={register} options={tabOptions} />
            <CheckboxInput name="hideNotesInPreview" label="Dölj anteckningar i förhandsgrankning" register={register} />
            <CreatableSelectInput control={control} name="diarieprefixes" label="Diarier" isMulti register={register} options={diarieprefixes} />
            <CheckboxInput name="workingMaterial" label="Visa arbetsmaterial" register={register} />
            <SelectInput control={control} name="hideConfidentialOccurences" label="Sekretess på händelser" register={register} options={occurenceVisibilityOptions} />
            <CreatableSelectInput control={control} name="hideCasesWithTextMatching" label="Dölj ärende där ärendemening innehåller följande text" isMulti register={register} options={hideCasesWithTextMatching} />
            <CreatableSelectInput control={control} name="hideOccurencesWithTextMatching" label="Dölj händelse där rubriken innehåller följande text" isMulti register={register} options={hideOccurencesWithTextMatching} />
            <CreatableSelectInput control={control} name="hideDocumentsWithNoteTextMatching" label="Dölj handlingar där anteckning innehåller följande text" isMulti register={register} options={hideDocumentsWithNoteTextMatching} />
            <CheckboxInput name="onlyActiveCases" label="Endast aktiva ärenden" register={register} />
            <CheckboxInput name="onlyCasesWithoutMainDecision" label="Endast ärenden utan huvudbeslut" register={register} />
            <DateInput name="minCaseStartDate" label="Tidigaste startdatum" register={register} />
            <SelectInput control={control} name="statuses" label="Statusar på ärenden att exkludera" isMulti register={register} options={statusOptions} menuPlacement="top" />
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
