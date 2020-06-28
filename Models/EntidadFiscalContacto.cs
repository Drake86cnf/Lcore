using System;
using System.Collections.Generic;

namespace Lcore.Models
{
    public partial class EntidadFiscalContacto
    {
        public int EntidadFiscalId { get; set; }
        public int ContactoId { get; set; }

        public virtual Contacto Contacto { get; set; }
        public virtual EntidadFiscal EntidadFiscal { get; set; }
    }
}
