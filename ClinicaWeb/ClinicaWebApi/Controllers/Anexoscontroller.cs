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
    public class Anexoscontroller : ControllerBase
    {
        private AnexosBL anexosBL = new AnexosBL();

        [HttpGet]
        public async Task<IEnumerable<Anexos>> Get()
        {
            return await anexosBL.ObtenerTodosAsync();
        }

        [HttpGet("id")]
        public async Task<Anexos> Get(int id)
        {
            Anexos anexos = new Anexos();
            anexos.Id = id;
            return await anexosBL.ObtenerPorId(anexos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Anexos anexos)
        {
            try
            {
                await anexosBL.CrearAsync(anexos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] Anexos anexos)
        {
            if (anexos.Id == id)
            {
                await anexosBL.ModificarAsync(anexos);
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
                Anexos anexos = new Anexos();
                anexos.Id = id;
                await anexosBL.EliminarAsync(anexos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Anexos>> Buscar([FromBody] object pAnexos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strAnexos = JsonSerializer.Serialize(pAnexos);
            Anexos anexos = JsonSerializer.Deserialize<Anexos>(strAnexos, option);
            return await anexosBL.BuscarAsync(anexos);

        }

    }
}
