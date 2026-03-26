using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

public partial class Contato
{
    [Key]
    [Column("Id_Contatos")]
    public Guid IdContatos { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(244)]
    public string FormaDeContato { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Imagem { get; set; } = null!;

    [Column("Id_TipoContatos")]
    public Guid? IdTipoContatos { get; set; }

    [ForeignKey("IdTipoContatos")]
    [InverseProperty("Contatos")]
    public virtual TipoContato? IdTipoContatosNavigation { get; set; }
}
