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
    public class MedicoDALTests
    {
        private static Medico MedInicial = new Medico { Id = 5 };

        [TestMethod()]
        public async Task T1MedicoCrearAsyncTest()
        {
            var med = new Medico();
            med.Nombre = "Juan Alvarez";
            med.Telefono = "123456";
            med.Especialidad = "Cardiologo";



            int result = await MedicoDAL.CrearAsync(med);
            Assert.AreNotEqual(0, result);
            MedInicial.Id = med.Id;
        }

        [TestMethod()]
        public async Task T3MedicoModificarAsyncTest()
        {
            var med = new Medico();
            med.Id = MedInicial.Id;
            med.Nombre = "Juan peres";
            med.Telefono = "789456";
            med.Especialidad = "Pediatra";

            int result = await MedicoDAL.ModificarAsync(med);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T6MedicoEliminarAsyncTest()
        {
            var med = new Medico();
            med.Id = MedInicial.Id;
            int result = await MedicoDAL.EliminarAsync(med);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2MedicoObtenerPorIdAsyncTest()
        {
            var med = new Medico();
            med.Id = MedInicial.Id;
            var resultmed = await MedicoDAL.ObtenerPorIdAsync(med);
            Assert.AreEqual(med.Id, resultmed.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultmed = await MedicoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultmed.Count);
        }

        [TestMethod()]
        public async Task T6MedicoBuscarAsyncTest()
        {
            var med = new Medico();
            med.Nombre = "Juan";

            med.Top_Aux = 10;
            var resultmed = await MedicoDAL.BuscarAsync(med);
            Assert.AreNotEqual(0, resultmed.Count);
        }
    }
}