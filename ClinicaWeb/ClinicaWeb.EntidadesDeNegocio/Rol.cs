using System;
using System.Collections.Generic;
using System.Text;

//importación de paquetes necesarios
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ClinicaWeb.EntidadesDeNegocio
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Usuario> Usuario { get; set; }

        public Task<Rol> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
