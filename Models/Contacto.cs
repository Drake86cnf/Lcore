using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LCore.LCDT;

namespace LCore.Models
{
    public partial class Contacto
    {
        public Contacto()
        {
            EntidadFiscalContacto = new HashSet<EntidadFiscalContacto>();
        }

        public int Id { get; set; }
        [Display(Name = "Nº Identificacion")]
        public int? NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public short? Genero { get; set; }
        [Display(Name = "Documento")]
        public int TipoIdentificacionId { get; set; }
        [Display(Name = "Localidad")]
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

        [Display(Name = "Genero")]
        public string GetNombreGenero{
            get{
                switch(this.Genero){
                    case (short)LCDT.Generos.Masculino:
                        return "Masculino";
                    case (short)LCDT.Generos.Femenino:
                        return "Femenino";
                    case (short)LCDT.Generos.Otro:
                        return "Otro";
                    default: return "No identificado";
                }
            }

        }
        [Display(Name = "Nombre Completo")]
        public string GetNombreCompleto{
            get{
                var Result = this.Apellidos;
                
                if(Result.Length>0){
                    Result+=", "+ this.Nombres;
                }
                else {
                    Result = this.Nombres;
                }
                return Result;

            }
        }
    }
}
