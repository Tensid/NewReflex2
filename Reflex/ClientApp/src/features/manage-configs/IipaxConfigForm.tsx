import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { IipaxConfig, Visibility, createIipaxConfig, deleteIipaxConfig, updateIipaxConfig } from '../../api/api';
import CreatableSelectInput from '../common/forms/CreateableSelectInput';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const visibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj sekretess' },
  { value: Visibility.Restrict, label: 'Visa förekomst' },
  { value: Visibility.Show, label: 'Visa sekretess' }
];

const pulVisibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj personuppifter' },
  { value: Visibility.Restrict, label: 'Visa förekomst' },
  { value: Visibility.Show, label: 'Visa personuppifter' }
];

const otherVisibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj övrigt skydd' },
  { value: Visibility.Restrict, label: 'Visa förekomst' },
  { value: Visibility.Show, label: 'Visa övrigt skydd' }
];

function resetVisibilty(value: Visibility, options: any[]) {
  return value in visibilityOptions ? { value: value, label: options.find((t: any) => t.value === value)!.label } : [];

}

export interface IipaxConfigFormProps {
  edit: boolean;
  formData: IipaxConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const IipaxConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: IipaxConfigFormProps) => {
  const objectTypes = edit ? formData?.objectTypes?.map((x) => ({ value: x, label: x })) ?? [] : [];
  let objectTypesOptions = [...objectTypes];
  if (!objectTypes.some((e) => e.value === 'environment_case')) {
    objectTypesOptions.push({ value: "environment_case", label: "Miljöärende" });
  }
  else {
    const objIndex = objectTypesOptions.findIndex((obj => obj.value === "environment_case"));
    objectTypesOptions[objIndex].label = "Miljöärende";
  }
  if (!objectTypes.some((e) => e.value === 'building_case')) {
    objectTypesOptions.push({ value: "building_case", label: "Byggärende" });
  }
  else {
    const objIndex = objectTypesOptions.findIndex((obj => obj.value === "building_case"));
    objectTypesOptions[objIndex].label = "Byggärende";
  }

  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        objectTypes,
        caseSecrecyVisibility: resetVisibilty(formData?.caseSecrecyVisibility, visibilityOptions),
        casePulPersonalSecrecyVisibility: resetVisibilty(formData?.casePulPersonalSecrecyVisibility, pulVisibilityOptions),
        caseOtherSecrecyVisibility: resetVisibilty(formData?.caseOtherSecrecyVisibility, otherVisibilityOptions),
        docSecrecyVisibility: resetVisibilty(formData?.docSecrecyVisibility, visibilityOptions),
        docPulPersonalSecrecyVisibility: resetVisibilty(formData?.docPulPersonalSecrecyVisibility, pulVisibilityOptions),
        docOtherSecrecyVisibility: resetVisibilty(formData?.docOtherSecrecyVisibility, otherVisibilityOptions),
        fileSecrecyVisibility: resetVisibilty(formData?.fileSecrecyVisibility, visibilityOptions),
        filePulPersonalSecrecyVisibility: resetVisibilty(formData?.filePulPersonalSecrecyVisibility, pulVisibilityOptions),
        fileOtherSecrecyVisibility: resetVisibilty(formData?.fileOtherSecrecyVisibility, otherVisibilityOptions)
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      objectTypes,
      caseSecrecyVisibility: resetVisibilty(formData?.caseSecrecyVisibility, visibilityOptions),
      casePulPersonalSecrecyVisibility: resetVisibilty(formData?.casePulPersonalSecrecyVisibility, pulVisibilityOptions),
      caseOtherSecrecyVisibility: resetVisibilty(formData?.caseOtherSecrecyVisibility, otherVisibilityOptions),
      docSecrecyVisibility: resetVisibilty(formData?.docSecrecyVisibility, visibilityOptions),
      docPulPersonalSecrecyVisibility: resetVisibilty(formData?.docPulPersonalSecrecyVisibility, pulVisibilityOptions),
      docOtherSecrecyVisibility: resetVisibilty(formData?.docOtherSecrecyVisibility, otherVisibilityOptions),
      fileSecrecyVisibility: resetVisibilty(formData?.fileSecrecyVisibility, visibilityOptions),
      filePulPersonalSecrecyVisibility: resetVisibilty(formData?.filePulPersonalSecrecyVisibility, pulVisibilityOptions),
      fileOtherSecrecyVisibility: resetVisibilty(formData?.fileOtherSecrecyVisibility, otherVisibilityOptions)
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.objectTypes = data?.objectTypes?.map((x: any) => x.value);
    data.caseSecrecyVisibility = data.caseSecrecyVisibility?.value;
    data.casePulPersonalSecrecyVisibility = data.casePulPersonalSecrecyVisibility?.value;
    data.caseOtherSecrecyVisibility = data.caseOtherSecrecyVisibility?.value;
    data.docSecrecyVisibility = data.docSecrecyVisibility?.value;
    data.docPulPersonalSecrecyVisibility = data.docPulPersonalSecrecyVisibility?.value;
    data.docOtherSecrecyVisibility = data.docOtherSecrecyVisibility?.value;
    data.fileSecrecyVisibility = data.fileSecrecyVisibility?.value;
    data.filePulPersonalSecrecyVisibility = data.filePulPersonalSecrecyVisibility?.value;
    data.fileOtherSecrecyVisibility = data.fileOtherSecrecyVisibility?.value;

    if (edit) {
      data.id = formData.id;
      await updateIipaxConfig(data);
    }
    else {
      data.id = undefined;
      await createIipaxConfig(data);
    }

    fetchAll();
    hideActiveForm();
  };

  return (
    <>
      <h4>iipax</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="name" label="Namn" required register={register} />
            <SelectInput control={control} name="caseSecrecyVisibility" label="Sekretess på ärende" register={register} options={visibilityOptions} />
            <SelectInput control={control} name="casePulPersonalSecrecyVisibility" label="Personuppgifter på ärende" register={register} options={pulVisibilityOptions} />
            <SelectInput control={control} name="caseOtherSecrecyVisibility" label="Övrigt skydd på ärende" register={register} options={otherVisibilityOptions} />
            <SelectInput control={control} name="docSecrecyVisibility" label="Sekretess på dokument" register={register} options={visibilityOptions} />
            <SelectInput control={control} name="docPulPersonalSecrecyVisibility" label="Personuppgifter på dokument" register={register} options={pulVisibilityOptions} />
            <SelectInput control={control} name="docOtherSecrecyVisibility" label="Övrigt skydd på dokument" register={register} options={otherVisibilityOptions} />
            <SelectInput control={control} name="fileSecrecyVisibility" label="Sekretess på filer" register={register} options={visibilityOptions} />
            <SelectInput control={control} name="filePulPersonalSecrecyVisibility" label="Personuppgifter på filer" register={register} options={pulVisibilityOptions} />
            <SelectInput control={control} name="fileOtherSecrecyVisibility" label="Övrigt skydd på filer" register={register} options={otherVisibilityOptions} />
            <CreatableSelectInput control={control} name="objectTypes" label="Objekttyper" isMulti register={register} options={objectTypesOptions} menuPlacement="top"
              getOptionLabel={(option: any) => {
                if (option.value === 'environment_case')
                  return 'Miljöärende';
                if (option.value === 'building_case')
                  return 'Byggärende';
                return option.label;
              }} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ms-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteIipaxConfig(formData.id);
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

export default IipaxConfigForm;
