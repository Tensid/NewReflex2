import React from 'react';
import { connect, useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';
import { SearchResult } from './api/api';
import { setSearchResult } from './features/search-result/searchResultSlice';
import Typeahead from './features/typeahead/Typeahead';

const Search = () => {
  const dispatch = useDispatch();
  const { push } = useHistory();

  function onSelectCallback(data: SearchResult) {
    dispatch(setSearchResult(data));
    push('/property');
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

export default connect(
  null,
  mapDispatch
)(Search);
