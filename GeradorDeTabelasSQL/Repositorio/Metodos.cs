using GeradorDeTabelasSQL.Models;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace GeradorDeTabelasSQL.Repositorio
{
    public class Metodos : IMetodos
    {
        public string QueryCreateTable(TabelaModel tabela)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> map = new Dictionary<string, string>();


            if (tabela.CamposSelecionados.Contains("Nome")) { map.Add("Nome", "VARCHAR(255) NOT NULL"); }
            if (tabela.CamposSelecionados.Contains("Idade")) { map.Add("Idade", "INT NOT NULL"); }
            if (tabela.CamposSelecionados.Contains("Sexo")) { map.Add("Sexo", "VARCHAR(20) NOT NULL"); }
            if (tabela.CamposSelecionados.Contains("Cidade")) { map.Add("Cidade", "VARCHAR(255) NOT NULL"); }
            if (tabela.CamposSelecionados.Contains("Estado")) { map.Add("Estado", "VARCHAR(255) NOT NULL"); }
            if (tabela.CamposSelecionados.Contains("Rg")) { map.Add("Rg", "VARCHAR(255) NOT NULL"); }
            if (tabela.CamposSelecionados.Contains("Cpf")) { map.Add("Cpf", "VARCHAR(255) NOT NULL"); }

            sb.Append("CREATE TABLE Persons (Id INT PRIMARY KEY, ");

            foreach (KeyValuePair<string, string> kvp in map)
            {
                sb.Append(kvp.Key + " " + kvp.Value + ",\n");
                //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            sb.Append(");");

            return sb.ToString();

        }
    }
}
