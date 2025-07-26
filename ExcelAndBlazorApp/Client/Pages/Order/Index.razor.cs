using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ExcelAndBlazorApp.Client.Pages.Order
{
    public partial class Index
    {
        private OrderDto[] orders;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            orders = await Http.GetFromJsonAsync<OrderDto[]>("api/orders");
            StateHasChanged();
        }
    }
}
