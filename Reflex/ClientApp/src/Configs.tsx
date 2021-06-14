import React, { MouseEvent, useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Config, ReflexUser, getConfigs, getContact, getCurrentUser } from './api/api';
import ConfigList from './features/configs/ConfigList';

interface Contact {
  body: string;
  email: string;
  subject: string;
}

const Configs = () => {
  const { push } = useHistory();
  const [configs, setConfigs] = useState<Config[]>();
  const [user, setUser] = useState<ReflexUser>();
  const [contact, setContact] = useState<Contact>({
    body: '',
    email: '',
    subject: ''
  });

  useEffect(() => {
    (async () => {
      setConfigs(await getConfigs() || []);
      setContact(await getContact());
      setUser(await getCurrentUser());
    })();
  }, []);

  function handleClick(e: MouseEvent<HTMLAnchorElement>) {
    e.preventDefault();
    push('/manage-configs');
  };

  if (!user || !configs)
    return null;

  return (
    <>
      {(configs.length === 0) ?
        user?.roles.includes('Admin') ?
          <h5 className="text-center">
            <a href="/manage-configs" onClick={handleClick}>Skapa</a> en konfiguration för att fortsätta.
          </h5>
          :
          <>
            <h5 className="text-center">Konfiguration saknas. Kontakta en administratör för att få tillgång till konfigurationerna.</h5>
            <div className="row d-flex justify-content-center">
              <a href={`mailto:${contact.email}?subject=${contact.subject}&body=${contact.body}`}>{contact.email}</a>
            </div>
          </>
        :
        <>
          <h5>Välj konfiguration</h5>
          <ConfigList configs={configs} />
        </>
      }
    </>
  );
};

export default Configs;
