import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateIipaxSettings } from '../../api/settings';
import TextInput from '../common/forms/TextInput';

export interface IipaxSettingsFormProps {
  formData: any;
  setActiveKey: (key: string) => void;
}

const IipaxSettingsForm = ({ formData, setActiveKey }: IipaxSettingsFormProps) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    await updateIipaxSettings(data);
    setActiveKey('');
  };

  return (
    <>
      <h4>iipax</h4>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextInput defaultValue={formData?.serviceUrl} name="serviceUrl" label="Service URL" required register={register} />
        <button className="btn btn-primary" type="submit">Spara</button>
      </form>
    </>
  );
};

export default IipaxSettingsForm;
