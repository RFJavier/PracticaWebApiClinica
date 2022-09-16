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
    public class MedicoDAL
    {
        public static async Task<int> CrearAsync(Medico pMedico)
        {
            int result = 0;
            using(var bdContexto = new BDContexto())
            {
                bdContexto.Add(pMedico);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Medico pMedico)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var medico = await bdContexto.Medico.FirstOrDefaultAsync(m => m.Id == pMedico.Id);
                medico.Nombre = pMedico.Nombre;
                medico.Telefono = pMedico.Telefono;
                medico.Especialidad = pMedico.Especialidad;

                bdContexto.Update(medico);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Medico pMedico)
        {
            int result = 0;
            using(var bdContexto = new BDContexto())
            {
                var medico = await bdContexto.Medico.FirstOrDefaultAsync(m => m.Id == pMedico.Id);
                bdContexto.Remove(medico);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Medico> ObtenerPorIdAsync(Medico pMedico)
        {
            var medico = new Medico();
            using(var bdContexto = new BDContexto())
            {
                medico = await bdContexto.Medico.FirstOrDefaultAsync(m => m.Id == pMedico.Id);
            }
            return medico;
        }

        public static async Task<List<Medico>> ObtenerTodosAsync()
        {
            var medico = new List<Medico>();
            using(var bdContexto = new BDContexto())
            {
                medico = await bdContexto.Medico.ToListAsync();
            }
            return medico;
        }

        internal static IQueryable<Medico> QuerySelect(IQueryable<Medico> pQuery, Medico pMedico)
        {
            if (pMedico.Id > 0) // buscado por ID
                pQuery = pQuery.Where(m => m.Id == pMedico.Id);

            if (!string.IsNullOrWhiteSpace(pMedico.Nombre)) // buscando por nombre de medico
                pQuery = pQuery.Where(m => m.Nombre.Contains(pMedico.Nombre));
            pQuery = pQuery.OrderByDescending(m => m.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(pMedico.Especialidad)) // buscando por especialidad
                pQuery = pQuery.Where(m => m.Especialidad.Contains(pMedico.Especialidad));
            pQuery = pQuery.OrderByDescending(m => m.Especialidad).AsQueryable();

            if (pMedico.Top_Aux > 0) // si se quiere obtener numero especifico de medicos
                pQuery = pQuery.Take(pMedico.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Medico>> BuscarAsync(Medico pMedico)
        {
            var medico = new List<Medico>();
            using(var bdContexto = new BDContexto())
            {
                var select = bdContexto.Medico.AsQueryable();
                select = QuerySelect(select, pMedico);
                medico = await select.ToListAsync();
            }
            return medico;
        }
    }
}
