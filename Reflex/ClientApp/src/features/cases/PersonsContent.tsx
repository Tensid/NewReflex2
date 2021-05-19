import React from 'react';
import { CasePerson } from '../../api/api';
import { TabState } from './CaseModal';

interface PersonsContentProps {
  personsState: TabState<CasePerson[]>;
}

const PersonsContent = ({ personsState }: PersonsContentProps) => {
  if (personsState.error)
    return <>Kunde inte hämta intressenter kopplade till ärendet.</>;
  if (personsState.loading)
    return <>Laddar intressenter...</>;
  if (!personsState?.value)
    return null;
  const persons = personsState.value;
  return (
    <div className="container">
      <div className="row">
        <div className="col-12">
          {persons?.length > 0 ?
            <>
              <div className="py-2">
                <h5>Intressenter</h5>
              </div>
              {persons.map((person) =>
                <ul>
                  <li>
                    {person.fullName} {person?.roles?.length > 0 && person.roles.join(', ')}
                    <ul>
                      {person?.communication?.length > 0 && person.communication.map((communication) =>
                        <li>{communication}</li>)
                      }
                    </ul>
                  </li>
                </ul>)}
            </>
            :
            <div className="py-2">
              <h5>Inga intressenter kopplade till ärendet.</h5>
            </div>
          }
        </div>
      </div>
    </div>
  );
};
export default PersonsContent;
