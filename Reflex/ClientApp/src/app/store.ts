import { Action, Middleware, ThunkAction, configureStore } from '@reduxjs/toolkit';
import { setConfigId } from '../api/api';
import casesReducer from '../features/cases/casesSlice';
import configReducer from '../features/configs/configsSlice';
import mapSettingsReducer from '../features/map/mapSettingsSlice';
import searchResultReducer from '../features/search-result/searchResultSlice';
import spinnerReducer from '../features/spinner/spinnerSlice';
import userSettingsReducer from '../features/user-settings/userSettingsSlice';

const setConfigIdMiddleWare: Middleware = store => next => action => {
  if (action.type === 'config/setConfig') {
    if (action?.payload)
      setConfigId(action.payload.id);
  }
  return next(action);
};

export const store = configureStore({
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(setConfigIdMiddleWare),
  reducer: {
    cases: casesReducer,
    config: configReducer,
    mapSettings: mapSettingsReducer,
    searchResult: searchResultReducer,
    spinner: spinnerReducer,
    userSettings: userSettingsReducer
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
