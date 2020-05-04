import React from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../app/store';

const Spinner = () => {
  const loading = useSelector((state: RootState) => state.spinner.loading);
  return (
    <div className={`spinner-grow text-brand ${loading ? '' : 'd-none'}`} role="status">
      <span className="sr-only">Loading...</span>
    </div>
  );
};

export default Spinner;
