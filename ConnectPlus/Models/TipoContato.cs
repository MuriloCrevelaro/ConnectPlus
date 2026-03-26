using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

public partial class TipoContato
{
    [Key]
    [Column("Id_TipoContatos")]
    public Guid IdTipoContatos { get; set; }

    [StringLength(244)]
    public string Identificador { get; set; } = null!;

    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("IdTipoContatosNavigation")]
    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
