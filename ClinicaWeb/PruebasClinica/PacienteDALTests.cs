using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicaWeb.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaWeb.EntidadesDeNegocio;

namespace ClinicaWeb.AccesoADatos.Tests
{
    [TestClass()]
    public class PacienteDALTests
    {
        private static Paciente pacInicial = new Paciente { Id = 1 };

        [TestMethod()]
        public async Task T1PacienteCrearAsyncTest()
        {
            var pac = new Paciente();
            pac.IdMedico = 1;
            pac.IdExamen = 1;
            pac.IdAnexo = 2;

            pac.Nombre = "Gerardo castillo";
            pac.Edad = "14";
            pac.Telefono = "545623";
            pac.FechaNacimiento = "12/12/2010";
            pac.Genero = "masculino";
            




            int result = await PacienteDAL.CrearAsync(pac);
            Assert.AreNotEqual(0, result);
            pacInicial.Id = pac.Id;
        }

        [TestMethod()]
        public async Task T3PacienteModificarAsyncTest()
        {
            var pac = new Paciente();
            pac.Id = pacInicial.Id;

            pac.Nombre = "jose castillo";
            pac.Edad = "15";
            pac.Telefono = "545783";
            pac.FechaNacimiento = "12/31/2010";
            pac.Genero = "masculino";

            int result = await PacienteDAL.ModificarAsync(pac);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T9PacienteEliminarAsyncTest()
        {
            var pac = new Paciente();
            pac.Id = pacInicial.Id;
            int result = await PacienteDAL.EliminarAsync(pac);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2PacienteObtenerPorIdAsyncTest()
        {
            var pac = new Paciente();
            pac.Id = pacInicial.Id;
            var resultexam = await PacienteDAL.ObtenerPorIdAsync(pac);
            Assert.AreEqual(pac.Id, resultexam.Id);
        }

        [TestMethod()]
        public async Task T4PacientesObtenerTodosAsyncTest()
        {
            var resulpac = await PacienteDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resulpac.Count);
        }

        [TestMethod()]
        public async Task T5PacienteBuscarAsyncTest()
        {
            var pac = new Paciente();
            pac.Nombre = "castillo";

            pac.Top_Aux = 10;
            var resulthor = await PacienteDAL.BuscarAsync(pac);
            Assert.AreNotEqual(0, resulthor.Count);
        }

        [TestMethod()]
        public async Task T7PacienteBuscarIncluirMedicoAsyncTest()
        {
            var pac = new Paciente();
            pac.IdMedico = 1;

            pac.Top_Aux = 10;
            var resultpac = await PacienteDAL.BuscarIncluirMedicoAsync(pac);
            Assert.AreNotEqual(0, resultpac.Count);
        }

        [TestMethod()]
        public async Task T8PacienteBuscarIncluirExamenAsyncTest()
        {
            var pac = new Paciente();
            pac.IdExamen = 1;

            pac.Top_Aux = 10;
            var resultpac = await PacienteDAL.BuscarIncluirExamenAsync(pac);
            Assert.AreNotEqual(0, resultpac.Count);
        }

        [TestMethod()]
        public async Task BuscarIncluirAnexoAsyncTest()
        {
            var pac = new Paciente();
            pac.IdAnexo = 2;

            pac.Top_Aux = 10;
            var resultpac = await PacienteDAL.BuscarIncluirAnexoAsync(pac);
            Assert.AreNotEqual(0, resultpac.Count);
        }
    }
}