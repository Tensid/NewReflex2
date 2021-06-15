import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateAgsSettings } from '../../api/settings/settingsApi';
import TextInput from '../common/forms/TextInput';

export interface AgsSettingsFormProps {
  formData: any;
  setActiveKey: (key: string) => void;
}

const AgsSettingsForm = ({ formData, setActiveKey }: AgsSettingsFormProps) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    await updateAgsSettings(data);
    setActiveKey('');
  };

  return (
    <>
      <h4>AGS</h4>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextInput defaultValue={formData?.serviceUrl} name="ServiceUrl" label="Service URL" register={register} />
        <button className="btn btn-primary" type="submit">Spara</button>
      </form>
    </>
  );

};

export default AgsSettingsForm;
