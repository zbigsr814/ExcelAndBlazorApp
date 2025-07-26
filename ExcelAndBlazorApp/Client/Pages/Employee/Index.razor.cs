using ExcelAndBlazorApp.Shared.Dtos;
using System.Net.Http.Json;

namespace ExcelAndBlazorApp.Client.Pages.Employee
{
    public partial class Index
    {
        private EmployeeDto[] employees;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            employees = await Http.GetFromJsonAsync<EmployeeDto[]>("api/employees");
            StateHasChanged();
        }
    }
}
