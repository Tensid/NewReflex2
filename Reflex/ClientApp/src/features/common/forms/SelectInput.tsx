import { Controller } from 'react-hook-form';
import Select from 'react-select';

const SelectInput = ({ name, label, options, isMulti, control, isSearchable = false }: any) => {
  return (
    <div className="mb-3">
      <label htmlFor={name}>{label}</label>
      <Controller
        as={<Select />}
        isMulti={isMulti}
        placeholder={`Välj ${label.toLowerCase()}...`}
        noOptionsMessage={() => null}
        closeMenuOnSelect={false}
        options={options}
        defaultValue={[]}
        name={name}
        control={control}
        isSearchable={isSearchable}
      />
    </div>
  );
};

export default SelectInput;
