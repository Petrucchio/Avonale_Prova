using Avonale_Prova.Data;
using Avonale_Prova.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.IO;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avonale_Prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoDbContext _context;

        public ProdutoController(ProdutoDbContext context) => _context = context;

        // GET: api/<ProdutoController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<Produto>> Get()
            => await _context.Produtos.Where(o => o.qtde_estoque > 0).ToListAsync();//retorna apenas os produtos que tiverem pelo menos 1 no estoque

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var produto =  await _context.Produtos.FindAsync(id);
            return produto == null ? NotFound() : Ok(produto);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = produto.Id}, produto);
        }


        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var produto_a_deletar = _context.Produtos.FindAsync(id);
            if (produto_a_deletar == null) return NotFound();

            _context.Produtos.Remove(await produto_a_deletar);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
