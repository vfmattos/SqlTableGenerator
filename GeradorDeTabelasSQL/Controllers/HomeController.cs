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

        public IActionResult GerarTabela(EstruturaModel estrutura)
        {
            bool nome = estrutura.camposSelecionados.Contains("Nome");
            bool idade = estrutura.camposSelecionados.Contains("Idade");
            bool sexo = estrutura.camposSelecionados.Contains("Sexo");
            bool cidade = estrutura.camposSelecionados.Contains("Cidade");
            bool estado = estrutura.camposSelecionados.Contains("Estado");
            bool rg = estrutura.camposSelecionados.Contains("Rg");
            bool cpf = estrutura.camposSelecionados.Contains("Cpf");

            var tabela = new List<TabelaModel>();

            tabela.Add(new TabelaModel());
            
            for(int i = 0; i < estrutura.camposSelecionados.Count; i++)
            {
                tabela[0].camposSelecionados.Add(estrutura.camposSelecionados[i]);
            }
            
            for (int i = 0; i < estrutura.NumeroDePessoas; i++)
            {

                var tabelaAux = new TabelaModel();

                if (nome) { tabelaAux.NomeUser = tabelaAux.GerarVetorNomes()[i]; }
                if (idade) { tabelaAux.Idade = tabelaAux.GerarVetorIdade()[i]; }
                if(sexo) { tabelaAux.Sexo = tabelaAux.GerarVetorSexo()[i]; }
                if(cidade) { tabelaAux.Cidade = tabelaAux.GerarVetorCidade()[i]; }
                if(estado) { tabelaAux.Estado = tabelaAux.GerarVetorEstado()[i]; }
                if(rg) { tabelaAux.Rg = tabelaAux.GerarVetorRg()[i]; }
                if (cpf) { tabelaAux.Cpf = tabelaAux.GerarVetorCpf()[i]; }

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