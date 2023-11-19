namespace GeradorDeTabelasSQL.Models
{
    public class TabelaModel
    {
        public List<string> Nome { get; set; } = new List<string>();
        public List<string> camposSelecionados { get; set; } = new List<string>();
        public string? NomeUser { get; set; }
        public string? Idade { get; set; }
        public string? Sexo { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Rg { get; set; }
        public string? Cpf { get; set; }

        public TabelaModel()
        {
            Nome.Add("Nome");
            Nome.Add("Idade");
            Nome.Add("Sexo");
            Nome.Add("Cidade");
            Nome.Add("Estado");
            Nome.Add("Rg");
            Nome.Add("Cpf");
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

        public string GerarRGFicticio(Random random)
        {
            int primeiroBloco = random.Next(10, 100);
            int segundoBloco = random.Next(100_000, 1_000_000);
            int terceiroBloco = random.Next(10, 100);

            return $"{primeiroBloco:D2}.{segundoBloco:D3}.{terceiroBloco:D3}-X";
        }

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

        public string GerarCPFFicticio(Random random)
        {
            int primeiroBloco = random.Next(100, 999);
            int segundoBloco = random.Next(100, 999);
            int terceiroBloco = random.Next(100, 999);
            int digitoVerificador1 = random.Next(0, 9);
            int digitoVerificador2 = random.Next(0, 9);

            return $"{primeiroBloco:D3}.{segundoBloco:D3}.{terceiroBloco:D3}-{digitoVerificador1:D2}{digitoVerificador2:D2}";
        }
    }
}
