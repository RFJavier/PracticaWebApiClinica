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
   public class AnexosDAL
    {
        public static async Task<int> CrearAsync(Anexos pAnexo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pAnexo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Anexos pAnexo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var anexo = await bdContexto.Anexos.FirstOrDefaultAsync(a => a.Id == pAnexo.Id);
                anexo.Anexo = pAnexo.Anexo;

                bdContexto.Update(anexo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Anexos pAnexo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var anexo = await bdContexto.Anexos.FirstOrDefaultAsync(a => a.Id == pAnexo.Id);
                bdContexto.Remove(anexo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Anexos> ObtenerPorIdAsync(Anexos pAnexo)
        {
            var anexo = new Anexos();
            using (var bdContexto = new BDContexto())
            {
                anexo = await bdContexto.Anexos.FirstOrDefaultAsync(a => a.Id == pAnexo.Id);
            }
            return anexo;
        }

        public static async Task<List<Anexos>> ObtenerTodosAsync()
        {
            var anexo = new List<Anexos>();
            using (var bdContexto = new BDContexto())
            {
                anexo = await bdContexto.Anexos.ToListAsync();
            }
            return anexo;
        }

        internal static IQueryable<Anexos> QuerySelect(IQueryable<Anexos> pQuery, Anexos pAnexo)
        {
            if (pAnexo.Id > 0) // buscado por ID
                pQuery = pQuery.Where(a => a.Id == pAnexo.Id);

            if (!string.IsNullOrWhiteSpace(pAnexo.Anexo)) // buscando por anexo medico
                pQuery = pQuery.Where(e => e.Anexo.Contains(pAnexo.Anexo));
            pQuery = pQuery.OrderByDescending(a => a.Id).AsQueryable();

            if (pAnexo.Top_Aux > 0) // si se quiere obtener numero especifico de medicos
                pQuery = pQuery.Take(pAnexo.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Anexos>> BuscarAsync(Anexos pAnexo)
        {
            var anexo = new List<Anexos>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Anexos.AsQueryable();
                select = QuerySelect(select, pAnexo);
                anexo = await select.ToListAsync();
            }
            return anexo;
        }
    }
}
