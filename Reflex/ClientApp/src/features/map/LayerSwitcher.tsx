import OlLayerSwitcher, { Options } from 'ol-layerswitcher';
import 'ol-layerswitcher/dist/ol-layerswitcher.css';
import Map from 'ol/Map';
import { useMapEffect } from './useMapEffect';

interface LayerSwitcherProps {
  options: Options;
}

export const LayerSwitcher = ({ options }: LayerSwitcherProps) => {
  useMapEffect(
    (map: Map) => {
      const layerSwitcher = new OlLayerSwitcher(options);
      map.addControl(layerSwitcher);
      return () => {
        map.removeControl(layerSwitcher);
      };
    }, [options]);
  return null;
};
