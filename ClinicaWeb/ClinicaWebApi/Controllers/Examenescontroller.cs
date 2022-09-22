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
    public class Examenescontroller : ControllerBase
    {
        private ExamenesBL examenesBL = new ExamenesBL();

        [HttpGet]
        public async Task<IEnumerable<Examenes>> Get()
        {
            return await examenesBL.ObtenerTodosAsync();
        }

        [HttpGet("id")]
        public async Task<Examenes> Get(int id)
        {
            Examenes examenes = new Examenes();
            examenes.Id = id;
            return await examenesBL.ObtenerPorId(examenes);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Examenes examenes)
        {
            try
            {
                await examenesBL.CrearAsync(examenes);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] Examenes examenes)
        {
            if (examenes.Id == id)
            {
                await examenesBL.ModificarAsync(examenes);
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
                Examenes examenes = new Examenes();
                examenes.Id = id;
                await examenesBL.EliminarAsync(examenes);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Examenes>> Buscar([FromBody] object pExamenes)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strExamenes = JsonSerializer.Serialize(pExamenes);
            Examenes examenes = JsonSerializer.Deserialize<Examenes>(strExamenes, option);
            return await examenesBL.BuscarAsync(examenes);

        }
    }
}
