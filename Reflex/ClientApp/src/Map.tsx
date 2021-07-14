import React from 'react';
import { useSelector } from 'react-redux';
import { RootState } from './app/store';
import ReflexMap from './features/map/ReflexMap';

const Map = () => {
  const type = useSelector((state: RootState) => state.searchResult.type);
  const value = useSelector((state: RootState) => state.searchResult.value);
  const estateName = useSelector((state: RootState) => state.searchResult.estateName);
  const projection = useSelector((state: RootState) => state.mapSettings?.mapSettings?.projection);

  if (!projection)
    return null;
  const fnr = type === 'Fastighet' ? value : undefined;
  return (
    <ReflexMap projection={projection} fnr={fnr} estateName={estateName} />
  );
};

export default Map;
