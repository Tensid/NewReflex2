import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateByggrSettings } from '../../api/settings/settingsApi';
import PasswordInput from '../common/forms/PasswordInput';
import TextInput from '../common/forms/TextInput';

export interface ByggrSettingsFormProps {
  formData: any;
  setActiveKey: (key: string) => void;
}

const ByggrSettingsForm = ({ formData, setActiveKey }: ByggrSettingsFormProps) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    await updateByggrSettings(data);
    setActiveKey('');
  };

  return (
    <>
      <h4>ByggR</h4>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextInput name="serviceUrl" label="Service URL" register={register} />
        <TextInput defaultValue={formData?.username} name="username" label="Användarnamn" register={register} />
        <PasswordInput defaultValue={formData?.password} name="password" label="Lösenord" register={register} />
        <button className="btn btn-primary" type="submit">Spara</button>
      </form>
    </>
  );
};

export default ByggrSettingsForm;
