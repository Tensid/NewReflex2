import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getPersons } from './api/api';
import { RootState } from './app/store';
import DataTable from './features/data-table/DataTable';
import { fetchSystemSettings } from './features/system-settings/systemSettingsSlice';

interface LinkButton {
  displayName: string;
  url: string | undefined;
}

const columns = [
  { 'data': 'firstname' },
  { 'data': 'familyname' },
  {
    'data': 'sex',
    'width': '1%'
  },
  {
    'data': 'age',
    'width': '2%'
  },
  { 'data': 'address' },
  { 'data': 'postalArea' },
  { 'data': 'estateName' }
];

const headers = [
  'Förnamn',
  'Efternamn',
  'Kön',
  'Ålder',
  'Adress',
  'Postort',
  'Fastighet'
];

const Population = () => {
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
        displayName: 'Boenderapport',
        url: fbWebbSettings?.fbWebbBoendeUrl ? fbWebbSettings.fbWebbBoendeUrl + searchResult.value : ''
      },
      {
        displayName: 'Lägenhetsrapport',
        url: fbWebbSettings?.fbWebbLagenhetUrl ? fbWebbSettings.fbWebbLagenhetUrl + searchResult.value : ''
      }
    ]);
  }, [fbWebbSettings, searchResult.value]);

  return (
    <>
      <h4>{(isValid) ? `Boende: ${count} personer på ` + searchResult.displayName : 'Ingen fastighet vald'}</h4>
      {(isValid && linkButtons.length > 0) && <DataTable setCount={setCount} headers={headers} columns={columns} linkButtons={linkButtons} getTableData={getPersons} />}
    </>
  );
};

export default Population;
