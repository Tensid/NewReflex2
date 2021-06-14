import React from 'react';
import { Controller } from 'react-hook-form';
import Select from 'react-select';

const SelectInput = ({ name, label, options, isMulti, control }: any) => {
  return (
    <div className="form-group">
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
      />
    </div>
  );
};

export default SelectInput;
