using System;
using System.Collections.Generic;

namespace LCore.Models
{
    public partial class Domicilio
    {
        public int Id { get; set; }
        public short Idrow { get; set; }
        public string Tabla { get; set; }
        public string Nombre { get; set; }
        public short Numero { get; set; }
        public short Piso { get; set; }
        public short Localidad { get; set; }
        public string Departamento { get; set; }
        public string Barrio { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaEditado { get; set; }
        public string Nota { get; set; }
        public bool Activo { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
    }
}
