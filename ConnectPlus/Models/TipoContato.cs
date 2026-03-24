using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Index("Identificador", Name = "UQ__TipoCont__F2374EB0D19F778E", IsUnique = true)]
public partial class TipoContato
{
    [Key]
    [Column("Id_TipoContatos")]
    public Guid IdTipoContatos { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(244)]
    public string FormaDeContato { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Imagem { get; set; } = null!;

    [StringLength(244)]
    public string Identificador { get; set; } = null!;

    [InverseProperty("IdTipoContatosNavigation")]
    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
