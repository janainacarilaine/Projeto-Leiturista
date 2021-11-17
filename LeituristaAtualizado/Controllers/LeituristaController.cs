using Business.Interfaces;
using Business.Interfaces.Servicos;
using Business.ViewModels.Leiturista;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("leiturista")]
    [Authorize(Roles = "Administrador")]
    public class LeituristaController : NotificadorController
    {
        private readonly ILeituristaServico _leituristaServico;
        public LeituristaController(INotificador notificador, ILeituristaServico leituristaServico) : base(notificador)
        {
            _leituristaServico = leituristaServico;
        }


        [HttpGet("{matricula:long}")]
        public async Task<IActionResult> BuscarPorMatricula(long matricula)
        {
            return RespostaCustomizada(await _leituristaServico.BuscarPorMatricula(matricula));
        }

        [HttpGet("buscar-todos")]
        public async Task<IEnumerable<LeituristaViewModel>> BuscarTodos()
        {
            return await _leituristaServico.BuscarTodos();
        }
        
        [HttpGet("{nome}")]
        public async Task<IEnumerable<LeituristaViewModel>> BuscarPorNome(string nome)
        {
            return await _leituristaServico.BuscarPorNome(nome);
        }

        [HttpGet("{status:bool}")]
        public async Task<IEnumerable<LeituristaViewModel>> BuscarPorStatus(bool status)
        {
            return await _leituristaServico.BuscarPorStatus(status);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(LeituristaCadastroViewModel leituristaViewModel)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            if (await _leituristaServico.Adicionar(leituristaViewModel))
                return Ok("Leiturista adicionado!");

            return RespostaCustomizada();
        }

        [HttpPut("{matricula:long}")]
        public async Task<IActionResult> Atualizar(long matricula, LeituristaCadastroViewModel leituristaViewModel)
        {
            if (matricula != leituristaViewModel.Matricula) 
                return BadRequest("A matrícula informada na busca difere da matrícula informada no modelo!");

            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            if (await _leituristaServico.Atualizar(leituristaViewModel))
                return Ok("Leiturista atualizado!");

            return RespostaCustomizada();
        }

        [HttpDelete("{matricula:long}")]
        public async Task<IActionResult> Deletar(long matricula)
        {
            if (await _leituristaServico.Deletar(matricula))
                return Ok("Leiturista deletado!");

            return RespostaCustomizada();
        }
    }
}
