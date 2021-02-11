namespace Biblioteca.Models
{
    public class Global
    {
        //Criada para pegar o nome do usuário no banco de dados e usar na conexão.
        public static string NomeDB { get; set; }
        public static int IdDB { get; set; }
        public static int TipoGlobal { get; set; }
        public static string Usuario { get; set; }
    }
}