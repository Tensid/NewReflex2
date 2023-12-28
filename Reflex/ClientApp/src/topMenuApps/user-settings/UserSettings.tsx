import { NavbarTopIcon } from '@sokigo-sbwebb/default-components';
import { useState } from 'react';
import { faUserCog } from '@fortawesome/pro-solid-svg-icons';
import UserSettingsModal from '../../features/user-settings/UserSettingsModal';

export function UserSettings({ expanded, ...props }: { expanded: boolean }) {
  const [show, setShow] = useState(false);

  console.log("UserSettings", props);

  return (
    <>
      {expanded ? (
        <div style={{ height: 40 }}>
          <NavbarTopIcon
            block
            title="Användarinställningar"
            expanded={expanded}
            icon={faUserCog}
            onClick={() => setShow(true)}
            aria-label="Användarinställningar"
          />
          {show && <UserSettingsModal setShow={setShow} />}
        </div>
      ) : (
        <>
          <NavbarTopIcon
            title="Användarinställningar"
            expanded={expanded}
            icon={faUserCog}
            onClick={() => setShow(true)}
            aria-label="Användarinställningar"
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