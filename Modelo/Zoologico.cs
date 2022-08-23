/**
 *  Clase zoologico
 *  @params: id - integer
 *  @params: pais - string
 *  @params: Nombre - string
 *  @params: Telefono - string
 *  @params: SitioWeb - string
 */
namespace tareaBase.Modelo
{
    public class Zoologico
    {
        public int id { get; set; }

        public string? Pais { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? SitioWeb { get; set; }

    }
}
