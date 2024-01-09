import { useHistory } from 'react-router-dom';
import { SearchResult } from './api/api';
import { useAppDispatch, useAppSelector } from './app/hooks';
import Autocomplete from './features/autocomplete/Autocomplete';
import { fetchCasesAsync } from './features/cases/casesSlice';
import { setSearchResult } from './features/search-result/searchResultSlice';

const Search = () => {
  const defaultTab = useAppSelector((state) => state.userSettings.defaultTab);
  const searchResult = useAppSelector((state) => state.searchResult);
  const tabs = useAppSelector((state) => state.config?.tabs);
  const dispatch = useAppDispatch();
  const { push } = useHistory();

  function onSelectCallback(data: SearchResult) {
    dispatch(fetchCasesAsync(data));
    dispatch(setSearchResult(data));

    if (tabs?.includes(defaultTab))
      push('/reflex/' + defaultTab.toLowerCase());
  }

  return (
    <>
      <label className="mb-1 col-form-label-sm fw-bold">Sök fastighet, adress eller ärende</label>
      <Autocomplete onSelectCallback={onSelectCallback} searchResult={searchResult} />
    </>
  );
};

export default Search;
