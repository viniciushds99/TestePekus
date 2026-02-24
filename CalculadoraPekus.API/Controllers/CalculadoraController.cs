using CalculadoraPekus.Application.Interfaces;
using CalculadoraPekus.Application.Models;
using CalculadoraPekus.Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraPekus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;
        public CalculadoraController(ICalculadoraService calculadoraService) {

            _calculadoraService = calculadoraService;

        }

        [HttpGet]
        public async Task <List<CalculoModel>> Get()
        {
            List<CalculoModel> calculos = await _calculadoraService.ListaCalculos();
            return calculos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CalculoRequest calculo)
        {
            if (calculo is null)
                return BadRequest("Calculo está vázio!");
            try
            {
                var inserirCalculo = await _calculadoraService.SalvaCalculo(calculo);
                return Ok(inserirCalculo);
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível acessar a API");
            }
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _calculadoraService.DeletaCalculo(id);
        }

        [HttpGet("LimpaContas")]
        public void DeleteAll()
        {
            _calculadoraService.DeletaRegistros();
        }


    }
}
