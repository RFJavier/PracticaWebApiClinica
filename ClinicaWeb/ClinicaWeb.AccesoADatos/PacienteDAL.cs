using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

//importacion de paquetes necesarios
using Microsoft.EntityFrameworkCore;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.AccesoADatos
{
    public class PacienteDAL
    {

        public static async Task<int> CrearAsync(Paciente pPaciente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pPaciente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Paciente pPaciente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var paciente = await bdContexto.Paciente.FirstOrDefaultAsync(p => p.Id == pPaciente.Id);
                paciente.Nombre = pPaciente.Nombre;
                paciente.Genero = pPaciente.Genero;
                paciente.Edad = pPaciente.Edad;

                bdContexto.Update(paciente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Paciente pPaciente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var paciente = await bdContexto.Paciente.FirstOrDefaultAsync(p => p.Id == pPaciente.Id);
                bdContexto.Remove(paciente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Paciente> ObtenerPorIdAsync(Paciente pPaciente)
        {
            var paciente = new Paciente();
            using (var bdContexto = new BDContexto())
            {
                paciente = await bdContexto.Paciente.FirstOrDefaultAsync(p => p.Id == pPaciente.Id);
            }
            return paciente;
        }

        public static async Task<List<Paciente>> ObtenerTodosAsync()
        {
            var paciente = new List<Paciente>();
            using (var bdContexto = new BDContexto())
            {
                paciente = await bdContexto.Paciente.ToListAsync();
            }
            return paciente;
        }

        internal static IQueryable<Paciente> QuerySelect(IQueryable<Paciente> pQuery, Paciente pPaciente)
        {
            if (pPaciente.Id > 0) // buscado por ID
                pQuery = pQuery.Where(p => p.Id == pPaciente.Id);

            if (!string.IsNullOrWhiteSpace(pPaciente.Nombre)) // buscando por nombre
                pQuery = pQuery.Where(p => p.Nombre.Contains(pPaciente.Nombre));
            pQuery = pQuery.OrderByDescending(p => p.Id).AsQueryable();

            if (pPaciente.Top_Aux > 0) // si se quiere obtener numero especifico de medicos
                pQuery = pQuery.Take(pPaciente.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Paciente>> BuscarAsync(Paciente pPaciente)
        {
            var paciente = new List<Paciente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Paciente.AsQueryable();
                select = QuerySelect(select, pPaciente);
                paciente = await select.ToListAsync();
            }
            return paciente;
        }

            public static async Task<List<Paciente>> BuscarIncluirMedicoAsync(Paciente pPaciente)
            {
                var paciente = new List<Paciente>();
                using (var bdContexto = new BDContexto())
                {
                    var select = bdContexto.Paciente.AsQueryable();
                    select = QuerySelect(select, pPaciente).Include(m => m.Medico).AsQueryable();
                    paciente = await select.ToListAsync();
                }
                return paciente;
            }
        public static async Task<List<Paciente>> BuscarIncluirExamenAsync(Paciente pPaciente)
        {
            var paciente = new List<Paciente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Paciente.AsQueryable();
                select = QuerySelect(select, pPaciente).Include(e => e.Examenes).AsQueryable();
                paciente = await select.ToListAsync();
            }
            return paciente;
        }

        public static async Task<List<Paciente>> BuscarIncluirAnexoAsync(Paciente pPaciente)
        {
            var paciente = new List<Paciente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Paciente.AsQueryable();
                select = QuerySelect(select, pPaciente).Include(a => a.Anexos).AsQueryable();
                paciente = await select.ToListAsync();
            }
            return paciente;
        }
    }
}
