import React from 'react';

const TextareaInput = ({ name, label, required, register, defaultValue }: any) => {
  return (
    <div className="form-group">
      <label htmlFor={name}>{label}</label>
      <textarea defaultValue={defaultValue} className="form-control" name={name} ref={register({ required: required })} />
    </div>
  );
};

export default TextareaInput;
