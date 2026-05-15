using Microsoft.AspNetCore.Components;
using MudBlazor;
using RcTireManager.Data.DTO;

namespace RcTireManager.Components.Dialogs
{
    public partial class EditItemDialog
    {
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; } = null!;

        [Parameter]
        public BaseItemDTO? Item { get; set; }

        private void Cancel()
        {
            MudDialog.Cancel();
        }

        private void Submit()
        {
            MudDialog.Close(DialogResult.Ok(Item));
        }
    }
}