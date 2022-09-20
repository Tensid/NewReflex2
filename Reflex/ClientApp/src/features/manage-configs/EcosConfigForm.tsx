import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { EcosConfig, Visibility, createEcosConfig, deleteEcosConfig, updateEcosConfig } from '../../api/api';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const caseVisibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj förekomst' },
  { value: Visibility.Show, label: 'Visa sekretess' }
];

const documentVisibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj förekomst' },
  { value: Visibility.Restrict, label: 'Visa förekomst' },
  { value: Visibility.Show, label: 'Visa sekretess' }
];

export interface EcosConfigFormProps {
  edit: boolean;
  formData: EcosConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const EcosConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: EcosConfigFormProps) => {
  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        hideConfidentialCases: formData?.hideConfidentialCases in Visibility ? { value: formData.hideConfidentialCases, label: caseVisibilityOptions.find((t) => t.value === formData.hideConfidentialCases)!.label } : [],
        hideConfidentialDocuments: formData?.hideConfidentialDocuments in Visibility ? { value: formData.hideConfidentialDocuments, label: documentVisibilityOptions.find((t) => t.value === formData.hideConfidentialDocuments)!.label } : [],
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      hideConfidentialCases: formData?.hideConfidentialCases in Visibility ? { value: formData.hideConfidentialCases, label: caseVisibilityOptions.find((t) => t.value === formData.hideConfidentialCases)!.label } : [],
      hideConfidentialDocuments: formData?.hideConfidentialDocuments in Visibility ? { value: formData.hideConfidentialDocuments, label: documentVisibilityOptions.find((t) => t.value === formData.hideConfidentialDocuments)!.label } : [],
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.hideConfidentialCases = data.hideConfidentialCases?.value;
    data.hideConfidentialDocuments = data.hideConfidentialDocuments?.value;
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
            <SelectInput control={control} name="hideConfidentialCases" label="Sekretess på ärenden" register={register} options={caseVisibilityOptions} />
            <SelectInput control={control} name="hideConfidentialDocuments" label="Sekretess på handlingar" register={register} options={documentVisibilityOptions} />
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
