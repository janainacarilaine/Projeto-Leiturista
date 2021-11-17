using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Repositorios;
using Business.Interfaces.Servicos;
using Business.Modelos;
using Business.Notificacoes;
using Business.Validacoes;
using Business.ViewModels.Ocorrencia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Servicos
{
    public class OcorrenciaServico : NotificacaoServico, IOcorrenciaServico
    {
        private readonly IOcorrenciaRepositorio _ocorrenciaRepositorio;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        public OcorrenciaServico(INotificador notificador, IOcorrenciaRepositorio ocorrenciaRepositorio, IMapper mapper) : base(notificador)
        {
            _ocorrenciaRepositorio = ocorrenciaRepositorio;
            _mapper = mapper;
            _notificador = notificador;
        }

        public async Task<IEnumerable<OcorrenciaViewModel>> BuscarTodas()
        {
            return _mapper.Map<IEnumerable<OcorrenciaViewModel>>(await _ocorrenciaRepositorio.BuscarTodos());
        }

        public async Task<OcorrenciaViewModel> BuscarPorId(long id)
        {
            var ocorrenciaBD = await _ocorrenciaRepositorio.BuscarPorId(id);
            if (ocorrenciaBD == null)
                _notificador.AdicionarNotificacao(new Notificacao("Ocorrência não encontrada!"));

            return _mapper.Map<OcorrenciaViewModel>(ocorrenciaBD);
        }

        public async Task<OcorrenciaViewModel> BuscarPorDescricao(string descricao)
        {
            var ocorrenciaBD = await _ocorrenciaRepositorio.BuscarOcorrenciaPorDescricao(descricao);
            if (ocorrenciaBD == null)
                _notificador.AdicionarNotificacao(new Notificacao("Ocorrência não encontrada!"));

            return _mapper.Map<OcorrenciaViewModel>(ocorrenciaBD);
        }

        public async Task<IEnumerable<OcorrenciaViewModel>> BuscarListaOcorrenciasPorDescricao(string descricao)
        {
            return _mapper.Map<IEnumerable<OcorrenciaViewModel>>(await _ocorrenciaRepositorio.BuscarListaOcorrenciasPorDescricao(descricao));
        }

        public async Task<bool> Adicionar(OcorrenciaCadastroViewModel ocorrenciaViewModel)
        {
            var ocorrencia = _mapper.Map<Ocorrencia>(ocorrenciaViewModel);

            if (!ExecutarValidacao(new OcorrenciaValidacao(), ocorrencia)) return false;

            var OcorrenciaBD = await _ocorrenciaRepositorio.BuscarOcorrenciaPorDescricao(ocorrencia.Descricao);

            if (OcorrenciaBD != null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Já existe uma ocorrência com esta descrição!"));
                return false;
            }

            await _ocorrenciaRepositorio.Adicionar(ocorrencia);
            return true;
        }

        public async Task<bool> Atualizar(OcorrenciaViewModel ocorrenciaViewModel)
        {
            var ocorrencia = _mapper.Map<Ocorrencia>(ocorrenciaViewModel);

            if (!ExecutarValidacao(new OcorrenciaValidacao(), ocorrencia)) return false;

            var OcorrenciaBD = await _ocorrenciaRepositorio.BuscarPorId(ocorrencia.Id);

            if (OcorrenciaBD == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Ocorrência não encontrada!"));
                return false;
            }

            var OcorrenciaDescritaDB = await _ocorrenciaRepositorio.BuscarOcorrenciaPorDescricao(ocorrencia.Descricao);
            
            if ((OcorrenciaDescritaDB != null) && (OcorrenciaBD.Id != OcorrenciaDescritaDB.Id))
            {
                _notificador.AdicionarNotificacao(new Notificacao("Não é possível atualizar pois já existe uma ocorrência com mesma descrição, verifique!"));
                return false;
            }            

            await _ocorrenciaRepositorio.Atualizar(ocorrencia);
            return true;
        }

        public async Task<bool> Deletar(long id)
        {
            var ocorrenciaBD = await _ocorrenciaRepositorio.BuscarPorId(id);
            if (ocorrenciaBD == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Ocorrência não encontrada!"));
                return false;
            }

            await _ocorrenciaRepositorio.Deletar(id);
            return true;
        }
    }
}
