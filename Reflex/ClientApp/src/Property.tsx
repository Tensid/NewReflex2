import React from 'react';
import { connect } from 'react-redux';
import { Config, SearchResult } from './api/api';
import { RootState } from './app/store';

interface PropertyProps {
  config: Config;
  searchResult: SearchResult;
}

const Property = ({ config, searchResult }: PropertyProps) => {
  return (
    <>
      <h4>Fastighet</h4>
      <div>
        {searchResult?.estateName && searchResult?.estateId ?
          <a target="_blank" rel="noopener noreferrer" href={config?.fbWebbFastighetUrl + searchResult?.estateId} title="Öppna fastighetsrapport">{searchResult.estateName}</a>
          : "Ingen fastighet vald"}
      </div>
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
