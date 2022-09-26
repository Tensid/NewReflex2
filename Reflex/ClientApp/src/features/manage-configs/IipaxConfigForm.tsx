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
        objectTypes: objectTypes,
        secrecyVisibility: formData?.secrecyVisibility in visibilityOptions ? { value: formData.secrecyVisibility, label: visibilityOptions.find((t: any) => t.value === formData.secrecyVisibility)!.label } : [],
        pulPersonalSecrecyVisibility: formData?.pulPersonalSecrecyVisibility in visibilityOptions ? { value: formData.pulPersonalSecrecyVisibility, label: visibilityOptions.find((t: any) => t.value === formData.pulPersonalSecrecyVisibility)!.label } : [],
        otherSecrecyVisibility: formData?.otherSecrecyVisibility in visibilityOptions ? { value: formData.otherSecrecyVisibility, label: visibilityOptions.find((t: any) => t.value === formData.otherSecrecyVisibility)!.label } : []
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      objectTypes: objectTypes,
      secrecyVisibility: formData?.secrecyVisibility in visibilityOptions ? { value: formData.secrecyVisibility, label: visibilityOptions.find((t: any) => t.value === formData.secrecyVisibility)!.label } : [],
      pulPersonalSecrecyVisibility: formData?.pulPersonalSecrecyVisibility in visibilityOptions ? { value: formData.pulPersonalSecrecyVisibility, label: visibilityOptions.find((t: any) => t.value === formData.pulPersonalSecrecyVisibility)!.label } : [],
      otherSecrecyVisibility: formData?.otherSecrecyVisibility in visibilityOptions ? { value: formData.otherSecrecyVisibility, label: visibilityOptions.find((t: any) => t.value === formData.otherSecrecyVisibility)!.label } : []
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.objectTypes = data?.objectTypes?.map((x: any) => x.value);
    data.secrecyVisibility = data.secrecyVisibility?.value;
    data.pulPersonalSecrecyVisibility = data.pulPersonalSecrecyVisibility?.value;
    data.otherSecrecyVisibility = data.otherSecrecyVisibility?.value;

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
            <SelectInput control={control} name="secrecyVisibility" label="Sekretess" register={register} options={visibilityOptions} />
            <SelectInput control={control} name="pulPersonalSecrecyVisibility" label="Personuppgifter" register={register} options={visibilityOptions} />
            <SelectInput control={control} name="otherSecrecyVisibility" label="Övrigt skydd" register={register} options={visibilityOptions} />
            <CreatableSelectInput control={control} name="objectTypes" label="Objekttyper" isMulti register={register} options={objectTypesOptions}
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
