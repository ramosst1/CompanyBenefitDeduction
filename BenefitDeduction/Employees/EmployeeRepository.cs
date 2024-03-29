﻿using System;
using System.Collections.Generic;
using BenefitDeduction.Employees.FamilyMembers;
using BenefitDeduction.Employees.Exempts;

namespace BenefitDeduction.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private IFamilyMemberSpouseRepository _EmployeeSpouseRepos;
        private IFamilyMemberChildRepository _EmployeeChildRepos; 
        private IEmployeeExemptRepository _EmployeeExemptRepos;
        public EmployeeRepository(
            IFamilyMemberSpouseRepository employeeSpouseRepos, 
            IFamilyMemberChildRepository employeeChildRepos,
            IEmployeeExemptRepository employeeExemptRepos
        )
        {
            _EmployeeSpouseRepos = employeeSpouseRepos;
            _EmployeeChildRepos = employeeChildRepos;
            _EmployeeExemptRepos = employeeExemptRepos;
            
        }

        public IEmployee GetEmployeeById(int employeeId)
        {

            try
            {

                return _EmployeeExemptRepos.GetEmployeeById(employeeId);
            }
            catch (Exception e) {

                throw new Exception("Some error message");
            }

        }

        public List<IFamilyMember> GetFamilyMembers(IEmployee employee)
        {
            try
            {

                var FamilyMemberList = new List<IFamilyMember>();

                FamilyMemberList.AddRange(_EmployeeSpouseRepos.GetFamilyMembers(employee));

                FamilyMemberList.AddRange(_EmployeeChildRepos.GetFamilyMembers(employee));

                return FamilyMemberList;
             
          }
            catch (Exception e) {
                throw new Exception("Some error message");
            }
        }

        public List<IEmployee> GetEmployees() {

            var EmployeeList = new List<IEmployee>();

            EmployeeList
                .Add(new Employee() {
                    IsExempt = true,
                    EmployeeId = 1,
                    FirstName = "Andrew",
                    LastName = "Smith"
                    }
                );

            EmployeeList
                .Add(new Employee()
                {
                    IsExempt = true,
                    EmployeeId = 2,
                    FirstName = "Jill",
                    LastName = "Jackson"
                }
                );

            EmployeeList
                .Add(new Employee()
                {
                    IsExempt = true,
                    EmployeeId = 3,
                    FirstName = "Hector",
                    LastName = "Daniel"
                }
                );

            EmployeeList
                .Add(new Employee()
                {
                    IsExempt = true,
                    EmployeeId = 4,
                    FirstName = "James",
                    LastName = "Mankey"
                }
                );

            return EmployeeList;
        }
    }
}
