using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Index("Titulo", Name = "UQ__Contatos__7B406B5658FCC9A6", IsUnique = true)]
public partial class Contato
{
    [Key]
    [Column("Id_Contatos")]
    public Guid IdContatos { get; set; }

    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    public Guid? IdTipoContatos { get; set; }

    [ForeignKey("IdTipoContatos")]
    [InverseProperty("Contatos")]
    public virtual TipoContato? IdTipoContatosNavigation { get; set; }
}
