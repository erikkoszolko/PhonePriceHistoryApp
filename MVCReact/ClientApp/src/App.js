import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import DownloadSettings from './components/DownloadSettings';
import Product from './components/Product';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import ProdDetail from "./components/ProdDetail";
import './custom.css'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout className="pages">
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/proddetail' component={ProdDetail} />  
        <AuthorizeRoute path='/fetch-data' component={FetchData} />
        <AuthorizeRoute path='/prodList' component={Product} />
        <AuthorizeRoute path='/settings' component={DownloadSettings} />
       
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}
