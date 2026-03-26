using ConnectPlus.Models;
using System.Diagnostics;

namespace ConnectPlus.Interface;

public interface ITipoContatoRepository 
{
    void Cadastrar(TipoContato tipoContato);
    List<TipoContato> Listar();
    TipoContato BuscarPorId(Guid id);
    void Delete(Guid IdTipoContatos);
    void Atualizar(Guid id, TipoContato tipoContato);
}
