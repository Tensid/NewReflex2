import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { IipaxConfig, createIipaxConfig, deleteIipaxConfig, updateIipaxConfig } from '../../api/api';
import CheckboxInput from '../common/forms/CheckboxInput';
import TextInput from '../common/forms/TextInput';

export interface IipaxConfigFormProps {
  edit: boolean;
  formData: IipaxConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const IipaxConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: IipaxConfigFormProps) => {

  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: ({ ...formData })
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    if (edit) {
      data.id = formData.id;
      await updateIipaxConfig(data);
    }
    else {
      data.id = undefined;
      await createIipaxConfig(data);
    }

    fetchAll();
    hideActiveForm();
  };

  return (
    <>
      <h4>iipax</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="name" label="Namn" required register={register} />
            <CheckboxInput name="hideCasesWithSecrecy" label="Dölj ärenden med sekretess" register={register} />
            <CheckboxInput name="hideCasesWithPulPersonalSecrecy" label="Dölj ärenden med personuppgifter" register={register} />
            <CheckboxInput name="hideCasesWithOtherSecrecy" label="Dölj ärenden med övrigt skydd" register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ml-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteIipaxConfig(formData.id);
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

export default IipaxConfigForm;
