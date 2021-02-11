using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
      /*   public void Inserir(Usuario u)
        {           
                dotUsuario.Add(u);
                SaveChanges();            
        } */

         public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }
       
    
     public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                usuario.Nome = u.Nome;
                usuario.Cpf = u.Cpf;
                usuario.Endereco = u.Endereco;
                usuario.Cidade = u.Cidade;
                usuario.dataNasc = u.dataNasc;
                usuario.Login = u.Login;
                usuario.Senha = u.Senha;

                bc.SaveChanges();
            }
        }   

    /*
        public void Atualizar(Usuario e)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(e.Id);
                usuario.Nome = e.Nome;
                usuario.Cpf = e.Cpf;
                usuario.Endereco = e.Endereco;
                usuario.dataNasc = e.dataNasc;
                usuario.Login = e.Login;
                usuario.Senha = e.Senha;

                bc.SaveChanges();
            }
        }  
        */         

      //Listar todos
    
       /* public ICollection<Usuario> ListarTodos()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                //return bc.Include(e => e.Usuario).ToList();
            }
        } */


      /*  public ICollection<Usuario> ListarTodos()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                //busca os livros onde o id não está entre os ids de livro em empréstimo
                // utiliza uma subconsulta
                return
                    bc.Usuarios
                    .Where(u =>  !(bc.Usuarios.Where(u => u.Devolvido == false).Select(e => u.Id).Contains(u.Id)) )
                    .ToList();
            }
        }
        */
        //Listagem

        public ICollection<Usuario> ListarTodos(FiltrosUsuarios filtro = null)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                
                if(filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro)
                    {
                        case "Nome":
                            query = bc.Usuarios.Where(u => u.Nome.Contains(filtro.Filtro));
                        break;

                        case "Cpf":
                            query = bc.Usuarios.Where(u => u.Nome.Contains(filtro.Filtro));
                        break;

                        default:
                            query = bc.Usuarios;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Usuarios;
                }
                
                //ordenação padrão
                return query.OrderBy(u => u.Nome).ToList();
            }
        }

    }
}