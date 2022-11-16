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
    public class HorariosDALTests
    {
        private static Horarios HorInicial = new Horarios { Id = 1 };

        [TestMethod()]
        public async Task T1HorariosCrearAsyncTest()
        {
            var hor = new Horarios();
            hor.IdMedico = 1;
            hor.Entrada = Convert.ToDateTime("12-04-2022");
            hor.Salida =  Convert.ToDateTime("12-03-2022");
           
           

            int result = await HorariosDAL.CrearAsync(hor);
            Assert.AreNotEqual(0, result);
            HorInicial.Id = hor.Id;
        }

        [TestMethod()]
        public async Task T3HorariosModificarAsyncTest()
        {
            var Hor = new Horarios();
            Hor.Id = HorInicial.Id;
            
            Hor.Entrada = Convert.ToDateTime("12-04-2025");
            Hor.Salida = Convert.ToDateTime("12-04-2025");

            int result = await HorariosDAL.ModificarAsync(Hor);
            Assert.AreNotEqual(0, result);

        }

        [TestMethod()]
        public async Task T6HorariosEliminarAsyncTest()
        {
            var hor = new Horarios();
            hor.Id = HorInicial.Id;
            int result = await HorariosDAL.EliminarAsync(hor);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2HorariosObtenerPorIdAsyncTest()
        {
            var hor = new Horarios();
            hor.Id = HorInicial.Id;
            var resultexam = await HorariosDAL.ObtenerPorIdAsync(hor);
            Assert.AreEqual(hor.Id, resultexam.Id);
        }

        [TestMethod()]
        public async Task T4HorariosObtenerTodosAsyncTest()
        {
            var resulhor = await HorariosDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resulhor.Count);
        }

        [TestMethod()]
        public async Task T5HorariosBuscarAsyncTest()
        {
            var hor = new Horarios();
            hor.Entrada = Convert.ToDateTime("12-04-2025");

            hor.Top_Aux = 10;
            var resulthor = await HorariosDAL.BuscarAsync(hor);
            Assert.AreNotEqual(0, resulthor.Count);
        }

        [TestMethod()]
        public async Task T7HorariosBuscarIncluirMedicoAsyncTest()
        {
            var hor = new Horarios();
            hor.IdMedico = 2;

            hor.Top_Aux = 10;
            var resulthor = await HorariosDAL.BuscarIncluirMedicoAsync(hor);
            Assert.AreNotEqual(0, resulthor.Count);
        }
    }
}