import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { AgsConfig, createAgsConfig, deleteAgsConfig, updateAgsConfig } from '../../api/api';
import CheckboxInput from '../common/forms/CheckboxInput';
import PasswordInput from '../common/forms/PasswordInput';
import TextInput from '../common/forms/TextInput';

export interface AgsConfigFormProps {
  edit: boolean;
  formData: AgsConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const AgsConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: AgsConfigFormProps) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { ...formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    if (edit) {
      data.id = formData.id;
      await updateAgsConfig(data);
    }
    else {
      data.id = undefined;
      await createAgsConfig(data);
    }

    fetchAll();
    hideActiveForm();
  };

  return (
    <>
      <h4>AGS</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="name" label="Namn" required register={register} />
            <TextInput name="username" label="Användarnamn" register={register} />
            <PasswordInput name="password" label="Lösenord" register={register} />
            <TextInput name="instance" label="Instans" register={register} />
            <TextInput name="department" label="Avdelning" register={register} />
            <TextInput name="searchWay" label="Söksätt" register={register} />
            <TextInput name="casePattern" label="Mall för ärendetext" register={register} />
            <TextInput name="documentPattern" label="Mall för handlingstext" register={register} />
            <TextInput name="dateField" label="Datumfält" register={register} />
            <CheckboxInput name="estateNameSearch" label="Sökning på fastighetsbeteckning" register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ml-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteAgsConfig(formData.id);
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

export default AgsConfigForm;
