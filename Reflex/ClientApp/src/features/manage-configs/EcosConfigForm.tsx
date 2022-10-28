import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { EcosConfig, Visibility, createEcosConfig, deleteEcosConfig, updateEcosConfig } from '../../api/api';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';
import documentTypes from './documentClassificationTypes.json';
import occurrenceTypes from './occurrenceTypes.json';
import processTypes from './processTypes.json';

const caseVisibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj sekretess' },
  { value: Visibility.Show, label: 'Visa sekretess' }
];

const documentVisibilityOptions = [
  { value: Visibility.Hide, label: 'Dölj sekretess' },
  { value: Visibility.Restrict, label: 'Visa förekomst' },
  { value: Visibility.Show, label: 'Visa sekretess' }
];

const documentTypesOptions = documentTypes.map(x => ({ value: x.DocumentTypeId, label: x.DocumentClassificationTypeDescription }));
const occurrenceTypesOptions = occurrenceTypes.map(x => ({ value: x.OccurrenceTypeId, label: x.OccurrenceDescription }));
const processTypesOptions = processTypes.map(x => ({ value: x.ProcessTypeName, label: x.ProcessTypeName }));

export interface EcosConfigFormProps {
  edit: boolean;
  formData: EcosConfig;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const EcosConfigForm = ({ edit, formData, fetchAll, hideActiveForm }: EcosConfigFormProps) => {
  const documentTypes = edit ? formData?.documentTypes?.map((x) => ({ value: x, label: documentTypesOptions.find((t) => t.value === x.toUpperCase())?.label })) ?? [] : [];
  const occurrenceTypes = edit ? formData?.occurrenceTypes?.map((x) => ({ value: x, label: occurrenceTypesOptions.find((t) => t.value === x.toUpperCase())?.label })) ?? [] : [];
  const processTypes = edit ? formData?.processTypes?.map((x) => ({ value: x, label: x })) ?? [] : [];

  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        hideConfidentialCases: formData?.hideConfidentialCases in Visibility ? { value: formData.hideConfidentialCases, label: caseVisibilityOptions.find((t) => t.value === formData.hideConfidentialCases)!.label } : [],
        hideConfidentialDocuments: formData?.hideConfidentialDocuments in Visibility ? { value: formData.hideConfidentialDocuments, label: documentVisibilityOptions.find((t) => t.value === formData.hideConfidentialDocuments)!.label } : [],
        documentTypes: documentTypes,
        occurrenceTypes: occurrenceTypes,
        processTypes: processTypes
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      hideConfidentialCases: formData?.hideConfidentialCases in Visibility ? { value: formData.hideConfidentialCases, label: caseVisibilityOptions.find((t) => t.value === formData.hideConfidentialCases)!.label } : [],
      hideConfidentialDocuments: formData?.hideConfidentialDocuments in Visibility ? { value: formData.hideConfidentialDocuments, label: documentVisibilityOptions.find((t) => t.value === formData.hideConfidentialDocuments)!.label } : [],
      documentTypes: documentTypes,
      occurrenceTypes: occurrenceTypes,
      processTypes: processTypes
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.hideConfidentialCases = data.hideConfidentialCases?.value;
    data.hideConfidentialDocuments = data.hideConfidentialDocuments?.value;
    data.documentTypes = data?.documentTypes?.map((x: any) => x.value);
    data.occurrenceTypes = data?.occurrenceTypes?.map((x: any) => x.value);
    data.processTypes = data?.processTypes?.map((x: any) => x.value);

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
            <SelectInput control={control} name="processTypes" label="Ärendentyper att exkludera" isMulti isSearchable register={register} options={processTypesOptions} />
            <SelectInput control={control} name="occurrenceTypes" label="Händelsetyper att exkludera" isMulti isSearchable register={register} options={occurrenceTypesOptions} />
            <SelectInput control={control} name="documentTypes" label="Dokumenttyper att exkludera" isMulti isSearchable register={register} options={documentTypesOptions} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ms-2"
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
