using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get() => 
        _produtoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProduto")]
        public ActionResult<Produto> Get(string id)
        {
            var produto = _produtoService.Get(id);

            if(produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public ActionResult<Produto> Create(Produto produto)
        {
            _produtoService.Create(produto);

            return CreatedAtRoute("GetBook", new {id = produto.id.ToString()},produto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Produto prod)
        {
            var produto = _produtoService.Get(id);

            if(produto == null)
            {
                return NotFound();
            }

            _produtoService.Update(id,prod);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var produto = _produtoService.Get(id);

            if(produto == null)
            {
                return NotFound();
            }

            _produtoService.Delete(produto.id);

            return NoContent();
        }
    }
}