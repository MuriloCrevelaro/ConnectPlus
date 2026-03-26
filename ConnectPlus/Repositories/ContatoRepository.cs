using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace ConnectPlus.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;
    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }
    public void Atualizar(Guid id, Contato contato)
    {
        var tipoContatoAtualizado = _context.Contatos.Find(id);
        if (tipoContatoAtualizado != null)
        {
            tipoContatoAtualizado!.Nome = contato.Nome;
            _context.SaveChanges();
        }
    }

    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.Find(id)!;
    }

    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void Delete(Guid IdContatos)
    {
        try
        {
            Contato filmeBuscado = _context.Contatos.Find(IdContatos)!;
            if (filmeBuscado != null)
            {
                _context.Contatos.Remove(filmeBuscado);
            }
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Contato> Listar()
    {
        return _context.Contatos.OrderBy(contato => contato.Nome).ToList();
    }
}
