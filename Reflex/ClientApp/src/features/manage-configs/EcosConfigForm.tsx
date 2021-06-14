import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { createEcosConfig, deleteEcosConfig, updateEcosConfig } from '../../api/api';
import TextInput from '../common/forms/TextInput';

const EcosConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: any) => {
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: { formData }
    });

  useEffect(() => {
    reset({ ...formData });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    if (edit) {
      data.id = formData.id;
      await updateEcosConfig(data);
    }
    else {
      data.id = undefined;
      await createEcosConfig(data);
    }

    fetchAll();
    hideActiveForm();
  };

  return (
    <>
      <h4>Ecos</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="name" label="Namn" required register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ml-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteEcosConfig(formData.id);
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

export default EcosConfigForm;
