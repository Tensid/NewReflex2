import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Case, CaseSource, getCase, getCases, SearchResult } from '../../api/api';
import { AppThunk } from '../../app/store';
import { decrease, increase } from '../spinner/spinnerSlice';

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
    if (data?.value) {
      dispatch(increase());
      dispatch(getCasesStart());
      let cases: Case[];
      if (data.type === 'Fastighet' || data.type === 'Adress')
        cases = await getCases(data.value);
      else
        if (data.value === '00000000-0000-0000-0000-000000000000')
          cases = await getCase(data.displayName, data.source as CaseSource, data?.caseSourceId);
        else
          cases = await getCase(data.value, data.source as CaseSource, data?.caseSourceId);
      dispatch(getCasesSuccess(cases));
      dispatch(decrease());
    }
  }
  catch (err) {
    dispatch(getCasesFailed(err.toString()));
    console.log(err.toString());
    dispatch(decrease());
  }
};

export const {
  getCasesStart,
  getCasesSuccess,
  getCasesFailed
} = casesSlice.actions;

export default casesSlice.reducer;
