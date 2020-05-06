import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { getUserSettings, Tab, updateUserSettings, UserSettings } from '../../api/api';
import { AppThunk } from '../../app/store';

let initialState: UserSettings = {
  defaultTab: Tab.Cases
};

const userSettingsSlice = createSlice({
  name: 'userSettings',
  initialState,
  reducers: {
    setUserSettings: (state, action: PayloadAction<UserSettings>) => {
      state.defaultTab = action.payload.defaultTab;
    },
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

export const { setUserSettings } = userSettingsSlice.actions;

export default userSettingsSlice.reducer;
