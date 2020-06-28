using System;
using System.Collections.Generic;

namespace Lcore.Models
{
    public partial class Contacto
    {
        public Contacto()
        {
            EntidadFiscalContacto = new HashSet<EntidadFiscalContacto>();
        }

        public int Id { get; set; }
        public int? NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public short? Genero { get; set; }
        public int TipoIdentificacionId { get; set; }
        public int LocalidadId { get; set; }
        public int? ImagenId { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaEditado { get; set; }
        public string Nota { get; set; }
        public bool Activo { get; set; }

        public virtual ContactoImagen Imagen { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual ICollection<EntidadFiscalContacto> EntidadFiscalContacto { get; set; }
    }
}
