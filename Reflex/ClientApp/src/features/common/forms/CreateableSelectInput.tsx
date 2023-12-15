import { Controller } from 'react-hook-form';
import CreatableSelect from 'react-select/creatable';

const CreatableSelectInput = ({ name, label, options, isMulti, control }: any) => {
  return (
    <div className="mb-3">
      <label htmlFor={name}>{label}</label>
      <Controller
        render={({ field }) => <CreatableSelect
          isMulti={isMulti}
          placeholder={`Välj ${label.toLowerCase()}...`}
          formatCreateLabel={(value) => <>{`Lägg till "${value}"`}</>}
          noOptionsMessage={() => null}
          closeMenuOnSelect={false}
          options={options}
        />}
        defaultValue={[]}
        name={name}
        control={control}
      />
    </div>
  );
};

export default CreatableSelectInput;
