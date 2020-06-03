import React from 'react';
import { Case } from '../../api/api';
import CaseItem from './CaseItem';

interface CaseListProps {
  cases: Case[];
  toggleShow: () => void;
  setModalData: (modalData: any) => void;
}

const CaseList = ({ cases, toggleShow, setModalData }: CaseListProps) => {
  return (
    <>
      {cases.map((case_) => <CaseItem
        key={case_.caseId}
        caseId={case_.caseId}
        dnr={case_.dnr}
        title={case_.title}
        caseSource={case_.caseSource}
        toggleShow={toggleShow}
        setModalData={setModalData}
      />)}
    </>
  );
};

export default CaseList;