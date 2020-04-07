import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Config } from '../../api/api';

const initialState = null as (null | Config);

const configSlice = createSlice({
  name: 'config',
  initialState,
  reducers: {
    setConfig: (state, action: PayloadAction<any>) => {
      return action.payload;
    }
  }
});

export const { setConfig } = configSlice.actions;

export default configSlice.reducer;
