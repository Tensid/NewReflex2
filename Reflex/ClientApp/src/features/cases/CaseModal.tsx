import React from 'react';
import { Modal } from "react-bootstrap";
import AgsCaseContent from './AgsCaseContent';
import ByggrCaseContent from './ByggrCaseContent';
import EcosCaseContent from './EcosCaseContent';
import { ArchivedDocument, CasePerson, CaseSource, Occurence, Preview } from '../../api/api';

interface CaseProps {
  dnr: string;
  caseSource: CaseSource;
  title: string;
  occurences: Occurence[];
  persons: CasePerson[];
  archivedDocuments: ArchivedDocument[];
  preview: Preview;
  show: boolean;
  toggleShow: () => void;
}

const CaseModal = ({ dnr, caseSource, title, show, toggleShow, occurences, persons, archivedDocuments, preview }: CaseProps) => {
  return (
    <Modal show={show} onHide={toggleShow} size="xl">
      <Modal.Header closeButton>
        <Modal.Title>{dnr}: {title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <div className="modal-body" title={`${dnr}: ${title}`}>
          <div className="container-fluid px-0">
            {caseSource === CaseSource.AGS && <AgsCaseContent caseSource={caseSource} archivedDocuments={archivedDocuments}></AgsCaseContent>}
            {caseSource === CaseSource.ByggR && <ByggrCaseContent caseSource={caseSource} occurences={occurences} preview={preview} dnr={dnr} persons={persons}></ByggrCaseContent>}
            {caseSource === CaseSource.Ecos && <EcosCaseContent caseSource={caseSource} occurences={occurences}></EcosCaseContent>}
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
