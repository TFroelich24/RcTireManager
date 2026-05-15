using Microsoft.AspNetCore.Components;
using MudBlazor;
using RcTireManager.Data.DTO;

namespace RcTireManager.Components.Dialogs
{
    public partial class EditItemDialog
    {
        [CascadingParameter]
        MudDialog MudDialogInstance { get; set; }
        DialogResult _result;


        [Parameter]
        public BaseItemDTO? Item { get; set; }

        public EditItemDialog()
        {
        }

        private void Cancel(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
        {
            _result = DialogResult.Cancel();            
        }
        private void Submit(Microsoft.AspNetCore.Components.Web.MouseEventArgs args)
        {
            //_result = DialogResult.Ok();
        }
    }
}   