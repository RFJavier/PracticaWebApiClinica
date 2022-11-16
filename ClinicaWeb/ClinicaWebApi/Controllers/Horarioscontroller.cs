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
    public class Horarioscontroller : ControllerBase
    {
        private HorariosBL horariosBL = new HorariosBL();

        [HttpGet]
        public async Task<IEnumerable<Horarios>> Get()
        {
            return await horariosBL.ObtenerTodosAsync();
        }

        [HttpGet("id")]
        public async Task<Horarios> Get(int id)
        {
            Horarios horarios = new Horarios();
            horarios.Id = id;
            return await horariosBL.ObtenerPorId(horarios);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Horarios horarios)
        {
            try
            {
                await horariosBL.CrearAsync(horarios);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] Horarios horarios)
        {
            if (horarios.Id == id)
            {
                await horariosBL.ModificarAsync(horarios);
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
                Horarios horarios = new Horarios();
                horarios.Id = id;
                await horariosBL.EliminarAsync(horarios);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Horarios>> Buscar([FromBody] object pHorarios)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strHorarios = JsonSerializer.Serialize(pHorarios);
            Horarios horarios = JsonSerializer.Deserialize<Horarios>(strHorarios, option);
            return await horariosBL.BuscarAsync(horarios);

        }
    }
}
