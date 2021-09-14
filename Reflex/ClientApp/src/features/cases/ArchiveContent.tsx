import React from 'react';
import { ArchivedDocument, CaseSource, getDocument } from '../../api/api';
import { TabState } from './CaseModal';

interface ArchiveContentProps {
  archiveState: TabState<ArchivedDocument[]>;
  caseSource: CaseSource;
  caseSourceId: string;
}

const ArchiveContent = ({ archiveState, caseSource, caseSourceId }: ArchiveContentProps) => {
  if (archiveState.error)
    return <>Kunde inte hämta arkiverade handlingar.</>;
  if (archiveState.loading)
    return <>Laddar arkiverade handlingar...</>;
  if (!archiveState?.value)
    return null;
  const archivedDocuments = archiveState.value;
  const archivedDocument = archivedDocuments[0];
  return (
    <div className="container">
      <div className="row">
        <div className="col-12">
          <ul className="list-group">
            {archivedDocument?.docs?.map(doc =>
              <li className="list-group-item">
                <h5>{doc.title}</h5>
                <ul>
                  {doc.files?.map(file =>
                    <li>
                      <span className="btn btn-link px-0" role="button" title={file.title} onClick={() => getDocument(file.physicalDocumentId, caseSource, caseSourceId)}>
                        {file.title}
                      </span>
                    </li>
                  )}
                </ul>
              </li>
            )}
          </ul>
        </div>
      </div>
    </div>
  );
};

export default ArchiveContent;
