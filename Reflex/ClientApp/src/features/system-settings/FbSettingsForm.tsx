import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateFbSettings } from '../../api/settings/settingsApi';
import PasswordInput from '../common/forms/PasswordInput';
import TextInput from '../common/forms/TextInput';

export interface FbSettingsFormProps {
  formData: any;
  setActiveKey: (key: string) => void;
}

const FbSettingsForm = ({ formData, setActiveKey }: FbSettingsFormProps) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    await updateFbSettings(data);
    setActiveKey('');
  };

  return (
    <>
      <h6>FB</h6>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextInput name="fbWebbBoendeUrl" label="FB Webb Befolkningsrapport URL" register={register} />
        <TextInput name="fbWebbLagenhetUrl" label="FB Webb Lägenhetsrapport URL" register={register} />
        <TextInput name="fbWebbFastighetUrl" label="FB Webb Fastighetsrapport URL" register={register} />
        <TextInput name="fbWebbFastighetUsrUrl" label="FB Webb Fastighetsrapport med val URL" register={register} />
        <TextInput name="fbWebbByggnadUrl" label="FB Webb Byggnadsrapport URL" register={register} />
        <TextInput name="fbWebbByggnadUsrUrl" label="FB Webb Byggnadsrapport med val URL" register={register} />
        <hr />
        <TextInput name="fbServiceUrl" label="FB Service URL" register={register} />
        <TextInput name="fbServiceDatabase" label="FB Databasnamn" register={register} />
        <TextInput name="fbServiceUser" label="FB Användarnamn" register={register} />
        <PasswordInput name="fbServicePassword" label="FB Lösenord" register={register} />
        <button className="btn btn-primary" type="submit">Spara</button>
      </form>
    </>
  );
};

export default FbSettingsForm;
