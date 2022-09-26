import Geolocation from 'ol/Geolocation';
import Map from 'ol/Map';
import { unByKey } from 'ol/Observable';
import { Control } from 'ol/control';
import { renderToStaticMarkup } from 'react-dom/server';
import GoToUserLocationSvg from '../../assets/NavigationWhite';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

class GoToUserLocationControl extends Control {
  constructor(opt_options: any) {
    const options = opt_options || {};

    const el = document.createElement('div');
    el.className = `${styles.goToUserLocation} draw-shape ol-unselectable ol-control`;
    const button = (
      <button style={{ overflow: 'hidden' }} title="Gå till min position">
        <GoToUserLocationSvg />
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
    const geolocation = options.geolocation;
    const map: Map = this.getMap()!;
    const changePosition = geolocation.on('change:position', () => {
      map.getView().setCenter(geolocation.getPosition());
      map.getView().setZoom(13);
      geolocation.setTracking(false);
      unByKey(changePosition);
    });
    options.geolocation.setTracking(true);
  };
}

export const GoToUserLocationControlButton = () => {
  useMapEffect(
    (map: Map) => {
      const geolocation = new Geolocation({
        trackingOptions: {
          enableHighAccuracy: true
        },
        projection: map.getView().getProjection()
      });

      const goToUserLocationControl = new GoToUserLocationControl({ geolocation });
      map.addControl(goToUserLocationControl);

      return () => {
        map.removeControl(goToUserLocationControl);
      };
    }, []);
  return null;
};
