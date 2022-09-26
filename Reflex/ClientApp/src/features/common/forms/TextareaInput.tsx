
const TextareaInput = ({ name, label, required, register, defaultValue }: any) => {
  return (
    <div className="mb-3">
      <label htmlFor={name}>{label}</label>
      <textarea defaultValue={defaultValue} className="form-control" name={name} ref={register({ required: required })} />
    </div>
  );
};

export default TextareaInput;
