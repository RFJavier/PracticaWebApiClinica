using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//importación de paquetes
using ClinicaWeb.AccesoADatos;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.LogicaDeNegocio
{
   public class AnexosBL
    {
        public async Task<int> CrearAsync(Anexos pAnexo)
        {
            return await AnexosDAL.CrearAsync(pAnexo);
        }

        public async Task<int> ModificarAsync(Anexos pAnexo)
        {
            return await AnexosDAL.ModificarAsync(pAnexo);
        }

        public async Task<int> EliminarAsync(Anexos pAnexo)
        {
            return await AnexosDAL.EliminarAsync(pAnexo);
        }

        public async Task<Anexos> ObtenerPorId(Anexos pAnexo)
        {
            return await AnexosDAL.ObtenerPorIdAsync(pAnexo);
        }

        public async Task<List<Anexos>> ObtenerTodosAsync()
        {
            return await AnexosDAL.ObtenerTodosAsync();
        }

        public async Task<List<Anexos>> BuscarAsync(Anexos pAnexo)
        {
            return await AnexosDAL.BuscarAsync(pAnexo);
        }
    }
}
