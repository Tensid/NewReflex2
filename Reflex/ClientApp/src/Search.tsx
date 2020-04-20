import React from 'react';
import { connect, useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';
import { SearchResult } from './api/api';
import { RootState } from './app/store';
import { fetchCasesAsync } from './features/cases/casesSlice';
import { setSearchResult } from './features/search-result/searchResultSlice';
import Typeahead from './features/typeahead/Typeahead';

const Search = () => {
  const dispatch = useDispatch();
  const { push } = useHistory();

  function onSelectCallback(data: SearchResult) {
    dispatch(fetchCasesAsync(data));
    dispatch(setSearchResult(data));
    push('/cases');
  }

  return (
    <>
      <div className="row">
        <label className="col col-form-label col-form-label-sm font-weight-bold">Sök fastighet eller adress:</label>
      </div>
      <Typeahead onSelectCallback={onSelectCallback}></Typeahead>
    </>
  );
};

const mapDispatch = { setSearchResult };

const mapStateToProps = (state: RootState) => ({
  searchResult: state.searchResult
});

export default connect(
  mapStateToProps,
  mapDispatch
)(Search);
