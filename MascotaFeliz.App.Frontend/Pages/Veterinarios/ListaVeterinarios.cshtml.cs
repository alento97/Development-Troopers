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
    public class ListaVeterinariosModel : PageModel
    {     
        private readonly IRepositorioVeterinario _repoVeterinario;
        [BindProperty]
        public IEnumerable<Veterinario> listaVeterinarios {get;set;}      
        public string Filtro {get;set;}      

        public ListaVeterinariosModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public void OnGet()
        {
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
        }

        public IActionResult OnPost(string? Filtro)
        {
            if (Filtro == "")
            {
                return Page();     
            }
            else
            {
                listaVeterinarios = _repoVeterinario.GetVeterinariosPorFiltro(Filtro);
            }
            return Page();
        }

        public async Task Limpiar()
        {
            Filtro = string.Empty;
        }

    }
}



