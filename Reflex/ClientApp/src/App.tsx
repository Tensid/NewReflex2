import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Route } from 'react-router';
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
import { Config, getConfigs } from './api/api';
import { RootState } from './app/store';
import { ApplicationPaths } from './features/api-authorization/ApiAuthorizationConstants';
import ApiAuthorizationRoutes from './features/api-authorization/ApiAuthorizationRoutes';
import AuthorizeRoute from './features/api-authorization/AuthorizeRoute';
import authService from './features/api-authorization/AuthorizeService';
import { setConfig } from './features/configs/configsSlice';
import { fetchUserSettings } from './features/user-settings/userSettingsSlice';
import { fetchGetUser } from './features/user/userSlice';

async function populateState(setAuthenticated: (authenticated: boolean) => void) {
  const [authenticated] = await Promise.all([authService.isAuthenticated()]);
  setAuthenticated(authenticated);
}

function App() {
  const [authenticated, setAuthenticated] = useState<Boolean>();
  const [configs, setConfigs] = useState<Config[]>([]);
  const dispatch = useDispatch();
  const config = useSelector((state: RootState) => state.config);
  const defaultConfigId = useSelector((state: RootState) => state.userSettings?.defaultConfigId);

  let _subscription: number;
  useEffect(() => {
    _subscription = authService.subscribe(() => populateState(setAuthenticated));
    populateState(setAuthenticated);

    return () => {
      authService.unsubscribe(_subscription);
    };
  }, []);

  useEffect(() => {
    if (authenticated) {
      dispatch(fetchUserSettings());
      dispatch(fetchGetUser());
      (async () => {
        setConfigs(await getConfigs());
      })();
    }
  }, [authenticated, dispatch]);

  useEffect(() => {
    if (!config && authenticated && defaultConfigId) {
      (async () => {
        const defaultConfig = configs.find(x => x.id === defaultConfigId);
        if (defaultConfig)
          dispatch(setConfig(defaultConfig));
      })();
    }
  }, [authenticated, config, defaultConfigId, configs, dispatch]);

  return (
    <>
      <Layout>
        <AuthorizeRoute exact path='/' component={() => config ? <Search /> : <Configs />} />
        <AuthorizeRoute path='/configs' component={() => <Configs />} />
        <AuthorizeRoute path='/search' component={() => config ? <Search /> : <Configs />} />
        <AuthorizeRoute path='/cases' component={() => config ? <Cases /> : <Configs />} />
        <AuthorizeRoute path='/population' component={() => config ? <Population /> : <Configs />} />
        <AuthorizeRoute path='/property' component={() => config ? <Property /> : <Configs />} />
        <AuthorizeRoute path='/manage-users' component={() => <ManageUsers />} />
        <AuthorizeRoute path='/manage-configs' component={() => <ManageConfigs />} />
        <AuthorizeRoute path='/system-settings' component={() => <ManageSystemSettings />} />
        <AuthorizeRoute path='/about' component={() => <About />} />
        {!config && <AuthorizeRoute path='/map' component={() => <Configs />} />}
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
      {config && <AuthorizeRoute path='/map' component={() => config ? <Map /> : <Configs />} />}
    </>
  );
}

export default App;
