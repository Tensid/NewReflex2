import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Config, SearchResult, getPersons } from './api/api';
import { RootState } from './app/store';
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

interface PopulationProps {
  config: Config;
  searchResult: SearchResult;
}

const Population = ({ config, searchResult }: PopulationProps) => {
  const [count, setCount] = useState(0);
  const [linkButtons, setLinkButtons] = useState<LinkButton[]>([]);
  const isValid = searchResult.value && (searchResult.type === 'Fastighet' || searchResult.type === 'Adress');

  useEffect(() => {
    setLinkButtons([
      {
        displayName: 'Boenderapport',
        url: config?.fbWebbBoendeUrl ? config.fbWebbBoendeUrl + searchResult.value : ""
      },
      {
        displayName: 'Lägenhetsrapport',
        url: config?.fbWebbLagenhetUrl ? config.fbWebbLagenhetUrl + searchResult.value : ""
      }
    ]);
  }, [config, searchResult.value]);

  return (
    <>
      <h4>{(isValid) ? `Boende: ${count} personer på ` + searchResult.displayName : 'Ingen fastighet vald'}</h4>
      {(isValid && linkButtons.length > 0) && <DataTable setCount={setCount} headers={headers} columns={columns} linkButtons={linkButtons} getTableData={getPersons} />}
    </>
  );
};

const mapStateToProps = (state: RootState, _ownProps: any) => ({
  searchResult: state.searchResult,
  config: state.config
});

export default connect(
  mapStateToProps,
  null
)(Population);
