const CheckboxInput = ({ name, required, register, label }: any) => {
  return (
    <div className="mb-3 form-check">
      <input type="checkbox" className="form-check-input" {...register(name, { required: required })} />
      <label htmlFor={name} className="form-check-label">{label}</label>
    </div>
  );
};

export default CheckboxInput;
