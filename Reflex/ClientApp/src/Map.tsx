import { useAppSelector } from './app/hooks';
import ReflexMap from './features/map/ReflexMap';

const Map = () => {
  const type = useAppSelector((state) => state.searchResult.type);
  const value = useAppSelector((state) => state.searchResult.value);
  const estateName = useAppSelector((state) => state.searchResult.estateName);
  const projection = useAppSelector((state) => state.mapSettings?.mapSettings?.projection);

  console.log("type", type);
  console.log("value", value);
  console.log("estateName", estateName);
  console.log("projection", projection);

  if (!projection)
    return null;
  const fnr = type === 'Fastighet' ? value : undefined;
  return (
    <ReflexMap projection={projection} fnr={fnr} estateName={estateName} />
  );
};

export default Map;
