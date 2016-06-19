﻿using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.BaseDataModels;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
     public   class EmployeeService : IEmployeeService
    {

        #region 'Private and Constructor'
        private readonly IEmployeeRepository employeeRepository;
         private readonly IDesignationRepository designationRepository;
         private readonly IEmployeeSupervisorRepository employeeSupervisorRepository;
         private readonly IAspNetRoleRepository aspNetRoleRepository;
         private readonly ITicketRepository ticketRepository;


         public EmployeeService(IEmployeeRepository EmployeeRepository,IDesignationRepository designationRepository,IEmployeeSupervisorRepository employeeSupervisorRepository,IAspNetRoleRepository aspNetRoleRepository, ITicketRepository ticketRepository)
         {
             this.employeeRepository = EmployeeRepository;
             this.designationRepository = designationRepository;
             //this.employeeSupervisorRepository = employeeSupervisorRepository;
             this.aspNetRoleRepository = aspNetRoleRepository;
             //this.ticketRepository = ticketRepository;
         }

         #endregion 'Private and Constructor'

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAll();
        }

        public EmployeeBaseData GetEmployeeData(int? employeeId)
        {
            EmployeeBaseData baseData = new EmployeeBaseData();
            if (employeeId != null)
            {
                var empId = (int) employeeId;
                baseData.Employee = employeeRepository.Find(empId);
            }
                
            baseData.Designation = designationRepository.GetAll();

            baseData.Role = aspNetRoleRepository.GetAll();

            return baseData;

            
        }

        public bool SaveEmployee(EmployeeBaseData employeeData)
         {
             if (employeeData.Employee.EmployeeId > 0)
             {
                 employeeRepository.Update(employeeData.Employee);
             }
             else
             {
                 employeeRepository.Add(employeeData.Employee);
             }
             employeeRepository.SaveChanges();

            //SaveEmployeeSupervisors(employeeData);

            return true;
         }

         private void SaveEmployeeSupervisors(EmployeeBaseData employeeData)
         {
             if (employeeData.Employee.EmployeeId > 0)
             {
                 var supervisors = employeeSupervisorRepository.GetSupervisorsByEmployeeId(employeeData.Employee.EmployeeId);

                 foreach (var employeeSupervisors in supervisors)
                 {
                     employeeSupervisorRepository.Delete(employeeSupervisors);
                 }
                 //employeeSupervisorRepository.SaveChanges();
             }
             if (employeeData.EmployeeSupervisors != null && employeeData.EmployeeSupervisors.Any())
             {
                 foreach (var employeeSupervisor in employeeData.EmployeeSupervisors)
                 {
                     employeeSupervisor.EmployeeId = employeeData.Employee.EmployeeId;

                     employeeSupervisorRepository.Add(employeeSupervisor);
                 }
             }
             employeeSupervisorRepository.SaveChanges();
         }
    }
}
