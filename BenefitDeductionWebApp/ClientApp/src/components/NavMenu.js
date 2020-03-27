import React from 'react';
import { AppBar, Toolbar, Typography, Button } from '@material-ui/core';
import HomeIcon from '@material-ui/icons/Home';
import PeopleIcon from '@material-ui/icons/People';
import PeopleOutlineIcon from '@material-ui/icons/PeopleOutline';
import Home from './Home';
import Employees from './employees/Employees';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";

import './NavMenu.css';

export default props => (
    <div className="rootNav">
        <Router>
            <AppBar position="static" >
            <Toolbar>
                <Typography variant="h6" className="rootTitleNav">
                        <Button href="/"  ><HomeIcon className="topNavIcon" />Home</Button>
                        <Button href="/employees" className="topNavButton" ><PeopleIcon className="topNavIcon" />Employees</Button>
                    </Typography>
                    <Button color="inherit" className="topNavButton" disabled>
                        <PeopleOutlineIcon className="topNavIcon" />
                        Sign In
                    </Button>
                </Toolbar>
            </AppBar>


        </Router>
        <Switch>
            <Route exact path="/">
                <Home />
            </Route>
            <Route exact path="/employees">
                <Employees />
            </Route>
        </Switch>
    </div>



);
