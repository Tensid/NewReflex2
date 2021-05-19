import React, { useEffect, useState } from 'react';
import BootstrapSwitchButton from 'bootstrap-switch-button-react';
import { connect } from 'react-redux';
import { Case, CaseSource, SearchResult } from './api/api';
import { RootState } from './app/store';
import CaseList from './features/cases/CaseList';
import CaseModal from './features/cases/CaseModal';

interface CasesProps {
  cases: Case[];
  searchResult: SearchResult;
  loading: boolean;
}

export interface ModalData {
  dnr: string;
  caseId: string;
  caseSource: CaseSource;
  title: string;
}

const Cases = ({ cases, searchResult, loading }: CasesProps) => {
  const [showAgs, setShowAgs] = useState(true);
  const [showByggr, setShowByggr] = useState(true);
  const [showEcos, setShowEcos] = useState(true);
  const [filteredCases, setFilteredCases] = useState<Case[]>(cases);
  const [show, setShow] = useState(false);
  const toggleShow = () => setShow(!show);
  const [modalData, setModalData] = useState<ModalData>();

  useEffect(() => {
    setFilteredCases(cases.filter(x =>
      (showAgs && x.caseSource === CaseSource.AGS)
      || (showByggr && x.caseSource === CaseSource.ByggR)
      || (showEcos && x.caseSource === CaseSource.Ecos)));
  }, [showAgs, showByggr, showEcos, cases]);

  return (
    <>
      <h5>
        {{
          'Ärende': <div>Visar ärende {searchResult.displayName}</div>,
          'Fastighet': <div>Ärenden för: {searchResult.displayName}</div>,
          'Adress': <div>Ärenden för: {searchResult.displayName}</div>
        }[searchResult.type!] || <div>Inget objekt valt</div>}
      </h5>
      {cases?.length > 0 && <>
        <BootstrapSwitchButton onlabel="Ecos" offlabel="Ecos" width={77} onstyle="success" style="mr-2" checked={showEcos}
          onChange={() => setShowEcos(!showEcos)} />
        <BootstrapSwitchButton onlabel="ByggR" offlabel="ByggR" width={77} onstyle="info" style="mr-2" checked={showByggr}
          onChange={() => setShowByggr(!showByggr)} />
        <BootstrapSwitchButton onlabel="AGS" offlabel="AGS" width={77} onstyle="warning" checked={showAgs}
          onChange={() => setShowAgs(!showAgs)} />
      </>}
      <div className="mt-2">
        {loading ? 'Hämtar ärenden...' :
          (filteredCases && filteredCases.length > 0) && <CaseList setModalData={setModalData} cases={filteredCases} toggleShow={toggleShow} />}
      </div>
      {(show && modalData) && <CaseModal show={show} modalData={modalData} toggleShow={toggleShow} />}
    </>
  );
};

const mapStateToProps = (state: RootState, _: any) => ({
  searchResult: state.searchResult,
  cases: state.cases?.value,
  loading: state.cases?.loading
});

export default connect(
  mapStateToProps,
  null
)(Cases);
