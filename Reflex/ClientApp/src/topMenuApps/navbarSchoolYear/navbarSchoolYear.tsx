import { useState } from 'react';

import { Link, useLocation } from 'react-router-dom';
import { useAppSelector } from '../../app/hooks';
import { Tab } from '../../api/api';

export function NavbarSchoolYear({ expanded, ...props }: { expanded: boolean }) {
  const tabs = useAppSelector((state) => state.config?.tabs);
  const [show, setShow] = useState(false);
  const { pathname } = useLocation();
  const authenticated = true;
  if (expanded) return null;
  return (
    <>
      <h4 className='align-self-center pl-2'>
        <Link to={'/reflex/configs'} className="text-decoration-none" onClick={(e) => e.stopPropagation()}>
          Reflex
        </Link>
      </h4>
      {/* <h5 className='align-self-center pl-2'>
        {authenticated &&
          <>
            <Link className="text-decoration-none mr-2 text-secondary" to="/search">
              Sök
            </Link>
            {tabs?.some((x) => x === Tab.Map) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/map">
                Karta
              </Link>}
            {tabs?.some((x) => x === Tab.Cases) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/cases">
                Ärenden
              </Link>}
            {tabs?.some((x) => x === Tab.Population) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/population">
                Befolkning
              </Link>}
            {tabs?.some((x) => x === Tab.Property) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/property">
                Fastighet
              </Link>}
          </>}
      </h5> */}
    </>
  );
}

export default NavbarSchoolYear;