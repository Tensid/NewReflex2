import {
  createSlice, PayloadAction
} from '@reduxjs/toolkit';
import { getLayersSettings, getMapSettings, MapSettings } from '../../api/mapSettingsApi';
import { AppThunk } from '../../app/store';

type Types = 'WMS' | 'WMTS';

export interface Layer {
  type: Types;
  title: string;
  id: string;
  baseLayer: boolean;
  endPoint: string;
  options: any;
  tileGridOptions?: any;
}

export interface BaseState {
  mapSettings: MapSettings | undefined;
  layers?: Layer[] | undefined;
}

const initialState: BaseState = {
  mapSettings: undefined
};

export const mapSettings = createSlice({
  name: 'mapSettings',
  initialState,
  reducers: {
    setMapSettings: (state, action: PayloadAction<MapSettings>) => {
      state.mapSettings = action.payload;
    },
    setLayers: (state, action: PayloadAction<any>) => {
      state.layers = action.payload;
    }
  }
});

export const {
  setMapSettings,
  setLayers
} = mapSettings.actions;

export const fetchMapSettings = (): AppThunk => async dispatch => {
  try {
    var result = await getMapSettings();
    dispatch(setMapSettings(result));
  }
  catch (err: any) {
    console.log(err.toString());
  }
};

export const fetchLayers = (): AppThunk => async dispatch => {
  try {
    var result = await getLayersSettings();
    dispatch(setLayers(result));
  }
  catch (err: any) {
    console.log(err.toString());
  }
};

export default mapSettings.reducer;
