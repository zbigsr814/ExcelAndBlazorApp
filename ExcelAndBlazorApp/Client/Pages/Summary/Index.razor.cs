using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ExcelAndBlazorApp.Client.Pages.Summary
{
    public partial class Index
    {
        private SummaryDto[] summary;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            summary = await Http.GetFromJsonAsync<SummaryDto[]>("api/summary");
            StateHasChanged();
        }
    }
}
