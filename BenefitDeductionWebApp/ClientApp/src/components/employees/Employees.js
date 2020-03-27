import React, { Component } from 'react';
import './Employees.css';
import BenefitDeductionDetail from '../BenefitDeductionDetail';
import EmployeeSalary from './EmployeeSalary';
import FamilyMembers from './FamilyMembers';
import { Button, Paper, AppBar, Tabs, Tab, Grid } from '@material-ui/core';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core';
import MonetizationOnIcon from '@material-ui/icons/MonetizationOn';
import PeopleIcon from '@material-ui/icons/People'
import LibraryBooksIcon from '@material-ui/icons/LibraryBooks';

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

                            <TableContainer component={Paper}>
                                <Table aria-label="Employee List" size="small">
                                    <TableHead>
                                        <TableRow>
                                            <TableCell align="right" style={{ width: '25%' }}>Employee Id</TableCell>
                                            <TableCell align="left">Employee Name</TableCell>
                                            <TableCell align="left">Employee Type</TableCell>
                                            <TableCell align="center">Action</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        {this.state.employees.map(employee => (
                                            <TableRow key={employee.employeeId}>
                                                <TableCell align="right" component="th" scope="row">
                                                    {employee.employeeId}
                                                </TableCell>
                                                <TableCell align="left">{employee.firstName} {employee.lastName}</TableCell>
                                                <TableCell align="left">{employee.isExempt === true ? 'Exempt' : 'NonExempt'}</TableCell>
                                                <TableCell align="center">
                                                    <Button onClick={() => this.handleBenefitDeduction(employee)} color="primary" >view</Button>
                                                </TableCell>
                                            </TableRow>
                                        ))}
                                    </TableBody>
                                </Table>
                            </TableContainer>


                        </Paper>

                    </Grid>
                    <Grid item xs={8} >
                        {this.state.openBenefitDeductionDetail ?

                            <div>
                                <Paper elevation={10} square={false}>
                                    <AppBar position="static">
                                        <Tabs
                                        value={this.state.employeeDetailOptions}
                                        onChange={this.handleEmployeeDetailOnChange}
                                        aria-label="Employee Details"
                                        square={false}
                                        >
                                            <Tab label="Salary Info" value="salary" icon={<MonetizationOnIcon/>}/>
                                            <Tab label="Family Members" value="family_members" icon={<PeopleIcon/>} />
                                            <Tab label="Benefit Deductions" value="benefit_deductions" icon={<LibraryBooksIcon />} />
                                        </Tabs>
                                    </AppBar>
                                    {this.renderEmployeeDetailOptions()}

                                </Paper>


                            </div>
                            : null
                        }

                    </Grid>
                </Grid>
    
                <table className='table' style={{ width: '60%', float: 'left' }} >
                    <tr>
                        <td style={{ paddingLeft: 15, verticalAlign:"top" }}>




                            </td>
                        </tr>
                    </table>

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

    handleBenefitDeduction = employee => {
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


