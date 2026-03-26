using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class ContatoDTO
{
    [Required(ErrorMessage = "O Titulo e o Identificador do Tipo Contato é obrigatório")]
    public string? Nome { get; set; } = null!;
    public string? FormaDeContato { get; set; } = null!;
    public IFormFile? Imagem { get; set; } = null!;
    public Guid? IdTipoContatos { get; set; }
}
