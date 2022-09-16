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
   public class ExamenesDAL
    {
        public static async Task<int> CrearAsync(Examenes pExamen)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pExamen);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Examenes pExamen)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var examen = await bdContexto.Examenes.FirstOrDefaultAsync(e => e.Id == pExamen.Id);
                examen.Examen = pExamen.Examen;

                bdContexto.Update(examen);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Examenes pExamen)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var examen = await bdContexto.Examenes.FirstOrDefaultAsync(e => e.Id == pExamen.Id);
                bdContexto.Remove(examen);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Examenes> ObtenerPorIdAsync(Examenes pExamen)
        {
            var examen = new Examenes();
            using (var bdContexto = new BDContexto())
            {
                examen = await bdContexto.Examenes.FirstOrDefaultAsync(e => e.Id == pExamen.Id);
            }
            return examen;
        }

        public static async Task<List<Examenes>> ObtenerTodosAsync()
        {
            var examen = new List<Examenes>();
            using (var bdContexto = new BDContexto())
            {
                examen = await bdContexto.Examenes.ToListAsync();
            }
            return examen;
        }

        internal static IQueryable<Examenes> QuerySelect(IQueryable<Examenes> pQuery, Examenes pExamen)
        {
            if (pExamen.Id > 0) // buscado por ID
                pQuery = pQuery.Where(e => e.Id == pExamen.Id);

            if (!string.IsNullOrWhiteSpace(pExamen.Examen)) // buscando por examen medico
                pQuery = pQuery.Where(e => e.Examen.Contains(pExamen.Examen));
            pQuery = pQuery.OrderByDescending(e => e.Id).AsQueryable();

            if (pExamen.Top_Aux > 0) // si se quiere obtener numero especifico de medicos
                pQuery = pQuery.Take(pExamen.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Examenes>> BuscarAsync(Examenes pExamen)
        {
            var examen = new List<Examenes>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Examenes.AsQueryable();
                select = QuerySelect(select, pExamen);
                examen = await select.ToListAsync();
            }
            return examen;
        }
    }
}
