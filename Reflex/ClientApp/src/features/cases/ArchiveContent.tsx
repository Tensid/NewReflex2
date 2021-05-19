import React from 'react';
import { ArchivedDocument, CaseSource } from '../../api/api';
import { TabState } from './CaseModal';

interface ArchiveContentProps {
  archiveState: TabState<ArchivedDocument[]>;
  caseSource: CaseSource;
}

const ArchiveContent = ({ archiveState, caseSource }: ArchiveContentProps) => {
  if (archiveState.error)
    return <>Kunde inte hämta arkiverade handlingar.</>;
  if (archiveState.loading)
    return <>Laddar arkiverade handlingar...</>;
  if (!archiveState?.value)
    return null;
  const archivedDocuments = archiveState.value;
  return (
    <div className="container">
      <div className="row">
        <div className="col-12">
          <div className="py-2">
            <h5>Arkiverade handlingar</h5>
          </div>
          {archivedDocuments?.length > 0 ?
            <ul className="list-group">
              {archivedDocuments.map(doc =>
                <li className="list-group-item">
                  <a href={`cases/document?docId=${doc.physicalDocumentId}&caseSource=${caseSource}`}>
                    {doc.title}
                  </a>
                </li>
              )}
            </ul>
            :
            'Det finns inga handlingar att hämta'
          }
        </div>
      </div>
    </div>
  );
};

export default ArchiveContent;
