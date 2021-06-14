import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getOwners } from './api/api';
import { RootState } from './app/store';
import DataTable from './features/data-table/DataTable';
import { fetchSystemSettings } from './features/system-settings/systemSettingsSlice';

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
  const fbWebbSettings = useSelector((state: RootState) => state.systemSettings.fbWebbSettings);
  const searchResult = useSelector((state: RootState) => state.searchResult);
  const isValid = searchResult.value && (searchResult.type === 'Fastighet' || searchResult.type === 'Adress');
  const dispatch = useDispatch();

  useEffect(() => {
    if (!fbWebbSettings)
      dispatch(fetchSystemSettings());
  }, [fbWebbSettings]);

  useEffect(() => {
    setLinkButtons([
      {
        displayName: 'Fastighetsrapport',
        url: fbWebbSettings?.fbWebbFastighetUrl ? fbWebbSettings.fbWebbFastighetUrl + searchResult.value : ''
      },
      {
        displayName: 'Fastighetsrapport med val',
        url: fbWebbSettings?.fbWebbFastighetUsrUrl ? fbWebbSettings.fbWebbFastighetUsrUrl + searchResult.value : ''
      },
      {
        displayName: 'Byggnadsrapport',
        url: fbWebbSettings?.fbWebbByggnadUrl ? fbWebbSettings.fbWebbByggnadUrl + searchResult.value : ''
      },
      {
        displayName: 'Byggnadsrapport med val',
        url: fbWebbSettings?.fbWebbByggnadUsrUrl ? fbWebbSettings.fbWebbByggnadUsrUrl + searchResult.value : ''
      }
    ]);
  }, [fbWebbSettings, searchResult.value]);

  return (
    <>
      <h4>{(isValid) ? `Ägare: ${count} för ${searchResult.displayName}` : 'Ingen fastighet vald'}</h4>
      {(isValid && linkButtons.length > 0) && <DataTable setCount={setCount} headers={headers} columns={columns} linkButtons={linkButtons} getTableData={getOwners} />}
    </>
  );
};

export default Property;
