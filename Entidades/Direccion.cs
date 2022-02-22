using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlClientes.Entidades
{
    public class Direccion
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese El Id de la Direccion")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La Calle es Obligatoria.")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "La El numero de la casa/Apartamento es Obligatorio.")]
        public string NumeroCasa { get; set; }

        [Required(ErrorMessage = "La Ciudad es Obligatoria.")]
        public string Ciudad  { get; set; }

            [Required(ErrorMessage = "La Provincia es Obligatoria.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El Municipio es Obligatorio.")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "El Pais es Obligatorio.")]
        public string Pais { get; set; }

        public Direccion()
        {
            Id = 0;
            ClienteId = 0;
            Calle = string.Empty;
            NumeroCasa = string.Empty;
            Ciudad = string.Empty;
            Provincia = string.Empty;
            Municipio = string.Empty;
            Pais = string.Empty;
        }
    }
}
