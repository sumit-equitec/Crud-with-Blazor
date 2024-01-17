﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Employee.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Models
{
    public partial interface IDapperDBContextProcedures
    {
        Task<List<DeletedRecordsResult>> DeletedRecordsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteEmployeeAsync(int? EmpID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetAllEmployeesResult>> GetAllEmployeesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> GetBackDeletedRecordAsync(int? EmpID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetDeletedRecordsResult>> GetDeletedRecordsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetEmployeeByResult>> GetEmployeeByAsync(int? EmpID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetEmployeeByIdResult>> GetEmployeeByIdAsync(int? EmpId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetPagedCountResult>> GetPagedCountAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetPagedEmpResult>> GetPagedEmpAsync(int? Offset, int? PageSize, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetPagedEmployeeResult>> GetPagedEmployeeAsync(int? Offset, int? PageSize, bool? IsDeleted, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertEmployeeAsync(string EName, string DeptName, int? Age, int? Salary, string Skills, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> SoftDeleteRecordAsync(int? EmpID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateEmpAsync(int? EmpID, string EName, string DeptName, int? Age, int? Salary, string Skills, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateEmployeeAsync(string EName, string DeptName, int? Age, int? Salary, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateEmployeeeAsync(int? EmpID, string EName, string DeptName, int? Age, int? Salary, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}