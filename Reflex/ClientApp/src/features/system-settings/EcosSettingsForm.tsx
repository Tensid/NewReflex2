import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateEcosSettings } from '../../api/settings/settingsApi';
import PasswordInput from '../common/forms/PasswordInput';
import TextInput from '../common/forms/TextInput';

const EcosSettingsForm = ({ formData, setActiveKey }: any) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    await updateEcosSettings(data);
    setActiveKey('');
  };

  return (
    <>
      <h4>Ecos</h4>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextInput defaultValue={formData?.serviceUrl} name="serviceUrl" label="Service URL" required register={register} />
        <TextInput defaultValue={formData?.username} name="username" label="Användarnamn" register={register} />
        <PasswordInput defaultValue={formData?.password} name="password" label="Lösenord" register={register} />
        <button className="btn btn-primary" type="submit">Spara</button>
      </form>
    </>
  );
};

export default EcosSettingsForm;
