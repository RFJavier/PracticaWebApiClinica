using System;
using System.Collections.Generic;
using System.Text;

//importación paquetes necesarios
using Microsoft.EntityFrameworkCore;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Examenes> Examenes { get; set; }
        public DbSet<Anexos> Anexos { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Usuario> Usuario { get; internal set; }
        public DbSet<Rol> Rol { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-7QDEK088;Initial Catalog=ClinicaWebDB;Integrated Security=True");
        }
    }
}
