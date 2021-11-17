using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Repositorios;
using Business.Interfaces.Servicos;
using Business.Modelos;
using Business.Notificacoes;
using Business.Validations;
using Business.ViewModels;
using Business.ViewModels.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Servicos
{
    public class UsuarioServico : NotificacaoServico, IUsuarioServico
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly INotificador _notificador;
        private readonly ITokenServico _tokenServico;

        public UsuarioServico(IMapper mapper, IUsuarioRepositorio usuarioRepositorio,
            INotificador notificador, ITokenServico tokenServico) : base(notificador)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
            _notificador = notificador;
            _tokenServico = tokenServico;
        }

        public async Task<bool> Adicionar(UsuarioCadastroViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);

            if (!ExecutarValidacao(new UsuarioValidacao(), usuario)) return false;

            await _usuarioRepositorio.Adicionar(usuario);
            return true;
        }

        public async Task<bool> Atualizar(UsuarioAtualizacaoViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);

            var usuarioBD = await _usuarioRepositorio.BuscarPorId(usuario.Id);

            if (usuarioBD == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Usuário não encontrado!"));
                return false;
            }

            if (!ExecutarValidacao(new UsuarioValidacao(), usuario))
                return false;

            await _usuarioRepositorio.Atualizar(usuario);
            return true;
        }

        public async Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarPorFuncao(string funcao)
        {
            var usuarioBD = await _usuarioRepositorio.BuscarPorFuncao(funcao);

            return _mapper.Map<IEnumerable<UsuarioExibicaoViewModel>>(usuarioBD);
        }

        public async Task<UsuarioExibicaoViewModel> BuscarPorId(long id)
        {
            var usuarioBD = await _usuarioRepositorio.BuscarPorId(id);

            if (usuarioBD == null)
                _notificador.AdicionarNotificacao(new Notificacao("Não foi possível encontrar o usuário pelo id informado!"));

            return _mapper.Map<UsuarioExibicaoViewModel>(usuarioBD);
        }

        public async Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarPorNome(string nome)
        {
            var usuarioBD = await _usuarioRepositorio.BuscarPorNome(nome);

            return _mapper.Map<IEnumerable<UsuarioExibicaoViewModel>>(usuarioBD);

        }

        public async Task<UsuarioLogadoViewModel> Logar(UsuarioLoginViewModel usuarioLogin)
        {
            var usuario = await _usuarioRepositorio.BuscarPorEmailSenha(usuarioLogin.Email, usuarioLogin.Senha);

            if (usuario == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Email ou senha inválidos!"));
                return null;
            }

            var usuarioLogado = _mapper.Map<UsuarioLogadoViewModel>(usuario);
            usuarioLogado.Token = _tokenServico.GerarToken(usuario);

            return usuarioLogado;
        }

        public async Task<IEnumerable<UsuarioExibicaoViewModel>> BuscarTodos()
        {
            var usuarioBD = await _usuarioRepositorio.BuscarTodos();

            return _mapper.Map<IEnumerable<UsuarioExibicaoViewModel>>(usuarioBD);
        }

        public async Task<bool> Deletar(long id)
        {
            var usuarioBD = await _usuarioRepositorio.BuscarPorId(id);

            if (usuarioBD == null)
            {
                _notificador.AdicionarNotificacao(new Notificacao("Usuário não encontrado!"));
                return false;
            }

            await _usuarioRepositorio.Deletar(id);
            return true;
        }
    }
}
