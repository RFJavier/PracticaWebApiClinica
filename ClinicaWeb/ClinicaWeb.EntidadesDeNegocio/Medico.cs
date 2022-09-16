using System;
using System.Collections.Generic;
using System.Text;

//importación de paquetes necesarios
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaWeb.EntidadesDeNegocio
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre es Obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo de 50 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Telefono es Obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo de 10 Caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Especialidad es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo de 100 Caracteres")]
        public string Especialidad { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Horarios> Horarios { get; set; }
        public List<Paciente> Paciente { get; set; }
    }
}
