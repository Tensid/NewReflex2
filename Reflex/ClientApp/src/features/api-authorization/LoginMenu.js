import React, { Component, Fragment } from 'react';
import { NavDropdown } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import { ApplicationPaths } from './ApiAuthorizationConstants';
import authService from './AuthorizeService';

export class LoginMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      userName: null
    };
  }

  componentDidMount() {
    this._subscription = authService.subscribe(() => this.populateState());
    this.populateState();
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  async populateState() {
    const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()]);
    this.setState({
      isAuthenticated,
      userName: user && user.name
    });
  }

  render() {
    const { isAuthenticated, userName } = this.state;
    if (!isAuthenticated) {
      const registerPath = `${ApplicationPaths.Register}`;
      const loginPath = `${ApplicationPaths.Login}`;
      return this.anonymousView(registerPath, loginPath);
    } else {
      const profilePath = `${ApplicationPaths.Profile}`;
      const logoutPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
      return this.authenticatedView(userName, profilePath, logoutPath);
    }
  }

  authenticatedView(userName, profilePath, logoutPath) {
    return (<Fragment>
      <LinkContainer to={profilePath}>
        <NavDropdown.Item className="text-dark">Min profil</NavDropdown.Item>
      </LinkContainer>
      <LinkContainer to={logoutPath}>
        <NavDropdown.Item className="text-dark">Logga ut</NavDropdown.Item>
      </LinkContainer>
    </Fragment>);
  }

  anonymousView(registerPath, loginPath) {
    return (<Fragment>
      <LinkContainer to={registerPath}>
        <NavDropdown.Item className="text-dark">Registrera</NavDropdown.Item>
      </LinkContainer>
      <LinkContainer to={loginPath}>
        <NavDropdown.Item className="text-dark">Logga in</NavDropdown.Item>
      </LinkContainer>
    </Fragment>);
  }
}
