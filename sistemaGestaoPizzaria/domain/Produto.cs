using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaGestaoPizzaria.domain
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int tempoDePreparo { get; set; }

        public Produto() { }
        public Produto(string nome, int tempoDePreparo)
        {
            this.nome = nome;
            this.tempoDePreparo = tempoDePreparo;
        }
    }
}
