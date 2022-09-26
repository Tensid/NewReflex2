import { useEffect, useState } from 'react';
import { getOwners } from './api/api';
import { useAppSelector } from './app/hooks';
import DataTable from './features/data-table/DataTable';

interface LinkButton {
  displayName: string;
  url: string | undefined;
}

const columns = [
  {
    'data': 'uuIdEstate',
    'visible': false,
  },
  { 'data': 'fnr' },
  { 'data': 'estateName' },
  { 'data': 'status' },
  { 'data': 'countyCode' },
  { 'data': 'municipalityCode' },
  { 'data': 'municipality' },
  { 'data': 'share' },
  { 'data': 'name' },
  { 'data': 'streetAddress' },
  { 'data': 'postalCode' },
  { 'data': 'postalArea' }
];

const headers = [
  'ID',
  'FNR',
  'BETECKNING',
  'STATUS',
  'LANKOD',
  'KOMKOD',
  'KOMMUN',
  'ANDEL',
  'ÄGARE',
  'GATUADRESS',
  'POSTNR',
  'POSTORT'
];

const Property = () => {
  const [count, setCount] = useState(0);
  const [linkButtons, setLinkButtons] = useState<LinkButton[]>([]);
  const fbWebbFastighetUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbFastighetUrl);
  const fbWebbFastighetUsrUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbFastighetUsrUrl);
  const fbWebbByggnadUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbByggnadUrl);
  const fbWebbByggnadUsrUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbByggnadUsrUrl);
  const displayName = useAppSelector((state) => state.searchResult.displayName);
  const type = useAppSelector((state) => state.searchResult.type);
  const value = useAppSelector((state) => state.searchResult.value);
  const isValid = value && (type === 'Fastighet' || type === 'Adress');

  useEffect(() => {
    setLinkButtons([
      {
        displayName: 'Fastighetsrapport',
        url: fbWebbFastighetUrl ? fbWebbFastighetUrl + value : ''
      },
      {
        displayName: 'Fastighetsrapport med val',
        url: fbWebbFastighetUsrUrl ? fbWebbFastighetUsrUrl + value : ''
      },
      {
        displayName: 'Byggnadsrapport',
        url: fbWebbByggnadUrl ? fbWebbByggnadUrl + value : ''
      },
      {
        displayName: 'Byggnadsrapport med val',
        url: fbWebbByggnadUsrUrl ? fbWebbByggnadUsrUrl + value : ''
      }
    ]);
  }, [fbWebbFastighetUrl, fbWebbFastighetUsrUrl, fbWebbByggnadUrl, fbWebbByggnadUsrUrl, value]);

  return (
    <>
      <h4>{(isValid) ? `Ägare: ${count} för ${displayName}` : 'Ingen fastighet vald'}</h4>
      {(isValid && linkButtons.length > 0) && <DataTable setCount={setCount} headers={headers} columns={columns} linkButtons={linkButtons} getTableData={getOwners} />}
    </>
  );
};

export default Property;
