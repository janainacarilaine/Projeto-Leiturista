using Business.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositorios
{
    public interface ILeituraRepositorio : IBaseRepositorio<Leitura>
    {
        Task<IEnumerable<Leitura>> BuscarPorLeiturista(long matricula);

        Task<IEnumerable<Leitura>> BuscarPorOcorrencia(string descricao);

        Task<IEnumerable<Leitura>> BuscarPorMesAno(int mes, int ano);
    }
}
