using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeradorDeTabelasSQL.Models
{
    public class TabelaModel
    {
        //Atributos
        public int Id { get; set; }

        [NotMapped]
        public List<string> Nome { get; set; } = new List<string>();

        [NotMapped]
        public List<string> CamposSelecionados { get; set; } = new List<string>();

        public int? NumeroDePessoas { get; set; } = null;
        public string? NomeUser { get; set; }
        public string? Idade { get; set; }
        public string? Sexo { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Rg { get; set; }
        public string? Cpf { get; set; }
        public string? QueryCreate { get; set; }
        public int NumeroPessoas { get; set; }

        //Construtor responsável por inicializar os nomes do cabeçalho da tabela
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

        
    }
}
