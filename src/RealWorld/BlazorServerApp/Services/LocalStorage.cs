using BlazorServerApp.Models;
using Microsoft.JSInterop;

namespace BlazorServerApp.Services;

public class LocalStorage
{
    private readonly IJSRuntime JS;

    public LocalStorage(IJSRuntime jS)
    {
        JS = jS;
    }

    public async Task<string> GetItem(string key)
    {
        return await JS.InvokeAsync<string>("localStorage.getItem", key);
    }

    public async Task SetItem(string key, string value)
    {
        await JS.InvokeVoidAsync("localStorage.setItem", key, value);
    }
}
