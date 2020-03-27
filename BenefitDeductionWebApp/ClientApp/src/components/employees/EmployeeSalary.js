import React, { Component } from 'react';
import { Grid, Button, Paper } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import './EmployeeSalary.css'

class EmployeeSalary extends Component {


    constructor(props) {

        super(props);
        this.state = {
            employee: this.props.employee,
            uxNumberOfPayPeriod: 0,
            uxGrossSalaryAnnual: 0,
            uxGrossSalaryPerPayPeriod: 0
        };


        this.populateEmployeeSalary()
    }


    render() {

        return (
            <div className="root">
                <Paper className="root" >
                    <strong>Employee Salary: </strong> {this.props.employee.firstName} {this.props.employee.lastName}
                    <br/><br/>
                    <Grid container spacing={1}>
                        <Grid item xs={4}>
                            <strong>
                                Number of Pay Periods
                            </strong>
                        </Grid>
                        <Grid item xs={1} className="dataAlignRight">
                            <div >
                                {this.state.uxNumberOfPayPeriod}
                            </div>
                        </Grid>
                        <Grid item xs={7} />



                        <Grid item xs={4}>
                            <strong>
                                Salary Per Pay Periods
                            </strong>
                        </Grid>
                        <Grid item xs={1} className="dataAlignRight">
                            <span>
                                ${this.state.uxGrossSalaryPerPayPeriod}
                            </span>
                        </Grid>
                        <Grid item xs={3}>
                            <strong>
                                Annual Salary
                            </strong>
                        </Grid>
                        <Grid item xs={1} className="dataAlignRight">
                            <span>
                                ${this.state.uxGrossSalaryAnnual}
                            </span>
                        </Grid>
                        <Grid item xs={3} />

                        </Grid>
                </Paper>
                <Grid item xs={12} >
                    <div className="actionButtons">
                        <Button
                            onClick={this.props.onCancel}
                            type="button"
                            variant="contained"
                            color="primary"
                        >
                            <CloseIcon />
                            Close
                                </Button>
                    </div>

                </Grid>

            </div>
        )
    };

    populateEmployeeSalary() {
        return fetch("http://localhost:54162/api/salaries/" + this.state.employee.employeeId)
            .then(resp => resp.json())
            .then(employeeSalary => {
                this.setState({
                    uxNumberOfPayPeriod: employeeSalary.numberOfPayPeriod,
                    uxGrossSalaryAnnual: employeeSalary.grossSalaryAnnual,
                    uxGrossSalaryPerPayPeriod: employeeSalary.grossSalaryPerPayPeriod
                });
            });
    }

}

export default EmployeeSalary
