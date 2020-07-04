using System;
using System.Collections.Generic;

namespace LCore.Models
{
    public partial class TipoIdentificacion
    {
        public TipoIdentificacion()
        {
            Contacto = new HashSet<Contacto>();
            EntidadFiscal = new HashSet<EntidadFiscal>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Acronimo { get; set; }
        public bool EsFiscal { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaEditado { get; set; }
        public string Nota { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Contacto> Contacto { get; set; }
        public virtual ICollection<EntidadFiscal> EntidadFiscal { get; set; }
    }
}
