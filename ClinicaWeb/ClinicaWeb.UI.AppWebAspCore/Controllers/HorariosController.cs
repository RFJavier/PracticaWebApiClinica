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
    public class HorariosController : Controller
    {
        HorariosBL horariosBL = new HorariosBL();
        MedicoBL medicoBL = new MedicoBL();

        // Acción que muestra el listado de Horarios
        public async Task<IActionResult> Index(Horarios pHorario = null)
        {
            if (pHorario == null)
                pHorario = new Horarios();
            if (pHorario.Top_Aux == 0)
                pHorario.Top_Aux = 10;
            else if (pHorario.Top_Aux == -1)
                pHorario.Top_Aux = 0;

            var taskBuscar = horariosBL.BuscarIncluirMedicosAsync(pHorario);
            var taskObtenerTodosMedicos = horariosBL.ObtenerTodosAsync();
            var horario = await taskBuscar;

            ViewBag.Top = pHorario.Top_Aux;
            ViewBag.Medics = await taskObtenerTodosMedicos;
            return View(horario);
        }

        // Acción que muestra el detalle de un horario
        public async Task<IActionResult> Details(int id)
        {
            var horario = await horariosBL.ObtenerPorId(new Horarios { Id = id });
            horario.Medico = await medicoBL.ObtenerPorId(new Medico { Id = horario.IdMedico });
            return View(horario);
        }

        // Acción que muestra el formulario para agregar un horario
        public async Task<IActionResult> Create()
        {
            ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // Acción que recibe los datos del formulario y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Horarios pHorarios)
        {
            try
            {
                int result = await horariosBL.CrearAsync(pHorarios);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
                return View(pHorarios);
            }
        }

        // Acción que muestra los datos del usuario en el formulario
        public async Task<IActionResult> Edit(Horarios pHorario)
        {
            var horario = await horariosBL.ObtenerPorId(pHorario);
            ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View(horario);
        }

        // Acción que recibe los datos modificados y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Horarios pHorario)
        {
            try
            {
                int result = await horariosBL.ModificarAsync(pHorario);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Medico = await medicoBL.ObtenerTodosAsync();
                return View(pHorario);
            }
        }

        // Accion que muestra los datos del usuario a Eliminar
        public async Task<IActionResult> Delete(Horarios pHorario)
        {
            var horario = await horariosBL.ObtenerPorId(pHorario);
            horario.Medico = await medicoBL.ObtenerPorId(new Medico { Id = horario.IdMedico });
            return View();
        }

        // POST: HorariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Horarios pHorario)
        {
            try
            {
                int result = await horariosBL.EliminarAsync(pHorario); 
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                var horario = await horariosBL.ObtenerPorId(pHorario);
                if (horario == null)
                    horario = new Horarios();

                if (horario.Id > 0)
                    horario.Medico = await medicoBL.ObtenerPorId(new Medico { Id = horario.IdMedico });

                return View(horario);
            }
        }
    }
}
