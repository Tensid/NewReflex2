import Geolocation from 'ol/Geolocation';
import Map from 'ol/Map';
import { unByKey } from 'ol/Observable';
import { Control } from 'ol/control';
import goToUserLocationSvg from '../../assets/navigation-white.svg';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

const GoToUserLocationControl: any = ((Control) => {
  function GoToUserLocationControl(this: any, opt_options: any) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = 'hidden';
    button.innerHTML = `<img src="${goToUserLocationSvg}" class="img-fluid ${styles.svg}" title="Gå till min position">`;

    const element = document.createElement('div');
    element.className = `${styles.goToUserLocation} ol-unselectable ol-control`;
    element.appendChild(button);

    Control.call(this,
      {
        element: element,
        target: options.target
      });
    button.addEventListener('click', this.handleGoToUserLocation.bind(this, options), true);
  }

  if (Control)
    GoToUserLocationControl.__proto__ = Control;
  GoToUserLocationControl.prototype = Object.create(Control && Control.prototype);
  GoToUserLocationControl.prototype.constructor = GoToUserLocationControl;

  GoToUserLocationControl.prototype.handleGoToUserLocation = function (options: any) {
    const geolocation = options.geolocation;
    const map: Map = this.getMap();
    const changePosition = geolocation.on('change:position', () => {
      map.getView().setCenter(geolocation.getPosition());
      map.getView().setZoom(13);
      geolocation.setTracking(false);
      unByKey(changePosition);
    });
    options.geolocation.setTracking(true);
  };
  return GoToUserLocationControl;
})(Control);

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
