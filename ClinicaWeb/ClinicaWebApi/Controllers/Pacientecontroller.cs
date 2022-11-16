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
    [Route("api/[Controller]")]
    [ApiController]
    public class Pacientecontroller : ControllerBase
    {
        private PacienteBL pacienteBL = new PacienteBL();

        [HttpGet]
        public async Task<IEnumerable<Paciente>> Get()
        {
            return await pacienteBL.ObtenerTodosAsync();
        }

        [HttpGet("id")]
        public async Task<Paciente> Get(int id)
        {
            Paciente paciente = new Paciente();
            paciente.Id = id;
            return await pacienteBL.ObtenerPorId(paciente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Paciente paciente)
        {
            try
            {
                await pacienteBL.CrearAsync(paciente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] Paciente paciente)
        {
            if (paciente.Id == id)
            {
                await pacienteBL.ModificarAsync(paciente);
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
                Paciente paciente = new Paciente();
                paciente.Id = id;
                await pacienteBL.EliminarAsync(paciente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Paciente>> Buscar([FromBody] object pPaciente)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strPaciente = JsonSerializer.Serialize(pPaciente);
            Paciente paciente = JsonSerializer.Deserialize<Paciente>(strPaciente, option);
            return await pacienteBL.BuscarAsync(paciente);

        }
    }
}
