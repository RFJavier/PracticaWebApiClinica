using System;
using System.Collections.Generic;
using System.Text;

//importación de paquetes necesarios
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaWeb.EntidadesDeNegocio
{
    public class Anexos
    {
        [Key]
        public int Id { get; set; }
        

        [Required(ErrorMessage = "Anexo es Obligatorio")]
        [StringLength(1500, ErrorMessage = "Maximo de 1500 Caracteres")]
        public string Anexo { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Paciente> Paciente { get; set; }
    }
}
