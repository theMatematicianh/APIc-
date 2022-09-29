using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIZ2.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string? Descricao { get; set; }
        public decimal preco { get; set; }
        [Required]
        [MaxLength(300)]
        public string? ImagemUrl { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }


        public Produto(int produtoId, string? nome, string? descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Descricao = descricao;
            this.preco = preco;
            ImagemUrl = imagemUrl;
            Estoque = estoque;
            DataCadastro = dataCadastro;
        }
    }
}
