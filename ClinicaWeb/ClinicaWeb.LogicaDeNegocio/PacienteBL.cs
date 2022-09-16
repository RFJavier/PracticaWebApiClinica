using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//importación de paquetes
using ClinicaWeb.AccesoADatos;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.LogicaDeNegocio
{
    public class PacienteBL
    {

        public async Task<int> CrearAsync(Paciente pPaciente)
        {
            return await PacienteDAL.CrearAsync(pPaciente);
        }

        public async Task<int> ModificarAsync(Paciente pPaciente)
        {
            return await PacienteDAL.ModificarAsync(pPaciente);
        }

        public async Task<int> EliminarAsync(Paciente pPaciente)
        {
            return await PacienteDAL.EliminarAsync(pPaciente);
        }

        public async Task<Paciente> ObtenerPorId(Paciente pPaciente)
        {
            return await PacienteDAL.ObtenerPorIdAsync(pPaciente);
        }

        public async Task<List<Paciente>> ObtenerTodosAsync()
        {
            return await PacienteDAL.ObtenerTodosAsync();
        }

        public async Task<List<Paciente>> BuscarAsync(Paciente pPaciente)
        {
            return await PacienteDAL.BuscarAsync(pPaciente);
        }

        public async Task<List<Paciente>> BuscarIncluirMedicoAsync(Paciente pPaciente)
        {
            return await PacienteDAL.BuscarIncluirMedicoAsync(pPaciente);
        }
        public async Task<List<Paciente>> BuscarIncluirAnexoAsync(Paciente pPaciente)
        {
            return await PacienteDAL.BuscarIncluirAnexoAsync(pPaciente);
        }
        public async Task<List<Paciente>> BuscarIncluirExamenAsync(Paciente pPaciente)
        {
            return await PacienteDAL.BuscarIncluirExamenAsync(pPaciente);
        }
    }
}
