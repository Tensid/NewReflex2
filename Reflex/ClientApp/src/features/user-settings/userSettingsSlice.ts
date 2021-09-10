import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { getConfigs, getUserSettings, Tab, updateUserSettings, UserSettings } from '../../api/api';
import { AppThunk } from '../../app/store';
import { setConfig } from '../configs/configsSlice';

export interface UserSettingsState extends UserSettings {
  hasReceived: boolean;
}

let initialState: UserSettingsState = {
  defaultTab: Tab.Cases,
  hasReceived: false
};

const userSettingsSlice = createSlice({
  name: 'userSettings',
  initialState,
  reducers: {
    setUserSettings: (state, action: PayloadAction<UserSettings>) => {
      state.defaultTab = action.payload.defaultTab;
      state.defaultConfigId = action.payload.defaultConfigId;
    },
    setUserSettingsHasReceived: (state) => {
      state.hasReceived = true;
    }
  }
});

export const fetchUserSettings = (): AppThunk => async dispatch => {
  try {
    const userSettings = await getUserSettings();
    dispatch(setUserSettings(userSettings));
  }
  catch (err) {
    console.log(err.toString());
  }
};

export const fetchUpdateUserSettings = (userSettings: UserSettings): AppThunk => async dispatch => {
  try {
    await updateUserSettings(userSettings);
    dispatch(setUserSettings(userSettings));
  }
  catch (err) {
    console.log(err.toString());
  }
};

export const fetchInitiateSettings = (): AppThunk => async dispatch => {
  try {
    const userSettings: UserSettings = await getUserSettings();
    const configs = await getConfigs();
    const defaultConfig = configs.find(x => x.id === userSettings.defaultConfigId);

    dispatch(setUserSettings(userSettings));
    dispatch(setConfig(defaultConfig));
    dispatch(setUserSettingsHasReceived());
  }
  catch (err) {
    console.log(err.toString());
  }
};

export const { setUserSettings, setUserSettingsHasReceived } = userSettingsSlice.actions;

export default userSettingsSlice.reducer;
