
const PasswordInput = ({ name, label, required, register, defaultValue }: any) => {
  return (
    <div className="mb-3">
      <label htmlFor={name}>{label}</label>
      <input type="password" defaultValue={defaultValue} className="form-control"{...register(name, { required: required })} />
    </div>
  );
};

export default PasswordInput;
