import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'
import {FilterSort} from "./components/FilterSort";
import {Form} from "./components/Form";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/filtering-sorting' component={FilterSort} />
        <Route path='/form' component={Form} />
        {/*<Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />*/}
      </Layout>
    );
  }
}
