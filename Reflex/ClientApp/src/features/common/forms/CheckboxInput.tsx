import React from 'react';

const CheckboxInput = ({ name, required, register, label }: any) => {
  return (
    <div className="form-check">
      <input type="checkbox" className="form-check-input" name={name} ref={register({ required: required })} />
      <label htmlFor={name} className="form-check-label">{label}</label>
    </div>
  );
};

export default CheckboxInput;
