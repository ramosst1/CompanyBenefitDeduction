import React, { Component } from 'react';
import './BenefitDeductionDetail.css'
import { Button, Grid, Paper } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core';

class BenefitDeductionDetail extends Component {


    constructor(props) {
        super(props);

        const APropEmployee = this.props.employee;

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
            perPayPeriodTotalCostGross: 0,
            perPayPeriodTotalCostNet: 0,
            benefitDeductionItems: []

        };

        if (props.employee === null) return;

        this.populateDeductionDetail()

    }

	render() {
        return (
            <div className="root">
                <Paper style={{padding: 5}}>
                    <strong>Benefit Deductions:</strong>
                    <br /><br />
                    <Grid container spacing={0} xs={12} style={{ padding: "0px 20px 0px 0px" }}>
                        <Grid item xs={8} />
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            <strong>Per Pay Period</strong>
                        </Grid>
                        <Grid item xs={2} style={{ textAlign: "right" }}>
                            <strong>Annually</strong>
                        </Grid>
                    </Grid>
                    <Grid container spacing={0} xs={12} style={{padding: "0px 20px 0px 0px"}}>
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
                    <Grid container spacing={0} xs={12} style={{ padding: "0px 20px 0px 0px" }}>
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

                    <TableContainer style={{ padding: 0 }}>

                        <Table aria-label="Benefit Deductions List" component={Paper} >
                            <TableHead >
                                <TableRow className="dataTableHeader" >
                                        <TableCell >Family Member</TableCell>
                                        <TableCell align="right" ># Pay Periods</TableCell>
                                        <TableCell align="right">Discount</TableCell>
                                        <TableCell align="right">Pay Period Gross</TableCell>
                                        <TableCell align="right">Pay Period Net</TableCell>
                                        <TableCell align="right">Annual Gross</TableCell>
                                        <TableCell align="right">Annual Net</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {this.state.benefitDeductionItems.map(benefitDeductItem => (
                                    <TableRow key={benefitDeductItem.familyMemberId}>
                                        <TableCell component="th" scope="row" style={{ whiteSpace: "nowrap" }}>
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
                    <br/>
                </Paper>
                <div style={{ textAlign: "center", padding: 10 }}>
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

            </div>
            
		);
	};

     //componentDidUpdate(prevProps) {

     //}

    populateDeductionDetail() {

        return fetch("http://localhost:54162/api/benefitdeductions/" +this.state.selectedEmployeeId )
            .then(resp => resp.json())
            .then(benefitDeductionList => {
                this.setState({
                    annualTotalCostGross: benefitDeductionList.annualTotalCostGross,
                    annualTotalCostNet: benefitDeductionList.annualTotalCostNet,
                    perPayPeriodTotalCostGross: benefitDeductionList.perPayPeriodTotalCostGross,
                    perPayPeriodTotalCostNet: benefitDeductionList.perPayPeriodTotalCostNet,
                    benefitDeductionItems: benefitDeductionList.benefitDeductionItems

                });
            });
    }
}




export default BenefitDeductionDetail;
