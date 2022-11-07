import { Fragment } from 'react';
import { CaseTab, Preview } from '../../api/api';
import { TabState } from './CaseModal';
import styles from './Preview.module.css';

interface PreviewContentProps {
  previewState: TabState<Preview>;
  tabs: CaseTab[];
}

const PreviewContent = ({ previewState, tabs }: PreviewContentProps) => {
  if (previewState.error)
    return <>Kunde inte hämta förhandsgranskning för ärendet.</>;
  if (previewState.loading)
    return <>Laddar händelser...</>;
  if (!previewState?.value)
    return null;
  const
    {
      handelser,
      persons,
      fastighetsbeteckning,
      dnr,
      status,
      handlaggareFornamn,
      handlaggareEfternamn,
      handlaggareSignatur
    } = previewState.value;

  return (
    <>
      <div className="row">
        <div className="col-12">
          <p><b>{dnr} {fastighetsbeteckning}</b> <small><b>({status})</b></small></p>
        </div>
      </div>
      <div className="row">
        <div className="col-12">
          <p>
            <b>Huvudhandläggare</b>
            <br />
            {handlaggareFornamn} {handlaggareEfternamn} {handlaggareSignatur && <>({handlaggareSignatur})</>}
          </p>
        </div>
      </div>
      <div className="row">
        <div className="col-12">
          <p>
            <b>Objekt</b>
            <br />
            {fastighetsbeteckning}
          </p>
        </div>
      </div>
      {(persons?.length > 0 && tabs.includes('Persons')) && (
        <div className="row">
          <div className="col-12">
            <b>Intressenter</b>
          </div>
          {persons.map((person) =>
            <div className="row" key={person.adress + person.fullName}>
              <div className="col-4">
                {person.fullName}
              </div>
              <div className="col-5">
                {person.adress} {person.postNr} {person.ort}
              </div>
              <div className="col-3 text-end">
                {person.roles &&
                  <> {person.roles.join(', ')} </>
                }
              </div>
            </div>
          )}
        </div>
      )}
      <div className="row" id="händelser">
        <div className="col-12">
          <b>Händelser</b>
        </div>
        {handelser?.length > 0 && handelser.map((handelse, i) => <Fragment key={i}>
          <div className="col-2 pe-0">
            {new Date(handelse.arrival).getFullYear()}-<wbr />{(new Date(handelse.arrival).getMonth() + 1).toString().padStart(2, '0')}-{(new Date(handelse.arrival).getDate()).toString().padStart(2, '0')}
          </div>
          <div className={"col-3 pe-0 " + styles.breakAll}>
            {handelse.handelsetyp}
          </div>
          <div className={"col-5 pe-0 " + styles.breakWord}>
            {handelse.title}
          </div>
          {handelse.beslutNr &&
            <div className={"col-2 ps-1 text-end " + styles.breakWord}>
              (nr: {handelse.beslutNr})
            </div>
          }
          <div className="col-10 offset-2">
            <div className={styles.preWrap}><i>{handelse.anteckning}</i></div>
          </div>
          {handelse?.documents.length > 0 &&
            <div className="col-10 offset-2">
              <u>Handlingar</u>
              <br />
              {handelse.documents.map((doc, j) =>
                <Fragment key={j}>
                  {doc.title}
                  <br />
                </Fragment>
              )}
            </div>
          }
          <hr className={styles.horizontalRule} />
        </Fragment>
        )}
      </div>
    </>
  );
};
export default PreviewContent;
