import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { SearchResult } from '../../api/api';

const initialState: SearchResult = {
  estateName: '',
  displayName: ''
};

const searchSlice = createSlice({
  name: 'search',
  initialState,
  reducers: {
    setSearchResult: (state, action: PayloadAction<SearchResult>) => {
      return action.payload;
    }
  }
});

export const { setSearchResult } = searchSlice.actions;

export default searchSlice.reducer;
