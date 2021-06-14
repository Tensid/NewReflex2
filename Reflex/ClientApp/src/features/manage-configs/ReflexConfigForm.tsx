import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { createConfig, deleteConfig, Tab, updateConfig } from '../../api/api';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const tabOptions = [
  { value: Tab.Map, label: 'Karta' },
  { value: Tab.Cases, label: 'Ärenden' },
  { value: Tab.Population, label: 'Befolkning' },
  { value: Tab.Property, label: 'Fastighet' }
];

const ConfigForm = ({ edit, formData, caseSourceOptions, fetchAll, hideActiveForm }: any) => {
  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        tabs: formData?.tabs?.map((x: any) => ({ value: x, label: tabOptions.find((t: any) => t.value === x)!.label })),
        caseSources: formData?.caseSources || []
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      tabs: formData?.tabs?.map((x: any) => ({ value: x, label: tabOptions.find((t: any) => t.value === x)!.label })),
      caseSources: formData?.caseSources || []
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.tabs = data?.tabs?.map((x: any) => x.value);

    if (edit) {
      data.id = formData.id;
      await updateConfig(data);
    }
    else
      await createConfig(data);
    fetchAll();
    hideActiveForm();
  };

  return (
    <>
      <h6>{edit ? 'Konfigurationsredigering' : 'Skapa konfiguration'}</h6>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="name" label="Namn" required register={register} />
            <TextInput name="description" label="Beskrivning" register={register} />
            <TextInput name="map" label="Karta" register={register} />
            <SelectInput control={control} name="tabs" label="Flikar" isMulti register={register} options={tabOptions} />
            <SelectInput control={control} name="caseSources" label="Ärendekällor" isMulti register={register} options={caseSourceOptions} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ml-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteConfig(formData.id);
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

export default ConfigForm;
