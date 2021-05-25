import React from 'react';
import { IconDefinition, faArchive, faBug, faHammer } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { ModalData } from '../../Cases';
import { CaseSource } from '../../api/api';
import styles from './Cases.module.css';

interface CaseItemProps {
  dnr: string;
  title: string;
  caseSource: CaseSource;
  toggleShow: () => void;
  setModalData: (modalData: ModalData) => void;
  caseId: string;
  status: string;
}

const CaseItem = ({ dnr, title, caseSource, toggleShow, setModalData, caseId, status }: CaseItemProps) => {
  let color = 'secondary';
  let symbol: IconDefinition;
  if (caseSource === CaseSource.Ecos) {
    color = 'success';
    symbol = faBug;
  }
  if (caseSource === CaseSource.ByggR) {
    color = 'info';
    symbol = faHammer;
  }
  if (caseSource === CaseSource.AGS) {
    color = 'warning';
    symbol = faArchive;
  }

  function handleClick() {
    setModalData({ dnr, caseId, caseSource, title });
    toggleShow();
  }

  return (
    <div className="row align-items-center">
      <div className="col-lg-12">
        <button className={`btn btn-outline-${color} btn-block text-left mb-1 ${styles.blackOutline} ${styles.btn}`} onClick={() => handleClick()}>
          <span className={`${styles.caseSymbol} pr-2 text-${color}`}><FontAwesomeIcon icon={symbol!} /></span>
          {dnr}: {title}{status ? ` (${status})` : ''}
        </button>
      </div>
    </div>
  );
};

export default CaseItem;
