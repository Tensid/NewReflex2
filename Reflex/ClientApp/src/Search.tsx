import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useHistory } from 'react-router-dom';
import { SearchResult } from './api/api';
import { RootState } from './app/store';
import Autocomplete from './features/autocomplete/Autocomplete';
import { fetchCasesAsync } from './features/cases/casesSlice';
import { setSearchResult } from './features/search-result/searchResultSlice';

const Search = () => {
  const defaultTab = useSelector((state: RootState) => state.userSettings.defaultTab);
  const searchResult = useSelector((state: RootState) => state.searchResult);
  const dispatch = useDispatch();
  const { push } = useHistory();

  function onSelectCallback(data: SearchResult) {
    dispatch(fetchCasesAsync(data));
    dispatch(setSearchResult(data));
    push('/' + defaultTab.toLowerCase());
  }

  return (
    <>
      <label className="mb-1 col-form-label col-form-label-sm font-weight-bold">Sök fastighet eller adress:</label>
      <Autocomplete onSelectCallback={onSelectCallback} searchResult={searchResult} />
    </>
  );
};

export default Search;
