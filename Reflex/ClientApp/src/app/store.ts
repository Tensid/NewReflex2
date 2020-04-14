import { Action, ThunkAction, configureStore } from '@reduxjs/toolkit';
import configReducer from '../features/configs/configsSlice';
import searchResultReducer from '../features/search-result/searchResultSlice';

export const store = configureStore({
  reducer: {
    config: configReducer,
    searchResult: searchResultReducer
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppThunk = ThunkAction<void, RootState, unknown, Action<string>>;
