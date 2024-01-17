using Employee.Models;

namespace Employee.Data
{
    public class EmployeeService
    {
        private readonly DapperDBContext _employee;

        public EmployeeService(DapperDBContext employee)
        {
            _employee = employee;
        }

        public async Task<List<Models.GetAllEmployeesResult>> Get()
        {
            List<Models.GetAllEmployeesResult> employees = await _employee.Procedures.GetAllEmployeesAsync();
            return employees;
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
        public async Task<int> InsertEmployeeAsync(string name, string department, int? age, int? salary, string skills)
        {
            try
            {
                // Call the stored procedure or SQL query to insert the employee
                int affectedRows = await _employee.Procedures.InsertEmployeeAsync(name, department, age, salary, skills);

                return affectedRows;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, notify, etc.)
                Console.WriteLine($"An error occurred while inserting an employee: {ex.Message}");
                throw; // Rethrow the exception if needed
            }
        }

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

        public async Task<int> Update(int EmpID, string EName, string DeptName, int? Age, int? Salary, string Skills)
        {
            try
            {
                // Call the stored procedure or SQL query to delete the employee
                int affectedRows = await _employee.Procedures.UpdateEmpAsync(EmpID, EName, DeptName,Age, Salary, Skills);

                return affectedRows;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, notify, etc.)
                Console.WriteLine($"An error occurred while deleting an employee: {ex.Message}");
                throw; // Rethrow the exception if needed
            }
        }

        // Inside your EmployeeService class
        public async Task<GetEmployeeByResult?> GetEmployeeDetailsAsync(int empId)
        {
            // Call your stored procedure or data access method to get details by ID
            List<GetEmployeeByResult> details = await _employee.Procedures.GetEmployeeByAsync(empId);

            // Return the first item or null if the list is empty
            return details.FirstOrDefault();
        }
    }
}
