using System;
using System.Collections.Generic;

namespace LCore.Models
{
    public partial class ContactoImagen
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaEditado { get; set; }
        public string Nota { get; set; }
        public bool Activo { get; set; }

        public virtual Contacto Contacto { get; set; }
    }
}
