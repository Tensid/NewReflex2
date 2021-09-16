import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { IipaxConfig, createIipaxConfig, deleteIipaxConfig, updateIipaxConfig } from '../../api/api';
import CheckboxInput from '../common/forms/CheckboxInput';
import CreatableSelectInput from '../common/forms/CreateableSelectInput';
import TextInput from '../common/forms/TextInput';

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
        objectTypes: objectTypes
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      objectTypes: objectTypes
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.objectTypes = data?.objectTypes?.map((x: any) => x.value);

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
            <CheckboxInput name="hideCasesWithSecrecy" label="Dölj ärenden med sekretess" register={register} />
            <CheckboxInput name="hideCasesWithPulPersonalSecrecy" label="Dölj ärenden med personuppgifter" register={register} />
            <CheckboxInput name="hideCasesWithOtherSecrecy" label="Dölj ärenden med övrigt skydd" register={register} />
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
                className="btn btn-primary ml-2"
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
