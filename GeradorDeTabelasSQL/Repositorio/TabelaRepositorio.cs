using GeradorDeTabelasSQL.Data;
using GeradorDeTabelasSQL.Models;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace GeradorDeTabelasSQL.Repositorio
{
    public class TabelaRepositorio : ITabelaRepositorio
    {
        private readonly TableContext _tableContext;

        public TabelaRepositorio(TableContext tableContext)
        {
            _tableContext = tableContext;
        }

        public void AdicionaTabela(List<TabelaModel> tabela)
        {
            _tableContext.tabelaModels.AddRange(tabela);
            _tableContext.SaveChanges();
        }

        public List<TabelaModel> ListarTabela()
        {
            return _tableContext.tabelaModels.ToList();
        }

        public string QueryCreateTable(List<TabelaModel> tabela)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> map = new Dictionary<string, string>();


            bool nome = tabela[0].CamposSelecionados.Contains("Nome");
            bool idade = tabela[0].CamposSelecionados.Contains("Idade");
            bool sexo = tabela[0].CamposSelecionados.Contains("Sexo");
            bool cidade = tabela[0].CamposSelecionados.Contains("Cidade");
            bool estado = tabela[0].CamposSelecionados.Contains("Estado");
            bool rg = tabela[0].CamposSelecionados.Contains("Rg");
            bool cpf = tabela[0].CamposSelecionados.Contains("Cpf");

            if (nome) { map.Add("Nome", "VARCHAR(255) NOT NULL"); }
            if (idade) { map.Add("Idade", "INT NOT NULL"); }
            if (sexo) { map.Add("Sexo", "VARCHAR(20) NOT NULL"); }
            if (cidade) { map.Add("Cidade", "VARCHAR(255) NOT NULL"); }
            if (estado) { map.Add("Estado", "VARCHAR(255) NOT NULL"); }
            if (rg) { map.Add("Rg", "VARCHAR(255) NOT NULL"); }
            if (cpf) { map.Add("Cpf", "VARCHAR(255) NOT NULL"); }

            sb.Append("CREATE TABLE Persons (Id INT PRIMARY KEY");

            foreach (KeyValuePair<string, string> kvp in map)
            {
                sb.Append(", " + kvp.Key + " " + kvp.Value);
            }

            sb.Append(");");


            StringBuilder sbi = new StringBuilder();
            sbi.AppendLine("\nINSERT INTO Persons VALUES");

            //bool verificaUltimo = false;

            bool primeiroElemento = true;
            bool isString;
            int id = 0;

            foreach (var insert in tabela)
            {
                if (insert != tabela[0])
                {
                    if (!primeiroElemento)
                    {
                        sbi.AppendLine(",");
                    }
                    else
                    {
                        primeiroElemento = false;
                    }

                    sbi.Append($"({++id}");

                    AdicionarValor(sbi, nome, insert.NomeUser, isString = true);
                    AdicionarValor(sbi, idade, insert.Idade, isString = false);
                    AdicionarValor(sbi, sexo, insert.Sexo, isString = true);
                    AdicionarValor(sbi, cidade, insert.Cidade, isString = true);
                    AdicionarValor(sbi, estado, insert.Estado, isString = true);
                    AdicionarValor(sbi, rg, insert.Rg, isString = true);
                    AdicionarValor(sbi, cpf, insert.Cpf, isString = true);

                    sbi.AppendLine(")");
                }
            }

            // Função para adicionar os valores
            void AdicionarValor(StringBuilder builder, bool adicionarSeparador, string valor, bool isString)
            {
                if (adicionarSeparador && builder[builder.Length - 1] != '(')
                {
                    builder.Append(", ");
                }

                if (isString)
                {
                    builder.Append($"\'{valor}\'");
                }
                else
                {
                    builder.Append($"{valor}");
                }
            }


            sb.Append(sbi.ToString());

            return sb.ToString();

        }

        public string[] GerarVetorNomes()
        {
            return new string[] { "Alice", "Bob", "Charlie", "David", "Emma",
                "Frank", "Grace", "Hank", "Ivy", "Jack",
                "Kelly", "Liam", "Mia", "Noah", "Olivia",
                "Pam", "Quinn", "Ryan", "Sara", "Tom",
                "Uma", "Victor", "Wendy", "Xavier", "Yara",
                "Zane", "Sophia", "Ethan", "Ava", "Logan",
                "Madison", "Caleb", "Chloe", "Daniel", "Emily",
                "Elijah", "Hailey", "Isaac", "Isabella", "Jacob",
                "Kylie", "Lucas", "Lily", "Mason", "Natalie",
                "Owen", "Penelope", "Quentin", "Rachel", "Samuel",
                "Stella", "Theo", "Taylor", "Ursula", "Vincent",
                "Violet", "William", "Willow", "Xander", "Ximena",
                "Yasmine", "Yusuf", "Zara", "Zachary", "Zoe",
                "Xander", "Ximena", "Yasmine", "Yusuf", "Zara",
                "Zachary", "Zoe", "Wyatt", "Aria", "Gabriel",
                "Avery", "Eva", "Ezra", "Hannah", "Hunter",
                "Leah", "Maddox", "Naomi", "Nolan", "Sadie",
                "Sebastian", "Sophie", "Tristan", "Aaliyah", "Adrian" };
        }

        public string[] GerarVetorIdade()
        {
            string[] idades = new string[100];

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                idades[i] = random.Next(1, 101).ToString();
            }

            return idades;
        }

        public string[] GerarVetorSexo()
        {
            string[] sexos = new string[100];

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                sexos[i] = random.Next(0, 2) == 0 ? "Masculino" : "Feminino";
            }

            return sexos;
        }

        public string[] GerarVetorCidade()
        {
            return new string[] {
                "Cidade A", "Cidade B", "Cidade C", "Cidade D", "Cidade E",
                "Cidade F", "Cidade G", "Cidade H", "Cidade I", "Cidade J",
                "Cidade K", "Cidade L", "Cidade M", "Cidade N", "Cidade O",
                "Cidade P", "Cidade Q", "Cidade R", "Cidade S", "Cidade T",
                "Cidade U", "Cidade V", "Cidade W", "Cidade X", "Cidade Y",
                "Cidade Z", "Cidade do Norte", "Cidade do Sul", "Cidade do Leste", "Cidade do Oeste",
                "Nova Cidade", "Velha Cidade", "Cidade Central", "Cidade Costeira", "Cidade Montanhosa",
                "Cidade Verde", "Cidade Dourada", "Cidade Prateada", "Cidade de Cristal", "Cidade de Pedra",
                "Cidade dos Ventos", "Cidade da Lua", "Cidade do Sol", "Cidade da Estrela", "Cidade do Mar",
                "Cidade Tranquila", "Cidade Feliz", "Cidade Brilhante", "Cidade Sombria", "Cidade Misteriosa",
                "Cidade Radiante", "Cidade Encantada", "Cidade Harmoniosa", "Cidade Alegre", "Cidade Serena",
                "Cidade Celestial", "Cidade Submersa", "Cidade Eterna", "Cidade Reluzente", "Cidade Vibrante",
                "Cidade Harmoniosa", "Cidade do Arco-Íris", "Cidade da Aurora", "Cidade do Crepúsculo", "Cidade Efêmera",
                "Cidade da Esperança", "Cidade da Inspiração", "Cidade da Imaginação", "Cidade da Inovação", "Cidade da Aventura",
                "Cidade da Tranquilidade", "Cidade da Paixão", "Cidade da Liberdade", "Cidade da Justiça", "Cidade da Sabedoria",
                "Cidade da Prosperidade", "Cidade da Amizade", "Cidade da Solidariedade", "Cidade da Diversidade", "Cidade da União",
                "Cidade da Resiliência", "Cidade da Perseverança", "Cidade da Generosidade", "Cidade da Sustentabilidade", "Cidade da Tolerância" };
        }

        public string[] GerarVetorEstado()
        {
            string[] estados = {
            "Acre", "Alagoas", "Amapá", "Amazonas", "Bahia",
            "Ceará", "Distrito Federal", "Espírito Santo", "Goiás", "Maranhão",
            "Mato Grosso", "Mato Grosso do Sul", "Minas Gerais", "Pará", "Paraíba",
            "Paraná", "Pernambuco", "Piauí", "Rio de Janeiro", "Rio Grande do Norte",
            "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina", "São Paulo",
            "Sergipe", "Tocantins" };


            string[] estadosAleatorios = new string[100];

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                estadosAleatorios[i] = estados[random.Next(estados.Length)];
            }

            return estadosAleatorios;
        }

        //Gera RG
        public string[] GerarVetorRg()
        {
            string[] rgs = new string[100];

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                rgs[i] = GerarRGFicticio(random);
            }

            return rgs;
        }

        //Formata o RG
        public string GerarRGFicticio(Random random)
        {
            int primeiroBloco = random.Next(10, 100);
            int segundoBloco = random.Next(100, 999);
            int terceiroBloco = random.Next(100, 999);

            return $"{primeiroBloco:D2}.{segundoBloco:D3}.{terceiroBloco:D3}-X";
        }

        //Gera CPF
        public string[] GerarVetorCpf()
        {
            string[] cpfs = new string[100];

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                cpfs[i] = GerarCPFFicticio(random);
            }

            return cpfs;
        }

        //Formata o CPF
        public string GerarCPFFicticio(Random random)
        {
            int primeiroBloco = random.Next(100, 999);
            int segundoBloco = random.Next(100, 999);
            int terceiroBloco = random.Next(100, 999);
            int digitoVerificador1 = random.Next(0, 99);

            return $"{primeiroBloco:D3}.{segundoBloco:D3}.{terceiroBloco:D3}-{digitoVerificador1:D2}";
        }

    }
}
