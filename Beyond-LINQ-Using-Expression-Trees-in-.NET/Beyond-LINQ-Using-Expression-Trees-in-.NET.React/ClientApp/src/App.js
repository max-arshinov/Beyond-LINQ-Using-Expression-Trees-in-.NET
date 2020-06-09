import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'
import {FilteringSorting} from "./components/FilteringSorting";
import {Form} from "./components/Form";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/filtering-sorting' component={FilteringSorting} />
        <Route path='/form' component={Form} />
        {/*<Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />*/}
      </Layout>
    );
  }
}