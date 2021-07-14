import Geolocation from 'ol/Geolocation';
import { unByKey } from 'ol/Observable';
import { EventsKey } from 'ol/events';
import { buffer, extend } from 'ol/extent';
import GeoJson from 'ol/format/GeoJSON';
import { transform } from 'ol/proj';
import { useEffect } from 'react';
import { getEstateName, getEstatePosition, getGeometryFromFnr } from '../../api/api';
import { useMap } from './MapProvider';

interface MapPostRenderEventProps {
  fnr?: string;
  setAlert: (alert: any) => void;
  setInfoClick: (infoClick: boolean) => void;
  setEstateName: (estateName: string) => void;
  setEstatePosition: (estatePosition: any) => void;
  setEstateFeatures: (features: any) => void;
}

export const MapPostRenderEvent = ({ fnr, setInfoClick, setAlert, setEstateFeatures, setEstateName, setEstatePosition }: MapPostRenderEventProps) => {
  const map = useMap();

  function drawEstate(content: any, fitToFeature = false) {
    const grupp = content.data[0].grupp;
    const geojsonObject = {
      'type': 'FeatureCollection',
      'features': [
      ]
    };

    Object.entries(grupp).forEach(([key, val]) => {
      // @ts-ignore
      Object.entries(val).forEach(([key2, val2]) => {
        if (key2 === 'yta') {
          // @ts-ignore
          geojsonObject['features'].push(val2);
        }
      });
    });
    const features = (new GeoJson()).readFeatures(geojsonObject, {
      dataProjection: map!.getView().getProjection().getCode(),
      featureProjection: map!.getView().getProjection()
    });
    if (fitToFeature) {
      if (features && features.length > 0) {
        const extents = features.map((f) => f.getGeometry()!.getExtent());
        const totalExtent = extents.reduce((acc: any, cur: any) => {
          if (!acc) return cur;
          return extend(acc, cur);
        }, null);
        if (totalExtent) {
          const buffered = buffer(totalExtent, 50);
          map!.getView().fit(buffered);
        }
      }
    }
    setEstateFeatures(features);
  }

  useEffect(() => {
    if (!map)
      return;
    let postrender: EventsKey;
    let geolocation = new Geolocation({
      trackingOptions: {
        enableHighAccuracy: true
      },
      projection: map.getView().getProjection()
    });
    const changePosition = geolocation.on('change:position', () => {
      map.getView().setCenter(geolocation.getPosition());
      map.getView().setZoom(13);
      geolocation.setTracking(false);
      unByKey(changePosition);
    });

    postrender = map.once('postrender', () => {
      if (fnr) {
        (async () => {
          let geometryContent;
          let estateName;
          let estatePosition;
          [geometryContent, estateName, estatePosition] = await Promise.all([
            getGeometryFromFnr(fnr),
            getEstateName(fnr),
            getEstatePosition(fnr)
          ]);
          drawEstate(geometryContent, true);
          setAlert({ fnr, estateName, show: true });
          setEstateName(estateName);

          const coords = transform([Math.round(estatePosition.eastingKoordinat), Math.round(estatePosition.northingKoordinat)], 'EPSG:3006', map.getView().getProjection().getCode());
          const transformedEstatePosition = { eastingKoordinat: coords[0], northingKoordinat: coords[1] };
          setEstatePosition(transformedEstatePosition);
        })();
      }
      else {
        geolocation.setTracking(true);
      }
      setInfoClick(true);
    });

    return () => {
      if (postrender)
        unByKey(postrender);
      unByKey(changePosition);
      geolocation.setTracking(false);
    };
  }, [map]);
  return null;
};
