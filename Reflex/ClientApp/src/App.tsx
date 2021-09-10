import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Route } from 'react-router';
import { Redirect } from 'react-router-dom';
import About from './About';
import './App.scss';
import Cases from './Cases';
import Configs from './Configs';
import { Layout } from './Layout';
import ManageConfigs from './ManageConfigs';
import ManageSystemSettings from './ManageSystemSettings';
import ManageUsers from './ManageUsers';
import Map from './Map';
import Population from './Population';
import Property from './Property';
import Search from './Search';
import { RootState } from './app/store';
import { ApplicationPaths } from './features/api-authorization/ApiAuthorizationConstants';
import ApiAuthorizationRoutes from './features/api-authorization/ApiAuthorizationRoutes';
import AuthorizeRoute from './features/api-authorization/AuthorizeRoute';
import useAuthService from './features/api-authorization/useAuthService';
import { fetchLayers, fetchMapSettings } from './features/map/mapSettingsSlice';
import { fetchSystemSettings } from './features/system-settings/systemSettingsSlice';
import { fetchInitiateSettings } from './features/user-settings/userSettingsSlice';
import { fetchGetUser } from './features/user/userSlice';

function App() {
  const dispatch = useDispatch();
  const config = useSelector((state: RootState) => state.config);
  const hasReceived = useSelector((state: RootState) => state.userSettings.hasReceived);
  const { authenticated } = useAuthService();

  useEffect(() => {
    if (authenticated) {
      dispatch(fetchInitiateSettings());
      dispatch(fetchMapSettings());
      dispatch(fetchSystemSettings());
      dispatch(fetchLayers());
      dispatch(fetchGetUser());
    }
  }, [authenticated, dispatch]);

  return (
    <Layout>
      {hasReceived && <AuthorizeRoute exact path='/' component={() => config ? <Search /> : <Redirect to="/configs" />} />}
      <AuthorizeRoute path='/configs' component={() => <Configs />} />
      {hasReceived && <AuthorizeRoute path='/search' component={() => config ? <Search /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/map' component={() => config ? <Map /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/cases' component={() => config ? <Cases /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/population' component={() => config ? <Population /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/property' component={() => config ? <Property /> : <Redirect to="/configs" />} />}
      <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-users' component={() => <ManageUsers />} />
      <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-configs' component={() => <ManageConfigs />} />
      <AuthorizeRoute requiredRoles={["Admin"]} path='/system-settings' component={() => <ManageSystemSettings />} />
      <Route path='/about' component={() => <About />} />
      <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
    </Layout>
  );
}

export default App;
