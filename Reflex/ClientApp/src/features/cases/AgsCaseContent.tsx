import React from 'react';
import { ArchivedDocument, CaseSource } from '../../api/api';
import ArchiveContent from './ArchiveContent';

interface AgsCaseContentProps {
  archivedDocuments: ArchivedDocument[];
  caseSource: CaseSource;
}

const AgsCaseContent = ({ archivedDocuments, caseSource }: AgsCaseContentProps) => {
  return (
    <ArchiveContent archivedDocuments={archivedDocuments} caseSource={caseSource} />
  );
};

export default AgsCaseContent;
