using System;
using System.Collections.Generic;
using System.Text;

//importación de paquetes necesarios
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaWeb.EntidadesDeNegocio
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Medico")]
        [Required(ErrorMessage = "Medico es obligatorio")]
        [Display(Name = "Medico")]
        public int IdMedico { get; set; }

        [ForeignKey("Examenes")]
        [Required(ErrorMessage = "Examenes es obligatorio")]
        [Display(Name = "Examenes")]
        public int IdExamen { get; set; }

        [ForeignKey("Anexos")]
        [Required(ErrorMessage = "Anexos es obligatorio")]
        [Display(Name = "Anexos")]
        public int IdAnexo { get; set; }

        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo de 50 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Edad es Obligatorio")]
        [StringLength(5, ErrorMessage = "Maximo de 5 Caracteres")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "Telefono es Obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo de 10 Caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento es Obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo de 10 Caracteres")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Genero de Nacimiento es Obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo de 10 Caracteres")]
        public string Genero { get; set; }

        public Medico Medico { get; set; }

        public Examenes Examenes { get; set; }

        public Anexos Anexos { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
