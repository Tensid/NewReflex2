import Map from 'ol/Map';
import { Control } from 'ol/control';
import VectorLayer from 'ol/layer/Vector';
import clearFeaturesSvg from '../../assets/rubbish-bin-delete-button-white.svg';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

export const ClearFeaturesControl: any = ((Control) => {
  function ClearFeaturesControl(this: any, opt_options: any) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = "hidden";
    button.innerHTML = `<img src="${clearFeaturesSvg}" class="img-fluid ${styles.svg}" title="Rensa karta">`;

    const element = document.createElement('div');
    element.className = `${styles.clearFeatures} ol-unselectable ol-control`;
    element.appendChild(button);

    Control.call(this,
      {
        element: element,
        target: options.target
      });
    button.addEventListener('click', this.handleClearFeatures.bind(this, options), true);
  }

  if (Control)
    ClearFeaturesControl.__proto__ = Control;
  ClearFeaturesControl.prototype = Object.create(Control && Control.prototype);
  ClearFeaturesControl.prototype.constructor = ClearFeaturesControl;

  ClearFeaturesControl.prototype.handleClearFeatures = function (options: any) {
    const map: Map = this.getMap();
    map.getOverlays().clear();
    const layers = [...map.getLayers().getArray()];
    layers.forEach((layer) => {
      if (layer instanceof VectorLayer)
        map.removeLayer(layer);
    });
    options.callBack();
  };

  return ClearFeaturesControl;
})(Control);

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
