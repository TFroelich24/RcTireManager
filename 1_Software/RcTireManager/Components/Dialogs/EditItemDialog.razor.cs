using Microsoft.AspNetCore.Components;
using MudBlazor;
using RcTireManager.Data.DTO;
using RcTireManager.Interfaces.Viewmodels;

namespace RcTireManager.Components.Dialogs
{
    public partial class EditItemDialog
    {
        [Inject]
        private IViewModelEditItemDialog ViewModel { get; set; } = null!;

        [CascadingParameter]
        IMudDialogInstance MudDialog { get; set; } = null!;

        [Parameter]
        public BaseItemDTO? Item { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ViewModel.Item = Item;
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }

        private void Submit()
        {
            MudDialog.Close(DialogResult.Ok(ViewModel.Item));
        }
    }
}