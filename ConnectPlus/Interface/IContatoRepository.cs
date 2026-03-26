using ConnectPlus.Models;

namespace ConnectPlus.Interface;

public interface IContatoRepository
{
    void Cadastrar(Contato contato);
    List<Contato> Listar();
    Contato BuscarPorId(Guid id);
    void Delete(Guid IdContatos);
    void Atualizar(Guid id, Contato contato);
}
