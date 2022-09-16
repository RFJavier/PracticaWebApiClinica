using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//importación de paquetes
using ClinicaWeb.AccesoADatos;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.LogicaDeNegocio
{
    public class ExamenesBL
    {
        public async Task<int> CrearAsync(Examenes pExamen)
        {
            return await ExamenesDAL.CrearAsync(pExamen);
        }

        public async Task<int> ModificarAsync(Examenes pExamen)
        {
            return await ExamenesDAL.ModificarAsync(pExamen);
        }

        public async Task<int> EliminarAsync(Examenes pExamen)
        {
            return await ExamenesDAL.EliminarAsync(pExamen);
        }

        public async Task<Examenes> ObtenerPorId(Examenes pExamen)
        {
            return await ExamenesDAL.ObtenerPorIdAsync(pExamen);
        }

        public async Task<List<Examenes>> ObtenerTodosAsync()
        {
            return await ExamenesDAL.ObtenerTodosAsync();
        }

        public async Task<List<Examenes>> BuscarAsync(Examenes pExamen)
        {
            return await ExamenesDAL.BuscarAsync(pExamen);
        }
    }
}
