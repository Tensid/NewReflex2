import React, { useState } from 'react';
import { Container, Nav, NavDropdown, Navbar } from 'react-bootstrap';
import { useSelector } from 'react-redux';
import { LinkContainer } from 'react-router-bootstrap';
import { useLocation } from 'react-router-dom';
import './NavMenu.css';
import { Tab } from './api/api';
import { RootState } from './app/store';
import { LoginMenu } from './features/api-authorization/LoginMenu';
import useAuthService from './features/api-authorization/useAuthService';
import Spinner from './features/spinner/Spinner';
import UserSettingsModal from './features/user-settings/UserSettingsModal';

export function NavMenu() {
  const tabs = useSelector((state: RootState) => state.config?.tabs);
  const [show, setShow] = useState(false);
  const { pathname } = useLocation();
  const { authenticated, user } = useAuthService();
  const hasPermission = user?.role?.includes("Admin") ?? false;

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
                {authenticated &&
                  <>
                    <LinkContainer to="/search">
                      <Nav.Link className="text-dark">Sök</Nav.Link>
                    </LinkContainer>
                    {tabs?.some((x) => x === Tab.Map) &&
                      <LinkContainer to="/map">
                        <Nav.Link className="text-dark">Karta</Nav.Link>
                      </LinkContainer>}
                    {tabs?.some((x) => x === Tab.Cases) &&
                      <LinkContainer to="/cases">
                        <Nav.Link className="text-dark">Ärenden</Nav.Link>
                      </LinkContainer>}
                    {tabs?.some((x) => x === Tab.Population) &&
                      <LinkContainer to="/population">
                        <Nav.Link className="text-dark">Befolkning</Nav.Link>
                      </LinkContainer>}
                    {tabs?.some((x) => x === Tab.Property) &&
                      <LinkContainer to="/property">
                        <Nav.Link className="text-dark">Fastighet</Nav.Link>
                      </LinkContainer>}
                  </>}
                <NavDropdown title="Mer" id="basic-nav-dropdown">
                  {authenticated &&
                    <>
                      <NavDropdown.Item onClick={() => setShow(true)} className="text-dark">Personliga inställningar</NavDropdown.Item>
                      <LinkContainer to="/configs">
                        <NavDropdown.Item className="text-dark">Välj konfiguration</NavDropdown.Item>
                      </LinkContainer>
                      {hasPermission &&
                        <>
                          <LinkContainer to="/manage-configs">
                            <NavDropdown.Item className="text-dark">Hantera konfigurationer</NavDropdown.Item>
                          </LinkContainer>
                          <LinkContainer to="/manage-users">
                            <NavDropdown.Item className="text-dark">Hantera användare</NavDropdown.Item>
                          </LinkContainer>
                          <LinkContainer to="/system-settings">
                            <NavDropdown.Item className="text-dark">Systeminställningar</NavDropdown.Item>
                          </LinkContainer>
                        </>}
                    </>}
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
