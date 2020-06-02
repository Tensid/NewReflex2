import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateAgsConfig } from '../../api/api';
import CheckboxInput from './CheckboxInput';
import PasswordInput from './PasswordInput';
import TextInput from './TextInput';

const AgsConfigForm = ({ formData, hideActiveForm }: any) => {
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
    await updateAgsConfig(data);
    hideActiveForm();
  };

  return (
    <>
      <h4>AGS</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="username" label="Användarnamn" register={register} />
            <PasswordInput name="password" label="Lösenord" register={register} />
            <TextInput name="instance" label="Instans" register={register} />
            <TextInput name="department" label="Avdelning" register={register} />
            <TextInput name="searchWay" label="Söksätt" register={register} />
            <TextInput name="casePattern" label="Mall för ärendetext" register={register} />
            <TextInput name="documentPattern" label="Mall för handlingstext" register={register} />
            <TextInput name="dateField" label="Datumfält" register={register} />
            <CheckboxInput name="estateNameSearch" label="Sökning på fastighetsbeteckning" register={register} />
            <TextInput defaultValue={formData?.serviceUrl} name="ServiceUrl" label="Service URL" register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
          </form>
        </div>
      </div>
    </>
  );
};

export default AgsConfigForm;
