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
   public class HorariosDAL
    {
        public static async Task<int> CrearAsync(Horarios pHorario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pHorario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Horarios pHorario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var horario = await bdContexto.Horarios.FirstOrDefaultAsync(h => h.Id == pHorario.Id);
                horario.Medico = pHorario.Medico;
                horario.Entrada = pHorario.Entrada;
                horario.Salida = pHorario.Salida;

                bdContexto.Update(horario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Horarios pHorario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var horario = await bdContexto.Horarios.FirstOrDefaultAsync(h => h.Id == pHorario.Id);
                bdContexto.Remove(horario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Horarios> ObtenerPorIdAsync(Horarios pHorario)
        {
            var horario = new Horarios();
            using (var bdContexto = new BDContexto())
            {
                horario = await bdContexto.Horarios.FirstOrDefaultAsync(h => h.Id == pHorario.Id);
            }
            return horario;
        }

        public static async Task<List<Horarios>> ObtenerTodosAsync()
        {
            var horario = new List<Horarios>();
            using (var bdContexto = new BDContexto())
            {
                horario = await bdContexto.Horarios.ToListAsync();
            }
            return horario;
        }

        internal static IQueryable<Horarios> QuerySelect(IQueryable<Horarios> pQuery, Horarios pHorario)
        {
            if (pHorario.Id > 0) // buscado por ID
                pQuery = pQuery.Where(h => h.Id == pHorario.Id);

            if (pHorario.Entrada.Hour > 0)
            {
                DateTime date = new DateTime
                    (pHorario.Entrada.Hour, 0000);
            }
            if (pHorario.Salida.Hour > 0)
            {
                DateTime date = new DateTime
                    (pHorario.Salida.Hour, 0000);
            }

            if (pHorario.Top_Aux > 0) // si se quiere obtener numero especifico de medicos
                pQuery = pQuery.Take(pHorario.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Horarios>> BuscarAsync(Horarios pHorario)
        {
            var horario = new List<Horarios>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Horarios.AsQueryable();
                select = QuerySelect(select, pHorario);
                horario = await select.ToListAsync();
            }
            return horario;
        }
        public static async Task<List<Horarios>> BuscarIncluirMedicoAsync(Horarios pHorario)
        {
            var horario = new List<Horarios>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Horarios.AsQueryable();
                select = QuerySelect(select, pHorario).Include(m => m.Medico).AsQueryable();
                horario = await select.ToListAsync();
            }
            return horario;
        }
    }
}
