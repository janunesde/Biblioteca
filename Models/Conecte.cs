using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Models
{
    public class Conecte : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                   
            optionsBuilder.UseMySql("Server=localhost;DataBase=Biblioteca;Uid=root;");
        }
    }
}