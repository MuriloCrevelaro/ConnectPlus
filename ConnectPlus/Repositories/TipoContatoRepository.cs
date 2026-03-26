using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus.Models;

namespace ConnectPlus.Repositories;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnectContext _context;
    public TipoContatoRepository(ConnectContext context)
    {
        _context = context; 
    }
    public void Atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoAtualizado = _context.TipoContatos.Find(id);
        if (tipoContatoAtualizado != null)
        {
            tipoContatoAtualizado!.Titulo = tipoContato.Titulo;
            _context.SaveChanges();
        }
    }

    public TipoContato BuscarPorId(Guid id)
    {
        return _context.TipoContatos.Find(id)!;
    }

    public void Cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }

    public void Delete(Guid IdTipoContatos)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(IdTipoContatos);
        _context.TipoContatos.Remove(tipoContatoBuscado!);
        _context.SaveChanges();
    }

    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.OrderBy(tipoContato => tipoContato.Titulo).ToList();
    }
}
