#pragma checksum "C:\Users\Alex\source\repos\SZ\ModalWindowComponent\ModalWindow.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba80c1a378dd9ce312300521adb68e04a748eb3c"
// <auto-generated/>
#pragma warning disable 1591
namespace ModalWindowComponent
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\Alex\source\repos\SZ\ModalWindowComponent\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
    public partial class ModalWindow : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", (
#line 3 "C:\Users\Alex\source\repos\SZ\ModalWindowComponent\ModalWindow.razor"
             Texts.ModalContainerClass

#line default
#line hidden
            ) + " " + (
#line 3 "C:\Users\Alex\source\repos\SZ\ModalWindowComponent\ModalWindow.razor"
                                         IsVisible ? Texts.ModalActiveContainerClass : string.Empty

#line default
#line hidden
            ));
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddContent(3, 
#line 4 "C:\Users\Alex\source\repos\SZ\ModalWindowComponent\ModalWindow.razor"
     Content

#line default
#line hidden
            );
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 7 "C:\Users\Alex\source\repos\SZ\ModalWindowComponent\ModalWindow.razor"
       
    protected bool IsVisible { get; set; }
    protected RenderFragment Content { get; set; }

    protected override void OnInitialized()
    {
        _service.OnShow += ShowModal;
        _service.OnClose += CloseModal;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (IsVisible == false)
        {
            _service.ClosedCall().Wait();
        }
        else
        {
            _service.ShowedCall().Wait();
        }
    }

    public Task ShowModal(RenderFragment content)
    {
        Content = content;
        IsVisible = true;

        return InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }

    public Task CloseModal()
    {
        IsVisible = false;
        Content = null;

        return InvokeAsync(() =>
        {
            StateHasChanged();
        });
    }

    public void Dispose()
    {
        _service.OnShow -= ShowModal;
        _service.OnClose -= CloseModal;
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ModalWindowService _service { get; set; }
    }
}
#pragma warning restore 1591