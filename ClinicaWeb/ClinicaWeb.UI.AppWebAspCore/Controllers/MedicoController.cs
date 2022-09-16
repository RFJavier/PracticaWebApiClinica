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
    //[Authorize(AuthenticationSchemes = 
    //  CookieAuthenticationDefaults.AuthenticationScheme)]
    public class MedicoController : Controller
    {
        MedicoBL medicoBL = new MedicoBL(); //Instancias de clase BL
        
        // Accion que muestra registro de registro
        public async Task<IActionResult> Index(Medico pMedico = null)
        {
            if (pMedico == null)
                pMedico = new Medico();
            if (pMedico.Top_Aux == 0)
                pMedico.Top_Aux = 10;
            else if (pMedico.Top_Aux == -1)
                pMedico.Top_Aux = 0;

            var medico = await medicoBL.BuscarAsync(pMedico);
            ViewBag.Top = pMedico.Top_Aux;
            return View(medico);
        }

        // Acción que muestra el detalle de un medico
        public async Task<IActionResult> Details(int id)
        {
            var medico = await medicoBL.ObtenerPorId(new Medico { Id = id });

            return View(medico);
        }

        // Acción que muestra el formulario para agregar un medico
        public IActionResult Create()
        {
            ViewBag.Error = "";

            return View();
        }

        // Acción que recibe los datos del formulario para llevarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medico pMedico)
        {
            try
            {
                int result = await medicoBL.CrearAsync(pMedico);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMedico);
            }
        }

        // Acción que muestra el formulario con los datos cargados
        public async Task<IActionResult> Edit(Medico pMedico)
        {
            var medico = await medicoBL.ObtenerPorId(pMedico);
            ViewBag.Error = "";
            return View(medico);
        }

        // Acción que recibe los datos modificados para llevarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medico pMedico)
        {
            try
            {
                int result = await medicoBL.ModificarAsync(pMedico);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMedico);
            }
        }

        // Acción que muestra el formulario con los datos a eliminar
        public async Task<IActionResult> Delete(Medico pMedico)
        {
            var medico = await medicoBL.ObtenerPorId(pMedico);
            ViewBag.Error = "";
            return View(medico);
        }

        // Acción que recibe la confirmación de eliminación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Medico pMedico)
        {
            try
            {
                int result = await medicoBL.EliminarAsync(pMedico);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pMedico);
            }
        }
    }
}
