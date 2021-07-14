import Map from 'ol/Map';
import View from 'ol/View';
import { ScaleLine, defaults } from 'ol/control';
import { Extent } from 'ol/extent';
import 'ol/ol.css';
import Projection from 'ol/proj/Projection';
import { register } from 'ol/proj/proj4';
import proj4 from 'proj4';
import React, {
  FC,
  createContext,
  useContext,
  useEffect, useState
} from 'react';

proj4.defs('EPSG:3857',
  '+proj=merc +a=6378137 +b=6378137 +lat_ts=0.0 +lon_0=0.0 +x_0=0.0 +y_0=0 +k=1.0 +units=m +nadgrids=@null +wktext +no_defs');

// EPSG:3006 SWEREF 99 TM 15°00'E
proj4.defs('EPSG:3006', '+proj=utm +zone=33 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3007 SWEREF 99 12 00 12°00'E
proj4.defs('EPSG:3007',
  '+proj=tmerc +lat_0=0 +lon_0=12 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3008 SWEREF 99 13 30 13°30'E
proj4.defs('EPSG:3008',
  '+proj=tmerc +lat_0=0 +lon_0=13.5 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3009 SWEREF 99 15 00 15°00'E
proj4.defs('EPSG:3009',
  '+proj=tmerc +lat_0=0 +lon_0=15 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3010 SWEREF 99 16 30 16°30'E
proj4.defs('EPSG:3010',
  '+proj=tmerc +lat_0=0 +lon_0=16.5 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3011 SWEREF 99 18 00 18°00'E
proj4.defs('EPSG:3011',
  '+proj=tmerc +lat_0=0 +lon_0=18 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3012 SWEREF 99 14 15 14°15'E
proj4.defs('EPSG:3012',
  '+proj=tmerc +lat_0=0 +lon_0=14.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3013 SWEREF 99 15 45 15°45'E
proj4.defs('EPSG:3013',
  '+proj=tmerc +lat_0=0 +lon_0=15.75 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3014 SWEREF 99 17 15 17°15'E
proj4.defs('EPSG:3014',
  '+proj=tmerc +lat_0=0 +lon_0=17.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3015 SWEREF 99 18 45 18°45'E
proj4.defs('EPSG:3015',
  '+proj=tmerc +lat_0=0 +lon_0=18.75 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3016 SWEREF 99 20 15 20°15'E
proj4.defs('EPSG:3016',
  '+proj=tmerc +lat_0=0 +lon_0=20.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3017 SWEREF 99 21 45 21°45'E
proj4.defs('EPSG:3017',
  '+proj=tmerc +lat_0=0 +lon_0=21.75 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');

// EPSG:3018 SWEREF 99 23 15 23°15'E
proj4.defs('EPSG:3018',
  '+proj=tmerc +lat_0=0 +lon_0=23.25 +k=1 +x_0=150000 +y_0=0 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +axis=neu');
register(proj4);

interface MapProviderProps {
  projection: string | Projection | undefined;
  extent?: Extent;
  initialExtent: Extent;
}

function useTrackExtent(map: Map | undefined, extent: Extent | undefined) {
  // track the extent values, not the array
  const minX = extent?.[0] ?? NaN;
  const minY = extent?.[1] ?? NaN;
  const maxX = extent?.[2] ?? NaN;
  const maxY = extent?.[3] ?? NaN;
  useEffect(() => {
    if (isNaN(minX) || isNaN(maxX) || isNaN(minY) || isNaN(maxY)) return;
    if (!map) return;
    map.getView().fit([minX, minY, maxX, maxY]);
  }, [map, minX, minY, maxX, maxY]);
}

const MapContext = createContext<Map | undefined>(undefined);

export const MapProvider: FC<MapProviderProps> = ({
  children, projection, initialExtent, extent
}) => {
  const [map, setMap] = useState<Map | undefined>(undefined);
  const [savedInitialExtent] = useState(initialExtent);

  useEffect(() => {
    const map = new Map({
      controls: defaults().extend([new ScaleLine()]),
      layers: [],
      target: 'map',
      view: new View({
        projection,
        zoom: 10
      })
    });

    if (savedInitialExtent) {
      map.getView().fit(savedInitialExtent);
    }

    setMap(map);

    return () => {
      map.setTarget(undefined);
    };
  }, [projection, savedInitialExtent]);

  useTrackExtent(map, extent);

  return (
    <MapContext.Provider value={map}>
      {children}
    </MapContext.Provider>
  );
};

export const useMap = () => useContext<Map | undefined>(MapContext);
