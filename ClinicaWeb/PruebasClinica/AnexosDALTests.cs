using ClinicaWeb.AccesoADatos;
using ClinicaWeb.EntidadesDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;


namespace AnexosDALtest
{
    [TestClass()]
    public class AnexosDALTests
    {
        private static Anexos anexInicial = new Anexos { Id = 5 };

        [TestMethod()]
        public async Task T1anexoCrearAsyncTest()
        {
            var anex = new Anexos();
            anex.Anexo = "Santa";
            
            int result = await AnexosDAL.CrearAsync(anex);
            Assert.AreNotEqual(0, result);
            anexInicial.Id = anex.Id;
        }

        [TestMethod()]
        public async Task T3anexoModificarAsyncTest()
        {
            var anex = new Anexos();
            anex.Id = anexInicial.Id;
            anex.Anexo = "prueba metodo modificar ";
            
            int result = await AnexosDAL.ModificarAsync(anex);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T6AnexoEliminarAsyncTest()
        {
            var anex = new Anexos();
            anex.Id = anexInicial.Id;
            int result = await AnexosDAL.EliminarAsync(anex);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ObtenerPorIdAsyncTest()
        {
            var anex = new Anexos();
            anex.Id = anexInicial.Id;
            var resultanex = await AnexosDAL.ObtenerPorIdAsync(anex);
            Assert.AreEqual(anex.Id, resultanex.Id);
            
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultanex = await AnexosDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultanex.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var anex = new Anexos();
            anex.Anexo = "p";
            
            anex.Top_Aux = 10;
            var resultanex = await AnexosDAL.BuscarAsync(anex);
            Assert.AreNotEqual(0, resultanex.Count);
        }
    }
}