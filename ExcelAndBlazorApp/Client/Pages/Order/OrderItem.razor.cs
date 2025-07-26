using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ExcelAndBlazorApp.Client.Pages.Order
{
    public partial class OrderItem
    {
        [Parameter]
        public int Id { get; set; }

        private OrderDto order;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            order = await Http.GetFromJsonAsync<OrderDto>($"api/orders/order-items/{Id}");
            StateHasChanged();
        }
    }
}
