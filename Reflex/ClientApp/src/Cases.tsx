import { faCheck } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import xor from 'lodash/xor';
import { useEffect, useState } from 'react';
import { ButtonGroup, Col, Dropdown, DropdownButton, Row } from 'react-bootstrap';
import { Case, CaseSource, CaseTab } from './api/api';
import { useAppSelector } from './app/hooks';
import CaseList from './features/cases/CaseList';
import CaseModal from './features/cases/CaseModal';

export interface ModalData {
  dnr: string;
  caseId: string;
  caseSource: CaseSource;
  diarieprefix?: string;
  title: string;
  caseSourceId: string;
  date: string | undefined;
  isConfidential: boolean;
  tabs?: CaseTab[];
}

type SortBy = 'TITLE_ASC' | 'TITLE_DESC' | 'DATE_ASC' | 'DATE_DESC' | 'DNR_ASC' | 'DNR_DESC';

function sortCases(filteredCases: Case[], sort: SortBy | undefined) {
  const collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  switch (sort) {
    case 'TITLE_ASC':
      return filteredCases.sort((a, b) => a.title.localeCompare(b.title));
    case 'TITLE_DESC':
      return filteredCases.sort((a, b) => b.title.localeCompare(a.title));
    case 'DATE_ASC':
      return filteredCases.sort((a, b) => {
        if (new Date(a.date) > new Date(b.date))
          return 1;
        if (new Date(a.date) < new Date(b.date))
          return -1;
        return 0;
      });
    case 'DATE_DESC':
      return filteredCases.sort((a, b) => {
        if (new Date(a.date) > new Date(b.date))
          return -1;
        if (new Date(a.date) < new Date(b.date))
          return 1;
        return 0;
      });
    case 'DNR_ASC':
      return filteredCases.sort((a, b) => collator.compare(a.dnr, b.dnr));
    case 'DNR_DESC':
      return filteredCases.sort((a, b) => collator.compare(b.dnr, a.dnr));
    default:
      return filteredCases;
  }
}

const Cases = () => {
  const cases = useAppSelector((state) => state.cases?.value);
  const loading = useAppSelector((state) => state.cases?.loading);
  const searchResult = useAppSelector((state) => state.searchResult);
  const [filteredCases, setFilteredCases] = useState<Case[]>(cases);
  const [sortBy, setSortBy] = useState<SortBy>();
  const [caseSourceFilter, setCaseSourceFilter] = useState<string[]>([]);
  const [statusFilter, setStatusFilter] = useState<string[]>([]);
  const [diarieprefixFilter, setDiarieprefixFilter] = useState<string[]>([]);
  const [casesWithoutMainDecisionFilter, setCasesWithoutMainDecisionFilter] = useState<boolean[]>([]);
  const [show, setShow] = useState(false);
  const toggleShow = () => setShow(!show);
  const [modalData, setModalData] = useState<ModalData>();
  const caseSources: CaseSource[] = [];
  const statuses: string[] = [];
  const casesWithoutMainDecision: boolean[] = [];
  const diarieprefixes: string[] = [];

  cases.forEach(c => {
    if (!caseSources.includes(c.caseSource))
      caseSources.push(c.caseSource);
    if (c?.status !== null && !statuses.includes(c.status))
      statuses.push(c.status);
    if (c?.caseWithoutMainDecision !== null && !casesWithoutMainDecision.includes(c.caseWithoutMainDecision))
      casesWithoutMainDecision.push(c.caseWithoutMainDecision);
    if (c?.diarieprefix !== null && !diarieprefixes.includes(c.diarieprefix))
      diarieprefixes.push(c.diarieprefix);
  });

  const handleCaseSourceFilter = (caseSource: CaseSource) => {
    setCaseSourceFilter(xor(caseSourceFilter, [caseSource]));
  };

  const handleStatusFilter = (status: string) => {
    setStatusFilter(xor(statusFilter, [status]));
  };

  const handleDiarieprefixFilter = (diarieprefix: string) => {
    setDiarieprefixFilter(xor(diarieprefixFilter, [diarieprefix]));
  };

  const handleCasesWithoutMainDecisionFilter = (caseWithoutMainDecision: boolean) => {
    setCasesWithoutMainDecisionFilter(xor(casesWithoutMainDecisionFilter, [caseWithoutMainDecision]));
  };

  useEffect(() => {
    const sortedCases = cases.filter(x => (caseSourceFilter.length === 0 || caseSourceFilter.includes(x.caseSource))
      && (statusFilter.length === 0 || statusFilter.includes(x.status))
      && (diarieprefixFilter.length === 0 || diarieprefixFilter.includes(x.diarieprefix))
      && (casesWithoutMainDecisionFilter.length === 0 || casesWithoutMainDecisionFilter.includes(x.caseWithoutMainDecision)));
    setFilteredCases(sortCases(sortedCases, sortBy));
  }, [cases, caseSourceFilter, statusFilter, casesWithoutMainDecisionFilter, diarieprefixFilter, sortBy]);

  return (
    <>
      <h5>
        {{
          'Ärende': <div>Visar ärende {searchResult.displayName}</div>,
          'Fastighet': <div>Ärenden för: {searchResult.displayName}</div>,
          'Adress': <div>Ärenden för: {searchResult.displayName}</div>
        }[searchResult.type!] || <div>Inget objekt valt</div>}
      </h5>
      {cases?.length > 0 &&
        <Row>
          <Col>
            <ButtonGroup>
              <DropdownButton variant="outline-secondary"
                autoClose="outside"
                title={<>Ärendekällor {(caseSourceFilter.length > 0) && <span className="badge text-bg-secondary">{caseSourceFilter.length}</span>}</>}
                className="pe-2"
              >
                <Dropdown.Item disabled={!caseSources.includes(CaseSource.Ecos)} className="d-flex justify-content-between" onClick={() => handleCaseSourceFilter(CaseSource.Ecos)}>Ecos {caseSourceFilter.includes(CaseSource.Ecos) && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                <Dropdown.Item disabled={!caseSources.includes(CaseSource.ByggR)} className="d-flex justify-content-between" onClick={() => handleCaseSourceFilter(CaseSource.ByggR)}>ByggR {caseSourceFilter.includes(CaseSource.ByggR) && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                <Dropdown.Item disabled={!caseSources.includes(CaseSource.AGS)} className="d-flex justify-content-between" onClick={() => handleCaseSourceFilter(CaseSource.AGS)}>AGS {caseSourceFilter.includes(CaseSource.AGS) && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                <Dropdown.Item disabled={!caseSources.includes(CaseSource.iipax)} className="d-flex justify-content-between" onClick={() => handleCaseSourceFilter(CaseSource.iipax)}>iipax {caseSourceFilter.includes(CaseSource.iipax) && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
              </DropdownButton>
              {statuses.length > 0 && <DropdownButton variant="outline-secondary"
                autoClose="outside"
                title={<>Status {(statusFilter.length > 0) && <span className="badge text-bg-secondary">{statusFilter.length}</span>}</>}
                className="pe-2"
              >
                <Dropdown.Item className="d-flex justify-content-between" onClick={() => handleStatusFilter('Pågående')}>Pågående {statusFilter.includes('Pågående') && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                <Dropdown.Item className="d-flex justify-content-between" onClick={() => handleStatusFilter('Avslutat')}>Avslutat {statusFilter.includes('Avslutat') && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
              </DropdownButton>}
              {diarieprefixes.length > 0 && <DropdownButton variant="outline-secondary"
                autoClose="outside"
                title={<>Diarier {(diarieprefixFilter.length > 0) && <span className="badge text-bg-secondary">{diarieprefixFilter.length}</span>}</>}
                className="pe-2"
              >
                {diarieprefixes.map(x => <Dropdown.Item className="d-flex justify-content-between" onClick={() => handleDiarieprefixFilter(x)}>{x} {diarieprefixFilter.includes(x) && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>)}
              </DropdownButton>}
              {casesWithoutMainDecision.length > 0 &&
                <DropdownButton variant="outline-secondary"
                  autoClose="outside"
                  title={<>Huvudbeslut {(casesWithoutMainDecisionFilter.length > 0) && <span className="badge text-bg-secondary">{casesWithoutMainDecisionFilter.length}</span>}</>}
                  className="pe-2"
                >
                  <Dropdown.Item className="d-flex justify-content-between" onClick={() => handleCasesWithoutMainDecisionFilter(true)}>Ärenden med huvudbeslut {casesWithoutMainDecisionFilter.includes(true) && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                  <Dropdown.Item className="d-flex justify-content-between" onClick={() => handleCasesWithoutMainDecisionFilter(false)}>Ärenden utan huvudbeslut {casesWithoutMainDecisionFilter.includes(false) && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                </DropdownButton>}
            </ButtonGroup>
          </Col>
          <Col>
            <ButtonGroup className="float-end">
              <DropdownButton title="Sortera" variant="outline-secondary">
                <Dropdown.Item className="d-flex justify-content-between" onClick={() => (setSortBy('TITLE_ASC'))} >Titel stigande {sortBy === 'TITLE_ASC' && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                <Dropdown.Item className="d-flex justify-content-between" onClick={() => (setSortBy('TITLE_DESC'))} >Titel fallande {sortBy === 'TITLE_DESC' && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                {/* <Dropdown.Item className="d-flex justify-content-between" onClick={() => (setSortBy('DATE_ASC'))} >Datum stigande {sortBy === 'DATE_ASC' && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                <Dropdown.Item className="d-flex justify-content-between" onClick={() => (setSortBy('DATE_DESC'))} >Datum fallande {sortBy === 'DATE_DESC' && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item> */}
                <Dropdown.Item className="d-flex justify-content-between" onClick={() => (setSortBy('DNR_ASC'))} >DNR stigande {sortBy === 'DNR_ASC' && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
                <Dropdown.Item className="d-flex justify-content-between" onClick={() => (setSortBy('DNR_DESC'))} >DNR fallande {sortBy === 'DNR_DESC' && <FontAwesomeIcon icon={faCheck} />}</Dropdown.Item>
              </DropdownButton>
            </ButtonGroup>
          </Col>
        </Row>
      }
      <div className="mt-2">
        {loading ? 'Hämtar ärenden...' :
          (filteredCases && filteredCases.length > 0) && <CaseList setModalData={setModalData} cases={filteredCases} toggleShow={toggleShow} />}
      </div>
      {(show && modalData) && <CaseModal show={show} modalData={modalData} toggleShow={toggleShow} />}
    </>
  );
};

export default Cases;
