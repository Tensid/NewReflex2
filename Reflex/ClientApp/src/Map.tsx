import React from 'react';
import { connect } from 'react-redux';
import { Config } from './api/api';
import { RootState } from './app/store';
import Map from './features/map/Map.js';
import { fetchMapSettings } from './features/map/mapSettingsSlice';
import { setSearchResult } from './features/search-result/searchResultSlice';

interface MapViewProps {
  fnr: string | undefined;
  config: Config | null;
  estateName: string | undefined;
  setSearchResult: any;
  mapSettings: any;
  fetchMapSettings: any;
}

const MapView = ({ fnr, setSearchResult, config, estateName, mapSettings, fetchMapSettings }: MapViewProps) => {
  if (!mapSettings) {
    fetchMapSettings();
    return null;
  }

  return (
    <Map fnr={fnr} setSearchResult={setSearchResult} mapSettings={mapSettings} estateName={estateName} {...config} />
  );
};

const mapDispatch = { setSearchResult, fetchMapSettings };

const mapStateToProps = (state: RootState, _ownProps: any) => ({
  fnr: state.searchResult.type === 'Fastighet' ? state.searchResult.value : undefined,
  estateName: state.searchResult.type === 'Fastighet' ? state.searchResult.estateName : undefined,
  mapSettings: state.mapSettings.mapSettings,
  config: state?.config
});

export default connect(
  mapStateToProps,
  mapDispatch
)(MapView);
