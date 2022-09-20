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
    public class ListaMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        [BindProperty]
        public IEnumerable<Mascota> listaMascotas {get;set;}      

        public string Filtro {get;set;}      

        public ListaMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }

        public void OnGet()
        {
            listaMascotas = _repoMascota.GetAllMascotas();
        }

         public IActionResult OnPost(string? Filtro)
        {
            if (Filtro == "")
            {
                return Page();     
            }
            else
            {
                listaMascotas = _repoMascota.GetMascotasPorFiltro(Filtro);
            }
            return Page();
        }

        public async Task Limpiar()
        {
            Filtro = string.Empty;
        }

    }
}





