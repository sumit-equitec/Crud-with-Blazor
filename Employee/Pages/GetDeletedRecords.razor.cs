using Employee.Models;

namespace Employee.Pages
{
    public partial class GetDeletedRecords
    {
        private List<GetDeletedRecordsResult>? Employees; // Remove nullable operator

        protected override async Task OnInitializedAsync()
        {
            Employees = await EmployeeService.GetDeleted();
        }

        private async Task GetBack(int employeeId)
        {
            // Show confirmation dialog if needed...

            // Call the DeleteEmployeeAsync method from EmployeeService
            int affectedRows = await EmployeeService.GetBackEmployee(employeeId);

            // After deletion, refresh the employee list

            NavigationManager.NavigateTo("/fetchdataEmp");

        }
    }
}
