import React from 'react';
import { Accordion, Card } from 'react-bootstrap';
import { CaseSource, Occurence } from '../../api/api';

function occurenceText(occurence: Occurence) {
  let occurenceText = '';
  if (occurence.isSecret)
    occurenceText = ' (Sekretessbelagd händelse)';
  else {
    if (occurence.documents != null && occurence.documents.length > 0) {
      let availableDocuments = 0;
      occurence.documents.forEach(doc => {
        if (doc.docLinkId != null && doc.docLinkId !== '0' && doc.docLinkId !== '-1')
          availableDocuments++;
      });
      occurenceText = ` (${occurence.documents.length} ${occurence.documents.length === 1 ? 'handling' : 'handlingar'} varav ${availableDocuments} ${availableDocuments === 1 ? 'tillgänglig' : 'tillgängliga'})`;
    }
  }
  return occurenceText;
}

const OccurenceContent = ({ occurences, caseSource }: { occurences: Occurence[], caseSource: CaseSource }) => {
  return (
    <div className="row">
      <div className="col">
        <div className="py-2">
          <h5>Händelser</h5>
        </div>
        <Accordion>
          {occurences?.map((occurence, i) =>
            <div className="card" key={i}>
              <Accordion.Toggle as={Card.Header} className="p-1" eventKey={i.toString()} >
                <h5 className="mb-0">
                  <button className="btn btn-link collapsed text-left"><i className="fa"></i> {new Date(occurence.arrival).toLocaleDateString()}: {`${occurence.title} ${occurenceText(occurence)}`}</button>
                </h5>
              </Accordion.Toggle>
              <Accordion.Collapse eventKey={i.toString()}>
                <div className="card-body">
                  <ul className="mb-0">
                    {occurence.documents?.length > 0 ?
                      occurence.documents.map((doc) => {
                        return (
                          <li>
                            {doc?.docLinkId === '-1' ?
                              <>{doc.title}</>
                              :
                              <a href={`cases/document?docId=${doc.docLinkId}&caseSource=${caseSource}`}>
                                {doc.title}
                              </a>
                            }
                          </li>
                        );
                      })
                      :
                      occurence.isSecret ? 'Sekretessbelagt' : 'Inga handlingar kopplade till händelsen.'
                    }
                  </ul>
                </div>
              </Accordion.Collapse>
            </div>
          )}
        </Accordion>
      </div>
    </div>
  );
};

export default OccurenceContent;