using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListaDuenosModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        [BindProperty]
        public IEnumerable<Dueno> listaDuenos {get;set;}      
        public string Filtro {get;set;}      

        public ListaDuenosModel()
        {
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        }

        public void OnGet()
        {
            listaDuenos = _repoDueno.GetAllDuenos();
        }

         public IActionResult OnPost(string? Filtro)
        {
            if (Filtro == "")
            {
                return Page();     
            }
            else
            {
                listaDuenos = _repoDueno.GetDuenosPorFiltro(Filtro);
            }
            return Page();
        }

        public async Task Limpiar()
        {
            Filtro = string.Empty;
        }


    }
}
