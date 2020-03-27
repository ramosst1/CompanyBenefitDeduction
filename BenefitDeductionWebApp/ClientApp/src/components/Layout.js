import React from 'react';
import { Grid } from '@material-ui/core';
import NavMenu from './NavMenu';

export default props => (
    <Grid container>
      <Grid item xs={12}>
        <NavMenu />
      </Grid>
  </Grid>
);
