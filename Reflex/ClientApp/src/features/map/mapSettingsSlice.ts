import {
  createSlice, PayloadAction
} from '@reduxjs/toolkit';
import { getMapSettings } from '../../api/api';
import { AppThunk } from '../../app/store';

export interface BaseState {
  mapSettings: any;
}

const initialState: BaseState = {
  mapSettings: undefined
};

export const mapSettings = createSlice({
  name: 'mapSettings',
  initialState,
  reducers: {
    setMapSettings: (state, action: PayloadAction<any>) => {
      state.mapSettings = action.payload;
    }
  }
});

export const {
  setMapSettings,
} = mapSettings.actions;

export const fetchMapSettings = (): AppThunk => async dispatch => {
  try {
    var settings = await getMapSettings();
    dispatch(setMapSettings(settings));
  }
  catch (err) {
    console.log(err.toString());
  }
};

export default mapSettings.reducer;
