using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//importar paquetes
using ClinicaWeb.EntidadesDeNegocio;
using ClinicaWeb.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ClinicaWeb.UI.AppWebAspCore.Controllers
{

    public class PacienteController : Controller
    {
        PacienteBL pacienteBL = new PacienteBL();
        MedicoBL medicoBL = new MedicoBL();
        ExamenesBL examenBL = new ExamenesBL();
        AnexosBL anexosBL = new AnexosBL();

        // GET: PacienteController
        public async Task<IActionResult> Index(Paciente pPaciente = null)
        {
            if (pPaciente == null)
                pPaciente = new Paciente();
            if (pPaciente.Top_Aux == 0)
                pPaciente.Top_Aux = 10;
            else if (pPaciente.Top_Aux == -1)
                pPaciente.Top_Aux = 0;

            var paciente = await pacienteBL.BuscarAsync(pPaciente);

            var taskBuscarmedico = pacienteBL.BuscarIncluirMedicoAsync(pPaciente);
            var taskObtenerTodosMedicos = pacienteBL.ObtenerTodosAsync();
            var pacientemedico = await taskBuscarmedico;

            var taskBuscarexamen = pacienteBL.BuscarIncluirExamenAsync(pPaciente);
            var taskObtenerTodosExamenes = pacienteBL.ObtenerTodosAsync();
            var pacienteexamen = await taskBuscarexamen;

            var taskBuscaranexo = pacienteBL.BuscarIncluirAnexoAsync(pPaciente);
            var taskObtenerTodosAnexos = pacienteBL.ObtenerTodosAsync();
            var pacienteanexo = await taskBuscaranexo;

            ViewBag.Top = pPaciente.Top_Aux;
            ViewBag.Medics = await taskObtenerTodosMedicos;
            ViewBag.Examen = await taskObtenerTodosExamenes;
            ViewBag.Anexo = await taskObtenerTodosAnexos;
            return View(paciente);
        }

        // GET: PacienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var paciente = await pacienteBL.ObtenerPorId(new Paciente { Id = id });

            paciente.Medico = await medicoBL.ObtenerPorId(new Medico { Id = paciente.IdMedico });
            paciente.Examenes = await examenBL.ObtenerPorId(new Examenes { Id = paciente.IdExamen});
            paciente.Anexos = await anexosBL.ObtenerPorId(new Anexos { Id = paciente.IdAnexo });

            return View(paciente);
        }

        // GET: PacienteController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
            ViewBag.Examen = await examenBL.ObtenerTodosAsync();
            ViewBag.Anexo = await anexosBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente pPaciente)
        {
            try
            {
                int result = await pacienteBL.CrearAsync(pPaciente);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
                ViewBag.Examen = await examenBL.ObtenerTodosAsync();
                ViewBag.Anexo = await anexosBL.ObtenerTodosAsync();
                return View(pPaciente);
            }
        }

        // GET: PacienteController/Edit/5
        public async Task<IActionResult>Edit(Paciente pPaciente)
        {
            var paciente = await pacienteBL.ObtenerPorId(pPaciente);
            ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
            ViewBag.Examen = await examenBL.ObtenerTodosAsync();
            ViewBag.Anexo = await anexosBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View(paciente);
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente pPaciente)
        {
            try
            {
                int result = await pacienteBL.ModificarAsync(pPaciente);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
                ViewBag.Examen = await examenBL.ObtenerTodosAsync();
                ViewBag.Anexo = await anexosBL.ObtenerTodosAsync();
                return View(pPaciente);
            }
        }

        // GET: PacienteController/Delete/5
        public async Task<IActionResult> Delete(Paciente pPaciente)
        {
            var paciente = await pacienteBL.ObtenerPorId(pPaciente);
            paciente.Medico = await medicoBL.ObtenerPorId(new Medico { Id = paciente.IdMedico });
            paciente.Examenes = await examenBL.ObtenerPorId(new Examenes { Id = paciente.IdExamen });
            paciente.Anexos = await anexosBL.ObtenerPorId(new Anexos { Id = paciente.IdAnexo });
            return View();
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Paciente pPaciente)
        {
            try
            {
                int result = await pacienteBL.EliminarAsync(pPaciente);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                var paciente = await pacienteBL.ObtenerPorId(pPaciente);
                if (paciente == null)
                    paciente = new Paciente();

                if (paciente.Id > 0)
                    paciente.Medico = await medicoBL.ObtenerPorId(new Medico { Id = paciente.IdMedico });
                paciente.Examenes = await examenBL.ObtenerPorId(new Examenes { Id = paciente.IdExamen }); 
                paciente.Anexos = await anexosBL.ObtenerPorId(new Anexos { Id = paciente.IdAnexo });
                return View(paciente);
            }
        }
    }
}
