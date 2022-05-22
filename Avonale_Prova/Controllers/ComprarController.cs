using Avonale_Prova.Data;
using Avonale_Prova.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avonale_Prova.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ComprarController : ControllerBase
    {

        private readonly ProdutoDbContext _context;

        public ComprarController(ProdutoDbContext context) => _context = context;

        // POST api/<ComprarController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post([FromBody] Comprar comprar)
        {
            string cardformat = comprar.cartao.CartaoCredito.Replace(" ", "");
            Regex VisaRegEx = new Regex(@"^4[0-9]{15}$");
            Regex MasterCardRegEx = new Regex(@"^((5(([1-2]|[4-5])[0-9]{8}|0((1|6)([0-9]{7}))|3(0(4((0|[2-9])[0-9]{5})|([0-3]|[5-9])[0-9]{6})|[1-9][0-9]{7})))|((508116)\\d{4,10})|((502121)\\d{4,10})|((589916)\\d{4,10})|(2[0-9]{15})|(67[0-9]{14})|(506387)\\d{4,10})");
            Regex HiperCardRegEx = new Regex(@"^606282|^3841(?:[0|4|6]{1})0");
            Regex AmexRegEx = new Regex(@"^3[47][0-9]{13}$");
            Regex EloRegEx = new Regex(@"^4011(78|79)|^43(1274|8935)|^45(1416|7393|763(1|2))|^504175|^627780|^63(6297|6368|6369)|(65003[5-9]|65004[0-9]|65005[01])|(65040[5-9]|6504[1-3][0-9])|(65048[5-9]|65049[0-9]|6505[0-2][0-9]|65053[0-8])|(65054[1-9]|6505[5-8][0-9]|65059[0-8])|(65070[0-9]|65071[0-8])|(65072[0-7])|(65090[1-9]|6509[1-6][0-9]|65097[0-8])|(65165[2-9]|6516[67][0-9])|(65500[0-9]|65501[0-9])|(65502[1-9]|6550[34][0-9]|65505[0-8])|^(506699|5067[0-6][0-9]|50677[0-8])|^(509[0-8][0-9]{2}|5099[0-8][0-9]|50999[0-9])|^65003[1-3]|^(65003[5-9]|65004\d|65005[0-1])|^(65040[5-9]|6504[1-3]\d)|^(65048[5-9]|65049\d|6505[0-2]\d|65053[0-8])|^(65054[1-9]|6505[5-8]\d|65059[0-8])|^(65070\d|65071[0-8])|^65072[0-7]|^(65090[1-9]|65091\d|650920)|^(65165[2-9]|6516[6-7]\d)|^(65500\d|65501\d)|^(65502[1-9]|6550[3-4]\d|65505[0-8])");
            Console.Write(VisaRegEx.IsMatch(cardformat));
            if (VisaRegEx.IsMatch(cardformat))
            {
                comprar.cartao.bandeira = "Visa";
            }else if (EloRegEx.IsMatch(cardformat))
            {
                comprar.cartao.bandeira = "Elo";
            }else if (MasterCardRegEx.IsMatch(cardformat))
            {
                comprar.cartao.bandeira = "MasterCard";
            }else if (HiperCardRegEx.IsMatch(cardformat))
            {
                comprar.cartao.bandeira = "HiperCard";
            }else if (AmexRegEx.IsMatch(cardformat))
            {
                comprar.cartao.bandeira = "American express";
            }
            var produto = await _context.Produtos.FindAsync(comprar.produto_id);
            if(produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            await _context.Compras.AddAsync(comprar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByTitular), new { titular = comprar.cartao.titular }, comprar);

        }

        // GET api/<ProdutoController>/5
        [HttpGet("{titular}")]
        [ProducesResponseType(typeof(Comprar), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitular(string titular)
        {
            var comprar = await _context.Compras.FindAsync(titular);
            return comprar == null ? NotFound() : Ok(comprar);
        }
    }
}
