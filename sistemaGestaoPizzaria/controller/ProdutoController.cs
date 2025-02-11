using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaGestaoPizzaria.domain;
using sistemaGestaoPizzaria.infra;
using sistemaGestaoPizzaria.model;

namespace sistemaGestaoPizzaria.controller
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        [HttpPost]
        [Authorize(Roles = "cozinheiro")]
        [Consumes("application/json", "application/xml")]
        public IActionResult Add([FromBody] ProdutoRequest produtoRequest)
        {
            var produto = produtoRepository.Add(produtoRequest);
            return Ok(produto);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "cozinheiro")]
        public IActionResult Update(int id, [FromBody] ProdutoRequest produtoRequest)
        {
            var produto = produtoRepository.Update(id, produtoRequest);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = produtoRepository.GetAll();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var produto = produtoRepository.Get(id);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "cozinheiro")]
        public IActionResult Delete(int id)
        {
            produtoRepository.Delete(id);
            return Ok();
        }
    }
}
