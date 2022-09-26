import { faLock } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { useAccordionButton } from 'react-bootstrap';
import Accordion from 'react-bootstrap/Accordion';
import Card from 'react-bootstrap/Card';
import { CaseSource, Occurence, getDocument } from '../../api/api';
import { TabState } from './CaseModal';

function occurenceText(occurence: Occurence) {
  let occurenceText = '';
  if (occurence.isSecret)
    occurenceText = ' (Sekretessmarkerad händelse)';
  else {
    if (occurence.documents != null && occurence.documents.length > 0) {
      let availableDocuments = 0;
      occurence.documents.forEach(doc => {
        if (doc.docLinkId != null && doc.docLinkId !== '0' && doc.docLinkId !== '-1')
          availableDocuments++;
      });
      occurenceText = ` (${occurence.documents.length} ${occurence.documents.length === 1 ? 'handling' : 'handlingar'} varav ${availableDocuments} ${availableDocuments === 1 ? 'tillgänglig' : 'tillgängliga'})`;
      if (occurence.isWorkingMaterial) {
        occurenceText += ' (Arbetsmaterial)';
      }
    }
  }
  return occurenceText;
}

interface OccurenceContentProps {
  occurenceState: TabState<Occurence[]>;
  caseSource: CaseSource;
  caseSourceId: string;
}

function CustomToggle({ children, eventKey }: any) {
  const decoratedOnClick = useAccordionButton(eventKey);

  return (
    <Card.Header className="p-1" onClick={decoratedOnClick}>
      <button
        type="button"
        className="btn btn-link collapsed text-start text-decoration-none"
      >
        {children}
      </button>
    </Card.Header>
  );
}

const OccurenceContent = ({ occurenceState, caseSource, caseSourceId }: OccurenceContentProps) => {
  if (occurenceState.error)
    return <>Kunde inte hämta händelser kopplade till ärendet.</>;
  if (occurenceState.loading)
    return <>Laddar händelser...</>;
  return (
    <div className="row">
      <div className="col">
        <Accordion flush>
          {occurenceState.value?.map((occurence, i) =>
            <Card className={"list-group-flush"} key={i}>
              <CustomToggle eventKey={i.toString()}>
                {new Date(occurence.arrival).toLocaleDateString()}: {`${occurence.title} ${occurenceText(occurence)}`}
              </CustomToggle>
              <Accordion.Collapse eventKey={i.toString()}>
                <Card.Body>
                  <ul className="mb-0">
                    {occurence.documents?.length > 0 ?
                      occurence.documents.map((doc) => {
                        return (
                          <li>
                            {doc?.docLinkId === '-1' ?
                              <>{doc.title}</>
                              :
                              <span className="btn btn-link px-0" role="button" onClick={() => getDocument(doc.docLinkId, caseSource, caseSourceId)}>
                                {doc.title}
                              </span>
                            }
                            {doc.isConfidential && <FontAwesomeIcon title="Handlingen är sekretessmarkerad" icon={faLock} />}
                          </li>
                        );
                      })
                      :
                      occurence.isSecret ? 'Sekretess' : 'Inga handlingar kopplade till händelsen.'
                    }
                  </ul>
                </Card.Body>
              </Accordion.Collapse>
            </Card>
          )}
        </Accordion>
      </div>
    </div>
  );
};

export default OccurenceContent;
