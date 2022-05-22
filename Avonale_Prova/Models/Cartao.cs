using System.ComponentModel.DataAnnotations;


namespace Avonale_Prova.Models
{
    public class Cartao
    {
        public int id { get; set; }
        [Required]
        public string titular { get; set; }
        [Required]
        [CreditCard(ErrorMessage = "Cartão de crédito inválido")]
        public string CartaoCredito{get; set;}
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string data_expiracao { get; set;}
        public string bandeira { get; set;}
        public int cvv { get; set; }

        public Cartao()
        {
            
        }
    }

}
