using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlClientes.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Teléfono es Obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La Cédula es Obligatoria.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "La Fecha Nacimineto es Obligatorio.")]
        public DateTime FechaNacimineto { get; set; }
         
        [ForeignKey("ClienteId")]
        public virtual List<Direccion> Direciones { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            FechaNacimineto = DateTime.Now;
            Direciones = new List<Direccion>();
        }
    }
}
