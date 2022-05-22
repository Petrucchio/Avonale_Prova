using System.ComponentModel.DataAnnotations;

namespace Avonale_Prova.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public float valor_unitario { get; set; }
        [Required]
        public int qtde_estoque { get; set; }
        public DateTime? Ultima_venda { get; set; }
        public float? valor_ultima_venda { get; set; }

        public Produto(DateTime? ultima_venda, float? valor_ultima_venda)
        {
            Ultima_venda = null;
            this.valor_ultima_venda = null;
        }

    }
}
