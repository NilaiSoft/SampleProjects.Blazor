using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using SampleProjects.Client;
using SampleProjects.Client.Shared;

namespace SampleProjects.Client.Pages
{
    public partial class Counter
    {
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }

    }
}