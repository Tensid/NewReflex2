import { useAppSelector } from '../../app/hooks';

const Spinner = () => {
  const pendingActions = useAppSelector((state) => state.spinner.pendingActions);
  return (
    <div className={`spinner-grow text-brand ${pendingActions > 0 ? '' : 'd-none'}`} role="status" />
  );
};

export default Spinner;
