import { Action, ThunkAction, configureStore } from '@reduxjs/toolkit';
import configReducer from '../features/configs/configsSlice';

export const store = configureStore({
  reducer: {
    config: configReducer
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppThunk = ThunkAction<void, RootState, unknown, Action<string>>;
