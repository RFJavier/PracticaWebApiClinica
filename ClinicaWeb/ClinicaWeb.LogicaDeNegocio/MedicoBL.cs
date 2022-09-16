using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//importación de paquetes
using ClinicaWeb.AccesoADatos;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.LogicaDeNegocio
{
   public class MedicoBL
    {
        public async Task<int> CrearAsync(Medico pMedico)
        {
            return await MedicoDAL.CrearAsync(pMedico);
        }

        public async Task<int> ModificarAsync(Medico pMedico)
        {
            return await MedicoDAL.ModificarAsync(pMedico);
        }

        public async Task<int> EliminarAsync(Medico pMedico)
        {
            return await MedicoDAL.EliminarAsync(pMedico);
        }

        public async Task<Medico> ObtenerPorId(Medico pMedico)
        {
            return await MedicoDAL.ObtenerPorIdAsync(pMedico);
        }

        public async Task<List<Medico>> ObtenerTodosAsync()
        {
            return await MedicoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Medico>> BuscarAsync(Medico pMedico)
        {
            return await MedicoDAL.BuscarAsync(pMedico);
        }
    }
}
