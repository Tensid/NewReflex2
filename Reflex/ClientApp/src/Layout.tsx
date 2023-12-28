import { FC, ReactNode } from 'react';
import { useLocation } from 'react-router-dom';
import Footer from './Footer';
import { NavMenu } from './NavMenu';

export const Layout: FC<{ children: ReactNode }> = ({ children }) => {
  const { pathname } = useLocation();
  console.log("layout");
  return (
    <>
      {/* <NavMenu /> */}
      {!pathname.includes('map') ?

        <div id="layout" className="pt-3">
          <div className="container" style={{ paddingBottom: '24px' }}>
            {children}
          </div>
          <Footer />
        </div>
        : children}
    </>
  );
};
