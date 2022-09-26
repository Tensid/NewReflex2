import { useEffect, useState } from 'react';
import { getPersons } from './api/api';
import { useAppSelector } from './app/hooks';
import DataTable from './features/data-table/DataTable';

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
  const fbWebbBoendeUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbBoendeUrl);
  const fbWebbLagenhetUrl = useAppSelector((state) => state.systemSettings.fbWebbSettings?.fbWebbLagenhetUrl);
  const displayName = useAppSelector((state) => state.searchResult.displayName);
  const type = useAppSelector((state) => state.searchResult.type);
  const value = useAppSelector((state) => state.searchResult.value);
  const isValid = value && (type === 'Fastighet' || type === 'Adress');

  useEffect(() => {
    setLinkButtons([
      {
        displayName: 'Boenderapport',
        url: fbWebbBoendeUrl ? fbWebbBoendeUrl + value : ''
      },
      {
        displayName: 'Lägenhetsrapport',
        url: fbWebbLagenhetUrl ? fbWebbLagenhetUrl + value : ''
      }
    ]);
  }, [fbWebbBoendeUrl, fbWebbLagenhetUrl, value]);

  return (
    <>
      <h4>{(isValid) ? `Boende: ${count} personer på ` + displayName : 'Ingen fastighet vald'}</h4>
      {(isValid && linkButtons.length > 0) && <DataTable setCount={setCount} headers={headers} columns={columns} linkButtons={linkButtons} getTableData={getPersons} />}
    </>
  );
};

export default Population;
