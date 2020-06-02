import React from 'react';

const PasswordInput = ({ name, label, required, register, defaultValue }: any) => {
  return (
    <div className="form-group">
      <label htmlFor={name}>{label}</label>
      <input type="password" defaultValue={defaultValue} className="form-control" name={name} ref={register({ required: required })} />
    </div>
  );
};

export default PasswordInput;
