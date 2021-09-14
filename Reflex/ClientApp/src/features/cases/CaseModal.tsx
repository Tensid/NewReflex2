import React, { useEffect, useState } from 'react';
import { Modal, Tab, Tabs } from 'react-bootstrap';
import { ModalData } from '../../Cases';
import { ArchivedDocument, CasePerson, CaseSource, CaseTab, Occurence, Preview, getArchivedDocuments, getCasePersons, getOccurences, getPreview } from '../../api/api';
import Archive from './ArchiveContent';
import OccurenceContent from './OccurenceContent';
import PersonsContent from './PersonsContent';
import PreviewContent from './PreviewContent';

interface CaseProps {
  show: boolean;
  toggleShow: () => void;
  modalData: ModalData;
}

export interface TabState<T> {
  value: T | undefined;
  loading: boolean;
  error: string | undefined;
  tab?: CaseTab;
}

const initTabState = { value: undefined, loading: false, error: undefined };

const availableCaseDetailsTabs = new Map<CaseSource, CaseTab[]>();
availableCaseDetailsTabs.set(CaseSource.AGS, ['Archive']);
availableCaseDetailsTabs.set(CaseSource.ByggR, ['Preview', 'Occurences', 'Persons']);
availableCaseDetailsTabs.set(CaseSource.Ecos, ['Occurences']);
availableCaseDetailsTabs.set(CaseSource.iipax, ['Archive']);

const mappedCaseTabs = new Map<CaseTab, string>();
mappedCaseTabs.set('Preview', 'Förhandsgranskning');
mappedCaseTabs.set('Occurences', 'Händelser');
mappedCaseTabs.set('Persons', 'Intressenter');
mappedCaseTabs.set('Archive', 'Arkiverade handlingar');

function fetchTabData(setTabState: (tabState: TabState<any>) => void, tabData: any, fetchFunction: () => any) {
  (async () => {
    try {
      setTabState({ value: undefined, loading: true, error: undefined });
      const result = await fetchFunction();
      setTabState({ value: result, loading: false, error: undefined });
    }
    catch (e) {
      setTabState({ value: undefined, loading: false, error: e });
    }
  })();
}

const CaseModal = ({ show, toggleShow, modalData }: CaseProps) => {
  const [previewData, setPreview] = useState<TabState<Preview>>({ ...initTabState, tab: 'Preview' });
  const [occurencesData, setOccurences] = useState<TabState<Occurence[]>>({ ...initTabState, tab: 'Occurences' });
  const [personsData, setPersons] = useState<TabState<CasePerson[]>>({ ...initTabState, tab: 'Persons' });
  const [archivedDocumentsData, setArchivedDocuments] = useState<TabState<ArchivedDocument[]>>({ ...initTabState, tab: 'Archive' });
  const { caseSource, dnr, caseId, title, caseSourceId } = modalData;

  const availableTabs = availableCaseDetailsTabs.get(caseSource)!;

  useEffect(() => {
    const id = caseSource === 'ByggR' ? dnr : caseId;
    availableTabs.forEach((tab) => {
      if (tab === 'Preview')
        fetchTabData(setPreview, previewData, () => getPreview(id, caseSource, caseSourceId));
      if (tab === 'Occurences')
        fetchTabData(setOccurences, occurencesData, () => getOccurences(id, caseSource, caseSourceId));
      if (tab === 'Persons')
        fetchTabData(setPersons, personsData, () => getCasePersons(id, caseSource, caseSourceId));
      if (tab === 'Archive')
        fetchTabData(setArchivedDocuments, archivedDocumentsData, () => getArchivedDocuments(id, caseSource, caseSourceId));
    });
  }, [dnr, caseSource]);

  return (
    <Modal show={show} onHide={toggleShow} size="xl">
      <Modal.Header closeButton>
        <Modal.Title>{dnr}: {title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <div className="modal-body" title={`${dnr}: ${title}`}>
          <div className="container-fluid px-0">
            {availableTabs!.length === 1 && <>
              <h3>
                {mappedCaseTabs.get(availableTabs![0])}
              </h3>
              {{
                'Preview': <PreviewContent previewState={previewData} />,
                'Occurences': <OccurenceContent occurenceState={occurencesData} caseSource={caseSource} caseSourceId={caseSourceId} />,
                'Persons': <PersonsContent personsState={personsData} />,
                'Archive': <Archive archiveState={archivedDocumentsData} caseSource={caseSource} caseSourceId={caseSourceId} />
              }[availableTabs![0]]}
            </>}
            {availableTabs!.length > 1 &&
              <Tabs defaultActiveKey={availableTabs![0]} variant="pills">
                {availableTabs.map((tab, i) => {
                  if (availableTabs[i] === 'Preview')
                    return (
                      <Tab eventKey={tab} title="Förhandsgranskning">
                        <PreviewContent previewState={previewData} />
                      </Tab>);
                  if (availableTabs[i] === 'Occurences')
                    return (
                      <Tab eventKey={tab} title="Händelser">
                        <OccurenceContent occurenceState={occurencesData} caseSource={caseSource} caseSourceId={caseSourceId} />
                      </Tab>);
                  if (availableTabs[i] === 'Persons')
                    return (
                      <Tab eventKey={tab} title="Intressenter">
                        <PersonsContent personsState={personsData} />
                      </Tab>);
                  if (availableTabs[i] === 'Archive')
                    return (
                      <Tab eventKey={tab} title="Intressenter">
                        <Archive archiveState={archivedDocumentsData} caseSource={caseSource} caseSourceId={caseSourceId} />
                      </Tab>);
                })}
              </Tabs>
            }
          </div>
        </div>
      </Modal.Body>
      <Modal.Footer>
        <button type="button" className="btn btn-primary" onClick={toggleShow}>Stäng</button>
      </Modal.Footer>
    </Modal>
  );
};

export default CaseModal;
