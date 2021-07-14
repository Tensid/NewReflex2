import OlMap from 'ol/Map';
import TileLayer from 'ol/layer/Tile';
import WMTS from 'ol/source/WMTS';
import Tilegrid from 'ol/tilegrid/WMTS';
import { useMapEffect } from './useMapEffect';

interface WmtsLayerProps {
  options: any;
  visible: boolean;
  title: string;
  tileGridOptions: any;
}

export const WmtsLayer = ({ options, tileGridOptions, visible, title }: WmtsLayerProps) => {
  useMapEffect(
    (map: OlMap) => {
      const source = new WMTS({ ...options, tileGrid: new Tilegrid(tileGridOptions) });
      const layer = new TileLayer({
        source
      });
      layer.set('title', title);
      layer.set('type', 'base');
      layer.setVisible(visible);
      map.addLayer(layer);
      return () => {
        map.removeLayer(layer);
      };
    }, [options]);

  return null;
};
