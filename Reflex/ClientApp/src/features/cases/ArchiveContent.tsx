import React from 'react';
import { ArchivedDocument, CaseSource, getDocument } from '../../api/api';
import { TabState } from './CaseModal';

interface ArchiveContentProps {
  archiveState: TabState<ArchivedDocument[]>;
  caseSource: CaseSource;
  caseSourceId: string;
  date: string | undefined;
}

function getSecrecyText(object: any) {
  const { secrecy, otherSecrecy, pulPersonalSecrecy, unavailableDueToSecrecy } = object;
  if (unavailableDueToSecrecy)
    return <>Sekretess</>;
  const result = [secrecy, otherSecrecy, pulPersonalSecrecy].filter(x => !!Number(x)).join(", ");
  if (result.length > 0)
    return <span title={result}>Sekretess</span>;
  return null;
}

const formatDate = (date: Date | string | undefined, missingDate: string = '-') => {
  if (!date) {
    return missingDate;
  }
  return (new Date(date).toLocaleDateString('sv-SE'));
};

const ArchiveContent = ({ archiveState, caseSource, caseSourceId, date }: ArchiveContentProps) => {
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
          {archivedDocument.unavailableDueToSecrecy === false ? <>
            <div className="py-2">
              Beslutsdatum: {formatDate(date, 'Datum saknas')}
            </div>
            <ul className="list-group">
              {archivedDocument?.docs?.map(doc =>
                <li className="list-group-item">
                  {doc.unavailableDueToSecrecy === false ?
                    <>
                      <h5>{doc.title}</h5>
                      <ul>
                        {doc.files?.map(file =>
                          <li>
                            {file.unavailableDueToSecrecy === false ?
                              <span className="btn btn-link px-0" role="button" title={file.title} onClick={() => getDocument(file.physicalDocumentId, caseSource, caseSourceId)}>
                                {file.title}
                              </span>
                              :
                              <>{getSecrecyText(file)}</>
                            }
                          </li>
                        )}
                      </ul>
                    </>
                    :
                    <h5>{getSecrecyText(doc)}</h5>}
                </li>
              )}
            </ul>
          </> : getSecrecyText(archivedDocument)}
        </div>
      </div>
    </div>
  );
};

export default ArchiveContent;
