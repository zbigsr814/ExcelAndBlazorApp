using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ExcelAndBlazorApp.Client.Pages.Employee
{
    public partial class WorkLog
    {
        [Parameter]
        public int Id { get; set; }

        private EmployeeDto employee;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            employee = await Http.GetFromJsonAsync<EmployeeDto>($"api/employees/work-logs/{Id}");
            StateHasChanged();
        }
    }
}
