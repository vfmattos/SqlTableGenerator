namespace GeradorDeTabelasSQL.Models
{
    public class EstruturaModel
    {
        public int NumeroDePessoas { get; set; }
        public List<string> camposSelecionados { get; set; } = new List<string>();
    }
}
