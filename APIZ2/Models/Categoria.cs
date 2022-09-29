using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIZ2.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }

        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [MaxLength(80)]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string? ImagemUrl { get; set; }

        public ICollection<Produto>? Produtos { get; set; }

        public Categoria(int categoriaId, string? nome, string? imagemUrl)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            ImagemUrl = imagemUrl;
        }
    }
}
