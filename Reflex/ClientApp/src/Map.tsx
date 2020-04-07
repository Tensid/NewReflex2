import OlMap from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import 'ol/ol.css';
import OSM from 'ol/source/OSM';
import React, { useEffect, useRef } from 'react';

const Map = () => {
  const mapContainer = useRef(null);

  useEffect(() => {
    new OlMap({
      layers: [
        new TileLayer({
          source: new OSM()
        })
      ],
      target: mapContainer.current!,
      view: new View({
        center: [0, 0],
        zoom: 2
      })
    });
  }, []);

  return (
    <div id="map" ref={mapContainer} style={{ height: '720px' }} />
  );
};

export default Map;
