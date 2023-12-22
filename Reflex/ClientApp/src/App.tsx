import { useEffect } from 'react';
import { useProvideNavbarSubItems } from '@sokigo-sbwebb/default-core';
import About from './About';
import './App.scss';
import Cases from './Cases';
import Configs from './Configs';
import { Layout } from './Layout';
import ManageConfigs from './Administration/ManageConfigs';
import ManageSystemSettings from './Administration/ManageSystemSettings';
import ManageUsers from './ManageUsers';
import Map from './Map';
import Population from './Population';
import Property from './Property';
import Search from './Search';
import { useAppDispatch, useAppSelector } from './app/hooks';
import AuthorizeRoute from './features/api-authorization/AuthorizeRoute';
// import useAuthService from './features/api-authorization/useAuthService';
import { fetchLayers, fetchMapSettings } from './features/map/mapSettingsSlice';
import { fetchSystemSettings } from './features/system-settings/systemSettingsSlice';
import { fetchInitiateSettings } from './features/user-settings/userSettingsSlice';
import { fetchGetUser } from './features/user/userSlice';
import { Redirect, Route, Switch } from 'react-router-dom';
import ManageRoles from './Administration/ManageRoles';
import { faHome, faSearch, faGlobe, faTasks, faPerson, faBuilding } from '@fortawesome/pro-solid-svg-icons';

function App() {
  const dispatch = useAppDispatch();
  const config = useAppSelector((state) => state.config);
  const hasReceived = useAppSelector((state) => state.userSettings.hasReceived);

  useEffect(() => {
    // if (authenticated) {
    if (true) {
      dispatch(fetchInitiateSettings());
      dispatch(fetchMapSettings());
      dispatch(fetchSystemSettings());
      dispatch(fetchLayers());
      dispatch(fetchGetUser());
    }
  }, [dispatch]);

  const navbarSubItems = [
    {
      label: 'Konfigurationer', to: `/reflex/configs`, icon: faHome, permissions: []
    },
    {
      label: 'Sök', to: `/reflex/search`, icon: faSearch, permissions: []
    },
    {
      label: 'Karta', to: `/reflex/map`, icon: faGlobe, permissions: ['IsAdministrator', 'IsEntreprenour', 'IsReadOnlyUser']
    },
    {
      label: 'Ärenden', to: `/reflex/cases`, icon: faTasks, permissions: []
    },
    {
      label: 'Befolkning', to: `/reflex/population`, icon: faPerson, permissions: ['IsAdministrator', 'IsEntreprenour', 'IsReadOnlyUser']
    },
    {
      label: 'Fastighet', to: `/reflex/property`, icon: faBuilding, permissions: []
    }
  ];
  const filteredNavbarSubItemsByPermission = navbarSubItems.filter((x) => true);
  useProvideNavbarSubItems(filteredNavbarSubItemsByPermission);
  console.log("hasReceived", hasReceived);
  console.log("config", config);
  return (
    <Layout>
      <Switch>
        {/* <Route path='/' exact component={() => <AuthorizeRoute path='/' element={(hasReceived && config) ? <Search /> : <Redirect to="/configs" />} />} /> */}
        <Route path='/reflex' exact component={() => <AuthorizeRoute path='/reflex' element={(hasReceived && config) ? <Search /> : <Redirect to="/reflex/configs" />} />} />
        <Route path='/reflex/configs' exact component={() => <AuthorizeRoute path='/configs' element={<Configs />} />} />
        <Route path='/reflex/search' exact component={() => <AuthorizeRoute path='/search' element={(hasReceived && config) ? <Search /> : <Redirect to="/reflex/configs" />} />} />
        <Route path='/reflex/map' exact component={() => <AuthorizeRoute path='/map' element={(hasReceived && config) ? <Map /> : <Redirect to="/reflex/configs" />} />} />
        <Route path='/reflex/cases' exact component={() => <AuthorizeRoute path='/cases' element={(hasReceived && config) ? <Cases /> : <Redirect to="/reflex/configs" />} />} />
        <Route path='/reflex/population' exact component={() => <AuthorizeRoute path='/population' element={(hasReceived && config) ? <Population /> : <Redirect to="/reflex/configs" />} />} />
        <Route path='/reflex/property' exact component={() => <AuthorizeRoute path='/property' element={(hasReceived && config) ? <Property /> : <Redirect to="/reflex/configs" />} />} />
        <Route path='/reflex/manage-users' exact component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-users' element={<ManageUsers />} />} />
        <Route path='/reflex/manage-configs' exact component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-configs' element={<ManageConfigs />} />} />
        <Route path='/reflex/manage-roles' exact component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-roles' element={<ManageRoles />} />} />
        <Route path='/reflex/system-settings' exact component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/system-settings' element={<ManageSystemSettings />} />} />
        <Route path='/reflex/about' exact component={() => <About />} />
      </Switch>
    </Layout>
  );
}

export default App;
