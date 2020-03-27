import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
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
//import { color } from '@material-ui/system';

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
    },
    topNavIcon: {
        margin: "0px 5px 0px 0px",
        padding: 0,
        color: "#21a631"
    },
    topNavButton: {
        color: "#dbffe0",
        padding: "0px 30px 0px 00px"
    },
    rootTitleNav: {
        flexGrow: 1,
    },
}));


export default function NavMenu() {

    const classes = useStyles();
    return (
        <div className={classes.root}>
        <Router>
            <AppBar position="static" >
                <Toolbar>
                        <Typography className={classes.rootTitleNav}>
                            <Button href="/" className={classes.topNavButton} ><HomeIcon className={classes.topNavIcon} />Home</Button>
                            <Button href="/employees" className={classes.topNavButton} ><PeopleIcon className={classes.topNavIcon} />Employees</Button>
                    </Typography>
                        <Button color="inherit" className={classes.topNavButton} disabled>
                            <PeopleOutlineIcon className={classes.topNavIcon} />
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

}