using GeradorDeTabelasSQL.Models;

namespace GeradorDeTabelasSQL.Repositorio
{
    public interface ITabelaRepositorio
    {

        public string QueryCreateTable(TabelaModel tabela);

        public void AdicionaTabela(List<TabelaModel> tabela);
        public List<TabelaModel> ListarTabela();

        public string[] GerarVetorNomes();
        public string[] GerarVetorIdade();
        public string[] GerarVetorSexo();
        public string[] GerarVetorCidade();
        public string[] GerarVetorEstado();
        public string[] GerarVetorRg();
        public string GerarRGFicticio(Random random);
        public string[] GerarVetorCpf();
        public string GerarCPFFicticio(Random random);

    }
}
