import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Employees from './components/Employees';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
        <Route path='/Employees' component={Employees} />
  </Layout>
);
