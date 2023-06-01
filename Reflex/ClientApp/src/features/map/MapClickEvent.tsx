import { unByKey } from 'ol/Observable';
import { EventsKey } from 'ol/events';
import { buffer, extend } from 'ol/extent';
import GeoJson from 'ol/format/GeoJSON';
import { transform } from 'ol/proj';
import { useEffect } from 'react';
import { CaseSource, SearchResult, getEstateName, getEstatePosition, getFnrFromPosition, getGeometryFromFnr } from '../../api/api';
import { useAppDispatch } from '../../app/hooks';
import { fetchCasesAsync } from '../cases/casesSlice';
import { setSearchResult } from '../search-result/searchResultSlice';
import { useMap } from './MapProvider';

interface MapClickEventProps {
  fnr?: string;
  contextmenu: any;
  infoClick: boolean;
  setAlert: (alert: any) => void;
  setEstateName: (estateName: string) => void;
  setEstatePosition: (estatePosition: any) => void;
  setEstateFeatures: (features: any) => void;
}

export const MapClickEvent = ({ fnr, setAlert, contextmenu, setEstateFeatures, infoClick, setEstateName, setEstatePosition }: MapClickEventProps) => {
  const map = useMap();
  const dispatch = useAppDispatch();
  function searchEstateCases(estateId: string, estateName: string | undefined) {
    const searchResult: SearchResult = {
      value: estateId,
      estateId: estateId,
      source: 'FB' as CaseSource,
      type: 'Fastighet',
      displayName: estateName || '',
      estateName: estateName || ''
    };

    dispatch(setSearchResult(searchResult));
    dispatch(fetchCasesAsync(searchResult));
  }

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
    let singleClick: EventsKey;

    singleClick = map.on('singleclick', (evt) => {
      contextmenu?.close();
      if (!infoClick)
        return;

      const lon = evt.coordinate[0];
      const lat = evt.coordinate[1];
      const epsg = map.getView().getProjection().getCode().split(':');
      const srid = epsg[epsg.length - 1];

      (async () => {
        let geometryContent;
        let estateName;
        let estatePosition;
        fnr = await getFnrFromPosition(lat, lon, srid, 1);
        [geometryContent, estateName, estatePosition] = await Promise.all([
          getGeometryFromFnr(fnr),
          getEstateName(fnr),
          getEstatePosition(fnr)
        ]);
        drawEstate(geometryContent);
        searchEstateCases(fnr, estateName);
        setAlert({ fnr, estateName, show: true });
        setEstateName(estateName);
        const coords = transform([Math.round(estatePosition.eastingKoordinat), Math.round(estatePosition.northingKoordinat)], 'EPSG:3006', map.getView().getProjection().getCode());
        const transformedEstatePosition = { eastingKoordinat: coords[0], northingKoordinat: coords[1] };
        setEstatePosition(transformedEstatePosition);
      })();
    });

    return () => {
      if (singleClick)
        unByKey(singleClick);
    };
  }, [map, infoClick]);

  return null;
};
