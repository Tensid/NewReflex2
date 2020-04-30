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

const Cases = ({ cases, searchResult, loading }: CasesProps) => {
  const [showAgs, setShowAgs] = useState(true);
  const [showByggr, setShowByggr] = useState(true);
  const [showEcos, setShowEcos] = useState(true);
  const [filteredCases, setFilteredCases] = useState<Case[]>(cases);
  const [show, setShow] = useState(false);
  const toggleShow = () => setShow(!show);
  const [modalData, setModalData] = useState([]);

  useEffect(() => {
    setFilteredCases(cases.filter(x =>
      (showAgs && x.caseSource === CaseSource.AGS)
      || (showByggr && x.caseSource === CaseSource.ByggR)
      || (showEcos && x.caseSource === CaseSource.Ecos)));
  }, [showAgs, showByggr, showEcos, cases]);

  return (
    <>
      <h5>
        {searchResult.estateName ? `Ärenden för ${searchResult.estateName}` : 'Ingen fastighet vald'}
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
          (filteredCases && filteredCases.length > 0) && <CaseList cases={filteredCases} setModalData={setModalData} toggleShow={toggleShow} />}
      </div>
      {/*@ts-ignore*/}
      {show && <CaseModal show={show} {...modalData} toggleShow={toggleShow} />}
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
