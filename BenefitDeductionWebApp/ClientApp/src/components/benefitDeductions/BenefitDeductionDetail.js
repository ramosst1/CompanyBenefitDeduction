import React, { Component } from 'react';
import './BenefitDeductionDetail.css'
import { Button, Grid, Paper } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core';
import Collapse from '@material-ui/core/Collapse';

import ExpansionPanel from '@material-ui/core/ExpansionPanel';
import ExpansionPanelDetails from '@material-ui/core/ExpansionPanelDetails';
import ExpansionPanelSummary from '@material-ui/core/ExpansionPanelSummary';
import Typography from '@material-ui/core/Typography';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';

const GlobalUserExperience = {

    FamilyMembersExpandDetail: true
}


class BenefitDeductionDetail extends Component {



       constructor(props) {
        super(props);

        let firstName = this.props.employee != null? this.props.employee.firstName : "";
        let lastName = this.props.employee ? this.props.employee.lastName : ""
        let selectedEmployeeId = 0;


        if (this.props.employee) {
            firstName = this.props.employee.firstName;
            lastName = this.props.employee.lastName;
            selectedEmployeeId = this.props.employee.employeeId;
        }


        this.state = {
            uxFirstName: firstName,
            uxLastName: lastName,
            employee: null,
            selectedEmployeeId: selectedEmployeeId,
            benefitDeduction: null,
            annualTotalCostGross: 0,
            annualTotalCostNet: 0,
            annualSalaryAjustment: 0,
            perPayPeriodTotalCostGross: 0,
            perPayPeriodTotalCostNet: 0,
            perPayPeriodSalaryAjustment: 0,
            familyMembersExpandDetail: true,
            employeeSalary: 0,
            benefitDeductionItems: []

        };

        if (props.employee === null) return;

        this.populateDeductionDetail()

    }

	render() {


        return (
            <Grid className="root" xs={12} style={{ borderRadius: "15px" }}>
                <Grid container xs={12}>
                    <Grid item xs={4} >
                        <strong>Employee</strong> {this.props.employee.firstName} {this.props.employee.lastName}
                    </Grid>
                    <Grid item xs={4} >
                        <strong>Number of Beneficiaries</strong> {this.state.benefitDeductionItems.length}
                    </Grid>
                </Grid>
                <br/>
                <ExpansionPanel expanded={GlobalUserExperience.FamilyMembersExpandDetail}
                    onClick={() => this.handleChangeFamilyMembersDetailExpand()}
                    style={{ borderRadius: "15px" }}
                >
                    <ExpansionPanelSummary
                        expandIcon={<ExpandMoreIcon color="primary" />}
                        aria-controls="panel1bh-content"
                        id="panel1bh-header"
                        className="root"
                        style={{ borderRadius: " 15px", padding: 5 }}
                    >
                    <strong>Family Members</strong>

                    </ExpansionPanelSummary>
                    <ExpansionPanelDetails style={{ borderRadius: "15px" }}>
                                <TableContainer style={{ padding: 0, borderRadius: "15px" }}>

                                    <Table aria-label="Benefit Deductions List" component={Paper} >
                                        <TableHead >
                                            <TableRow className="dataTableHeader" >
                                                <TableCell >Family Member</TableCell>
                                                <TableCell align="right" ># Pay Periods</TableCell>
                                                <TableCell align="right" >Discount</TableCell>
                                                <TableCell align="right" >Pay Period Gross</TableCell>
                                                <TableCell align="right" >Pay Period Net</TableCell>
                                                <TableCell align="right" >Annual Gross</TableCell>
                                                <TableCell align="right" xs={2}>Annual Net</TableCell>
                                            </TableRow>
                                        </TableHead>
                                        <TableBody>
                                            {this.state.benefitDeductionItems.map(benefitDeductItem => (
                                        <TableRow key={benefitDeductItem.familyMemberId}
                                            style={{ backgroundColor: "#f6f6f6de" }}
                                        >
                                                    <TableCell component="th" scope="row" >
                                                        {benefitDeductItem.firstName} {benefitDeductItem.lastName}

                                                        <span style={{ color: 'gray' }}>
                                                            {benefitDeductItem.isSpouse ? ' (spouse)' : ''}
                                                            {benefitDeductItem.isChild ? ' (child)' : ''}
                                                        </span>
                                                    </TableCell>
                                                    <TableCell align="right">{benefitDeductItem.numberOfPayPeriod}</TableCell>
                                                    <TableCell align="right">{benefitDeductItem.annualDiscountPerentage}%</TableCell>
                                                    <TableCell align="right">${benefitDeductItem.perPayPeriodCostGross}</TableCell>
                                                    <TableCell align="right">${benefitDeductItem.perPayPeriodCostNet}</TableCell>
                                                    <TableCell align="right">${benefitDeductItem.annualCostGross}</TableCell>
                                                    <TableCell align="right">${benefitDeductItem.annualCostNet}</TableCell>
                                                </TableRow>
                                            ))}
                                        </TableBody>
                                    </Table>


                                </TableContainer>
                            </ExpansionPanelDetails>
                        </ExpansionPanel>


                    <br />
                <Paper style={{ padding: 5, borderRadius: " 15px 15px 15px 15px"}}>

                    <Grid container spacing={0} xs={12} style={{ padding: "0px 20px 0px 0px" }}>
                        <Grid item xs={8} >
                            <strong>Benefit Deductions:</strong>
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right", whiteSpace: "nowrap" }}>
                            <strong>Per Pay Period</strong>
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right", whiteSpace: "nowrap" }}>
                            <strong>Annually</strong>
                        </Grid>
                    </Grid>
                    <Grid container spacing={0} xs={12} style={{ padding: "0px 20px 0px 0px", whiteSpace: "nowrap"}}>
                        <Grid item xs={7} />
                        <Grid item xs={1} style={{ textAlign: "right" }} >
                            Total Gross:
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            ${this.state.perPayPeriodTotalCostGross}
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            ${this.state.annualTotalCostGross}
                        </Grid>
                    </Grid>
                    <Grid container spacing={0} xs={12} style={{ padding: "0px 20px 0px 0px", whiteSpace: "nowrap" }}>
                        <Grid item xs={7} />
                        <Grid item xs={1} style={{ textAlign: "right" }}>
                                Total Net:
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            ${this.state.perPayPeriodTotalCostNet}
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            ${this.state.annualTotalCostNet}
                        </Grid>

                    </Grid>
                    <Grid container spacing={0} xs={12} style={{ padding: "0px 20px 0px 0px" }}>
                        <Grid item xs={8} >
                            <strong>Salary:</strong> $ {this.state.employeeSalary}
                        </Grid>

                    </Grid>
                    <Grid container spacing={0} xs={12} style={{ padding: "0px 20px 0px 0px", whiteSpace: "nowrap" }}>
                        <Grid item xs={7} />
                        <Grid item xs={1} style={{ textAlign: "right" }} >
                            Salary Ajustment:
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            ${this.state.perPayPeriodSalaryAjustment}
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            ${this.state.annualSalaryAjustment}
                        </Grid>
                    </Grid>

                </Paper>
                <div style={{ textAlign: "center", padding: 10 }}>
                    <Button
                        onClick={this.handleOnClose}
                        type="button"
                        variant="contained"
                        color="primary"
                        style={{ borderRadius: 25}}
                    >
                        <CloseIcon />
                        Close
                    </Button>
                </div>

            </Grid>
            
		);
	};

    handleOnClose = () => {
        GlobalUserExperience.FamilyMembersExpandDetail = true;

        this.props.onCancel();
    }
    handleChangeFamilyMembersDetailExpand = () => {

        GlobalUserExperience.FamilyMembersExpandDetail = (GlobalUserExperience.FamilyMembersExpandDetail === false); 
        let ToggleState = (this.state.familyMembersExpandDetail === false);

        this.setState({ familyMembersExpandDetail: ToggleState });
    }

    populateDeductionDetail() {

        return fetch("http://localhost:54162/api/benefitdeductions/" +this.state.selectedEmployeeId )
            .then(resp => resp.json())
            .then(benefitDeductionList => {
                this.setState({
                    annualTotalCostGross: benefitDeductionList.annualTotalCostGross,
                    annualTotalCostNet: benefitDeductionList.annualTotalCostNet,
                    annualSalaryAjustment: benefitDeductionList.annualSalaryAjustment,
                    perPayPeriodTotalCostGross: benefitDeductionList.perPayPeriodTotalCostGross,
                    perPayPeriodTotalCostNet: benefitDeductionList.perPayPeriodTotalCostNet,
                    perPayPeriodSalaryAjustment: benefitDeductionList.perPayPeriodSalaryAjustment,
                    benefitDeductionItems: benefitDeductionList.benefitDeductionItems,
                    employeeSalary: benefitDeductionList.employeeSalary
                });
            });
    }
}




export default BenefitDeductionDetail;
