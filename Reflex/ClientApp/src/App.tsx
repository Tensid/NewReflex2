import { useEffect } from 'react';
import { Route, Routes } from 'react-router';
import { Navigate } from 'react-router-dom';
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
import { useAppDispatch, useAppSelector } from './app/hooks';
import ApiAuthorizationRoutes from './features/api-authorization/ApiAuthorizationRoutes';
import AuthorizeRoute from './features/api-authorization/AuthorizeRoute';
import useAuthService from './features/api-authorization/useAuthService';
import { fetchLayers, fetchMapSettings } from './features/map/mapSettingsSlice';
import { fetchSystemSettings } from './features/system-settings/systemSettingsSlice';
import { fetchInitiateSettings } from './features/user-settings/userSettingsSlice';
import { fetchGetUser } from './features/user/userSlice';

function App() {
  const dispatch = useAppDispatch();
  const config = useAppSelector((state) => state.config);
  const hasReceived = useAppSelector((state) => state.userSettings.hasReceived);
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
      <Routes>
        <Route path='/' element={<AuthorizeRoute path='/search' element={(hasReceived && config) ? <Search /> : <Navigate to="/configs" />} />} />
        <Route path='/configs' element={<AuthorizeRoute path='/configs' element={<Configs />} />} />
        <Route path='/search' element={<AuthorizeRoute path='/search' element={(hasReceived && config) ? <Search /> : <Navigate to="/configs" />} />} />
        <Route path='/map' element={<AuthorizeRoute path='/map' element={(hasReceived && config) ? <Map /> : <Navigate to="/configs" />} />} />
        <Route path='/cases' element={<AuthorizeRoute path='/cases' element={(hasReceived && config) ? <Cases /> : <Navigate to="/configs" />} />} />
        <Route path='/population' element={<AuthorizeRoute path='/population' element={(hasReceived && config) ? <Population /> : <Navigate to="/configs" />} />} />
        <Route path='/property' element={<AuthorizeRoute path='/property' element={(hasReceived && config) ? <Property /> : <Navigate to="/configs" />} />} />
        <Route path='/manage-users' element={<AuthorizeRoute requiredRoles={["Admin"]} path='/manage-users' element={<ManageUsers />} />} />
        <Route path='/manage-configs' element={<AuthorizeRoute requiredRoles={["Admin"]} path='/manage-configs' element={<ManageConfigs />} />} />
        <Route path='/system-settings' element={<AuthorizeRoute requiredRoles={["Admin"]} path='/system-settings' element={<ManageSystemSettings />} />} />
        <Route path='/about' element={<About />} />
        {ApiAuthorizationRoutes()}
      </Routes>
    </Layout>
  );
}

export default App;
