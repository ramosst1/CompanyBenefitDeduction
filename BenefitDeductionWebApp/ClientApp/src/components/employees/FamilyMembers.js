﻿import React, { Component } from 'react';
import { Button, Grid, Paper } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow} from '@material-ui/core';

import './FamilyMembers.css'

class FamilyMembers extends Component {

    constructor(props) {

        super(props);
        this.state = {
            employee: this.props?.employee,
            familyMembers: []
        };

        if (props.employee === null) return;

        this.populateFamilyMembers()
    }

    render() {

        const { firstName, lastName } = this.props.employee;

        return (
            <div className="root" style={{ borderRadius: " 15px 15px 15px 15px"}}>
                <strong>Employee Family Members:</strong> {firstName} {lastName}
                <br/><br/>


                <Grid container spacing={1} >
                    <TableContainer component={Paper} className="root" style={{padding:0,  borderRadius: " 15px 15px 15px 15px" }}  >
                        
                        <Table className="dataTable" aria-label="Family Members" >
                            <TableHead className="dataTableHeader"  >
                                <TableRow className="dataTableHeader" >
                                    <TableCell className="dataTableHeader"  style={{ width:"40%" }}>Name</TableCell>
                                    <TableCell className="dataTableHeader"  align="left" style={{ width: "20%" }}>Relationship</TableCell>
                                    <TableCell className="dataTableHeader"  />
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {this.state.familyMembers.map(aFamilyMember =>
                                    <TableRow key={aFamilyMember.familyMemberId}>
                                        <TableCell component="th" scope="row">
                                            {aFamilyMember.firstName} {aFamilyMember.middleName}{aFamilyMember.lastName} 
                                        </TableCell>
                                        <TableCell component="th" scope="row" align="left">
                                            {aFamilyMember.isSpouse && (' Spouse') }
                                            {aFamilyMember.isChild && (' Child')}
                                        </TableCell>
                                        <TableCell component="th" scope="row"/>
                                    </TableRow>
                                )}

                                {this.state.familyMembers.length === 0 && (
                                    <TableRow style={{ height: 53 }}>
                                        <TableCell colSpan={3} >
                                            <strong>The employee has no family members.</strong>
                                        </TableCell>
                                    </TableRow>
                                )}
                            </TableBody>
                        </Table>
                    </TableContainer>


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


                </Grid>

            </div>
        )
    };

    populateFamilyMembers() {
        return fetch("http://localhost:54162/api/familymembers/EmployeeFamilyMembers/" + this.state.employee.employeeId)
            .then(resp => resp.json())
            .then(familyMemberList => {
                this.setState({
                    familyMembers: familyMemberList
                });
            });
    }

}

export default FamilyMembers;

