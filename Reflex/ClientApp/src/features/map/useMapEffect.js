import { useEffect } from 'react';
import { useMap } from './MapProvider';

export const useMapEffect = (effect, dependencies) => {
  const map = useMap();
  const deps = [map, ...(dependencies || [])];

  useEffect(() => {
    if (!map) {
      return;
    }
    return effect(map);
  }, deps); // eslint-disable-line react-hooks/exhaustive-deps
};
