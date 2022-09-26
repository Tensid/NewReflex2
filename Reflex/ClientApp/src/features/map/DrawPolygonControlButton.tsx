import Map from 'ol/Map';
import { Control } from 'ol/control';
import { renderToStaticMarkup } from 'react-dom/server';
import DrawPolygonSvg from '../../assets/MeasurePolygonWhite';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

class DrawPolygonControl extends Control {
  constructor(opt_options: any) {
    const options = opt_options || {};

    const el = document.createElement('div');
    el.className = `${styles.drawPolygon} draw-shape ol-unselectable ol-control`;
    const button = (
      <button style={{ overflow: 'hidden' }} title="Mät sträcka">
        <DrawPolygonSvg />
      </button>
    );
    el.innerHTML = renderToStaticMarkup(button);

    super({
      element: el,
      target: options.target,
    });
    el.addEventListener?.('click', () => this.handlePolygonLine(options));
  }

  handlePolygonLine = (options: { callBack: () => void }) => {
    options.callBack();
  };
}

export interface DrawPolygonControlButtonProps {
  callBack: () => void;
}

export const DrawPolygonControlButton = ({ callBack }: DrawPolygonControlButtonProps) => {
  useMapEffect(
    (map: Map) => {
      const drawLineControl = new DrawPolygonControl({ callBack });
      map.addControl(drawLineControl);
      return () => {
        map.removeControl(drawLineControl);
      };
    }, [callBack]);
  return null;
};
