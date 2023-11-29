using GeradorDeTabelasSQL.Models;
using GeradorDeTabelasSQL.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeradorDeTabelasSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITabelaRepositorio _tabelaRepositorio;

        public HomeController(ILogger<HomeController> logger, ITabelaRepositorio tabelaRepositorio)
        {
            _logger = logger;
            _tabelaRepositorio = tabelaRepositorio;
        }

        public IActionResult Index()
        {

            var tabela = new TabelaModel();
              

            return View(tabela);
        }

        public IActionResult GerarQueries() {

           var tabela = _tabelaRepositorio.ListarTabela();

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
            tabela.Add(new TabelaModel());
            
            //Criação do cabeçalho da tabela de acordo com os elementos selecionados.
            for(int i = 0; i < estrutura.CamposSelecionados.Count; i++)
            {
                tabela[0].CamposSelecionados.Add(estrutura.CamposSelecionados[i]);
            }
            
            //Inserção de dados randômicos na tabela
            for (int i = 0; i < estrutura.NumeroDePessoas; i++)
            {

                var tabelaAux = new TabelaModel();

                if (nome) { tabelaAux.NomeUser = _tabelaRepositorio.GerarVetorNomes()[random.Next(0, _tabelaRepositorio.GerarVetorNomes().Length)]; }
                if (idade) { tabelaAux.Idade = _tabelaRepositorio.GerarVetorIdade()[random.Next(0, _tabelaRepositorio.GerarVetorIdade().Length)]; }
                if(sexo) { tabelaAux.Sexo = _tabelaRepositorio.GerarVetorSexo()[random.Next(0, _tabelaRepositorio.GerarVetorSexo().Length)]; }
                if(cidade) { tabelaAux.Cidade = _tabelaRepositorio.GerarVetorCidade()[random.Next(0, _tabelaRepositorio.GerarVetorCidade().Length)]; }
                if(estado) { tabelaAux.Estado = _tabelaRepositorio.GerarVetorEstado()[random.Next(0, _tabelaRepositorio.GerarVetorEstado().Length)]; }
                if(rg) { tabelaAux.Rg = _tabelaRepositorio.GerarVetorRg()[random.Next(0, _tabelaRepositorio.GerarVetorRg().Length)]; }
                if (cpf) { tabelaAux.Cpf = _tabelaRepositorio.GerarVetorCpf()[random.Next(0, _tabelaRepositorio.GerarVetorCpf().Length)]; }



                tabela.Add(tabelaAux);
            }

            tabela[0].QueryCreate = _tabelaRepositorio.QueryCreateTable(tabela);

            _tabelaRepositorio.AdicionaTabela(tabela);

            return View(tabela);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}