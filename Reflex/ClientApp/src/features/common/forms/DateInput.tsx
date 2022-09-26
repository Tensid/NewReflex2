const DateInput = ({ name, label, required, register, defaultValue }: any) => {
  return (
    <div className="mb-3">
      <label htmlFor={name}>{label}</label>
      <input type="date" defaultValue={defaultValue} className="form-control" name={name} ref={register({ required: required })} />
    </div>
  );
};

export default DateInput;
