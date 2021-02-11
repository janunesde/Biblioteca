namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id{get; set;}
        public string Nome{get; set;}
        public string Cpf{get; set;}
        public string Endereco{get; set;}
        public string Cidade{get; set;}
        public string dataNasc{get; set;}
        public string Login{get; set;}
        public string Senha{get; set;}            
        public int Tipo{get; set;}                
    }
}