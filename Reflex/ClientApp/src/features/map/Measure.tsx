import Feature from 'ol/Feature';
import Map from 'ol/Map';
import MapBrowserEvent from 'ol/MapBrowserEvent';
import { unByKey } from 'ol/Observable';
import Overlay from 'ol/Overlay';
import { Coordinate } from 'ol/coordinate';
import { EventsKey } from 'ol/events';
import { LineString, Polygon } from 'ol/geom';
import GeometryType from 'ol/geom/GeometryType';
import Draw from 'ol/interaction/Draw';
import Interaction from 'ol/interaction/Interaction';
import { Vector as VectorLayer } from 'ol/layer';
import 'ol/ol.css';
import { Vector as VectorSource } from 'ol/source';
import { getArea, getLength } from 'ol/sphere';
import { Circle as CircleStyle, Fill, Stroke, Style } from 'ol/style';
import styles from './map.module.css';
import { useMapEffect } from './useMapEffect';

interface MeasureProps {
  typeSelect: string | GeometryType;
}

export const Measure = ({ typeSelect }: MeasureProps) => {
  useMapEffect(
    (map: Map) => {
      const tooltips: HTMLElement[] = [];
      const source = new VectorSource();

      const vector = new VectorLayer({
        source: source,
        style: new Style({
          fill: new Fill({
            color: 'rgba(255, 255, 255, 0.2)'
          }),
          stroke: new Stroke({
            color: '#ffcc33',
            width: 2
          }),
          image: new CircleStyle({
            radius: 7,
            fill: new Fill({
              color: '#ffcc33'
            })
          })
        })
      });

      map.addLayer(vector);

      /**
       * Currently drawn feature.
       * @type {import("../src/ol/Feature.js").default}
       */
      let sketch: Feature | null;


      /**
       * The help tooltip element.
       */
      let helpTooltipElement: HTMLElement;


      /**
       * Overlay to show the help messages.
       */
      let helpTooltip: Overlay;


      /**
       * The measure tooltip element.
       * @type {HTMLElement}
       */
      let measureTooltipElement: HTMLElement | null;


      /**
       * Overlay to show the measurement.
       */
      let measureTooltip: Overlay;


      /**
       * Message to show when the user is drawing a polygon.
       */
      const continuePolygonMsg = 'Klicka för att fortsätta mäta ytan';


      /**
       * Message to show when the user is drawing a line.
       */
      const continueLineMsg = 'Klicka för att fortsätta mäta sträckan';


      /**
       * Handle pointer move.
       * @param {import("../src/ol/MapBrowserEvent").default} evt The event.
       */
      const pointerMoveHandler = (evt: MapBrowserEvent) => {
        if (evt.dragging) {
          return;
        }

        let helpMsg = 'Klicka för att börja rita';

        if (sketch) {
          const geom = sketch.getGeometry();
          if (geom instanceof Polygon) {
            helpMsg = continuePolygonMsg;
          } else if (geom instanceof LineString) {
            helpMsg = continueLineMsg;
          }
        }

        helpTooltipElement.innerHTML = helpMsg;
        helpTooltip.setPosition(evt.coordinate);

        helpTooltipElement.classList.remove('hidden');
      };

      const pointermove = map.on('pointermove', pointerMoveHandler);

      const mouseout = map.getViewport().addEventListener('mouseout', () => {
        helpTooltipElement.classList.add('hidden');
      });


      let draw: Interaction; // global so we can remove it later


      /**
       * Format length output.
       * @param {LineString} line The line.
       * @return {string} The formatted length.
       */
      const formatLength = (line: LineString) => {
        const length = getLength(line);
        let output;
        if (length > 1000) {
          output = `${Math.round(length / 1000 * 10) / 10} km`;
        } else {
          output = `${Math.round(length * 10) / 10} m`;
        }
        return output;
      };


      /**
       * Format area output.
       * @param {Polygon} polygon The polygon.
       * @return {string} Formatted area.
       */
      const formatArea = (polygon: Polygon) => {
        const area = getArea(polygon);
        let output;
        if (area > 1000000) {
          output = `${Math.round(area / 1000000 * 10) / 10} km<sup>2</sup>`;
        } else {
          output = `${Math.round(area * 10) / 10} m<sup>2</sup>`;
        }
        return output;
      };


      function addInteraction() {
        const type = (typeSelect === 'Area' ? 'Polygon' : 'LineString') as GeometryType;

        draw = new Draw({
          source: source,
          type: type,
          style: new Style({
            fill: new Fill({
              color: 'rgba(255, 255, 255, 0.2)'
            }),
            stroke: new Stroke({
              color: 'rgba(0, 0, 0, 0.5)',
              lineDash: [10, 10],
              width: 2
            }),
            image: new CircleStyle({
              radius: 5,
              stroke: new Stroke({
                color: 'rgba(0, 0, 0, 0.7)'
              }),
              fill: new Fill({
                color: 'rgba(255, 255, 255, 0.2)'
              })
            })
          })
        });
        map.addInteraction(draw);

        createMeasureTooltip();
        createHelpTooltip();

        let listener: EventsKey;
        draw.on('drawstart',
          (evt) => {
            // set sketch
            sketch = evt.feature;

            let tooltipCoord: Coordinate | undefined = evt.coordinate;

            listener = sketch?.getGeometry()?.on('change', function (evt) {
              const geom = evt.target;
              let output!: string;
              if (geom instanceof Polygon) {
                output = formatArea(geom);
                tooltipCoord = geom.getInteriorPoint().getCoordinates();
              } else if (geom instanceof LineString) {
                output = formatLength(geom);
                tooltipCoord = geom.getLastCoordinate();
              }
              measureTooltipElement!.innerHTML = output;
              measureTooltip.setPosition(tooltipCoord);
            })!;
          });

        draw.on('drawend', () => {
          measureTooltipElement!.className = `${styles.olTooltip} ${styles.olTooltipStatic}`;
          measureTooltip.setOffset([0, -7]);
          // unset sketch
          sketch = null;
          // unset tooltip so that a new one can be created
          measureTooltipElement = null;
          createMeasureTooltip();
          unByKey(listener!);
        });
      }


      /**
       * Creates a new help tooltip
       */
      function createHelpTooltip() {
        if (helpTooltipElement) {
          helpTooltipElement.parentNode?.removeChild(helpTooltipElement);
        }
        helpTooltipElement = document.createElement('div');
        helpTooltipElement.className = `${styles.olTooltip} hidden`;
        helpTooltip = new Overlay({
          element: helpTooltipElement,
          offset: [15, 0],
          positioning: 'center-left'
        });
        map.addOverlay(helpTooltip);
      }

      /**
       * Creates a new measure tooltip
       */
      function createMeasureTooltip() {
        if (measureTooltipElement) {
          measureTooltipElement.parentNode?.removeChild(measureTooltipElement);
        }
        measureTooltipElement = document.createElement('div');
        measureTooltipElement.className = `${styles.olTooltip} ${styles.olTtooltipMeasure}`;
        measureTooltip = new Overlay({
          element: measureTooltipElement,
          offset: [0, -15],
          positioning: 'bottom-center'
        });
        map.addOverlay(measureTooltip);
        tooltips.push(measureTooltipElement);
      }
      const contextmenu = map.on('contextmenu', e => {
        e.preventDefault();
        map.removeOverlay(helpTooltip);
        map.removeOverlay(measureTooltip);
        map.removeInteraction(draw);
        sketch = null;
        addInteraction();
      });

      function handleKeydown(evt: any) {
        //Escape
        if (evt.keyCode === 27) {
          map.removeOverlay(helpTooltip);
          map.removeOverlay(measureTooltip);;
          map.removeInteraction(draw);
          sketch = null;
          addInteraction();
        }
      }
      document.addEventListener('keydown', handleKeydown);

      addInteraction();
      return () => {
        map.removeOverlay(helpTooltip);
        map.removeOverlay(measureTooltip);
        map.removeInteraction(draw);
        document.removeEventListener('keydown', handleKeydown);
        unByKey(contextmenu);
        unByKey(pointermove);
      };
    }, [typeSelect]);
  return null;
};
