using System.ComponentModel.DataAnnotations;
namespace MinhaPrimeiraApi.Models;
public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome do produto não pode exceder 100 caracteres.")]
    public string Nome { get; set; }

[Range(0.01, 1000, ErrorMessage = "O preço do produto deve estar entre 0,01 e 1000.")]
    public decimal Preco { get; set; }
}