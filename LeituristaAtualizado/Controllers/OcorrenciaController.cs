using Business.Interfaces;
using Business.Interfaces.Servicos;
using Business.ViewModels.Ocorrencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("ocorrencia")]
    [Authorize]
    public class OcorrenciaController : NotificadorController
    {
        private readonly IOcorrenciaServico _ocorrenciaServico;

        public OcorrenciaController(INotificador notificador, IOcorrenciaServico ocorrenciaServico) : base(notificador)
        {
            _ocorrenciaServico = ocorrenciaServico;
        }

        [HttpGet("buscar-todas")]
        public async Task<IEnumerable<OcorrenciaViewModel>> BuscarTodas()
        {
            return await _ocorrenciaServico.BuscarTodas();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            return RespostaCustomizada(await _ocorrenciaServico.BuscarPorId(id));
        }

        [HttpGet("{descricao}")]
        public async Task<IActionResult> BuscarPorDescricao(string descricao)
        {
            return RespostaCustomizada(await _ocorrenciaServico.BuscarPorDescricao(descricao));
        }

        [HttpGet("buscar-lista/{descricao}")]
        public async Task<IEnumerable<OcorrenciaViewModel>> BuscarListaOcorrenciasPorDescricao(string descricao)
        {
            return await _ocorrenciaServico.BuscarListaOcorrenciasPorDescricao(descricao);
        }

        [Authorize(Roles = "Leiturista")]
        [HttpPost]
        public async Task<IActionResult> Adicionar(OcorrenciaCadastroViewModel ocorrenciaViewModel)
        {
            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            if (await _ocorrenciaServico.Adicionar(ocorrenciaViewModel))
                return Ok("Ocorrência adicionada!");

            return RespostaCustomizada();
        }

        [Authorize(Roles = "Leiturista")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Atualizar(long id, OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (id != ocorrenciaViewModel.Id) return BadRequest("O id informado na busca difere do id informado no modelo!");

            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            if (await _ocorrenciaServico.Atualizar(ocorrenciaViewModel))
                return Ok("Ocorrência Atualizada!");

            return RespostaCustomizada(ocorrenciaViewModel);

        }

        [Authorize(Roles = "Leiturista")]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Deletar(long id)
        {
            if (await _ocorrenciaServico.Deletar(id))
                return Ok("Ocorrência deletada!");

            return RespostaCustomizada();
        }


    }
}
