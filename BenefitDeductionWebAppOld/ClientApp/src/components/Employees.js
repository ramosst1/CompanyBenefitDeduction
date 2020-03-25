import React, { Component } from 'react';
import { Grid } from '@material-ui/core/'

export class Employees extends Component {
    displayName = Employees.name

    constructor(props) {
        super(props);
        this.state = { currentCount: 0 };
        this.incrementCounter = this.incrementCounter.bind(this);
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }

    render() {
        return (
            <div>
                <h1>Employees</h1>

                <p>List of Employees.</p>


            </div>
        );
    }
}
