import React, { FC } from 'react';
import { Container } from 'react-bootstrap';
import { useLocation } from 'react-router-dom';
import Footer from './Footer';
import { NavMenu } from './NavMenu';

export const Layout: FC = ({ children }) => {
  const { pathname } = useLocation();
  return (
    <>
      <NavMenu />
      {pathname !== '/map' ?
        <>
          <Container>
            {children}
          </Container>
          <Footer />
        </>
        : children}
    </>
  );
};
