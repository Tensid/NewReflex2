import Map from 'ol/Map';
import { Control } from 'ol/control';
import drawPolygonSvg from '../../assets/measure-polygon-white.svg';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

export const DrawPolygonControl: any = ((Control) => {
  function DrawPolygonControl(this: any, opt_options: any) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = 'hidden';
    button.innerHTML = `<img src="${drawPolygonSvg}" class="img-fluid ${styles.svg} ${styles.toggle}" title="Mät yta">`;

    const element = document.createElement('div');
    element.className = `${styles.drawPolygon} draw-shape ol-unselectable ol-control`;
    element.appendChild(button);

    Control.call(this,
      {
        element: element,
        target: options.target
      });
    button.addEventListener('click', this.handleDrawPolygon.bind(this, options), false);
  }

  if (Control)
    DrawPolygonControl.__proto__ = Control;
  DrawPolygonControl.prototype = Object.create(Control && Control.prototype);
  DrawPolygonControl.prototype.constructor = DrawPolygonControl;

  DrawPolygonControl.prototype.handleDrawPolygon = (options: { callBack: () => void }) => {
    options.callBack();
  };
  return DrawPolygonControl;
})(Control);

export interface DrawPolygonControlButtonProps {
  callBack: () => void;
}

export const DrawPolygonControlButton = ({ callBack }: DrawPolygonControlButtonProps) => {
  useMapEffect(
    (map: Map) => {
      const drawPolygonControl = new DrawPolygonControl({ callBack });
      map.addControl(drawPolygonControl);
      return () => {
        map.removeControl(drawPolygonControl);
      };
    }, [callBack]);
  return null;
};
