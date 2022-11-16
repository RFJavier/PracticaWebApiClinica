using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicaWeb.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaWeb.EntidadesDeNegocio;

namespace AnexosDALtest
{


    [TestClass()]
    public class ExamenesDALTests
    {
        private static Examenes examInicial = new Examenes { Id = 2 };

        [TestMethod()]
        public async Task T1ExamenCrearAsyncTest()
        {
            var exam = new Examenes();
            exam.Examen = "Santa";

            int result = await ExamenesDAL.CrearAsync(exam);
            Assert.AreNotEqual(0, result);
            examInicial.Id = exam.Id;
        }

        [TestMethod()]
        public async Task T3ExamenModificarAsyncTest()
        {
            var exam = new Examenes();
            exam.Id = examInicial.Id;
            exam.Examen = "prueba metodo modificar ";

            int result = await ExamenesDAL.ModificarAsync(exam);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T6ExamenEliminarAsyncTest()
        {
            var exam = new Examenes();
            exam.Id = examInicial.Id;
            int result = await ExamenesDAL.EliminarAsync(exam);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ExamenObtenerPorIdAsyncTest()
        {
            var exam = new Examenes();
            exam.Id = examInicial.Id;
            var resultexam = await ExamenesDAL.ObtenerPorIdAsync(exam);
            Assert.AreEqual(exam.Id, resultexam.Id);
        }

        [TestMethod()]
        public async Task T4ExamenObtenerTodosAsyncTest()
        {
            var resultexam = await ExamenesDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultexam.Count);
        }

        [TestMethod()]
        public async Task T5ExamenBuscarAsyncTest()
        {
            var exam = new Examenes();
            exam.Examen = "p";

            exam.Top_Aux = 10;
            var resultexam = await ExamenesDAL.BuscarAsync(exam);
            Assert.AreNotEqual(0, resultexam.Count);
        }
    }
}