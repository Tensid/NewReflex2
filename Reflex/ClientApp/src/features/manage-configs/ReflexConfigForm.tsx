import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { CaseSourceOption, ConfigFormData, createConfig, deleteConfig, Tab, updateConfig } from '../../api/api';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const tabOptions = [
  { value: Tab.Map, label: 'Karta' },
  { value: Tab.Cases, label: 'Ärenden' },
  { value: Tab.Population, label: 'Befolkning' },
  { value: Tab.Property, label: 'Fastighet' }
];

export interface ConfigFormProps {
  edit: boolean;
  formData: ConfigFormData;
  caseSourceOptions: CaseSourceOption[];
  layers: any;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const ConfigForm = ({ edit, formData, caseSourceOptions, layers, fetchAll, hideActiveForm }: ConfigFormProps) => {
  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        tabs: formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })),
        caseSources: formData?.caseSources || [],
        map: formData?.map?.map((x) => (layers.find((l: any) => l.value === x))) || []
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      tabs: formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })),
      caseSources: formData?.caseSources || [],
      map: formData?.map?.map((x) => (layers.find((l: any) => l.value === x))) || []
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.tabs = data?.tabs?.map((x: any) => x.value);
    data.map = data?.map?.map((x: any) => x.value);

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
            <SelectInput control={control} name="map" label="Karta" isMulti register={register} options={layers} />
            <SelectInput control={control} name="tabs" label="Flikar" isMulti register={register} options={tabOptions} />
            <SelectInput control={control} name="caseSources" label="Ärendekällor" isMulti register={register} options={caseSourceOptions} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ms-2"
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
