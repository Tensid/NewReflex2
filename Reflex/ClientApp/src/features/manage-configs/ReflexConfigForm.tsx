import { faArchive, faBug, faHammer, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import chroma from 'chroma-js';
import { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { components, OptionProps } from 'react-select';
import { StylesConfig } from 'react-select/dist/declarations/src/styles';
import { CaseSource, CaseSourceOption, ConfigFormData, createConfig, deleteConfig, Tab, updateConfig } from '../../api/api';
import SelectInput from '../common/forms/SelectInput';
import TextInput from '../common/forms/TextInput';

const getColor = (caseSource: CaseSource) => {
  const styles = getComputedStyle(document.documentElement);
  switch (caseSource) {
    case CaseSource.AGS:
    case CaseSource.iipax:
      return chroma(styles.getPropertyValue('--bs-warning').trim());
    case CaseSource.ByggR:
      return chroma(styles.getPropertyValue('--bs-info').trim());
    case CaseSource.Ecos:
      return chroma(styles.getPropertyValue('--bs-success').trim());
    default:
      return chroma("Black");
  }
};

const Option = (props: OptionProps<CaseSourceOption>) => {
  let color = 'secondary';
  let icon: IconDefinition;
  const caseSource = props.data.caseSource;
  switch (caseSource) {
    case CaseSource.AGS:
    case CaseSource.iipax:
      color = 'warning';
      icon = faArchive;
      break;
    case CaseSource.ByggR:
      color = 'info';
      icon = faHammer;
      break;
    case CaseSource.Ecos:
      color = 'success';
      icon = faBug;
      break;
  }

  return (
    <components.Option {...props}>
      <FontAwesomeIcon className={`text-${color} pe-2`} icon={icon!} />{' '}{props.data.label}
    </components.Option>
  );
};

const colourStyles: any = {
  option: (styles: any, { data, isDisabled, isFocused, isSelected }: any) => {
    let color = getColor(data.caseSource);
    return {
      ...styles,
      backgroundColor: isDisabled
        ? undefined
        : isSelected
          ? color.css()
          : isFocused
            ? color.alpha(0.1).css()
            : undefined,
      cursor: isDisabled ? 'not-allowed' : 'default',
      ':active': {
        ...styles[':active'],
        backgroundColor: !isDisabled
          ? isSelected
            ? color.css()
            : color.alpha(0.3).css()
          : undefined
      },
    };
  },
  multiValue: (styles: any, { data }: any) => {
    const color = getColor(data.caseSource);
    return {
      ...styles,
      backgroundColor: color.alpha(0.1).css()
    };
  },
  multiValueLabel: (styles: any, { data }: any) => {
    return {
      ...styles
    };
  },
  multiValueRemove: (styles: any, { data }: any) => {
    const color = getColor(data.caseSource);
    return {
      ...styles,
      color: color.css(),
      ':hover': {
        backgroundColor: color.css(),
        color: 'white'
      }
    };
  },
};

const tabOptions = [
  { value: Tab.Map, label: 'Karta' },
  { value: Tab.Cases, label: 'Ärenden' },
  { value: Tab.Population, label: 'Befolkning' },
  { value: Tab.Property, label: 'Fastighet' }
];

export interface ConfigFormProps {
  edit: boolean;
  formData: ConfigFormData;
  caseSourceOptions: CaseSourceOption[];
  layers: any;
  fetchAll: () => void;
  hideActiveForm: () => void;
}

const ConfigForm = ({ edit, formData, caseSourceOptions, layers, fetchAll, hideActiveForm }: ConfigFormProps) => {
  const { register, handleSubmit, control, reset } =
    useForm({
      defaultValues: {
        ...formData,
        tabs: formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })),
        caseSources: formData?.caseSources || [],
        map: formData?.map?.map((x) => (layers.find((l: any) => l.value === x))) || []
      }
    });

  useEffect(() => {
    reset({
      ...formData,
      tabs: formData?.tabs?.map((x) => ({ value: x, label: tabOptions.find((t) => t.value === x)!.label })),
      caseSources: formData?.caseSources || [],
      map: formData?.map?.map((x) => (layers.find((l: any) => l.value === x))) || []
    });
  }, [formData, reset]);

  const onSubmit = async (data: any) => {
    data.tabs = data?.tabs?.map((x: any) => x.value);
    data.map = data?.map?.map((x: any) => x.value);

    if (edit) {
      data.id = formData.id;
      await updateConfig(data);
    }
    else
      await createConfig(data);
    fetchAll();
    hideActiveForm();
  };

  return (
    <>
      <h6>{edit ? 'Konfigurationsredigering' : 'Skapa konfiguration'}</h6>
      <div className="row">
        <div className="col">
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextInput name="name" label="Namn" required register={register} />
            <TextInput name="description" label="Beskrivning" register={register} />
            <SelectInput control={control} name="map" label="Karta" isMulti register={register} options={layers} />
            <SelectInput control={control} name="tabs" label="Flikar" isMulti register={register} options={tabOptions} />
            <SelectInput control={control} name="caseSources" label="Ärendekällor" isMulti register={register} components={{ Option }} options={caseSourceOptions} styles={colourStyles} />
            <button className="btn btn-primary" type="submit">Spara</button>
            {edit &&
              <button
                className="btn btn-primary ms-2"
                onClick={async (e) => {
                  e.preventDefault();
                  await deleteConfig(formData.id);
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

export default ConfigForm;
