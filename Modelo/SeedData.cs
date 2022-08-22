using tareaBase.Data;
using Microsoft.EntityFrameworkCore;
using tareaBase.Modelo;

namespace tareaBase.Modelo
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tareaBaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tareaBaseContext>>()))
            {
                if (context == null || context.Zoologico == null)
                {
                    throw new ArgumentNullException("Null CryptoDemoContext");
                }


                if (context.Zoologico.Any())
                {
                    return;
                }

                context.Zoologico.AddRange(
                    new Zoologico
                    {
                        Pais = "Costa Rica",
                        Nombre = "Simon Bolivar",
                        Telefono = "+506 8597-3846",
                        SitioWeb = "www.simonbolivar.cr"
                    },

                    new Zoologico
                    {
                        Pais = "Panama",
                        Nombre = "El Nispero",
                        Telefono = "+507 983-6142",
                        SitioWeb = "www.elnispero.pa"
                    },

                    new Zoologico
                    {
                        Pais = "El Salvador",
                        Nombre = "Zoologico Nacional",
                        Telefono = "+503 2270 0828",
                        SitioWeb = "www.zoonacional.sv"
                    },

                    new Zoologico
                    {
                        Pais = "Honduras",
                        Nombre = "Zoo Joya Grande",
                        Telefono = "+504 3382-3919",
                        SitioWeb = "www.zoojoyagrande.hn"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}