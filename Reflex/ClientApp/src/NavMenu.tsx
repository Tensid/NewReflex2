import React, { useState } from 'react';
import { Container, Nav, NavDropdown, Navbar } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import { useLocation } from 'react-router-dom';
import './NavMenu.css';
import { LoginMenu } from './features/api-authorization/LoginMenu';
import Spinner from './features/spinner/Spinner';
import UserSettingsModal from './features/user-settings/UserSettingsModal';

export function NavMenu() {
  const [show, setShow] = useState(false);
  const { pathname } = useLocation();

  return (
    <>
      <header>
        <Navbar expand="lg" className={`navbar-expand-sm navbar-toggleable-sm border-bottom ${pathname !== '/map' ? 'box-shadow  mb-3' : ''}`}>
          <Container>
            <LinkContainer to="configs">
              <Navbar.Brand>Reflex</Navbar.Brand>
            </LinkContainer>
            <Spinner />
            <Navbar.Toggle className="mr-2" />
            <Navbar.Collapse className="d-sm-inline-flex flex-sm-row-reverse">
              <ul className="navbar-nav flex-grow">
                <LinkContainer to="/search">
                  <Nav.Link className="text-dark">Sök</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/map">
                  <Nav.Link className="text-dark">Karta</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/cases">
                  <Nav.Link className="text-dark">Ärenden</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/population">
                  <Nav.Link className="text-dark">Befolkning</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/property">
                  <Nav.Link className="text-dark">Fastighet</Nav.Link>
                </LinkContainer>
                <NavDropdown title="Mer" id="basic-nav-dropdown">
                  <NavDropdown.Item onClick={() => setShow(true)} className="text-dark">Personliga inställningar</NavDropdown.Item>
                  <LinkContainer to="/configs">
                    <NavDropdown.Item className="text-dark">Välj konfiguration</NavDropdown.Item>
                  </LinkContainer>
                  <LinkContainer to="/manage-configs">
                    <NavDropdown.Item className="text-dark">Hantera konfigurationer</NavDropdown.Item>
                  </LinkContainer>
                  <LinkContainer to="/manage-users">
                    <NavDropdown.Item className="text-dark">Hantera användare</NavDropdown.Item>
                  </LinkContainer>
                  <LinkContainer to="/system-settings">
                    <NavDropdown.Item className="text-dark">Systeminställningar</NavDropdown.Item>
                  </LinkContainer>
                  <NavDropdown.Item onClick={() => window.open('https://dok.sokigo.com/display/REFLEX/?os_username=kund&os_password=Sokigo2048')} className="text-dark">Hjälp</NavDropdown.Item>
                  <LinkContainer to="/about">
                    <NavDropdown.Item className="text-dark">Om Reflex</NavDropdown.Item>
                  </LinkContainer>
                  <NavDropdown.Divider />
                  <LoginMenu />
                </NavDropdown>
              </ul>
            </Navbar.Collapse>
          </Container>
        </Navbar>
      </header>
      {show && <UserSettingsModal setShow={setShow} />}
    </>
  );
}
