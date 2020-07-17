import React from 'react';
import { Route } from 'react-router';
import About from './About';
import './App.scss';
import Cases from './Cases';
import Configs from './Configs';
import { Layout } from './Layout';
import ManageConfigs from './ManageConfigs';
import ManageUsers from './ManageUsers';
import Map from './Map';
import Population from './Population';
import Property from './Property';
import Search from './Search';
import { ApplicationPaths } from './features/api-authorization/ApiAuthorizationConstants';
import ApiAuthorizationRoutes from './features/api-authorization/ApiAuthorizationRoutes';
import AuthorizeRoute from './features/api-authorization/AuthorizeRoute';

function App() {
  return (
    <>
      <Layout>
        <AuthorizeRoute exact path='/' component={() => <Search />} />
        <AuthorizeRoute path='/configs' component={() => <Configs />} />
        <AuthorizeRoute path='/search' component={() => <Search />} />
        <AuthorizeRoute path='/cases' component={() => <Cases />} />
        <AuthorizeRoute path='/population' component={() => <Population />} />
        <AuthorizeRoute path='/property' component={() => <Property />} />
        <AuthorizeRoute path='/manage-users' component={() => <ManageUsers />} />
        <AuthorizeRoute path='/manage-configs' component={() => <ManageConfigs />} />
        <AuthorizeRoute path='/about' component={() => <About />} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
      <Route path='/map' render={() => <Map />} />
    </>
  );
}

export default App;
