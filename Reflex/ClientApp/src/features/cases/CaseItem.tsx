import { IconDefinition, faArchive, faBug, faHammer } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { ModalData } from '../../Cases';
import { CaseSource, CaseTab } from '../../api/api';
import styles from './Cases.module.css';
import Lock from './Lock';

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
  isConfidential: boolean;
  unavailableDueToSecrecy: boolean;
  tabs: CaseTab[];
  diarieprefix?: string;
}

function formatDnr(dnr: string, diarieprefix: string | undefined, caseSource: string) {
  const inputString = dnr;
  const parts = inputString.split(' ');

  if (parts.length > 0 && caseSource === CaseSource.ByggR) {
    const firstPart = parts[0];
    if (diarieprefix !== firstPart)
      return <span title={`Diarie: ${diarieprefix}`}>{dnr}</span>;
  }
  return dnr;
}

const CaseItem = ({ dnr, title, status, caseSource, toggleShow, setModalData, caseId, caseSourceId, date, isConfidential, unavailableDueToSecrecy, tabs, diarieprefix }: CaseItemProps) => {
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
    setModalData({ dnr, caseId, caseSource, title, caseSourceId, date, tabs, diarieprefix, isConfidential });
    toggleShow();
  }

  return (
    <div className="row align-items-center">
      <div className="col-lg-12 d-grid">
        <button disabled={unavailableDueToSecrecy} className={`btn btn-outline-${color} text-start mb-1 ${styles.blackOutline} ${styles.btn}`} onClick={handleClick}>
          <span className={`${unavailableDueToSecrecy ? '' : styles.caseSymbol} pe-2 text-${color}`}><FontAwesomeIcon icon={symbol!} /></span>
          {formatDnr(dnr, diarieprefix, caseSource)}: {title}{status ? ` (${status})` : ''}
          <Lock show={isConfidential} title="Ärendet är sekretessmarkerat" />
        </button>
      </div>
    </div>
  );
};

export default CaseItem;
