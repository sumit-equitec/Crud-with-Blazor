using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class EmployeeService
    {
        private readonly DapperDBContext _employee;

        public EmployeeService(DapperDBContext employee)
        {
            _employee = employee;
        }

        //public async Task<List<Models.GetAllEmployeesResult>> Get()
        //{
        //    List<Models.GetAllEmployeesResult> employees = await _employee.Procedures.GetAllEmployeesAsync();
        //    return employees;
        //}

        public async Task<List<Models.GetAllEmployeesResult>> Get()
        {
            List<GetAllEmployeesResult> rawData = await _employee.Procedures.GetAllEmployeesAsync();

            return rawData;
        }

        public async Task<List<GetEmployeeWithSkillsResult>> GetAllSkills(int EmpId)
        {
            // Call your stored procedure or SQL query to get data
            return await _employee.Procedures.GetEmployeeWithSkillsAsync(EmpId);

            // Transform raw data to your custom model

        }

        public async Task<List<GetAllSkillsResult>> GetSkillsOnly()
        {
            // Call your stored procedure or SQL query to get data
            return await _employee.Procedures.GetAllSkillsAsync();

            // Transform raw data to your custom model

        }

        public async Task<Models.GetEmployeeByIdResult> GetEmpByID(int ID)
        {
            List<Models.GetEmployeeByIdResult> employee = await _employee.Procedures.GetEmployeeByIdAsync(ID);
            return employee.FirstOrDefault();
        }
        //public async Task<List<Models.GetDeletedRecordsResult>> GetDeleted()
        //{
        //    List<Models.GetDeletedRecordsResult> employees = await _employee.Procedures.GetDeletedRecordsAsync();
        //    return employees;
        //}

        // Method to insert a new employee
        private List<GetAllEmployeesResult>? Employees;
        public async Task<int> InsertEmployee(string name, string department, int age, int salary, string skills, List<int> skillIds)
        {
            try
            {
                // Call the stored procedure or SQL query to insert the employee
                int affectedRows = await _employee.Procedures.InsertEmployeeAsync(name, department, age, salary, skills);

                int EmpId = 0;
                foreach (var employee in skillIds)
                {
                    Employees = await _employee.Procedures.GetAllEmployeesAsync();

                    var employeeId = Employees.Where(emp => emp.EName == name && emp.DeptName == department && emp.Age == age && emp.Salary == salary) // Apply the 'Where' condition
                      .Select(emp => emp.EmpID).FirstOrDefault();
                    EmpId = employeeId;
                    break;



                }
                foreach (var skillId in skillIds)
                {
                    await _employee.Procedures.InsertEmployeeSkillByIdAsync(EmpId, skillId);
                }

                return affectedRows;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, notify, etc.)
                Console.WriteLine($"An error occurred while inserting an employee: {ex.Message}");
                throw; // Rethrow the exception if needed
            }
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            return await _employee.Skills.ToListAsync();
        }


        //public async Task<int> InsertEmployee(int EmpId, string name, string department, int age, int salary, string skill)
        //{
        //    try
        //    {
        //        // Call the stored procedure or SQL query to insert the employee
        //        int employeeId = await _employee.Procedures.InsertEmployeeAsync(name, department, age, salary, skill);

        //        // Insert selected skills into the EmployeeSkill table
        //        foreach (var skillId in selectedSkillIds)
        //        {
        //            await _employee.Procedures.InsertEmployeeSkillAsync(EmpId, skillId);
        //        }

        //        return employeeId; // Return the newly inserted employee ID
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception (log, notify, etc.)
        //        Console.WriteLine($"An error occurred while inserting an employee: {ex.Message}");
        //        throw; // Rethrow the exception if needed
        //    }
        //}



        public async Task<int> DeleteRecord(int EmpID)
        {
            try
            {
                // Call the stored procedure or SQL query to delete the employee
                int affectedRows = await _employee.Procedures.SoftDeleteRecordAsync(EmpID);

                return affectedRows;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, notify, etc.)
                Console.WriteLine($"An error occurred while deleting an employee: {ex.Message}");
                throw; // Rethrow the exception if needed
            }
        }

        public async Task<List<Models.GetDeletedRecordsResult>> GetDeleted()
        {
            List<Models.GetDeletedRecordsResult> employees = await _employee.Procedures.GetDeletedRecordsAsync();
            return employees;
        }


        public async Task<int> GetBackEmployee(int EmpID)
        {
            try
            {
                // Call the stored procedure or SQL query to delete the employee
                int affectedRows = await _employee.Procedures.GetBackDeletedRecordAsync(EmpID);

                return affectedRows;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, notify, etc.)
                Console.WriteLine($"An error occurred while deleting an employee: {ex.Message}");
                throw; // Rethrow the exception if needed
            }
        }
        private List<GetAllEmployeesResult>? Employees1;
        public async Task<int> Update(int EmpID, string EName, string DeptName, int? Age, int? Salary, string Skills, List<int>? skillIds)
        {
            try
            {
                // Call the stored procedure or SQL query to delete the employee
                int affectedRows = await _employee.Procedures.UpdateEmpAsync(EmpID, EName, DeptName, Age, Salary, Skills);

                await _employee.Procedures.DeletPastSkillsAsync(EmpID);
                int EmpId = 0;
                foreach (var employee in skillIds)
                {
                    Employees1 = await _employee.Procedures.GetAllEmployeesAsync();

                    var employeeId = Employees1.Where(emp => emp.EName == EName && emp.DeptName == DeptName && emp.Age == Age && emp.Salary == Salary) // Apply the 'Where' condition
                      .Select(emp => emp.EmpID).FirstOrDefault();
                    EmpId = employeeId;
                    break;



                }
                foreach (var skillId in skillIds)
                {
                    await _employee.Procedures.InsertEmployeeSkillByIdAsync(EmpId, skillId);
                }

                return affectedRows;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, notify, etc.)
                Console.WriteLine($"An error occurred while deleting an employee: {ex.Message}");
                throw; // Rethrow the exception if needed
            }
        }
        public async Task<GetEmployeeByResult?> GetEmployeeDetailsAsync(int empId)
        {
            // Call your stored procedure or data access method to get details by ID
            List<GetEmployeeByResult> details = await _employee.Procedures.GetEmployeeByAsync(empId);

            // Return the first item or null if the list is empty
            return details.FirstOrDefault();
        }

        // Inside your EmployeeService class
        public async Task<List<GetSelectedSkillsResult?>> GetSelectSkills(int empId)
        {
            // Call your stored procedure or data access method to get details by ID
            List<GetSelectedSkillsResult> details = await _employee.Procedures.GetSelectedSkillsAsync(empId);

            // Return the first item or null if the list is empty
            return details;
        }
    }
}
