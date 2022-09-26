import { FC, ReactNode } from 'react';
import Container from 'react-bootstrap/Container';
import { useLocation } from 'react-router-dom';
import Footer from './Footer';
import { NavMenu } from './NavMenu';

export const Layout: FC<{ children: ReactNode }> = ({ children }) => {
  const { pathname } = useLocation();
  return (
    <>
      <NavMenu />
      {pathname !== '/map' ?
        <>
          <Container style={{ paddingBottom: '24px' }}>
            {children}
          </Container>
          <Footer />
        </>
        : children}
    </>
  );
};
