import React from 'react';
import { Case } from '../../api/api';
import CaseItem from './CaseItem';

interface CaseListProps {
  cases: Case[];
}

const CaseList = ({ cases }: CaseListProps) => {
  return (
    <>
      {cases.map((case_) => <CaseItem key={case_.caseId} dnr={case_.dnr} title={case_.title} caseSource={case_.caseSource} />)}
    </>
  );
};

export default CaseList;
