import { Feature } from 'ol';
import Map from 'ol/Map';
import Geometry from 'ol/geom/Geometry';
import VectorLayer from 'ol/layer/Vector';
import VectorSource from 'ol/source/Vector';
import { useEffect, useState } from 'react';
import { useMapEffect } from './useMapEffect';

interface FeatureLayerProps {
  features?: Feature<Geometry>[];
  options?: any;
}

export const FeatureLayer = ({ features, options }: FeatureLayerProps) => {
  const [source] = useState(() => new VectorSource());
  useEffect(() => {
    source.clear();
    if (features) source.addFeatures(features);
  }, [source, features]);

  useMapEffect(
    (map: Map) => {
      const layer = new VectorLayer({
        source,
        ...(options || {})
      });
      map.addLayer(layer);
      return () => {
        map.removeLayer(layer);
      };
    },
    [options]
  );
  return null;
};
