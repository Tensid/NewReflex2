import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Case, getCases, SearchResult } from '../../api/api';
import { AppThunk } from '../../app/store';

interface CasesState {
  value: Case[];
  loading: boolean;
  error: string | null;
}

const initialState: CasesState = {
  value: [],
  loading: false,
  error: null
};

const casesSlice = createSlice({
  name: 'cases',
  initialState,
  reducers: {
    getCasesStart(state) {
      state.loading = true;
      state.error = null;
    },
    getCasesSuccess: (state, action: PayloadAction<any>) => {
      state.loading = false;
      state.value = action.payload;
      state.error = null;
    },
    getCasesFailed(state, action: PayloadAction<string>) {
      state.loading = false;
      state.error = action.payload;
    }
  }
});

export const fetchCasesAsync = (data: SearchResult): AppThunk => async dispatch => {
  try {
    if (data?.estateId) {
      dispatch(getCasesStart());
      const cases = await getCases(data.estateId);
      dispatch(getCasesSuccess(cases));
    }
  }
  catch (err) {
    dispatch(getCasesFailed(err.toString()));
    console.log(err.toString());
  }
};

export const {
  getCasesStart,
  getCasesSuccess,
  getCasesFailed
} = casesSlice.actions;

export default casesSlice.reducer;
