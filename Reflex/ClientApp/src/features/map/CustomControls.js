import { Control } from 'ol/control';
import styles from './map.module.css';
import drawLineSvg from './measure-line-white.svg';
import drawPolygonSvg from './measure-polygon-white.svg';
import goToUserLocationSvg from './navigation-white.svg';
import infoClickSvg from './round-info-button-white.svg';
import clearFeaturesSvg from './rubbish-bin-delete-button-white.svg';

export const GoToUserLocationControl = ((Control) => {
  function GoToUserLocationControl(opt_options) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = "hidden";
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

  GoToUserLocationControl.prototype.handleGoToUserLocation = function (options) {
    const position = options.geolocation.getPosition();
    if (position) {
      this.getMap().getView().setCenter(position);
      this.getMap().getView().setZoom(8);
    }
  };
  return GoToUserLocationControl;
})(Control);


export const ClearFeaturesControl = ((Control) => {
  function ClearFeaturesControl(opt_options) {
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
    button.addEventListener('click', this.handleClearFeatures.bind(this, options), false);
  }

  if (Control)
    ClearFeaturesControl.__proto__ = Control;
  ClearFeaturesControl.prototype = Object.create(Control && Control.prototype);
  ClearFeaturesControl.prototype.constructor = ClearFeaturesControl;

  ClearFeaturesControl.prototype.handleClearFeatures = (options) => {
    options.clear();
  };
  return ClearFeaturesControl;
})(Control);


export const DrawLineControl = ((Control) => {
  function DrawLineControl(opt_options) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = "hidden";
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

  DrawLineControl.prototype.handleDrawLine = options => {
    options.callback();
  };
  return DrawLineControl;
})(Control);


export const DrawPolygonControl = ((Control) => {
  function DrawPolygonControl(opt_options) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = "hidden";
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

  DrawPolygonControl.prototype.handleDrawPolygon = options => {
    options.callback();
  };
  return DrawPolygonControl;
})(Control);


export const InfoClickControl = ((Control) => {
  function InfoClickControl(opt_options) {
    const options = opt_options || {};

    const button = document.createElement('button');
    button.style.overflow = "hidden";
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

  InfoClickControl.prototype.handleInfoClick = options => {
    options.callback();
  };
  return InfoClickControl;
})(Control);