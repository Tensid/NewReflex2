import { NavbarTopIcon } from '@sokigo-sbwebb/default-components';
import { useState } from 'react';
import { faUserCog } from '@fortawesome/pro-solid-svg-icons';
import UserSettingsModal from '../../features/user-settings/UserSettingsModal';

export function UserSettings({ expanded }: { expanded: boolean }) {
  const [show, setShow] = useState(false);

  return (
    <>
      {expanded ? (
        <div style={{ height: 40 }}>
          <NavbarTopIcon
            block
            title="Personliga inställningar"
            expanded={expanded}
            icon={faUserCog}
            onClick={() => setShow(true)}
            aria-label="Personliga inställningar"
          />
          {show && <UserSettingsModal setShow={setShow} />}
        </div>
      ) : (
        <>
          <NavbarTopIcon
            title="Personliga inställningar"
            expanded={expanded}
            icon={faUserCog}
            onClick={() => setShow(true)}
            aria-label="Personliga inställningar"
          />
          {show && (
            <UserSettingsModal
              setShow={setShow}
            />
          )}
        </>
      )}
    </>
  );
}

export default UserSettings;