using GeradorDeTabelasSQL.Models;

namespace GeradorDeTabelasSQL.Repositorio
{
    public interface IMetodos
    {

        public string QueryCreateTable(TabelaModel tabela);

    }
}
