import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

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
            <div style={{ backgroundColor:'whitesmoke' }}>

                <table className='table' style={{ padding: '0, 0, 0, 10', backgroundColor: 'whitesmoke'}}>
                    <thead>
                        <tr>
                            <th>
                            </th>
                            <th style={{ textAlign: "right" }}>
                                Per Pay Period
                            </th>
                            <th style={{ textAlign: "right" }}>
                                Annually
                            </th>
                        </tr>
                    </thead>
                    <tbody>

                        <tr>
                            <td>Total Gross:</td>
                            <td style={{ textAlign: "right" }}>${this.state.perPayPeriodTotalCostGross}</td>
                            <td style={{ textAlign: "right" }}>${this.state.annualTotalCostGross}</td>
                        </tr>
                        <tr>
                            <td colSpan='3' style={{ padding:20}}>
                                <table className='table' style={{ backgroundColor: 'whitesmoke', padding: '0, 0, 0, 10' }}>
                                    <tr>
                                        <th style={{ verticalAlign: "top" }}>Family Member</th>
                                        <th style={{ textAlign: "right" }}># Pay <br />Periods</th>
                                        <th style={{ textAlign: "right", verticalAlign:"top" }}>Discount</th>
                                        <th style={{ textAlign: "right" }}>Pay Period <br/>Gross</th>
                                        <th style={{ textAlign: "right" }}>Pay Period <br/>Net</th>
                                        <th style={{ textAlign: "right" }}>Annual <br/>Gross</th>
                                        <th style={{ textAlign: "right" }}>Annual <br/>Net</th>
                                    </tr>
                                {this.state.benefitDeductionItems.map(benefitDeductItem =>
                                        <tr key={benefitDeductItem.familyMemberId} >
                                            <td>
                                                {benefitDeductItem.firstName} {benefitDeductItem.lastName}

                                                <span style={{ color: 'gray' }}>
                                                    {benefitDeductItem.isSpouse? ' (spouse)' :'' }
                                                    {benefitDeductItem.isChild ? ' (child)' : ''}
                                                </span>
                                            </td>
                                            <td style={{ textAlign: "right" }}>
                                                {benefitDeductItem.numberOfPayPeriod}
                                            </td>
                                            <td style={{ textAlign: "right" }}>
                                                ${benefitDeductItem.annualDiscountPerentage}
                                            </td>
                                            <td style={{ textAlign: "right" }}>
                                                ${benefitDeductItem.perPayPeriodCostGross}
                                            </td>
                                            <td style={{ textAlign: "right" }}>
                                                ${benefitDeductItem.perPayPeriodCostNet}
                                            </td>

                                            <td style={{ textAlign: "right" }}>
                                                ${benefitDeductItem.annualCostGross}
                                            </td>
                                            <td style={{ textAlign: "right" }}>
                                                ${benefitDeductItem.annualCostNet}
                                            </td>


                                    </tr>

                                )}
                                </table>

                            </td>
                        </tr>
 
                        <tr>
                            <td>Total Net:</td>
                            <td style={{ textAlign:"right" }}>${this.state.perPayPeriodTotalCostNet}</td>
                            <td style={{ textAlign: "right" }}>${this.state.annualTotalCostNet}</td>
                        </tr>
                    </tbody>

                </table>

                <div style={{ textAlign: "center", padding: 10 }}>
                    <button
                        onClick={this.props.onCancel}
                        type="button"
                    >
                        Close
                    </button>
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
