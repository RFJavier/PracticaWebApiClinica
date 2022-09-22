using ClinicaWeb.EntidadesDeNegocio;
using ClinicaWeb.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClinicaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Medicoscontroller : ControllerBase
    {

        private MedicoBL medicoBL = new MedicoBL();

        [HttpGet]
        public async Task<IEnumerable<Medico>> Get()
        {
            return await medicoBL.ObtenerTodosAsync();
        }

        [HttpGet("id")]
        public async Task<Medico> Get(int id)
        {
            Medico medico = new Medico();
            medico.Id = id;
            return await medicoBL.ObtenerPorId(medico);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Medico medico)
        {
            try
            {
                await medicoBL.CrearAsync(medico);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] Medico medico)
        {
            if (medico.Id == id)
            {
                await medicoBL.ModificarAsync(medico);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Medico medico = new Medico();
                medico.Id = id;
                await medicoBL.EliminarAsync(medico);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Medico>> Buscar([FromBody] object pMedico)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strMedico = JsonSerializer.Serialize(pMedico);
            Medico medico = JsonSerializer.Deserialize<Medico>(strMedico, option);
            return await medicoBL.BuscarAsync(medico);

        }

    }
}
