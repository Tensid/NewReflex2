import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateMiscSettings } from '../../api/settings/settingsApi';
import TextInput from '../common/forms/TextInput';

const MiscSettingsForm = ({ formData, setActiveKey }: any) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    await updateMiscSettings(data);
    setActiveKey('');
  };

  return (
    <>
      <h6>Övrigt</h6>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextInput name="csmUrl" label="CSM URL" register={register} />
        <button className="btn btn-primary" type="submit">Spara</button>
      </form>
    </>
  );
};

export default MiscSettingsForm;
