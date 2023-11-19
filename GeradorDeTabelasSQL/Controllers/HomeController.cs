using GeradorDeTabelasSQL.Models;
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
            bool nome = estrutura.camposSelecionados.Contains("Nome");
            bool idade = estrutura.camposSelecionados.Contains("Idade");
            bool sexo = estrutura.camposSelecionados.Contains("Sexo");
            bool cidade = estrutura.camposSelecionados.Contains("Cidade");
            bool estado = estrutura.camposSelecionados.Contains("Estado");
            bool rg = estrutura.camposSelecionados.Contains("Rg");
            bool cpf = estrutura.camposSelecionados.Contains("Cpf");

            var tabela = new List<TabelaModel>();

            Random random = new Random();

            tabela.Add(new TabelaModel());
            
            for(int i = 0; i < estrutura.camposSelecionados.Count; i++)
            {
                tabela[0].camposSelecionados.Add(estrutura.camposSelecionados[i]);
            }
            
            for (int i = 0; i < estrutura.NumeroDePessoas; i++)
            {

                var tabelaAux = new TabelaModel();



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