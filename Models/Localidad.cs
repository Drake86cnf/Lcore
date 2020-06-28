using System;
using System.Collections.Generic;

namespace Lcore.Models
{
    public partial class Localidad
    {
        public Localidad()
        {
            Comprobante = new HashSet<Comprobante>();
            Contacto = new HashSet<Contacto>();
            EntidadFiscal = new HashSet<EntidadFiscal>();
            SituacionTributaria = new HashSet<SituacionTributaria>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public short? Parent { get; set; }
        public short? CodigoTelefonico { get; set; }
        public string Iso { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaEditado { get; set; }
        public string Nota { get; set; }
        public bool Activo { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string Iso2 { get; set; }
        public int? CodigoPostal { get; set; }

        public virtual ICollection<Comprobante> Comprobante { get; set; }
        public virtual ICollection<Contacto> Contacto { get; set; }
        public virtual ICollection<EntidadFiscal> EntidadFiscal { get; set; }
        public virtual ICollection<SituacionTributaria> SituacionTributaria { get; set; }
    }
}
