import { ArchivedDocument, CaseSource, getDocument } from '../../api/api';
import { TabState } from './CaseModal';
import Lock from './Lock';

interface ArchiveContentProps {
  archiveState: TabState<ArchivedDocument[]>;
  caseSource: CaseSource;
  caseSourceId: string;
  date: string | undefined;
}

function isConfidential(object: any) {
  const { secrecy, otherSecrecy, pulPersonalSecrecy, unavailableDueToSecrecy } = object;
  const result = [secrecy, otherSecrecy, pulPersonalSecrecy].filter(x => !!Number(x));
  return result.length > 0;
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
              Beslutsdatum: {formatDate(date, 'Datum saknas')}<Lock show={isConfidential(archivedDocument)} title="Skyddat" />
            </div>
            <ul className="list-group">
              {archivedDocument?.docs?.map(doc =>
                <li className="list-group-item">
                  {doc.unavailableDueToSecrecy === false ?
                    <>
                      <h5>{doc.title} <Lock show={isConfidential(doc)} title="Skyddat" /></h5>
                      <ul>
                        {doc.files?.map(file =>
                          <li>
                            {file.unavailableDueToSecrecy === false ?
                              <>
                                <span className="btn btn-link px-0" role="button" title={file.title} onClick={() => getDocument(file.physicalDocumentId, caseSource, caseSourceId)}>
                                  {file.title}
                                </span>
                              </>
                              :
                              <>Sekretess</>
                            }
                            <Lock show={isConfidential(file)} title="Skyddat" />
                          </li>
                        )}
                      </ul>
                    </>
                    :
                    <h5>Sekretess</h5>}
                </li>
              )}
            </ul>
          </> : <>Sekretess<Lock show={isConfidential(archivedDocument)} title="Skyddat" /></>}
        </div>
      </div>
    </div>
  );
};

export default ArchiveContent;
