using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using MatBlazor;
using PruebaExperticker.Shared;

namespace PruebaExperticker.Client.Pages.Personas
{
    public partial class Personas
    {
        [Inject]
        protected IMatToaster Toaster { get; set; }

        protected IEnumerable<Persona> personas { get; set; }

 
        protected override async Task OnInitializedAsync()
        {

            //Al iniciar componente se hace petición a la API 
            await FetchData();
        }

        protected async Task Borrar(string dni) {
            try
            {
                await Http.DeleteAsync("api/persona/" + dni);
                await FetchData();
                StateHasChanged();
            }
            catch
            {

            }
        }

        protected async Task FetchData() {
            try
            {
                var res = await Http.GetFromJsonAsync<List<Persona>>("api/persona");
                personas = res;
            }
            catch
            {
                Toaster.Add("Compruebe conexión y reintente", MatToastType.Danger, "Error", MatIconNames.Error);

            }
        }
    }
}
