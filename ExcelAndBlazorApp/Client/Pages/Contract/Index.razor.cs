using ExcelAndBlazorApp.Shared.Dtos;
using System.Net.Http.Json;

namespace ExcelAndBlazorApp.Client.Pages.Contract
{
    public partial class Index
    {
        private ContractDto[] contracts;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            contracts = await Http.GetFromJsonAsync<ContractDto[]>("api/contracts");
            StateHasChanged();
        }
    }
}
