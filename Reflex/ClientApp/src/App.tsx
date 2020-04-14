import React from 'react';
import { Route } from 'react-router';
import './App.scss';
import Cases from './Cases';
import Configs from './Configs';
import { FetchData } from './FetchData';
import { Layout } from './Layout';
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
    <Layout>
      <Route exact path='/' render={() => <Search />} />
      <Route path='/configs' render={() => <Configs />} />
      <Route path='/search' render={() => <Search />} />
      <Route path='/map' render={() => <Map />} />
      <Route path='/cases' render={() => <Cases />} />
      <Route path='/population' render={() => <Population />} />
      <Route path='/property' render={() => <Property />} />
      <Route path='/manage-users' render={() => <ManageUsers />} />
      <AuthorizeRoute path='/fetch-data' component={FetchData} />
      <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
    </Layout>
  );
}

export default App;
