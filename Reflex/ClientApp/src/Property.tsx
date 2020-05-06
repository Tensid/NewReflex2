import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Config, SearchResult } from './api/api';
import { RootState } from './app/store';
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

const url = './api/owners';

interface PropertyProps {
  config: Config;
  searchResult: SearchResult;
}

const Property = ({ config, searchResult }: PropertyProps) => {
  const [count, setCount] = useState(0);
  const [linkButtons, setLinkButtons] = useState<LinkButton[]>([]);
  const isValid = searchResult.value && (searchResult.type === 'Fastighet' || searchResult.type === 'Adress');

  useEffect(() => {
    setLinkButtons([
      {
        displayName: 'Fastighetsrapport',
        url: config?.fbWebbFastighetUrl ? config.fbWebbFastighetUrl + searchResult.value : ""
      },
      {
        displayName: 'Fastighetsrapport med val',
        url: config?.fbWebbFastighetUsrUrl ? config.fbWebbFastighetUsrUrl + searchResult.value : ""
      },
      {
        displayName: 'Byggnadsrapport',
        url: config?.fbWebbByggnadUrl ? config.fbWebbByggnadUrl + searchResult.value : ""
      },
      {
        displayName: 'Byggnadsrapport med val',
        url: config?.fbWebbByggnadUsrUrl ? config.fbWebbByggnadUsrUrl + searchResult.value : ""
      }
    ]);
  }, [config, searchResult.value]);

  return (
    <>
      <h4>{(isValid) ? `Ägare: ${count} för ${searchResult.displayName}` : 'Ingen fastighet vald'}</h4>
      {(isValid && linkButtons.length > 0) && <DataTable setCount={setCount} headers={headers} columns={columns} url={url} linkButtons={linkButtons} />}
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
)(Property);
