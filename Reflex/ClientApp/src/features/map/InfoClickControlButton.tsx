import Map from 'ol/Map';
import { unByKey } from 'ol/Observable';
import { Control } from 'ol/control';
import infoClickSvg from '../../assets/round-info-button-white.svg';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

export const InfoClickControl: any = ((Control) => {
  function InfoClickControl(this: any, opt_options: any) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = 'hidden';
    button.innerHTML = `<img src="${infoClickSvg}" class="img-fluid ${styles.svg} ${styles.toggle}" title="Infoklick">`;

    const element = document.createElement('div');
    element.className = `${styles.infoClick} ol-unselectable ol-control`;
    element.appendChild(button);

    Control.call(this,
      {
        element: element,
        target: options.target
      });
    button.addEventListener('click', this.handleInfoClick.bind(this, options), false);
  }

  if (Control)
    InfoClickControl.__proto__ = Control;
  InfoClickControl.prototype = Object.create(Control && Control.prototype);
  InfoClickControl.prototype.constructor = InfoClickControl;

  InfoClickControl.prototype.handleInfoClick = (options: { callBack: () => void }) => {
    options.callBack();
  };
  return InfoClickControl;
})(Control);

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
