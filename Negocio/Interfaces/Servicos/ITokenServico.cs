using Business.Modelos;

namespace Business.Interfaces.Servicos
{
    public interface ITokenServico
    {
        string GerarToken(Usuario usuario);
    }
}
