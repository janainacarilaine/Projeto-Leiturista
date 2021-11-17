using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Repositorios;
using Business.Interfaces.Servicos;
using Business.Modelos;
using Business.Notificacoes;
using Business.Validacoes;
using Business.ViewModels.Leitura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Servicos
{
    public class LeituraServico : NotificacaoServico, ILeituraServico
    {
        private readonly INotificador _notificador;
        private readonly ILeituraRepositorio _leituraRepositorio;
        private readonly ILeituristaRepositorio _leituristaRepositorio;
        private readonly IOcorrenciaRepositorio _ocorrenciaRepositorio;
        private readonly IMapper _mapper;

        public LeituraServico(INotificador notificador, ILeituraRepositorio leituraRepositorio, IMapper mapper, ILeituristaServico leituristaServico, IOcorrenciaServico ocorrenciaServico, ILeituristaRepositorio leituristaRepositorio, IOcorrenciaRepositorio ocorrenciaRepositorio) : base(notificador)
        {
            _notificador = notificador;
            _leituraRepositorio = leituraRepositorio;
            _mapper = mapper;
            _leituristaRepositorio = leituristaRepositorio;
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
        }


        public async Task<IEnumerable<LeituraViewModel>> BuscarPorMesAno(int mes, int ano)
        {
            return _mapper.Map<IEnumerable<LeituraViewModel>>(await _leituraRepositorio.BuscarPorMesAno(mes, ano));
        }

        public async Task<IEnumerable<LeituraViewModel>> BuscarPorLeiturista(long matricula)
        {
            return _mapper.Map<IEnumerable<LeituraViewModel>>(await _leituraRepositorio.BuscarPorLeiturista(matricula));
        }

        public async Task<IEnumerable<LeituraViewModel>> BuscarPorOcorrencia(string descricao)
        {
            return _mapper.Map<IEnumerable<LeituraViewModel>>(await _leituraRepositorio.BuscarPorOcorrencia(descricao));
        }

        public async Task<LeituraViewModel> BuscarPorId(long id)
        {
            var leituraBD = await _leituraRepositorio.BuscarPorId(id);

            if (leituraBD == null) _notificador.AdicionarNotificacao(new Notificacao("Leitura não encontrada!"));

            return _mapper.Map<LeituraViewModel>(leituraBD);
        }

        public async Task<IEnumerable<LeituraViewModel>> BuscarTodas()
        {
            return _mapper.Map<IEnumerable<LeituraViewModel>>(await _leituraRepositorio.BuscarTodos());
        }

        public async Task Adicionar(LeituraCadastroViewModel leituraViewModel)
        {
            var leitura = _mapper.Map<Leitura>(leituraViewModel);

            leitura.DataLeitura = DateTime.Now;

            var leiturista = await _leituristaRepositorio.BuscarPorId(leitura.LeituristaId);

            ExecutarValidacao(new LeituraValidacao(), leitura);

            if (leiturista == null) _notificador.AdicionarNotificacao(new Notificacao("Leiturista não encontrado!"));


            if (!leiturista.Ativo)
                _notificador.AdicionarNotificacao(new Notificacao("Leiturista inativo, não é possível realizar a leitura!"));


            var ocorrencia = await _ocorrenciaRepositorio.BuscarPorId(leitura.OcorrenciaId);

            if (ocorrencia == null) _notificador.AdicionarNotificacao(new Notificacao("Ocorrência não encontrada!"));


            if (!ocorrencia.PermiteLeitura)
            {
                leitura.LeituraAtual = null;
                _notificador.AdicionarAlerta(new Alerta("A Ocorrência informada não permite leitura portanto leitura atual salva como nula!"));
                await _leituraRepositorio.Adicionar(leitura);
            }

            await _leituraRepositorio.Adicionar(leitura);
        }

        public async Task Atualizar(LeituraAtualizacaoViewModel leituraViewModel)
        {
            var leitura = _mapper.Map<Leitura>(leituraViewModel);

            var leituraBD = await _leituraRepositorio.BuscarPorId(leituraViewModel.Id);

            if (leituraBD == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Leitura não encontrada!"));
                return;
            }

            leitura.DataLeitura = leituraBD.DataLeitura;

            var leiturista = await _leituristaRepositorio.BuscarPorId(leitura.LeituristaId);

            ExecutarValidacao(new LeituraValidacao(), leitura);

            if (leiturista == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Leiturista não encontrado!"));
                return;
            }

            if (!leiturista.Ativo)
                _notificador.AdicionarNotificacao(new Notificacao("Leiturista inativo, não é possível atualizar a leitura!"));

            var ocorrencia = await _ocorrenciaRepositorio.BuscarPorId(leitura.OcorrenciaId);

            if (ocorrencia == null) _notificador.AdicionarNotificacao(new Notificacao("Ocorrência não encontrada!"));

            if (!ocorrencia.PermiteLeitura)
            {
                leitura.LeituraAtual = null;
                _notificador.AdicionarAlerta(new Alerta("A Ocorrência informada não permite leitura portanto leitura atual salva como nula!"));
                await _leituraRepositorio.Atualizar(leitura);
                return;
            }

            await _leituraRepositorio.Atualizar(leitura);
        }

        public async Task<bool> Deletar(long id)
        {
            var leitura = await _leituraRepositorio.BuscarPorId(id);

            if (leitura == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Leitura não encontrada!"));
                return false;
            }

            await _leituraRepositorio.Deletar(id);
            return true;
        }
    }
}
