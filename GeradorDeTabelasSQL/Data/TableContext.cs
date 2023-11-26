using GeradorDeTabelasSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GeradorDeTabelasSQL.Data
{
    public class TableContext : DbContext
    {

        public TableContext(DbContextOptions<TableContext> options) : base(options) {
        }


        public DbSet<TabelaModel> tabelaModels { get; set; }

    }
}
