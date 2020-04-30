import React from 'react';
import { ArchivedDocument, CaseSource } from '../../api/api';

interface ArchiveContentProps {
  archivedDocuments: ArchivedDocument[];
  caseSource: CaseSource;
}

const ArchiveContent = ({ archivedDocuments, caseSource }: ArchiveContentProps) => {
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
