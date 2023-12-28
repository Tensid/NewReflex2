import { useState } from 'react';

import { Link, useLocation } from 'react-router-dom';
import { useAppSelector } from '../../app/hooks';
import { Tab } from '../../api/api';

function Navs({ expanded, ...props }: { expanded: boolean }) {
  const tabs = useAppSelector((state) => state.config?.tabs);
  const [show, setShow] = useState(false);
  const { pathname } = useLocation();

  // if(!pathname.includes("reflex"))
  const authenticated = true;
  console.log("navs", props);
  console.log("pathname", pathname);
  if (expanded || !pathname.includes("reflex")) return null;
  return (
    <>
      <h5 className='align-self-center pl-2'>
        {authenticated &&
          <>
            <Link className="text-decoration-none mr-2 text-secondary" to="/reflex/search">
              Sök
            </Link>
            {tabs?.some((x) => x === Tab.Map) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/reflex/map">
                Karta
              </Link>}
            {tabs?.some((x) => x === Tab.Cases) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/reflex/cases">
                Ärenden
              </Link>}
            {tabs?.some((x) => x === Tab.Population) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/reflex/population">
                Befolkning
              </Link>}
            {tabs?.some((x) => x === Tab.Property) &&
              <Link className="text-decoration-none mr-2 text-secondary" to="/reflex/property">
                Fastighet
              </Link>}

          </>}
      </h5>
    </>
  );
}

export default Navs;