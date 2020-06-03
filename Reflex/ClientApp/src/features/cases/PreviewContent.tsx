import React, { Fragment } from 'react';
import { Preview as PreviewProps } from '../../api/api';
import styles from './Preview.module.css';

const PreviewContent = ({
  handelser,
  persons,
  fastighetsbeteckning,
  arendegrupp,
  arendetyp,
  arendeslag,
  dnr,
  status,
  handlaggareFornamn,
  handlaggareEfternamn,
  handlaggareSignatur
}: PreviewProps) => {
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
            {arendegrupp} {arendetyp} {arendeslag}
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
      {persons?.length > 0 && (<div className="row">
        <div className="col-12">
          <b>Intressenter</b>
        </div>
        {persons.map((person) =>
          <Fragment key={person.adress + person.fullName}>
            <div className="col-4">
              {person.fullName}
            </div>
            <div className="col-7">
              {person.adress} {person.fullName} {person.ort}
            </div>
            <div className="col-1">
              {person.roles &&
                <> {person.roles.join(', ')} </>
              }
            </div>
          </Fragment>
        )}
      </div>)
      }
      <div className="row" id="händelser">
        <div className="col-12">
          <b>Händelser</b>
        </div>
        {handelser?.length > 0 && handelser.map((handelse, i) => <Fragment key={i}>
          <div className="col-2 pr-0">
            {new Date(handelse.arrival).getFullYear()}-<wbr />{(new Date(handelse.arrival).getMonth() + 1).toString().padStart(2, '0')}-{(new Date(handelse.arrival).getDate()).toString().padStart(2, '0')}
          </div>
          <div className={"col-3 pr-0 " + styles.breakAll}>
            {handelse.handelsetyp}
          </div>
          <div className={"col-5 pr-0 " + styles.breakWord}>
            {handelse.title}
          </div>
          {handelse.beslutNr &&
            <div className={"col-2 pl-1 text-right " + styles.breakWord}>
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