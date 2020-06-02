import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateEcosConfig } from '../../api/api';
import PasswordInput from './PasswordInput';
import TextInput from './TextInput';

const EcosConfigForm = ({ formData, hideActiveForm }: any) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.id = formData.id;
    data.configId = formData.configId;
    await updateEcosConfig(data);
    hideActiveForm();
  };

  return (
    <>
      <h4>Ecos</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput defaultValue={formData?.serviceUrl} name="serviceUrl" label="Service URL" required register={register} />
            <TextInput defaultValue={formData?.username} name="username" label="Användarnamn" register={register} />
            <PasswordInput defaultValue={formData?.password} name="password" label="Lösenord" register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
          </form>
        </div>
      </div>
    </>
  );
};

export default EcosConfigForm;
