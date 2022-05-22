using System.ComponentModel.DataAnnotations;

namespace Avonale_Prova.Models
{
    public class Pagamento
    {
        public int id { get; set; }
        [Required]
        public float valor { get; set; }
        public string estado { get; set; }
        [Required]
        public Cartao cartao { get; set; }
    }
}
