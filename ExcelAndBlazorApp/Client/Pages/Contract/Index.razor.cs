using ExcelAndBlazorApp.Shared.Dtos;
using System.Net.Http.Json;

namespace ExcelAndBlazorApp.Client.Pages.Contract
{
    public partial class Index
    {
        private ContractDto[] contracts;
		private ContractDto _contractToDelete;
		public bool DeleteDialogOpen { get; set; }

		public void OpenDeleteDialog(ContractDto contract)
		{
			DeleteDialogOpen = true;
			_contractToDelete = contract;
			StateHasChanged();
		}

		public async Task OnDeleteDialogClose(bool accepted)
		{
			if (accepted)
			{
				await Http.DeleteAsync($"api/contracts/{_contractToDelete.Id}");
				await LoadData();
				_contractToDelete = null;
			}

			DeleteDialogOpen = false;
			StateHasChanged();
		}

		protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            contracts = await Http.GetFromJsonAsync<ContractDto[]>("api/contracts");
            StateHasChanged();
        }

		public async Task Refresh()
		{
			await LoadData();
		}
	}
}
