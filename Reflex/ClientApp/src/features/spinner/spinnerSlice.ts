import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface SpinnerState {
  loading: boolean;
}

const initialState: SpinnerState = {
  loading: false
};

const spinnerSlice = createSlice({
  name: 'spinner',
  initialState,
  reducers: {
    setLoading(state, action: PayloadAction<boolean>) {
      state.loading = action.payload;
    }
  }
});

export const {
  setLoading
} = spinnerSlice.actions;

export default spinnerSlice.reducer;
