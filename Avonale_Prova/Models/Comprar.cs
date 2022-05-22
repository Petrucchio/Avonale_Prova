using System.ComponentModel.DataAnnotations;

namespace Avonale_Prova.Models
{
    public class Comprar
    {
        public int Id { get; set; }
        [Required]
        public int produto_id { get; set; }
        [Required]
        public int qtde_comprada { get; set; }
        [Required]
        public Cartao cartao { get; set; }
    }
}
