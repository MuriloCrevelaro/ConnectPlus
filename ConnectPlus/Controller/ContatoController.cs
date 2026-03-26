using ConnectPlus.DTO;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace ConnectPlus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_contatoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_contatoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(ContatoDTO contato)
        {
            if (String.IsNullOrWhiteSpace(contato.Nome))
                return BadRequest("É obrigatorio que o filme tenha nome e Gênero");

            Contato novoContato = new Contato();

            if (contato.Imagem != null && contato.Imagem.Length != 0)
            {
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                //Garante que a pasta exista
                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }

                novoContato.Imagem = nomeArquivo;
                novoContato.IdTipoContatos = contato.IdTipoContatos;
                novoContato.Nome = contato.Nome;
                novoContato.FormaDeContato = contato.FormaDeContato!;
            }

            try
            {
                _contatoRepository.Cadastrar(novoContato);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ContatoDTO contato)
        {
            var contatoBuscado = _contatoRepository.BuscarPorId(id); ;
            if (contatoBuscado == null)
                return NotFound("Filme não encontrado!");

            if (!String.IsNullOrWhiteSpace(contato.Nome))
                contatoBuscado.Nome = contato.Nome;

            if (!String.IsNullOrWhiteSpace(contato.Nome))
                contatoBuscado.IdTipoContatos = contato.IdTipoContatos;

            if (!String.IsNullOrWhiteSpace(contato.Nome))
                contatoBuscado.FormaDeContato = contato.FormaDeContato!;

            if (contato.IdTipoContatos != null && contatoBuscado.IdTipoContatos != contato.IdTipoContatos)
                contatoBuscado.IdTipoContatos = contato.IdTipoContatos;

            if (contato.Imagem != null && contato.Imagem.Length != 0)
            {
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                //Deleta arquivo antigo
                if (!string.IsNullOrEmpty(contatoBuscado.Imagem))
                {
                    var caminhoAntigo = Path.Combine(caminhoPasta, contatoBuscado.Imagem);

                    if (System.IO.File.Exists(caminhoAntigo))
                        System.IO.File.Delete(caminhoAntigo);
                }

                //Salva a nova imagem
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }

                contatoBuscado.Imagem = nomeArquivo;
            }
            try
            {
                _contatoRepository.Atualizar(id, contatoBuscado);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var contatoBuscado = _contatoRepository.BuscarPorId(id);
            if (contatoBuscado == null)
                return NotFound("Filme não encontrado!");

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            //Deleta o arquivo
            if (!String.IsNullOrEmpty(contatoBuscado.Imagem))
            {
                var caminho = Path.Combine(caminhoPasta, contatoBuscado.Imagem);

                if (System.IO.File.Exists(caminho))
                    System.IO.File.Delete(caminho);
            }

            try
            {
                _contatoRepository.Delete(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
