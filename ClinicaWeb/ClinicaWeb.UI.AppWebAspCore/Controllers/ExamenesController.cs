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
    public class ExamenesController : Controller
    {
        ExamenesBL examenesBL = new ExamenesBL();//Instancias de clase BL

        // Accion que muestra registro de Anexos
        public async Task<IActionResult> Index(Examenes pExamen = null)
        {
            if (pExamen == null)
                pExamen = new Examenes();
            if (pExamen.Top_Aux == 0)
                pExamen.Top_Aux = 10;
            else if (pExamen.Top_Aux == -1)
                pExamen.Top_Aux = 0;

            var examen = await examenesBL.BuscarAsync(pExamen);
            ViewBag.Top = pExamen.Top_Aux;
            return View(examen);
        }
        // Acción que muestra el detalle de un examen
        public async Task<IActionResult> Details(int id)
        {
            var examen = await examenesBL.ObtenerPorId(new Examenes { Id = id });
            return View(examen);
        }

        // Acción que muestra el formulario para agregar un Examen
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }
        // Acción que recibe los datos del formulario para llevarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Examenes pExamen)
        {
            try
            {
                int result = await examenesBL.CrearAsync(pExamen);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pExamen);
            }
        }

        // Acción que muestra el formulario con los datos cargados
        public async Task<IActionResult> Edit(Examenes pExamen)
        {
            var examen = await examenesBL.ObtenerPorId(pExamen);
            ViewBag.Error = "";
            return View(examen);
        }

        // Acción que recibe los datos modificados para llevarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Examenes pExamen)
        {
            try
            {
                int result = await examenesBL.ModificarAsync(pExamen);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pExamen);
            }
        }

        // Acción que muestra el formulario con los datos a eliminar
        public async Task<IActionResult> Delete(Examenes pExamen)
        {
            var examen = await examenesBL.ObtenerPorId(pExamen);
            ViewBag.Error = "";
            return View(examen);
        }

        // Acción que recibe la confirmación de eliminación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Examenes pExamen)
        {
            try
            {
                int result = await examenesBL.EliminarAsync(pExamen);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pExamen);
            }
        }
    }
}
