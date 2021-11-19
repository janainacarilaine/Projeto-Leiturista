using Business.Interfaces;
using Business.Interfaces.Servicos;
using Business.ViewModels.Leitura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("leitura")]
    [Authorize]
    public class LeituraController : NotificadorController
    {
        private readonly ILeituraServico _leituraServico;

        public LeituraController(INotificador notificador, ILeituraServico leituraServico) : base(notificador)
        {
            _leituraServico = leituraServico;
        }

        [HttpGet("buscar-todas")]
        public async Task<IEnumerable<LeituraViewModel>> BuscarTodas()
        {
            return await _leituraServico.BuscarTodas();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> BuscarPorId(long id)
        {
            var leituraViewModel = await _leituraServico.BuscarPorId(id);

            return RespostaCustomizada(leituraViewModel);
        }

        [HttpGet("buscar-por-leiturista/{matricula:long}")]
        public async Task<IEnumerable<LeituraViewModel>> BuscarPorLeiturista(long matricula)
        {
            return await _leituraServico.BuscarPorLeiturista(matricula);
        }

        [HttpGet("buscar-por-ocorrencia/{descricao}")]
        public async Task<IEnumerable<LeituraViewModel>> BuscarPorOcorrencia(string descricao)
        {
            return await _leituraServico.BuscarPorOcorrencia(descricao);
        }

        [HttpGet("buscar-por-mes-e-ano/{mes:int}/{ano:int}")]
        public async Task<ActionResult<IEnumerable<LeituraViewModel>>> BuscarPorMesAno(int mes, int ano)
        {
            if (mes > 12 || mes < 1) return BadRequest("Mês inválido!");

            if (ano < 1970 || ano > DateTime.Now.Year) return BadRequest("Ano inválido!");

            return RespostaCustomizada(await _leituraServico.BuscarPorMesAno(mes, ano));
        }

        [Authorize(Roles = "Leiturista")]
        [HttpPost]
        public async Task<IActionResult> Adicionar(LeituraCadastroViewModel leituraViewModel)
        {
            if (!ModelState.IsValid) return RespostaCustomizada();

            var leitura = await _leituraServico.Adicionar(leituraViewModel);
            return RespostaCustomizada(leitura);
        }

        [Authorize(Roles = "Leiturista")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Atualizar(long id, LeituraAtualizacaoViewModel leituraViewModel)
        {
            if (id != leituraViewModel.Id) return BadRequest("O id informado na rota difere do id informado no modelo!");

            if (!ModelState.IsValid) return RespostaCustomizada(ModelState);

            await _leituraServico.Atualizar(leituraViewModel);
            return RespostaCustomizada(leituraViewModel);
        }

        [Authorize(Roles = "Leiturista")]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Deletar(long id)
        {
            if (await _leituraServico.Deletar(id))
                return Ok("Leitura deletada!");

            return RespostaCustomizada();
        }
    }
}
