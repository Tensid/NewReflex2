import React, { FC } from 'react';
import { Container } from 'react-bootstrap';
import Footer from './Footer';
import { NavMenu } from './NavMenu';

export const Layout: FC = ({ children }) => (
  <div>
    <NavMenu />
    <Container>
      {children}
    </Container>
    <Footer />
  </div>
);
