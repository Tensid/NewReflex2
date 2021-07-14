import OlMap from 'ol/Map';
import TileLayer from 'ol/layer/Tile';
import { TileWMS } from 'ol/source';
import { useMapEffect } from './useMapEffect';

interface WmtsLayerProps {
  options: any;
  visible: boolean;
  title: string;
  baseLayer?: boolean;
}

export const WmsLayer = ({ options, visible, title, baseLayer }: WmtsLayerProps) => {
  useMapEffect(
    (map: OlMap) => {
      const source = new TileWMS(options);
      const layer = new TileLayer({
        source,
      });
      layer.set('title', title);
      if (baseLayer)
        layer.set('type', 'base');
      layer.setVisible(visible);
      map.addLayer(layer);
      return () => {
        map.removeLayer(layer);
      };
    }, [options]);
  return null;
};
