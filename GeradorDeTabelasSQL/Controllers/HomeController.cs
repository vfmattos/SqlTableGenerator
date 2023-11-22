using GeradorDeTabelasSQL.Models;
using GeradorDeTabelasSQL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeradorDeTabelasSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var tabela = new TabelaModel();
              

            return View(tabela);
        }

     

        [HttpPost]

        public IActionResult GerarTabela(TabelaModel estrutura)
        {
            //Verificando quais elementos foram selecionados nos checkbox
            bool nome = estrutura.CamposSelecionados.Contains("Nome");
            bool idade = estrutura.CamposSelecionados.Contains("Idade");
            bool sexo = estrutura.CamposSelecionados.Contains("Sexo");
            bool cidade = estrutura.CamposSelecionados.Contains("Cidade");
            bool estado = estrutura.CamposSelecionados.Contains("Estado");
            bool rg = estrutura.CamposSelecionados.Contains("Rg");
            bool cpf = estrutura.CamposSelecionados.Contains("Cpf");

            //Lista a ser "povoada" por elementos do tipo TabelaModel
            var tabela = new List<TabelaModel>();

            //Intanciando um objeto tipo Random. O Método Random.Next() será usado para gerar um indíce randômico nos métodos de TabelaModel
            Random random = new Random();

            //Primeiro elemento na lista. Usado para retornar o cabeçalho da tabela.
            tabela.Add(new TabelaModel() { QueryCreate = new Metodos().QueryCreateTable(estrutura)});
            
            //Criação do cabeçalho da tabela de acordo com os elementos selecionados.
            for(int i = 0; i < estrutura.CamposSelecionados.Count; i++)
            {
                tabela[0].CamposSelecionados.Add(estrutura.CamposSelecionados[i]);
            }
            
            //Inserção de dados randômicos na tabela
            for (int i = 0; i < estrutura.NumeroDePessoas; i++)
            {

                var tabelaAux = new TabelaModel
                {
                    Id = i + 1
                };
                if (nome) { tabelaAux.NomeUser = tabelaAux.GerarVetorNomes()[random.Next(0, tabelaAux.GerarVetorNomes().Length)]; }
                if (idade) { tabelaAux.Idade = tabelaAux.GerarVetorIdade()[random.Next(0, tabelaAux.GerarVetorIdade().Length)]; }
                if(sexo) { tabelaAux.Sexo = tabelaAux.GerarVetorSexo()[random.Next(0, tabelaAux.GerarVetorSexo().Length)]; }
                if(cidade) { tabelaAux.Cidade = tabelaAux.GerarVetorCidade()[random.Next(0, tabelaAux.GerarVetorCidade().Length)]; }
                if(estado) { tabelaAux.Estado = tabelaAux.GerarVetorEstado()[random.Next(0, tabelaAux.GerarVetorEstado().Length)]; }
                if(rg) { tabelaAux.Rg = tabelaAux.GerarVetorRg()[random.Next(0, tabelaAux.GerarVetorRg().Length)]; }
                if (cpf) { tabelaAux.Cpf = tabelaAux.GerarVetorCpf()[random.Next(0, tabelaAux.GerarVetorCpf().Length)]; }



                tabela.Add(tabelaAux);
            }
            return View(tabela);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}