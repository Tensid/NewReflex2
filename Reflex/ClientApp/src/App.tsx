import React from 'react';
import { Route } from 'react-router';
import './App.css';
import Cases from './Cases';
import Configs from './Configs';
import { FetchData } from './FetchData';
import { Home } from './Home';
import { Layout } from './Layout';
import Map from './Map';
import Population from './Population';
import Property from './Property';
import Search from './Search';
import { ApplicationPaths } from './features/api-authorization/ApiAuthorizationConstants';
import ApiAuthorizationRoutes from './features/api-authorization/ApiAuthorizationRoutes';
import AuthorizeRoute from './features/api-authorization/AuthorizeRoute';
import { Counter } from './features/counter/Counter';

function App() {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route path='/counter' render={() => <Counter />} />
      <Route path='/configs' render={() => <Configs />} />
      <Route path='/search' render={() => <Search />} />
      <Route path='/map' render={() => <Map />} />
      <Route path='/cases' render={() => <Cases />} />
      <Route path='/population' render={() => <Population />} />
      <Route path='/property' render={() => <Property />} />
      <AuthorizeRoute path='/fetch-data' component={FetchData} />
      <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
    </Layout>
  );
}

export default App;
