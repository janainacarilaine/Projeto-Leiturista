using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Repositorios;
using Business.Interfaces.Servicos;
using Business.Modelos;
using Business.Notificacoes;
using Business.Validacoes;
using Business.ViewModels.Leiturista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Servicos
{
    public class LeituristaServico : NotificacaoServico, ILeituristaServico
    {
        private readonly IMapper _mapper;
        private readonly ILeituristaRepositorio _leituristaRepositorio;
        private readonly INotificador _notificador;
        public LeituristaServico(INotificador notificador, IMapper mapper, ILeituristaRepositorio leituristaRepositorio) : base(notificador)
        {
            _mapper = mapper;
            _leituristaRepositorio = leituristaRepositorio;
            _notificador = notificador;
        }

         public async Task<bool> Adicionar(LeituristaCadastroViewModel leituristaViewModel)
        {
            var leiturista = _mapper.Map<Leiturista>(leituristaViewModel);

            if (!ExecutarValidacao(new LeituristaValidacao(), leiturista)) return false;

            var leituristaDB = await _leituristaRepositorio.BuscarPorMatricula(leiturista.Matricula);

            if (leituristaDB != null)
            {
               _notificador.AdicionarNotificacao(new Notificacao("Já existe um leiturista com a matrícula informada!"));
                return false;
            }

            await _leituristaRepositorio.Adicionar(leiturista);
            return true;
        }

        public async Task<bool> Atualizar(LeituristaCadastroViewModel leituristaViewModel)
        {
            var leiturista = _mapper.Map<Leiturista>(leituristaViewModel);

            var leituristaBD = await _leituristaRepositorio.BuscarPorMatricula(leiturista.Matricula);

            if (leituristaBD == null)
            {
               _notificador.AdicionarNotificacao(new Notificacao("Leiturista não encontrado!"));
                return false;
            }

            leiturista.Id = leituristaBD.Id;

            if (!ExecutarValidacao(new LeituristaValidacao(), leiturista))
                return false;

            await _leituristaRepositorio.Atualizar(leiturista);
            return true;
        }

        public async Task<LeituristaViewModel> BuscarPorMatricula(long matricula)
        {
            var leituristaBD = await _leituristaRepositorio.BuscarPorMatricula(matricula);

            if (leituristaBD == null)
                _notificador.AdicionarNotificacao(new Notificacao("Leiturista não encontrado!"));

            return _mapper.Map<LeituristaViewModel>(leituristaBD);
        }

        public async Task<IEnumerable<LeituristaViewModel>> BuscarPorNome(string nome)
        {
            var leituristasBD = await _leituristaRepositorio.BuscarPorNome(nome);

            return _mapper.Map<IEnumerable<LeituristaViewModel>>(leituristasBD);

        }

        public async Task<IEnumerable<LeituristaViewModel>> BuscarPorStatus(bool status)
        {
            var leituristasBD = await _leituristaRepositorio.BuscarPorStatus(status);

            return _mapper.Map<IEnumerable<LeituristaViewModel>>(leituristasBD);
        }

        public async Task<IEnumerable<LeituristaViewModel>> BuscarTodos()
        {
            var leituristasBD = await _leituristaRepositorio.BuscarTodos();

            return _mapper.Map<IEnumerable<LeituristaViewModel>>(leituristasBD);
        }       

        public async Task<bool> Deletar(long matricula)
        {
            var leiturista = await _leituristaRepositorio.BuscarPorMatricula(matricula);

            if (leiturista == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Leiturista não encontrado!"));
                return false;
            }

            if (leiturista.Ativo)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Leiturista ativo, impossível deletar!"));
                return false;
            }

            await _leituristaRepositorio.Deletar(leiturista.Id);
            return true;
        }
    }
}
