import React, { Component } from 'react';
import { Grid, Button, Paper } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import './EmployeeSalary.css'

class EmployeeSalary extends Component {


    constructor(props) {

        super(props);
        this.state = {
            employee: this.props?.employee,
            uxNumberOfPayPeriod: 0,
            uxGrossSalaryAnnual: 0,
            uxGrossSalaryPerPayPeriod: 0
        };


        this.populateEmployeeSalary()
    }


    render() {

        const { firstName, lastName } = this.props.employee;

        return (

            <div className="root">
                <Paper className="root" style={{ borderRadius: " 15px 15px 15px 15px" }}>
                    <strong>Employee Salary: </strong> {firstName} {lastName}
                    <br/><br/>
                    <Grid container spacing={1} xs={12}>
                        <Grid item xs={4}>
                            <strong>
                                Number of Pay Periods
                            </strong>
                            &nbsp; {this.state.uxNumberOfPayPeriod}

                        </Grid>
                        <Grid item alignItems="right">
                        </Grid>
                        <Grid item xs={2} className="dataAlignRight" style={{ whiteSpace:"nowrap" }}>
                            <strong >
                                Per Pay Period
                            </strong>
                        </Grid>
                        <Grid item xs={2} className="dataAlignRight">
                            <strong >
                                Annual
                            </strong>
                        </Grid>
                    </Grid>
                    <Grid container spacing={1} xs={12}>
                        <Grid item xs={4}>
                            <strong>
                                Salary
                            </strong>
                        </Grid>
                        <Grid item xs={2} className="dataAlignRight">
                            <span>
                                ${this.state.uxGrossSalaryPerPayPeriod}
                            </span>
                        </Grid>
                        <Grid item xs={2} className="dataAlignRight">
                            <span>
                                ${this.state.uxGrossSalaryAnnual}
                            </span>
                        </Grid>

                    </Grid>
                </Paper>
                <Grid item xs={12} >
                    <div className="actionButtons">
                        <Button
                            onClick={this.props.onCancel}
                            type="button"
                            variant="contained"
                            color="primary"
                            style={{ borderRadius: 25 }}
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
