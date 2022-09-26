import Map from 'ol/Map';
import { unByKey } from 'ol/Observable';
import { Control } from 'ol/control';
import { renderToStaticMarkup } from 'react-dom/server';
import InfoClickSvg from '../../assets/RoundInfoButtonWhite';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

class InfoClickControl extends Control {
  constructor(opt_options: any) {
    const options = opt_options || {};

    const el = document.createElement('div');
    el.className = `${styles.infoClick} draw-shape ol-unselectable ol-control`;
    const button = (
      <button style={{ overflow: 'hidden' }} title="Infoklick">
        <InfoClickSvg />
      </button>
    );
    el.innerHTML = renderToStaticMarkup(button);

    super({
      element: el,
      target: options.target,
    });
    el.addEventListener?.('click', () => this.handleGoToUserLocation(options));
  }

  handleGoToUserLocation = (options: any) => {
    options.callBack();
  };
}

export interface InfoClickControlButtonProps {
  infoClick: boolean;
  callBack: () => void;
}

export const InfoClickControlButton = ({ infoClick, callBack }: InfoClickControlButtonProps) => {
  useMapEffect(
    (map: Map) => {
      const key = map.on('pointermove', () => {
        if (infoClick)
          map.getTargetElement().style.cursor = 'pointer';
        else
          map.getTargetElement().style.cursor = '';
      });
      const infoClickControl = new InfoClickControl({ callBack });
      map.addControl(infoClickControl);
      return () => {
        map.removeControl(infoClickControl);
        unByKey(key);
      };
    }, [infoClick, callBack]);
  return null;
};
