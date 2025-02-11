using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sistemaGestaoPizzaria.model;
using sistemaGestaoPizzaria.services;

namespace sistemaGestaoPizzaria.controller
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public PedidoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("calcula_tempo_entrega")]
        [Authorize]
        public async Task<IActionResult> CalculaTempoPreparo([FromBody] Pedido pedido)
        {
            var resultado = await _produtoService.CalculaTempoPreparo(pedido);

            if (!resultado.Sucesso)
            {
                return BadRequest(new { mensagem = resultado.Mensagem });
            }
            return Ok(new { mensagem = resultado.Mensagem });
        }
    }
}
