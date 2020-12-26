using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Texnomic.Blazor.JsonViewer
{
    public class JsonViewerBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        public string ID { get; private set; }

        public JsonViewerBase()
        {
            ID = Guid.NewGuid().ToString().Replace("-", "");
        }

        public ValueTask Render(string json)
        {
            return JsRuntime.InvokeVoidAsync("Texnomic.Blazor.JsonViewer.SetData", ID, json);
        }

        public ValueTask Collapse(string filter)
        {
            return JsRuntime.InvokeVoidAsync("Texnomic.Blazor.JsonViewer.Collapse", ID, filter);
        }

        public ValueTask Expand(string filter)
        {
            return JsRuntime.InvokeVoidAsync("Texnomic.Blazor.JsonViewer.Expand", ID, filter);
        }

        public ValueTask Filter(string filter)
        {
            return JsRuntime.InvokeVoidAsync("Texnomic.Blazor.JsonViewer.Filter", ID, filter);
        }

    }
}
