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
    public class AnexosController : Controller
    {
        AnexosBL anexosBL = new AnexosBL(); //Instancias de clase BL

        // Accion que muestra registro de Anexos
        public async Task<IActionResult> Index(Anexos pAnexos = null)
        {
            if (pAnexos == null)
                pAnexos = new Anexos();
            if (pAnexos.Top_Aux == 0)
                pAnexos.Top_Aux = 10;
            else if (pAnexos.Top_Aux == -1)
                pAnexos.Top_Aux = 0;

            var anexo = await anexosBL.BuscarAsync(pAnexos);
            ViewBag.Top = pAnexos.Top_Aux;
            return View(anexo);
        }

        // Acción que muestra el detalle de un Anexo
        public async Task<IActionResult> Details(int id)
        {
            var anexo = await anexosBL.ObtenerPorId(new Anexos { Id = id });
            return View(anexo);
        }

        // Acción que muestra el formulario para agregar un Anexo
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // Acción que recibe los datos del formulario para llevarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Anexos pAnexo)
        {
            try
            {
                int result = await anexosBL.CrearAsync(pAnexo);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pAnexo);
            }
        }

        // Acción que muestra el formulario con los datos cargados
        public async Task<IActionResult> Edit(Anexos pAnexo)
        {
            var anexo = await anexosBL.ObtenerPorId(pAnexo);
            ViewBag.Error = "";
            return View(anexo);
        }
        // Acción que recibe los datos modificados para llevarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Anexos pAnexo)
        {
            try
            {
                int result = await anexosBL.ModificarAsync(pAnexo);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pAnexo);
            }
        }


        // Acción que muestra el formulario con los datos a eliminar
        public async Task<IActionResult> Delete(Anexos pAnexo)
        {
            var anexo = await anexosBL.ObtenerPorId(pAnexo);
            ViewBag.Error = "";
            return View(anexo);
        }

        // Acción que recibe la confirmación de eliminación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Anexos pAnexo)
        {
            try
            {
                int result = await anexosBL.EliminarAsync(pAnexo);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pAnexo);
            }
        }
    }
}
