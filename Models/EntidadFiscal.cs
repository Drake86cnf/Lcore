using System;
using System.Collections.Generic;

namespace Lcore.Models
{
    public partial class EntidadFiscal
    {
        public EntidadFiscal()
        {
            EntidadFiscalContacto = new HashSet<EntidadFiscalContacto>();
        }

        public int Id { get; set; }
        public string NumeroIdentificacionFiscal { get; set; }
        public int TipoIdentificacionId { get; set; }
        public int SituacionTributariaId { get; set; }
        public string Domicilio { get; set; }
        public int Comprobante { get; set; }
        public int LocalidadId { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaEditado { get; set; }
        public string Nota { get; set; }
        public bool Activo { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }

        public virtual Localidad Localidad { get; set; }
        public virtual SituacionTributaria SituacionTributaria { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual ICollection<EntidadFiscalContacto> EntidadFiscalContacto { get; set; }
    }
}
