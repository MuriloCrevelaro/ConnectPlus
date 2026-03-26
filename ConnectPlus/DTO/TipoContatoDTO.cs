using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class TipoContatoDTO
{
    [Required(ErrorMessage = "O Titulo e o Identificador do Tipo Contato é obrigatório")]
    public string? Titulo { get; set; } = null!;
    public string? Identificador { get; set; } = null!;
}
