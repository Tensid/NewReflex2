import {
  createSlice, PayloadAction
} from '@reduxjs/toolkit';
import { FbWebbSettings, getFbWebbSettings, getMiscSettings, MiscSettings } from '../../api/settings/';
import { AppThunk } from '../../app/store';

export interface BaseState {
  fbWebbSettings: FbWebbSettings | null;
  miscSettings: MiscSettings | null;
}

const initialState: BaseState = {
  fbWebbSettings: null,
  miscSettings: null
};

export const systemSettings = createSlice({
  name: 'systemSettings',
  initialState,
  reducers: {
    setFbWebbSettings: (state, action: PayloadAction<FbWebbSettings>) => {
      state.fbWebbSettings = action.payload;
    },
    setMiscSettings: (state, action: PayloadAction<MiscSettings>) => {
      state.miscSettings = action.payload;
    }
  }
});

export const {
  setFbWebbSettings,
  setMiscSettings
} = systemSettings.actions;

export const fetchSystemSettings = (): AppThunk => async dispatch => {
  try {
    var miscSettings = await getMiscSettings();
    var fbSettings = await getFbWebbSettings();
    dispatch(setFbWebbSettings(fbSettings) || {});
    dispatch(setMiscSettings(miscSettings) || {});
  }
  catch (err: any) {
    console.log(err.toString());
  }
};

export default systemSettings.reducer;
