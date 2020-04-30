import React from 'react';
import { IconDefinition, faArchive, faBug, faHammer } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { CaseSource, getArchivedDocuments, getCasePersons, getOccurences, getPreview } from '../../api/api';
import styles from './Cases.module.css';

interface CaseItemProps {
  dnr: string;
  title: string;
  caseSource: CaseSource;
  toggleShow: () => void;
  setModalData: (modalData: any) => void;
  caseId: string;
}

const CaseItem = ({ dnr, title, caseSource, toggleShow, setModalData, caseId }: CaseItemProps) => {
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

  async function handleClick() {
    const [preview, occurences, persons, documents] = await Promise.allSettled([
      caseSource === CaseSource.ByggR ? getPreview(caseSource === CaseSource.ByggR ? dnr : caseId, caseSource) : null,
      caseSource === CaseSource.ByggR || caseSource === CaseSource.Ecos ? getOccurences(caseSource === CaseSource.ByggR ? dnr : caseId, caseSource) : null,
      caseSource === CaseSource.ByggR ? getCasePersons(caseSource === CaseSource.ByggR ? dnr : caseId, caseSource) : null,
      caseSource === CaseSource.AGS ? getArchivedDocuments(caseId, caseSource) : null
    ]);

    setModalData({
      caseId: caseId, dnr: dnr, title: title, caseSource: caseSource, occurences: (occurences as any).value, preview: (preview as any).value, archivedDocuments: (documents as any)?.value,
      persons: (persons as any).value
    });
    toggleShow();
  }

  return (
    <div className="row align-items-center">
      <div className="col-lg-12">
        <button className={`btn btn-outline-${color} btn-block text-left mb-1 ${styles.blackOutline} ${styles.btn}`} onClick={() => handleClick()}>
          <span className={`${styles.caseSymbol} pr-2 text-${color}`}><FontAwesomeIcon icon={symbol!} /></span>
          {dnr}: {title}
        </button>
      </div>
    </div>
  );
};

export default CaseItem;
