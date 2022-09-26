import Feature from 'ol/Feature';
import Geometry from 'ol/geom/Geometry';
import Projection from 'ol/proj/Projection';
import { Fill, Stroke, Style } from 'ol/style';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAppSelector } from '../../app/hooks';
import { ClearFeaturesControlButton } from './ClearFeaturesControlButton';
import { ContextMenu } from './ContextMenu';
import { DrawLineControlButton } from './DrawLineControlButton';
import { DrawPolygonControlButton } from './DrawPolygonControlButton';
import { FeatureLayer } from './FeatureLayer';
import { GoToUserLocationControlButton } from './GoToUserLocationControlButton';
import { InfoClickControlButton } from './InfoClickControlButton';
import { LayerSwitcher } from './LayerSwitcher';
import { MapClickEvent } from './MapClickEvent';
import { MapContainer } from './MapContainer';
import { MapPostRenderEvent } from './MapPostRenderEvent';
import { MapProvider } from './MapProvider';
import { Measure } from './Measure';
import { WmsLayer } from './WmsLayer';
import { WmtsLayer } from './WmtsLayer';
import styles from './map.module.css';

interface ReflexMapProps {
  projection?: string | Projection | undefined;
  fnr?: string;
  estateName?: string;
}

interface Position {
  northingKoordinat: string;
  eastingKoordinat: string;
}

interface CaseAlertProps {
  estateName?: string;
  show: boolean;
  toggleAlert: () => void;
}

const CaseAlert = ({ estateName, show, toggleAlert }: CaseAlertProps) => {
  const navigate = useNavigate();
  if (show)
    return (
      <div className="mx-auto alert alert-info alert-dismissible alert-overlay">
        {estateName} <a href="cases" onClick={e => {
          e.preventDefault();
          navigate('/cases');
        }
        }>Visa ärenden</a>
        <button className="btn-close" onClick={toggleAlert} aria-label="close" />
      </div>
    );
  return null;
};

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

// @ts-ignore
const styleFunction = (feature: Feature) => geometryStyles[feature.getGeometry().getType()];
const estateLayerOptions = {
  style: styleFunction,
  name: 'estateLayer'
};

const ReflexMap = ({ projection, fnr, estateName: defaultEstateName }: ReflexMapProps) => {
  const extent = useAppSelector((state) => state.mapSettings.mapSettings?.extent);
  const layers = useAppSelector((state) => state.mapSettings.layers);
  const map = useAppSelector((state) => state.config?.map);
  const [estateFeatures, setEstateFeatures] = useState<Feature<Geometry>[]>();
  const [estatePosition, setEstatePosition] = useState<Position>();
  const [estateName, setEstateName] = useState(defaultEstateName);
  const [infoClick, setInfoClick] = useState(false);
  const [contextMenu, setContextMenu] = useState<any>();
  const [typeSelect, setTypeSelect] = useState<string>('');
  const [alert, setAlert] = useState({ estateName, fnr, show: false });
  const toggleInfoClick = () => setInfoClick(!infoClick);
  const toggleAlert = () => setAlert({ ...alert, show: !alert.show });

  if (!extent) return null;
  const baseLayers = layers?.filter((x) => x.baseLayer).filter((x: any) => map?.includes(x?.id));
  const nonbaseLayers = layers?.filter((x) => !x.baseLayer).filter((x: any) => map?.includes(x?.id));
  if ((!layers || layers.length === 0))
    return <>Det finns ingen karta att visa.</>;

  return (
    <MapProvider projection={projection} initialExtent={extent}>
      <MapContainer className="flex-grow-1" style={{ height: 'inherit' }} />
      {baseLayers?.map((x, i) => {
        if (x.type === 'WMS')
          return <WmsLayer visible={i === baseLayers.length - 1} options={x.options} title={x.title} baseLayer={x?.baseLayer} key={x.id} />;
        if (x.type === 'WMTS')
          return <WmtsLayer visible={i === baseLayers.length - 1} options={x.options} tileGridOptions={x.tileGridOptions} title={x.title} key={x.id} />;
        return null;
      })}
      {nonbaseLayers?.filter(x => x.type === 'WMS').map((x) => {
        return <WmsLayer visible={false} options={x.options} title={x.title} baseLayer={x?.baseLayer} key={x.id} />;
      })
      }
      <FeatureLayer features={estateFeatures} options={estateLayerOptions} />
      <GoToUserLocationControlButton />
      <InfoClickControlButton callBack={() => { toggleInfoClick(); setTypeSelect(''); }} infoClick={infoClick} />
      <ClearFeaturesControlButton callBack={() => { setAlert({ ...alert, show: false }); setEstateFeatures(undefined); setInfoClick(false); setTypeSelect(''); contextMenu?.close(); }} />
      <DrawLineControlButton callBack={() => { setInfoClick(false); setTypeSelect('Length'); contextMenu?.close(); }} />
      <DrawPolygonControlButton callBack={() => { setInfoClick(false); setTypeSelect('Area'); contextMenu?.close(); }} />
      <LayerSwitcher options={{ reverse: false }} />
      {infoClick && <ContextMenu fnr={fnr} estateName={estateName} estatePosition={estatePosition} setContextMenu={setContextMenu} />}
      {typeSelect && <Measure typeSelect={typeSelect} />}
      <MapClickEvent contextmenu={contextMenu} infoClick={infoClick} setAlert={setAlert} setEstateFeatures={setEstateFeatures} setEstateName={setEstateName} setEstatePosition={setEstatePosition} fnr={fnr} />
      <MapPostRenderEvent setAlert={setAlert} setEstateFeatures={setEstateFeatures} setEstateName={setEstateName} setEstatePosition={setEstatePosition} setInfoClick={setInfoClick} fnr={fnr} />
      <div className={styles.alertOverlay}>
        <CaseAlert {...alert} toggleAlert={toggleAlert} />
      </div>
    </MapProvider>
  );
};

export default ReflexMap;
