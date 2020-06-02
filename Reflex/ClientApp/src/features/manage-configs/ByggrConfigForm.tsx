import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { updateByggrConfig } from '../../api/api';
import CheckboxInput from './CheckboxInput';
import DateInput from './DateInput';
import TextInput from './TextInput';

const ByggrConfigForm = ({ formData, hideActiveForm }: any) => {
  const minCaseStartDate = !!formData?.minCaseStartDate ? (new Date(formData?.minCaseStartDate)).toLocaleDateString() : null;
  const { register, handleSubmit, reset } =
    useForm({
      defaultValues: {
        ...formData,
        minCaseStartDate
      },
    });

  useEffect(() => {
    reset({
      ...formData,
      minCaseStartDate
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.id = formData.id;
    data.configId = formData.configId;
    data.documentTypes = data?.documentTypes || null;
    data.hideDocumentsWithCommentMatching = data.hideDocumentsWithCommentMatching || null;
    data.minCaseStartDate = data?.minCaseStartDate || null;
    data.occurenceTypes = data?.occurenceTypes || null;
    data.personRoles = data?.personRoles || null;
    data.tabs = data?.tabs || null;
    await updateByggrConfig(data);
    hideActiveForm();
  };

  return (
    <>
      <h4>ByggR</h4>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="documentTypes" label="Handlingstyper" register={register} />
            <TextInput name="occurenceTypes" label="Händelsetyper" register={register} />
            <TextInput name="personRoles" label="Roller" register={register} />
            <TextInput name="tabs" label="Flikar" register={register} />
            <CheckboxInput name="workingMaterial" label="Visa arbetsmaterial" register={register} />
            <CheckboxInput name="hideCasesWithSecretOccurences" label="Dölj ärenden med sekretess" register={register} />
            <TextInput name="hideDocumentsWithCommentMatching" label="Dölj handlingar med kommentar" register={register} />
            <CheckboxInput name="onlyCasesWithoutMainDecision" label="Endast aktiva (utan huvudbeslut)" register={register} />
            <DateInput name="minCaseStartDate" label="Tidigaste startdatum (ÅÅÅÅ-MM-DD)" register={register} />
            <TextInput name="serviceUrl" label="Service URL" register={register} />
            <button className="btn btn-primary" type="submit">Spara</button>
          </form>
        </div>
      </div>
    </>
  );
};

export default ByggrConfigForm;
