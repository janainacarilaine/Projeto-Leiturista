using Business.Interfaces;
using Business.Interfaces.Servicos;
using Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Route("usuario")]
    [Authorize]
    public class UsuarioController : NotificadorController
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico, INotificador notificador) : base(notificador)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            return RespostaCustomizada(await _usuarioServico.BuscarPorId(id));
        }

        [HttpGet("buscar-todos")]
        public async Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarTodos()
        {
            return await _usuarioServico.BuscarTodos();
        }

        [HttpGet("buscar-por-funcao/{funcao}")]
        public async Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarPorFuncao(string funcao)
        {
            return await _usuarioServico.BuscarPorFuncao(funcao);
        }

        [HttpGet("buscar-por-nome/{nome}")]
        public async Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarPorNome(string nome)
        {
            return await _usuarioServico.BuscarPorNome(nome);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Adicionar(UsuarioCadastroViewModel usuario)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            if (await _usuarioServico.Adicionar(usuario)) 
                return Ok("Usuário Adicionado!");

            return RespostaCustomizada(usuario);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Atualizar(long id, UsuarioAtualizacaoViewModel usuario)
        {
            if (usuario.Id != id) return BadRequest("O id informado na rota deve ser o mesmo informado no modelo!");

            if (!ModelState.IsValid) return RespostaCustomizada();

            if (await _usuarioServico.Atualizar(usuario))
                return Ok("Usuário atualizado com sucesso!");

            return RespostaCustomizada(usuario);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Deletar(long id)
        {
            if (await _usuarioServico.Deletar(id))
                return Ok("Usuário deletado!");

            return RespostaCustomizada();
        }
    }
}
