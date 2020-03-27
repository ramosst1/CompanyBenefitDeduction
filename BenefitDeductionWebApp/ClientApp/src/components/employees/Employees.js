import React, { Component } from 'react';
import './Employees.css';
import BenefitDeductionDetail from '../benefitDeductions/BenefitDeductionDetail';
import EmployeeList from './EmployeeList';
import EmployeeSalary from './EmployeeSalary';
import FamilyMembers from './FamilyMembers';
import { Paper, AppBar, Tabs, Tab, Grid } from '@material-ui/core';
import MonetizationOnIcon from '@material-ui/icons/MonetizationOn';
import PeopleIcon from '@material-ui/icons/People'
import LibraryBooksIcon from '@material-ui/icons/LibraryBooks';
import { fontSize } from '@material-ui/system';

class Employees extends Component {


    constructor(props) {
        super(props);

        this.state = {
            employees: [],
            keyEmployeeKey: 0,
            selectedEmployee: null,
            openBenefitDeductionDetail: false,
            employeeDetailOptions: 'salary'
        };

    }

    render() {
        return (
            <div className="root2">
                <h1>Employees</h1>


                <Grid container xs={12} spacing={2} >
                    <Grid item xs={4}>
                        <Paper elevation={0}  >
                            <EmployeeList employees={this.state.employees} onView={this.handleViewEmployeeDetail} />
                        </Paper>
                    </Grid>
                    <Grid item xs={8} >
                        {this.state.openBenefitDeductionDetail ?

                            <div>
                                <AppBar position="static" elevation={10} style={{ borderRadius: " 15px 15px 0px 0px" }}>
                                    <Tabs
                                        value={this.state.employeeDetailOptions}
                                        onChange={this.handleEmployeeDetailOnChange}
                                        aria-label="Employee Details"
                                        square={false}
                                    >
                                        <Tab style={{ fontSize: 10 }} label="Salary Info" value="salary" icon={<MonetizationOnIcon style={{ fontSize: 13 }} />} />
                                        <Tab style={{ fontSize: 10 }} label="Family Members" value="family_members" icon={<PeopleIcon style={{ fontSize: 13 }} />} />
                                        <Tab style={{ fontSize: 10 }} label="Benefit Deductions" value="benefit_deductions" icon={<LibraryBooksIcon style={{ fontSize: 13 }} />} />
                                    </Tabs>
                                </AppBar>
                                <Grid xs={12}
                                    
                                    elevation={10}
                                >
                                    <Paper
                                        className="root2"
                                        style={{ backgroundColor: "whitesmoke", borderRadius: " 0px 0px 15px 15px" }}
                                        elevation={10}

                                    >
                                        {this.renderEmployeeDetailOptions()}
                                    </Paper>

                                </Grid>

                            </div>
                            : null
                        }

                    </Grid>
                </Grid>

            </div>
        );


    }

    renderEmployeeDetailOptions() {

        switch (this.state.employeeDetailOptions) {
            case 'salary':
                return (
                                    
                    <EmployeeSalary
                        key={"salary" + this.state.keyEmployeeKey }
                        employee={this.state.selectedEmployee}
                        onCancel={this.handleProfileDetailClose}
                    />
                )
                break;
            case 'family_members':
                return(

                    <FamilyMembers
                        key={"familymembers" + this.state.keyEmployeeKey}
                        employee={this.state.selectedEmployee}
                        onCancel={this.handleProfileDetailClose}
                        />
                )
                break;
            case 'benefit_deductions':

                return (
                    <BenefitDeductionDetail
                    key={"benefitdeductions" + this.state.keyEmployeeKey}
                    employee={this.state.selectedEmployee}
                    onCancel={this.handleProfileDetailClose}
                    />
                )

                break;
        }


    }

    handleEmployeeDetailOnChange = (event, newValue) => {
        this.setState({
            employeeDetailOptions: newValue
        });
    };

    componentDidMount(prevProps) {
        this.populateEmployeeList();
    }

    handleViewEmployeeDetail = employee => {
        this.setState({
            openBenefitDeductionDetail: true,
            keyEmployeeKey: employee.employeeId,
            selectedEmployee: employee
        });
    };

    handleProfileDetailClose = profile => {

        this.setState({
            openBenefitDeductionDetail: false,
            keyEmployeeKey: 0,
            selectedEmployee: null,
            employeeDetailOptions: 'salary'
        });
    };

    populateEmployeeList() {
        return fetch("http://localhost:54162/api/employees")
            .then(resp => resp.json())
            .then(employeeList => {
                this.setState({
                    employees: employeeList
                });
            });
    }


}


export default Employees;


