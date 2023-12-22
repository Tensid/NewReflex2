import { useState } from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Navbar from 'react-bootstrap/Navbar';
import { LinkContainer } from 'react-router-bootstrap';
import { Link, useLocation } from 'react-router-dom';
import './NavMenu.css';
import { Tab } from './api/api';
import { useAppSelector } from './app/hooks';
import Spinner from './features/spinner/Spinner';
import UserSettingsModal from './features/user-settings/UserSettingsModal';

export function NavMenu() {
  const tabs = useAppSelector((state) => state.config?.tabs);
  const [show, setShow] = useState(false);
  const { pathname } = useLocation();
  const authenticated = true;
  // const hasPermission = user?.role?.includes("Admin") ?? false;
  const hasPermission = true;

  return (
    <>
      <header>
        <Navbar expand="lg" className={`navbar-expand-sm navbar-toggleable-sm border-bottom ${pathname !== '/map' ? 'box-shadow  mb-3' : ''}`}>
          <Container>

            <h4 className='align-self-center pl-2'>
              <Link to={'/reflex/configs'} className="text-decoration-none" onClick={(e) => e.stopPropagation()}>
                <h3 className='align-self-center pl-2'>
                  <span className="text-primary">Reflex</span>
                </h3>
                {/* {'Vega Beslut'}<span className='text-muted'> - {currentYear}</span> */}
              </Link>
            </h4>

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
                <NavDropdown title="Mer" id="basic-nav-dropdown" align="end">
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
                          <LinkContainer to="/manage-roles">
                            <NavDropdown.Item className="text-dark">Hantera roller</NavDropdown.Item>
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
