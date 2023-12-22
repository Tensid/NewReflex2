import React from 'react';
import { useAppSelector } from '../../app/hooks';
import { Loader } from '../../components/Loader';
import { isAnythingLoading } from '../../features/loading/loadingReducers';
export function LoadingIndicator() {
  const isLoading = useAppSelector(isAnythingLoading);
  const actionsInProgress = useAppSelector((state) => state.loading.actionsInProgress);

  return (
    <div className="h-100 p-2 d-flex align-items-center">
      {actionsInProgress && (
        <Loader isLoading={isLoading} fullScreen={actionsInProgress[0]?.fullScreen} message={actionsInProgress[0]?.message} />
      )}
    </div>
  );
}

export default LoadingIndicator;