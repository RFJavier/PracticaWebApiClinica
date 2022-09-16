using System;
using System.Collections.Generic;
using System.Text;

//importación de paquetes necesarios
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaWeb.EntidadesDeNegocio
{
    public class Horarios
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Medico")]
        [Required(ErrorMessage = "Medico es obligatorio")]
        [Display(Name = "Medico")]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "Entrada es Obligatorio")]
        public DateTime Entrada { get; set; }

        [Required(ErrorMessage = "Salida es Obligatorio")]
        public DateTime Salida { get; set; }

        public Medico Medico { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
