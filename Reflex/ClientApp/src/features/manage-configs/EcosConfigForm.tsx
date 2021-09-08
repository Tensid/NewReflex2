import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { EcosConfig, createEcosConfig, deleteEcosConfig, updateEcosConfig } from '../../api/api';
import CheckboxInput from '../common/forms/CheckboxInput';
import TextInput from '../common/forms/TextInput';


export interface EcosConfigFormProps {
  edit: boolean;
  formData: EcosConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const EcosConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: EcosConfigFormProps) => {
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
            <CheckboxInput name="hideCasesWithSecretOccurences" label="Dölj ärenden med sekretess" register={register} />
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
