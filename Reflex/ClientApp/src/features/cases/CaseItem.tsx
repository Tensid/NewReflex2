import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBug, faHammer, faArchive, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import styles from './Cases.module.css';
import { CaseSource } from '../../api/api';

interface CaseItemProps {
  dnr: string;
  title: string;
  caseSource: CaseSource;
}

const CaseItem = ({ dnr, title, caseSource }: CaseItemProps) => {
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

  return (
    <div className={'row align-items-center'}>
      <div className="col-lg-12">
        <button className={`btn btn-outline-${color} btn-block text-left mb-1 ${styles.blackOutline} ${styles.btn}`}>
          <span className={`${styles.caseSymbol} pr-2 text-${color}`}><FontAwesomeIcon icon={symbol!} /></span>
          {dnr}: {title}
        </button>
      </div>
    </div>
  );
};

export default CaseItem;
