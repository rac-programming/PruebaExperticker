using PruebaExperticker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace PruebaExperticker.Client.Pages.Personas
{
    public partial class AddPersona
    {
        public Persona persona = new Persona();
        public string error;
        public bool loading;

        protected async Task Submit()
        {
            loading = true;
            try
            {
                error = "";
                var per = persona;
                var res = await Http.PostAsJsonAsync("api/persona", per);
                nav.NavigateTo("/personas");
            }
            catch
            {
                error = "Compruebe la conexión y vuelva a intentarlo";
                this.StateHasChanged();
            }
            loading = false;
        }
    }
}
