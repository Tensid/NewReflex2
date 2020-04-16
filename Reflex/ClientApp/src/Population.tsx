import React, { useState } from 'react';
import { connect } from 'react-redux';
import { Config, SearchResult } from './api/api';
import { RootState } from './app/store';
import DataTable from './features/data-table/DataTable';

interface PopulationProps {
  config: Config;
  searchResult: SearchResult;
}

const Population = ({ config, searchResult }: PopulationProps) => {
  const [count, setCount] = useState(0);

  return (
    <>
      <h4>
        {searchResult?.estateId ? `Boende: ${count} personer på ${searchResult?.estateName}` : 'Ingen fastighet vald'}
      </h4>
      {searchResult?.estateId && <DataTable setCount={setCount} config={config} />}
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
