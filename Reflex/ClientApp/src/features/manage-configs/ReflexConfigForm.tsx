import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { CaseSource, createConfig, deleteConfig, getFullConfigs, Tab, updateConfig } from '../../api/api';
import CheckboxInput from './CheckboxInput';
import PasswordInput from './PasswordInput';
import SelectInput from './SelectInput';
import TextInput from './TextInput';

const caseSourceOptions = [
  { value: CaseSource.AGS, label: CaseSource.AGS },
  { value: CaseSource.ByggR, label: CaseSource.ByggR },
  { value: CaseSource.Ecos, label: CaseSource.Ecos }
];

const tabOptions = [
  { value: Tab.Map, label: 'Karta' },
  { value: Tab.Cases, label: 'Ärenden' },
  { value: Tab.Population, label: 'Befolkning' },
  { value: Tab.Property, label: 'Fastighet' }
];

const ConfigForm = ({ formData, hideActiveForm, edit, setConfigs }: any) => {
  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        tabs: formData?.tabs?.map((x: any) => ({ value: x, label: tabOptions.find((t: any) => t.value === x)!.label })),
        caseSources: formData?.caseSources?.map((x: any) => ({ value: x, label: x })) || []
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      tabs: formData?.tabs?.map((x: any) => ({ value: x, label: tabOptions.find((t: any) => t.value === x)!.label })),
      caseSources: formData?.caseSources?.map((x: any) => ({ value: x, label: x })) || []
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.caseSources = data?.caseSources?.map((x: any) => x.value);
    data.tabs = data?.tabs?.map((x: any) => x.value);

    if (edit) {
      data.id = formData.id;
      await updateConfig(data);
    }
    else
      await createConfig(data);
    setConfigs(await getFullConfigs());
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
            <CheckboxInput name="default" label="Ange som standard" register={register} />
            <CheckboxInput name="visible" label="Synlig" register={register} />
            <SelectInput control={control} name="tabs" label="Flikar" isMulti register={register} options={tabOptions} />
            <SelectInput control={control} name="caseSources" label="Ärendekällor" isMulti register={register} options={caseSourceOptions} />
            <TextInput name="fbWebbBoendeUrl" label="FB Webb Befolkningsrapport URL" register={register} />
            <TextInput name="fbWebbLagenhetUrl" label="FB Webb Lägenhetsrapport URL" register={register} />
            <TextInput name="fbWebbFastighetUrl" label="FB Webb Fastighetsrapport URL" register={register} />
            <TextInput name="fbWebbFastighetUsrUrl" label="FB Webb Fastighetsrapport med val URL" register={register} />
            <TextInput name="fbWebbByggnadUrl" label="FB Webb Byggnadsrapport URL" register={register} />
            <TextInput name="fbWebbByggnadUsrUrl" label="FB Webb Byggnadsrapport med val URL" register={register} />
            <TextInput name="fbServiceUrl" label="FB Service URL" register={register} />
            <TextInput name="fbServiceDatabase" label="FB Databasnamn" register={register} />
            <TextInput name="fbServiceUser" label="Användarnamn" register={register} />
            <PasswordInput name="fbServicePassword" label="FB Lösenord" register={register} />
            <TextInput name="csmUrl" label="CSM URL" register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ml-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteConfig(formData.id);
                  setConfigs(await getFullConfigs());
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
