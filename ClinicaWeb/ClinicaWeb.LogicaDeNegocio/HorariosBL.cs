using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//importación de paquetes
using ClinicaWeb.AccesoADatos;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.LogicaDeNegocio
{
   public class HorariosBL
    {
        public async Task<int> CrearAsync(Horarios pHorario)
        {
            return await HorariosDAL.CrearAsync(pHorario);
        }

        public async Task<int> ModificarAsync(Horarios pHorario)
        {
            return await HorariosDAL.ModificarAsync(pHorario);
        }

        public async Task<int> EliminarAsync(Horarios pHorario)
        {
            return await HorariosDAL.EliminarAsync(pHorario);
        }

        public async Task<Horarios> ObtenerPorId(Horarios pHorario)
        {
            return await HorariosDAL.ObtenerPorIdAsync(pHorario);
        }

        public async Task<List<Horarios>> ObtenerTodosAsync()
        {
            return await HorariosDAL.ObtenerTodosAsync();
        }

        public async Task<List<Horarios>> BuscarAsync(Horarios pHorario)
        {
            return await HorariosDAL.BuscarAsync(pHorario);
        }

        public async Task<List<Horarios>> BuscarIncluirMedicosAsync(Horarios pUsuario)
        {
            return await HorariosDAL.BuscarIncluirMedicoAsync(pUsuario);
        }
    }
}
