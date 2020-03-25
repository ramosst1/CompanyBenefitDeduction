import React, { Component } from 'react';
import BenefitDeductionDetail from './BenefitDeductionDetail'

class Employees extends Component {


    constructor(props) {
        super(props);
        this.state = {
            employees: [],
            keyEmployeeKey: 0,
            selectedEmployee: null,
            openBenefitDeductionDetail: false
        };

    }

    render() {
        return (
            <div >
                <h1>Employees</h1>

                <table className='table' style={{ width: '40%', float: 'left'}}>
                    <thead>
                        <tr>
                            <th>Employee Id</th>
                            <th>Employee Name</th>
                            <th>Employee Type</th>
                            <th>Benefit Deduction</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.employees.map(employee =>
                            <tr key={employee.employeeId}>
                                <td>{employee.employeeId}</td>
                                <td>{employee.firstName} {employee.lastName}</td>
                                <td>
                                    {employee.isExempt === true? 'Exempt' : 'NonExempt'}
                                </td>
                                <td>
                                    <button onClick={() => this.handleBenefitDeduction(employee)} >view</button>
                                </td>
                            </tr>
                        )}

                    </tbody>
                </table>
                <table className='table' style={{ width: '60%', float: 'left' }} >
                    <tr>
                        <td style={{ paddingLeft: 15, verticalAlign:"top" }}>

                            {this.state.openBenefitDeductionDetail ?
                                <div>
                                    <div><strong>Benefit Deduction Detail:</strong></div>
                                    <BenefitDeductionDetail
                                        key={this.state.keyEmployeeKey}
                                        employee={this.state.selectedEmployee}
                                        onCancel={this.handleProfileDetailClose}

                                    />

                                </div>
                                : null}



                            </td>
                        </tr>
                </table>

            </div>
        );


    }


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
            selectedEmployee: null
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


