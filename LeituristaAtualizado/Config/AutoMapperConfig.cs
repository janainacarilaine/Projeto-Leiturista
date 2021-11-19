using AutoMapper;
using Business.Modelos;
using Business.ViewModels;
using Business.ViewModels.Leitura;
using Business.ViewModels.Leiturista;
using Business.ViewModels.Ocorrencia;
using Business.ViewModels.Usuario;

namespace Api.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UsuarioLoginViewModel,Usuario>();
            CreateMap<Usuario,UsuarioLogadoViewModel>();

            CreateMap<UsuarioCadastroViewModel, Usuario>();
            CreateMap<UsuarioAtualizacaoViewModel, Usuario>();
            CreateMap<Usuario, UsuarioExibicaoViewModel>();

            CreateMap<LeituristaCadastroViewModel, Leiturista>();
            CreateMap<Leiturista, LeituristaViewModel>();

            CreateMap<OcorrenciaCadastroViewModel, Ocorrencia>();
            CreateMap<OcorrenciaViewModel, Ocorrencia>().ReverseMap();

            CreateMap<Leitura, LeituraViewModel>()
               .ForMember(l => l.LeituristaViewModel, l => l.MapFrom(l => l.Leiturista))
               .ForMember(l => l.OcorrenciaViewModel, l => l.MapFrom(l => l.Ocorrencia));

            CreateMap<LeituraCadastroViewModel, Leitura>().ReverseMap();
            CreateMap<LeituraAtualizacaoViewModel, Leitura>();
        }
    }
}
