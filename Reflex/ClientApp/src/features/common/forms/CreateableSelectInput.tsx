import { Controller } from 'react-hook-form';
import CreatableSelect from 'react-select/creatable';

const CreatableSelectInput = ({ name, label, options, isMulti, control, ...props }: any) => {
  return (
    <div className="mb-3">
      <label htmlFor={name}>{label}</label>
      <Controller
        as={<CreatableSelect />}
        isMulti={isMulti}
        placeholder={`Välj ${label.toLowerCase()}...`}
        formatCreateLabel={(value: string) => <>{`Lägg till "${value}"`}</>}
        noOptionsMessage={() => null}
        closeMenuOnSelect={false}
        options={options}
        defaultValue={[]}
        name={name}
        control={control}
        {...props}
      />
    </div>
  );
};

export default CreatableSelectInput;
