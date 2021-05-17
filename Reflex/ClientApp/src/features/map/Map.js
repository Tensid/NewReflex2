import React, { createRef, useEffect, useState } from 'react';
import { connect, useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';
import ContextMenu from 'ol-contextmenu';
import Geolocation from 'ol/Geolocation';
import OlMap from 'ol/Map';
import View from 'ol/View';
import { ScaleLine, defaults as defaultControls } from 'ol/control';
import GeoJson from 'ol/format/GeoJSON';
import { Vector as VectorLayer } from 'ol/layer';
import TileLayer from 'ol/layer/Tile';
import { transform } from 'ol/proj';
import { register } from 'ol/proj/proj4';
import { Vector as VectorSource } from 'ol/source';
import Wmts from 'ol/source/WMTS';
import { Fill, Stroke, Style } from 'ol/style';
import Tilegrid from 'ol/tilegrid/WMTS';
import proj4 from 'proj4';
import { getEstateName, getEstatePosition, getFnrFromPosition, getGeometryFromFnr } from '../../api/api';
import { fetchCasesAsync } from '../cases/casesSlice';
import { ClearFeaturesControl, DrawLineControl, DrawPolygonControl, GoToUserLocationControl, InfoClickControl } from './CustomControls';
import { setTopowebbConfig } from './MapConfig.js';
import styles from './map.module.css';
import Measure from './measure';
import './ol-contextmenu.css';

const CaseAlert = ({ estateName, show, showEstateCases, toggleAlert }) => {
  if (show)
    return (
      <div class="mx-auto alert alert-info alert-dismissible alert-overlay">
        {estateName}
        {' '}
        <a href="cases" onClick={e => {
          e.preventDefault();
          showEstateCases();
        }}>
          Visa ärenden
        </a>
        <span class="close" onClick={toggleAlert} aria-label="close">&times;</span>
      </div>
    );
  return null;
};

const Map = ({ fnr, estateName, fbWebbFastighetUrl = "", fbWebbBoendeUrl = "", csmUrl = "", setSearchResult, mapSettings }) => {
  const dispatch = useDispatch();
  const history = useHistory();
  const mapContainer = createRef();
  const [alert, setAlert] = useState({ fnr, estateName, show: false });
  const toggleAlert = () => setAlert({ ...alert, show: !alert.show });

  function showEstateCases(fnr, estateName) {
    const searchResult = {
      value: fnr,
      estateId: fnr,
      source: 'FB',
      type: 'Fastighet',
      displayName: estateName || ""
    };
    setSearchResult(searchResult);
    dispatch(fetchCasesAsync(searchResult));
    history.push('/cases');
  }

  useEffect(() => {
    let toggleInfoClick = true;
    let measure;
    let estateSource;
    let contextmenu;
    let estatePosition;

    function handleClear() {
      measure.clear();
      estateSource.clear();
      contextmenu.close();
    }

    const topowebbConfig = setTopowebbConfig(mapSettings.projection);

    proj4.defs('EPSG:3006', '+proj=utm +zone=33 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs');
    proj4.defs("EPSG:3007", "+proj=tmerc +lat_0=0 +lon_0=12 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3008", "+proj=tmerc +lat_0=0 +lon_0=13.5 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3009", "+proj=tmerc +lat_0=0 +lon_0=15 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3010", "+proj=tmerc +lat_0=0 +lon_0=16.5 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3011", "+proj=tmerc +lat_0=0 +lon_0=18 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3012", "+proj=tmerc +lat_0=0 +lon_0=14.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3013", "+proj=tmerc +lat_0=0 +lon_0=15.75 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3014", "+proj=tmerc +lat_0=0 +lon_0=17.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3015", "+proj=tmerc +lat_0=0 +lon_0=18.75 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3016", "+proj=tmerc +lat_0=0 +lon_0=20.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3017", "+proj=tmerc +lat_0=0 +lon_0=21.75 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    proj4.defs("EPSG:3018", "+proj=tmerc +lat_0=0 +lon_0=23.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs");
    register(proj4);

    const view = new View({
      center: mapSettings.viewCenter,
      zoom: 10,
      projection: mapSettings.projection,
      resolutions: topowebbConfig.resolutions
    });

    const geometryStyles = {
      'Polygon': new Style({
        stroke: new Stroke({
          color: 'red',
          width: 1
        }),
        fill: new Fill({
          color: 'rgba(255, 0, 0, 0.3)'
        })
      })
    };

    const styleFunction = (feature) => geometryStyles[feature.getGeometry().getType()];

    estateSource = new VectorSource();
    const estateLayer = new VectorLayer({
      source: estateSource,
      style: styleFunction,
      name: 'estateLayer'
    });

    const geolocation = new Geolocation({
      trackingOptions: {
        enableHighAccuracy: true
      },
      projection: view.getProjection()
    });
    geolocation.setTracking(true);

    const map = new OlMap({
      controls: defaultControls().extend([
        new ScaleLine(),
        new GoToUserLocationControl({
          geolocation: geolocation
        }),
        new ClearFeaturesControl({
          clear: handleClear
        }),
        new DrawLineControl({
          callback: () => {
            toggleInfoClick = false;
            measure.typeSelect('length');
          }
        }),
        new DrawPolygonControl({
          callback: () => {
            toggleInfoClick = false;
            measure.typeSelect('area');
          }
        }),
        new InfoClickControl({
          callback: () => {
            measure.removeInteraction();
            toggleInfoClick = !toggleInfoClick;
          }
        })
      ]),
      layers: [
        new TileLayer({
          source: new Wmts({
            url: mapSettings.url + encodeURIComponent(mapSettings.localProxyUrl),
            layer: 'Topowebb nedtonad',
            matrixSet: mapSettings.projection,
            crossOrigin: null,
            format: 'image/png',
            projection: mapSettings.projection,
            tileGrid: new Tilegrid({
              origin: topowebbConfig.origin,
              resolutions: topowebbConfig.resolutions,
              matrixIds: topowebbConfig.matrixIds,
              tileSize: [512, 512]
            }),
            style: 'default',
            wrapX: false
          })
        }),
        estateLayer
      ],
      target: mapContainer.current,
      view: view
    });

    map.once('postrender', () => {
      if (fnr) {
        (async () => {
          let geometryContent;
          [geometryContent, estateName, estatePosition] = await Promise.all([
            getGeometryFromFnr(fnr),
            getEstateName(fnr),
            getEstatePosition(fnr)
          ]);
          drawEstate(geometryContent, true);
          setAlert({ fnr, estateName, show: true });
        })();
      }
      else {
        geolocation.setTracking(true);
      }
      toggleInfoClick = true;
    });

    contextmenu = new ContextMenu({
      width: 185
    });

    map.addControl(contextmenu);

    contextmenu.on('beforeopen', (evt) => {
      const values = forEachFeatureAtPixel(evt);
      if (values?.feature && values?.layer?.name === 'estateLayer') {
        contextmenu.enable();
      } else {
        contextmenu.disable();
      }
    });

    contextmenu.on('open', (evt) => {
      const values = forEachFeatureAtPixel(evt);
      contextmenu.clear();
      if (values?.feature && values?.layer?.name === 'estateLayer') {
        let estateItems = [
          {
            text: estateName,
            classname: styles.menuTitle
          },
          '-' // separator,
          ,
          {
            text: 'Visa ärenden',
            callback: () => showEstateCases(fnr, estateName)
          },
          '-'
          ,
          {
            text: 'Öppna fastighetsrapport',
            callback: () => window.open(fbWebbFastighetUrl + fnr)
          },
          {
            text: 'Öppna befolkningsrapport',
            callback: () => window.open(fbWebbBoendeUrl + fnr)
          },
          {
            text: 'Vägbeskrivning hit (Bing)',
            callback: () => showDirections('Bing')
          },
          {
            text: 'Vägbeskrivning hit (Google)',
            callback: () => showDirections('Google')
          }
        ];
        if (csmUrl) {
          const csmOption = {
            text: 'Öppna CSM',
            callback: () => openCsm(csmUrl)
          };
          estateItems.push(csmOption);
        }

        contextmenu.extend(estateItems);
      }
    });

    function forEachFeatureAtPixel(evt) {
      return map.forEachFeatureAtPixel(evt.pixel, (ft, l) => {
        return {
          feature: ft,
          layer: { ...l && l.getProperties() }
        };
      });
    }

    map.on('contextmenu', e => { e.preventDefault(); measure.removeInteraction(); });

    map.on('singleclick', (evt) => {
      contextmenu.close();
      if (!toggleInfoClick)
        return;

      const lon = evt.coordinate[0];
      const lat = evt.coordinate[1];
      const epsg = map.getView().getProjection().getCode().split(':');
      const srid = epsg[epsg.length - 1];

      (async () => {
        let geometryContent;
        fnr = await getFnrFromPosition(lat, lon, srid, 1);
        [geometryContent, estateName, estatePosition] = await Promise.all([
          getGeometryFromFnr(fnr),
          getEstateName(fnr),
          getEstatePosition(fnr)
        ]);
        drawEstate(geometryContent);
        setAlert({ fnr, estateName, show: true });
      })();
    });

    map.on('pointermove', () => {
      if (toggleInfoClick)
        map.getTargetElement().style.cursor = 'pointer';
      else
        map.getTargetElement().style.cursor = '';
    });

    function handleKeydown(evt) {
      //Escape
      if (evt.keyCode === 27) {
        contextmenu.close();
        measure.removeInteraction();
      }
    }

    document.addEventListener('keydown', handleKeydown);

    function renderDirections({ fromCoord, toCoord, mapProvider }) {
      if (fromCoord !== null) {
        fromCoord.x = fromCoord.x.toFixed(6);
        fromCoord.y = fromCoord.y.toFixed(6);
        toCoord.x = parseFloat(toCoord.x).toFixed(6);
        toCoord.y = parseFloat(toCoord.y).toFixed(6);
      }

      let gmapsUrl = 'https://www.google.com/maps';
      let bmapsUrl = 'https://www.bing.com/maps';

      if (fromCoord !== null) {
        gmapsUrl += `?daddr=${toCoord.y},${toCoord.x}&saddr=${fromCoord.y},${fromCoord.x}`;
        bmapsUrl += `?rtp=adr.${fromCoord.y},${fromCoord.x}~adr.${toCoord.y},${toCoord.x}`;
      } else {
        gmapsUrl += `?daddr=${toCoord.y},${toCoord.x}`;
        bmapsUrl += `?rtp=~adr.${toCoord.y},${toCoord.x}`;
      }
      if (mapProvider === 'Google')
        window.open(gmapsUrl);
      if (mapProvider === 'Bing')
        window.open(bmapsUrl);
    }

    function showDirections(mapProvider) {
      const position = geolocation.getPosition();
      const toCoord = projToWgs(estatePosition.eastingKoordinat, estatePosition.northingKoordinat, map.getView().getProjection().getCode());
      const fromCoord = projToWgs(position[0], position[1], map.getView().getProjection().getCode());
      if (position)
        renderDirections({ fromCoord: fromCoord, toCoord: toCoord, mapProvider: mapProvider });
      else {
        alert('Koordinater saknas!');
        return;
      }
    }

    function projToWgs(x, y, proj) {
      const coords = transform([Number(x), Number(y)], proj, 'WGS84');
      return { x: coords[0], y: coords[1] };
    }

    function openCsm(csmUrl) {
      const extent = map.getView().calculateExtent(map.getSize());
      const mapext = `&mapext=${extent[0]}+${extent[1]}+${extent[2]}+${extent[3]}`;
      const fullUrl = csmUrl + mapext;
      window.open(fullUrl);
    }

    function drawEstate(content, fitToFeature) {
      estateSource.clear();
      const grupp = content.data[0].grupp;
      const geojsonObject = {
        'type': 'FeatureCollection',
        'features': [
        ]
      };

      Object.entries(grupp).forEach(([key, val]) => {
        Object.entries(val).forEach(([key2, val2]) => {
          if (key2 === 'yta') {
            geojsonObject['features'].push(val2);
          }
        });
      });
      estateSource.addFeatures((new GeoJson()).readFeatures(geojsonObject, {
        dataProjection: map.getView().getProjection().getCode(),
        featureProjection: map.getView().getProjection()
      }));
      if (fitToFeature)
        map.getView().fit(estateSource.getExtent(), { size: map.getSize(), maxZoom: 17 });
    }

    measure = Measure(map);
    measure.clear();
    return () => { geolocation.setTracking(false); document.removeEventListener('keydown', handleKeydown); };
  }, []);
  return (
    <div id="map" ref={mapContainer} className={styles.content}>
      <div className={styles.alertOverlay}>
        <CaseAlert {...alert} showEstateCases={() => showEstateCases(alert.fnr, alert.estateName)} toggleAlert={toggleAlert} />
      </div>
    </div>
  );
};

const mapStateToProps = state => ({
  searchResult: state.searchResult
});

export default connect(
  mapStateToProps,
  null
)(Map);
