using MudBlazor;
using RcTireManager.Components.Dialogs;
using RcTireManager.Data.DTO;

namespace RcTireManager.Components.Pages
{
    public partial class Configuration
    {
        private async Task OpenEditDialog(BaseItemDTO item)
        {
            DialogParameters parameters = new DialogParameters<EditItemDialog>
            {
                { x => x.Item, item }
            };

            DialogOptions options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            IDialogReference dialog = await DialogService.ShowAsync<EditItemDialog>("Item bearbeiten", parameters, options);
            DialogResult? result = await dialog.Result;

            if (!result.Canceled && result.Data is BaseItemDTO updatedItem)
            {
                _viewModelConfiguration.Update(updatedItem);
            }
        }

    }
}