using System;
using Microsoft.JSInterop;

namespace TangyWeb_Server.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrErrorSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);

        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr","error", message);

        }
    }
}

