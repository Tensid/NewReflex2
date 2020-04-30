import React from 'react';
import { CaseSource, Occurence } from '../../api/api';
import OccurenceContent from './OccurenceContent';

interface EcosCaseContentProps {
  caseSource: CaseSource;
  occurences: Occurence[];
}

const EcosCaseContent = ({ caseSource, occurences }: EcosCaseContentProps) => {
  return (
    <OccurenceContent occurences={occurences} caseSource={caseSource} />
  );
};

export default EcosCaseContent;
