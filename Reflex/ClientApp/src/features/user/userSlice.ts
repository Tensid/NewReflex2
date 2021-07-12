import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { getCurrentUser, ReflexUser } from '../../api/api';
import { AppThunk } from '../../app/store';

const initialState = null as (null | ReflexUser);

const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    setUser: (state, action: PayloadAction<ReflexUser>) => {
      return { ...state, ...action.payload };
    },
  }
});

export const fetchGetUser = (): AppThunk => async dispatch => {
  try {
    const user = await getCurrentUser();
    dispatch(setUser(user));
  }
  catch (err) {
    console.log(err.toString());
  }
};

export const { setUser } = userSlice.actions;

export default userSlice.reducer;
