import Map from 'ol/Map';
import { Control } from 'ol/control';
import VectorLayer from 'ol/layer/Vector';
import { renderToStaticMarkup } from 'react-dom/server';
import ClearFeaturesSvg from '../../assets/RubbishBinDeleteButtonWhite';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

class ClearFeaturesControl extends Control {
  constructor(opt_options: any) {
    const options = opt_options || {};

    const el = document.createElement('div');
    el.className = `${styles.clearFeatures} draw-shape ol-unselectable ol-control`;
    const button = (
      <button style={{ overflow: 'hidden' }} title="Rensa karta">
        <ClearFeaturesSvg />
      </button>
    );
    el.innerHTML = renderToStaticMarkup(button);

    super({
      element: el,
      target: options.target,
    });
    el.addEventListener?.('click', () => this.handleClearFeatures(options));
  }

  handleClearFeatures = (options: any) => {
    const map: Map = this.getMap()!;
    map.getOverlays().clear();
    const layers = [...map.getLayers().getArray()];
    layers.forEach((layer) => {
      if (layer instanceof VectorLayer)
        map.removeLayer(layer);
    });
    options.callBack();
  };
}

export interface ClearFeaturesControlButtonProps {
  callBack: () => void;
}

export const ClearFeaturesControlButton = ({ callBack }: ClearFeaturesControlButtonProps) => {
  useMapEffect(
    (map: Map) => {
      const clearFeaturesControl = new ClearFeaturesControl({ callBack });
      map.addControl(clearFeaturesControl);
      return () => {
        map.removeControl(clearFeaturesControl);
      };
    }, [callBack]);
  return null;
};
