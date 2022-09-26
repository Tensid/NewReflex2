import Map from 'ol/Map';
import { Control } from 'ol/control';
import { renderToStaticMarkup } from 'react-dom/server';
import DrawLineSvg from '../../assets/MeasureLineWhite';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

class DrawLineControl extends Control {
  constructor(opt_options: any) {
    const options = opt_options || {};

    const el = document.createElement('div');
    el.className = `${styles.drawLine} draw-shape ol-unselectable ol-control`;
    const button = (
      <button style={{ overflow: 'hidden' }} title="Mät sträcka">
        <DrawLineSvg />
      </button>
    );
    el.innerHTML = renderToStaticMarkup(button);

    super({
      element: el,
      target: options.target
    });
    el.addEventListener?.('click', () => this.handleDrawLine(options));
  }

  handleDrawLine = (options: { callBack: () => void }) => {
    options.callBack();
  };
}

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
