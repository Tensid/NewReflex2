import React from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../app/store';

const Spinner = () => {
  const pendingActions = useSelector((state: RootState) => state.spinner.pendingActions);
  return (
    <div className={`spinner-grow text-brand ${pendingActions > 0 ? '' : 'd-none'}`} role="status">
      <span className="sr-only">Loading...</span>
    </div>
  );
};

export default Spinner;
