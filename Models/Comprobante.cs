using System;
using System.Collections.Generic;

namespace Lcore.Models
{
    public partial class Comprobante
    {
        public int Id { get; set; }
        public int LocalidadId { get; set; }
        public string Nombre { get; set; }
        public string Acronimo { get; set; }
        public bool Discrimina { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaEditado { get; set; }
        public string Nota { get; set; }
        public bool Activo { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
