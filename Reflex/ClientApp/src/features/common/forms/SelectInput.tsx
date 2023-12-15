import { Controller } from 'react-hook-form';
import Select from 'react-select';

const SelectInput = ({ name, label, options, isMulti, control, isSearchable = false, ...props }: any) => {
  return (
    <div className="mb-3">
      <label htmlFor={name}>{label}</label>
      <Controller
        render={({ field }) => <Select
          {...field}
          isMulti={isMulti}
          placeholder={`Välj ${label.toLowerCase()}...`}
          noOptionsMessage={() => null}
          closeMenuOnSelect={false}
          options={options}
          isSearchable={isSearchable}
        />}
        defaultValue={[]}
        name={name}
        control={control}
        isSearchable={isSearchable}
        {...props}
      />
    </div>
  );
};

export default SelectInput;
