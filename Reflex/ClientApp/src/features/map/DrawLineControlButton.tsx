import Map from 'ol/Map';
import { Control } from 'ol/control';
import drawLineSvg from '../../assets/measure-line-white.svg';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

export const DrawLineControl: any = ((Control) => {
  function DrawLineControl(this: any, opt_options: any) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = 'hidden';
    button.innerHTML = `<img src="${drawLineSvg}" class="img-fluid ${styles.svg} ${styles.toggle}" title="Mät sträcka">`;

    const element = document.createElement('div');
    element.className = `${styles.drawLine} draw-shape ol-unselectable ol-control`;
    element.appendChild(button);

    Control.call(this,
      {
        element: element,
        target: options.target
      });
    button.addEventListener('click', this.handleDrawLine.bind(this, options), false);
  }

  if (Control)
    DrawLineControl.__proto__ = Control;
  DrawLineControl.prototype = Object.create(Control && Control.prototype);
  DrawLineControl.prototype.constructor = DrawLineControl;
  DrawLineControl.prototype.handleDrawLine = (options: { callBack: () => void }) => {
    options.callBack();
  };
  return DrawLineControl;
})(Control);

export interface DrawLineControlButtonProps {
  callBack: () => void;
}

export const DrawLineControlButton = ({ callBack }: DrawLineControlButtonProps) => {
  useMapEffect(
    (map: Map) => {
      const drawLineControl = new DrawLineControl({ callBack });
      map.addControl(drawLineControl);
      return () => {
        map.removeControl(drawLineControl);
      };
    }, [callBack]);
  return null;
};
