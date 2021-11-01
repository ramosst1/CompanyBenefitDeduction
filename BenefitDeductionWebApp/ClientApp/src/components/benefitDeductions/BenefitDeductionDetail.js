import React, { Component } from 'react';
import './BenefitDeductionDetail.css'
import { Button, Grid, Paper } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core';
import { ExpansionPanel, ExpansionPanelDetails, ExpansionPanelSummary } from '@material-ui/core';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';

const GlobalUserExperience = {

    FamilyMembersExpandDetail: true,
    BenefitDeductionExpandDetail: true
}


class BenefitDeductionDetail extends Component {

       constructor(props) {
        super(props);


        this.state = {
            uxFirstName: this.props?.employee?.firstName ?? '',
            uxLastName: this.props?.employee?.lastName ?? '',
            employee: null,
            selectedEmployeeId: this.props?.employee?.employeeId ?? 0,
            benefitDeduction: null,
            annualTotalCostGross: .00,
            annualTotalCostNet: .00,
            annualSalaryAjustment: .00,
            perPayPeriodTotalCostGross: .00,
            perPayPeriodTotalCostNet: .00,
            perPayPeriodSalaryAjustment: .00,
            perPayPeriodBenefitAjustment: .00,
            expandDetailChanged: true,
            employeeSalary: .00,
            employeeSalaryPerPayPeriod: .00,
            benefitDeductionItems: []

        };

        if (props.employee === null) return;

        this.populateDeductionDetail()

    }

	render() {

        const { firstName, lastName } = this.props.employee;

        return (
            <Grid className="root" xs={12} style={{ borderRadius: "15px" }}>
                <strong>Employee</strong> {firstName} {lastName}
                <br/><br/>
                <ExpansionPanel expanded={GlobalUserExperience.FamilyMembersExpandDetail}
                    onClick={() => this.handleExpandDetailSection('FamilyMembers')}
                    style={{ borderRadius: "15px" }} 
                >
                    <ExpansionPanelSummary
                        expandIcon={<ExpandMoreIcon color="primary" />}
                        aria-controls="panel1bh-content"
                        id="panel1bh-header"
                        className="root"
                        style={{ borderRadius: " 15px", padding: 5 }}
                        
                    >

                        <Grid container xs={12}>
                            <Grid item xs={4} >
                                <strong>Family Members</strong>
                            </Grid>
                            <Grid item xs={4} >
                                <strong>Number of Beneficiaries</strong> {this.state.benefitDeductionItems.length}
                            </Grid>
                        </Grid>

                    </ExpansionPanelSummary>
                        <ExpansionPanelDetails style={{ borderRadius: "15px" }}>
                            <TableContainer style={{ padding: 0, borderRadius: "15px" }}>

                            <Table aria-label="Benefit Deductions List" component={Paper} size="small">
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

                                    <TableRow style={{ backgroundColor: "#f6f6f6de" }}>
                                        <TableCell ><strong>Grand Total</strong></TableCell>
                                        <TableCell align="right" >______</TableCell>
                                        <TableCell align="right" >______</TableCell>
                                        <TableCell align="right" >${this.state.perPayPeriodTotalCostGross}</TableCell>
                                        <TableCell align="right" >${this.state.perPayPeriodTotalCostNet}</TableCell>
                                        <TableCell align="right" >${this.state.annualTotalCostGross}</TableCell>
                                        <TableCell align="right" >${this.state.annualTotalCostNet}</TableCell>
                                    </TableRow>


                                    </TableBody>
                                </Table>


                            </TableContainer>
                        </ExpansionPanelDetails>
                </ExpansionPanel>
                <br/>
                <ExpansionPanel expanded={GlobalUserExperience.BenefitDeductionExpandDetail}
                    onClick={() => this.handleExpandDetailSection('BenefitDeduction')}
                    style={{ borderRadius: "15px" }}
                >
                    <ExpansionPanelSummary
                        expandIcon={<ExpandMoreIcon color="primary" />}
                        aria-controls="panel1bh-content"
                        id="panel1bh-header"
                        className="root"
                        style={{ borderRadius: " 15px", padding: 5 }}
                    >

                        <Grid container xs={12}>
                            <strong>Benefit Deduction Detail</strong>
                        </Grid>

                    </ExpansionPanelSummary>
                    <ExpansionPanelDetails style={{ borderRadius: "15px" }}>

                            <TableContainer style={{ padding: 0, borderRadius: "15px" }}>

                            <Table aria-label="Benefit Deductions List" component="th" size="small">
                                    <TableHead >
                                        <TableRow className="dataTableHeader" >
                                            <TableCell ></TableCell>
                                            <TableCell align="right" >Annual <br/>Deductions</TableCell>
                                        <TableCell align="right" >Pay Period <br />Deduction</TableCell>
                                        <TableCell align="right" >Paid Period <br />Discount Adjustment</TableCell>
                                        <TableCell align="right" >Pay Period <br />Total</TableCell>
                                        <TableCell align="right" >Annual <br />Total</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody >
                                        <TableRow style={{ backgroundColor: "#f6f6f6de" }}>
                                            <TableCell colSpan="4">
                                                <strong>Salary</strong>
                                            </TableCell>
                                            <TableCell align="right">
                                                ${this.state.employeeSalaryPerPayPeriod}
                                            </TableCell >
                                            <TableCell align="right">
                                                    ${this.state.employeeSalary}
                                                </TableCell>
                                            </TableRow>
                                        <TableRow style={{ backgroundColor: "#f6f6f6de" }}>
                                            <TableCell xs={6} ><strong>Benefit Deductions</strong></TableCell>
                                        <TableCell align="right" >
                                            ${this.state.annualTotalCostGross}
                                        </TableCell>
                                            <TableCell align="right" >
                                                ${this.state.perPayPeriodTotalCostGross}
                                            </TableCell>
                                            <TableCell align="right" >
                                                {this.state.perPayPeriodTotalCostGross === this.state.perPayPeriodTotalCostNet? "______" : 
                                                    "$" + this.state.perPayPeriodTotalCostNet
                                                }
                                            </TableCell>
                                            <TableCell align="right"  >
                                                (${this.state.perPayPeriodBenefitAjustment})
                                            </TableCell>
                                            <TableCell align="right">
                                                (${this.state.annualTotalCostNet})
                                            </TableCell>
                                        </TableRow>
                                        <TableRow style={{ backgroundColor: "#f6f6f6de" }}>
                                            <TableCell colSpan="3"><strong>Grand Total</strong></TableCell>
                                            <TableCell />
                                        <TableCell align="right">
                                            ${this.state.perPayPeriodSalaryAjustment}
                                        </TableCell>
                                            <TableCell align="right">
                                                ${this.state.annualSalaryAjustment}
                                            </TableCell>

                                        </TableRow>


                                    </TableBody>
                                </Table>


                            </TableContainer>
                            {/*${this.state.perPayPeriodSalaryAjustment}*/}

                    </ExpansionPanelDetails>
                </ExpansionPanel>

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
        this.resetExpandedDefaultState();
    }

    resetExpandedDefaultState = () => {
        GlobalUserExperience.FamilyMembersExpandDetail = true;
        GlobalUserExperience.BenefitDeductionExpandDetail = true;

        this.props.onCancel();

    }

    handleExpandDetailSection = (panel) => {

        switch (panel) {
            case 'FamilyMembers':
                GlobalUserExperience.FamilyMembersExpandDetail = (GlobalUserExperience.FamilyMembersExpandDetail === false);
                break;
            case 'BenefitDeduction':
                GlobalUserExperience.BenefitDeductionExpandDetail = (GlobalUserExperience.BenefitDeductionExpandDetail === false);
                break;
        }


        let ToggleState = (this.state.expandDetailChanged === false);

        this.setState({ expandDetailChanged: ToggleState });
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
                    perPayPeriodBenefitAjustment: benefitDeductionList.perPayPeriodBenefitAjustment,
                    benefitDeductionItems: benefitDeductionList.benefitDeductionItems,
                    employeeSalary: benefitDeductionList.employeeSalary,
                    employeeSalaryPerPayPeriod: benefitDeductionList.employeeSalaryPerPayPeriod
                });
            });
    }
}




export default BenefitDeductionDetail;
