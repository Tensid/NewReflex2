import React from 'react';
import { IconDefinition, faArchive, faBug, faHammer, faLock } from '@fortawesome/free-solid-svg-icons';
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
  caseSourceId: string;
  date: string;
  unavailableDueToSecrecy: boolean;
}

const CaseItem = ({ dnr, title, status, caseSource, toggleShow, setModalData, caseId, caseSourceId, date, unavailableDueToSecrecy }: CaseItemProps) => {
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
  if (caseSource === CaseSource.iipax) {
    color = 'warning';
    symbol = faArchive;
  }

  function handleClick() {
    setModalData({ dnr, caseId, caseSource, title, caseSourceId, date });
    toggleShow();
  }

  return (
    <div className="row align-items-center">
      <div className="col-lg-12">
        <button disabled={unavailableDueToSecrecy} className={`btn btn-outline-${color} btn-block text-left mb-1 ${styles.blackOutline} ${styles.btn}`} onClick={() => handleClick()}>
          <span className={`${unavailableDueToSecrecy ? '' : styles.caseSymbol} pr-2 text-${color}`}><FontAwesomeIcon icon={symbol!} /></span>
          {dnr}: {title}{status ? ` (${status})` : ''}
          <FontAwesomeIcon title="Sekretess" icon={faLock} />
        </button>
      </div>
    </div>
  );
};

export default CaseItem;
