using Employee.Models;
using Microsoft.AspNetCore.Components;


namespace Employee.Pages
{
    public partial class FetchdataEmp
    {

        private List<GetAllEmployeesResult>? Employees;
        private List<GetEmployeeWithSkillsResult>? Skills;// Remove nullable operator
        public Dictionary<int,string> Result=new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Employees = await EmployeeService.Get();
                foreach (var employee in Employees)
                {
                    Skills = await EmployeeService.GetAllSkills(employee.EmpID);
                   
                        var user = Skills.Select(sk => sk.SkillName);
                        Result[employee.EmpID] = string.Join(", ", user);
                    
                }


            }
            catch (Exception ex)
            {
                // Handle exception (log, display error, etc.)
                Console.WriteLine($"An error occurred while fetching employees: {ex.Message}");
            }

        }


        private async Task DeleteEmployee(int employeeId)
        {
            // Show confirmation dialog if needed...

            // Call the DeleteEmployeeAsync method from EmployeeService
            int affectedRows = await EmployeeService.DeleteRecord(employeeId);

            // After deletion, refresh the employee list
           
                Employees = await EmployeeService.Get();
            
        }


        
         private async Task UpdateEmployee(int EmpId)
        {
            // Show confirmation dialog if needed...

            // Call the DeleteEmployeeAsync method from EmployeeService
            NavigationManager.NavigateTo($"/update/{EmpId}");

            // After deletion, refresh the employee list


        }

        private async Task DetailEmployee(int EmpId)
        {
            // Show confirmation dialog if needed...

            // Call the DeleteEmployeeAsync method from EmployeeService
            NavigationManager.NavigateTo($"/details/{EmpId}");

            // After deletion, refresh the employee list


        }


    }
}
