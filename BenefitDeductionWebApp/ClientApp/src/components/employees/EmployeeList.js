import React, { Component } from 'react';
import { Button, Paper} from '@material-ui/core';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core';


class EmployeeList extends Component {


    constructor(props) {
        super(props);
        this.state = {
            employees: this.props.employees
        };

    }

    render() {
        return (
            <div>
                <Paper elevation={0}  >

                    <TableContainer component={Paper} style={{ borderRadius: " 15px 15px 15px 15px"}}>
                        <Table aria-label="Employee List" size="small">
                            <TableHead>
                                <TableRow>
                                    <TableCell align="right" style={{ width: '25%' }}>Employee Id</TableCell>
                                    <TableCell align="left">Employee Name</TableCell>
                                    <TableCell align="left">Employee Type</TableCell>
                                    <TableCell align="center">Action</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody >
                                {this.props.employees.map(employee => (
                                    <TableRow key={employee.employeeId}>
                                        <TableCell align="right" component="th" scope="row">
                                            {employee.employeeId}
                                        </TableCell>
                                        <TableCell align="left">{employee.firstName} {employee.lastName}</TableCell>
                                        <TableCell align="left">{employee.isExempt === true ? 'Exempt' : 'NonExempt'}</TableCell>
                                        <TableCell align="center">
                                            <Button onClick={() => this.handleViewEmployeeDetail(employee)} color="primary" >view</Button>
                                        </TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>


                </Paper>
            </div>
        )
    }

    handleViewEmployeeDetail = employee => {

        this.props.onView(employee);

    };

}
export default EmployeeList;