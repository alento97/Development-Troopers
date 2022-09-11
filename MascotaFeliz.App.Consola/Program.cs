using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        static void Main(string[] args)
        
        {
            Console.WriteLine("Hello World!");

            //Listar
            //AddDueno();
            //AddVeterinario();

            //AddMascota();
            //ListarMascota();
            //ListarMascotas();
            //BuscarMascota(1);
            ListadoMascotas();

        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Juan",
                Apellidos = "Sin Miedo",
                Direccion = "Bajo un puente",
                Telefono = "1234567891",
                Email = "juansinmiedo@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Mariana",
                Apellidos = "Marín",
                Direccion = "Calle 20 #80-30",
                Telefono = "5345689513",
                TarjetaProfesional = "125327"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                
                Nombre = "Katy",
                Color = "Dorado",
                Especie = "Criolla",
                Raza = "Schnauzer y cocker spaniel"
                
                
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void BuscarMascota(int idMascota)
        {           
            var mascota =  _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
        }

        private static void ListadoMascotas()
        {
            Console.WriteLine("Nombre  Color  Especie  Raza");
            var Mascotas = _repoMascota.GetAllMascotas();
                foreach (Mascota i in Mascotas) {
                    Console.WriteLine(i.Nombre+" "+i.Color+" "+i.Especie+" "+i.Raza);
                }
        }

    }
}
