import { createSlice } from '@reduxjs/toolkit';

interface SpinnerState {
  pendingActions: number;
}

const initialState: SpinnerState = {
  pendingActions: 0
};

const spinnerSlice = createSlice({
  name: 'spinner',
  initialState,
  reducers: {
    increase(state) {
      ++state.pendingActions;
    },
    decrease(state) {
      --state.pendingActions;
    }
  }
});

export const {
  increase,
  decrease
} = spinnerSlice.actions;

export default spinnerSlice.reducer;
