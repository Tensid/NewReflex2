import Geolocation from 'ol/Geolocation';
import Map from 'ol/Map';
import { unByKey } from 'ol/Observable';
import { transform } from 'ol/proj';
import { useNavigate } from 'react-router-dom';
import { useAppSelector } from '../../app/hooks';
import styles from './map.module.css';
import './ol-contextmenu.css';
import CtxMenu from './ol-contextmenu/main';
import { useMapEffect } from './useMapEffect';

function projToWgs(x: string | number, y: string | number, proj: string) {
  const coords = transform([Number(x), Number(y)], proj, 'WGS84');
  return { x: coords[0], y: coords[1] };
}

function renderDirections({ fromCoord, toCoord, mapProvider }: any) {
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

interface ContextMenuProps {
  fnr: string | undefined;
  estateName: string | undefined;
  estatePosition: any;
  setContextMenu: (contextmenu: any) => void;
}

export const ContextMenu = ({ fnr, estateName, estatePosition, setContextMenu }: ContextMenuProps) => {
  const navigate = useNavigate();
  const csmUrl = useAppSelector((state) => state.systemSettings.miscSettings?.csmUrl);
  const fbWebbBoendeUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbBoendeUrl);
  const fbWebbFastighetUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbFastighetUrl);

  useMapEffect(
    (map: Map) => {
      function showDirections(mapProvider: string) {
        const geolocation = new Geolocation({
          trackingOptions: {
            enableHighAccuracy: true
          },
          projection: map.getView().getProjection()
        });

        const changePosition = geolocation.on('change:position', () => {
          const position = geolocation.getPosition();
          if (position) {
            const code = map.getView().getProjection().getCode();
            const toCoord = projToWgs(estatePosition.eastingKoordinat, estatePosition.northingKoordinat, code);
            const fromCoord = projToWgs(position[0], position[1], code);
            renderDirections({ fromCoord, toCoord, mapProvider });
          }
          else {
            alert('Koordinater saknas!');
            return;
          }
          geolocation.setTracking(false);
          unByKey(changePosition);
        });
        geolocation.setTracking(true);
      }

      function openCsm(csmUrl: string) {
        const extent = map.getView().calculateExtent(map.getSize());
        const mapext = `&mapext=${extent[0]}+${extent[1]}+${extent[2]}+${extent[3]}`;
        const fullUrl = csmUrl + mapext;
        window.open(fullUrl);
      }

      function forEachFeatureAtPixel(evt: any) {
        return map.forEachFeatureAtPixel(evt.pixel, (ft, l) => {
          return {
            feature: ft,
            layer: { ...l && l.getProperties() }
          };
        });
      }

      const contextmenu = new CtxMenu({
        width: 185,
        defaultItems: false, // defaultItems are (for now) Zoom In/Zoom Out
      });

      map.addControl(contextmenu);

      // @ts-ignore
      contextmenu.on('beforeopen', (evt: any) => {
        const values = forEachFeatureAtPixel(evt);
        if (values?.feature && values?.layer?.name === 'estateLayer') {
          contextmenu.enable();

          const values = forEachFeatureAtPixel(evt);
          contextmenu.clear();
          if (values?.feature && values?.layer?.name === 'estateLayer') {
            let estateItems: any = [
              {
                text: estateName,
                classname: styles.menuTitle // add some CSS rules
                //icon: 'img/marker.png',  // this can be relative or absolute
              },
              '-' // separator,
              ,
              {
                text: 'Visa ärenden',
                callback: () => navigate('/cases')
              },
              '-'
            ];
            if (fbWebbFastighetUrl) {
              const csmOption = {
                text: 'Öppna fastighetsrapport',
                callback: () => window.open(fbWebbFastighetUrl + fnr)
              };
              estateItems.push(csmOption);
            }
            if (fbWebbBoendeUrl) {
              const csmOption = {
                text: 'Öppna befolkningsrapport',
                callback: () => window.open(fbWebbBoendeUrl + fnr)
              };
              estateItems.push(csmOption);
            }
            if (csmUrl) {
              const csmOption = {
                text: 'Öppna CSM',
                callback: () => openCsm(csmUrl)
              };
              estateItems.push(csmOption);
            }
            estateItems.push({
              text: 'Vägbeskrivning hit (Google)',
              callback: () => showDirections('Google')
            });
            estateItems.push({
              text: 'Vägbeskrivning hit (Bing)',
              callback: () => showDirections('Bing')
            });
            contextmenu.extend(estateItems);
            document.addEventListener('keydown', handleKeydown);
          }
        } else {
          contextmenu.disable();
        }
      });

      // @ts-ignore
      contextmenu.on('open', (evt: any) => {
        const values = forEachFeatureAtPixel(evt);
        contextmenu.clear();
        if (values?.feature && values?.layer?.name === 'estateLayer') {
          let estateItems: any = [
            {
              text: estateName,
              classname: styles.menuTitle // add some CSS rules
              //icon: 'img/marker.png',  // this can be relative or absolute
            },
            '-' // separator,
            ,
            {
              text: 'Visa ärenden',
              callback: () => navigate('/cases')
            },
            '-'
          ];
          if (fbWebbFastighetUrl) {
            const csmOption = {
              text: 'Öppna fastighetsrapport',
              callback: () => window.open(fbWebbFastighetUrl + fnr)
            };
            estateItems.push(csmOption);
          }
          if (fbWebbBoendeUrl) {
            const csmOption = {
              text: 'Öppna befolkningsrapport',
              callback: () => window.open(fbWebbBoendeUrl + fnr)
            };
            estateItems.push(csmOption);
          }
          if (csmUrl) {
            const csmOption = {
              text: 'Öppna CSM',
              callback: () => openCsm(csmUrl)
            };
            estateItems.push(csmOption);
          }
          estateItems.push({
            text: 'Vägbeskrivning hit (Google)',
            callback: () => showDirections('Google')
          });
          estateItems.push({
            text: 'Vägbeskrivning hit (Bing)',
            callback: () => showDirections('Bing')
          });
          contextmenu.extend(estateItems);
          document.addEventListener('keydown', handleKeydown);
        }
      });

      function handleKeydown(evt: any) {
        //Escape
        if (evt.keyCode === 27)
          contextmenu.closeMenu();
      }

      setContextMenu(contextmenu);
      return () => {
        document.removeEventListener('keydown', handleKeydown);
        map.removeControl(contextmenu);
        setContextMenu(undefined);
      };
    }, [fnr, estatePosition, estateName, csmUrl, fbWebbFastighetUrl, fbWebbBoendeUrl]);
  return null;
};
