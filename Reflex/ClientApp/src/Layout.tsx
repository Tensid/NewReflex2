import React, { FC } from 'react';
import { Container } from 'reactstrap';
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
