
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.Components.Modal;
public partial class Modal : IAsyncDisposable
{
    private readonly DotNetObjectReference<Modal> objRef;
    private ElementReference modalRef;

    public Modal()
    {
        objRef = DotNetObjectReference.Create(this);
    }

    [Inject] private IJSRuntime JS { get; set; }
    [Parameter] public string ModalId { get; set; }

    private bool _isOpen;
    [Parameter] public bool IsOpen { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (_isOpen != IsOpen)
        {
            _isOpen = IsOpen;
            await JS.InvokeVoidAsync("openModal", modalRef, _isOpen, objRef);
        }
    }
    [Parameter] public RenderFragment ModalTitle { get; set; }
    [Parameter] public RenderFragment ModalContent { get; set; }
    [Parameter] public RenderFragment ModalFooter { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }

    [JSInvokable]
    public async Task Close()
    {
        await OnClose.InvokeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if(IsOpen)
        {
            await JS.InvokeVoidAsync("openModal", modalRef, false, objRef);
        }
        objRef.Dispose();
    }
}
