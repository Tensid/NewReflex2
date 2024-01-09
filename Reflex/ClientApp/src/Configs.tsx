import { MouseEvent, useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Config, getConfigs, getContact } from './api/api';
import { useAppSelector } from './app/hooks';
import ConfigList from './features/configs/ConfigList';
import { useHasPermissions } from './hooks/useHasPermissions';

interface Contact {
  body: string;
  email: string;
  subject: string;
}

const Configs = () => {
  const { push } = useHistory();
  const roles = useAppSelector((state) => state.user?.roles);
  // const isAdministrator: boolean = hasPermission('IsAdministrator');
  const isAdmin = useHasPermissions('IsAdministrator');
  const [configs, setConfigs] = useState<Config[]>();
  const [contact, setContact] = useState<Contact>({
    body: '',
    email: '',
    subject: ''
  });

  useEffect(() => {
    (async () => {
      setConfigs(await getConfigs() || []);
      setContact(await getContact());
    })();
  }, []);

  function handleClick(e: MouseEvent<HTMLAnchorElement>) {
    e.preventDefault();
    push('/reflex/manage-configs');
  };

  if (!configs)
    return null;

  return (
    <>
      {(configs.length === 0) ?
        isAdmin ?
          <h5 className="text-center">
            <a href="/manage-configs" onClick={handleClick}>Skapa</a> en konfiguration för att fortsätta.
          </h5>
          :
          <h5 className="text-center">
            Konfiguration saknas. Klicka <a title={contact.email} href={`mailto:${contact.email}?subject=${contact.subject}&body=${encodeURIComponent(contact.body)}`}>här</a> och skicka mejl om du vill ha behörighet.
          </h5>
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
