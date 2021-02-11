using System;
using System.Collections.Generic;
using Biblioteca.Models;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Models
{
    public static class Logar{        
        private const string _strConexao = "Database=Biblioteca;Data Source=localhost;User Id=root;";
        private static MySqlConnection conexao = new MySqlConnection(_strConexao);
        public static List<Login> Login(){
            conexao.Open();
            string sql = "SELECT * FROM Usuarios";
            MySqlCommand Query = new MySqlCommand(sql, conexao);
            MySqlDataReader resultado = Query.ExecuteReader();
            List<Login> listaUsuarios = new List<Login>();
            while (resultado.Read()){
                Login usuario = new Login();
                usuario.login = resultado.GetString("login");
                usuario.senha = resultado.GetString("senha");
                usuario.nome = resultado.GetString("nome");
                usuario.tipo = resultado.GetInt32("tipo");                
                listaUsuarios.Add(usuario);
                Global.NomeDB = resultado.GetString("nome");
                Global.TipoGlobal = usuario.tipo;
            }
            resultado.Close();
            conexao.Close();
            return listaUsuarios;
        }
                
        public static List<Usuario> ListarUsuarios(){
            conexao.Open();
            string sql = "SELECT * FROM Usuarios";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuario> listarUsuarios = new List<Usuario>();
            while (reader.Read()){
                Usuario usuario = new Usuario();
                if(reader.GetInt32("Tipo") == 2){
                    usuario.Id = reader.GetInt32("id");
                    usuario.Nome = reader.GetString("nome");
                    usuario.dataNasc = reader.GetString("dataNasc");
                    usuario.Login = reader.GetString("login");
                    usuario.Senha = reader.GetString("senha");
                    usuario.Tipo = reader.GetInt32("tipo");                    
                    listarUsuarios.Add(usuario);

                    //Pegar o código do Banco de Dados do usuário
                    Global.IdDB = reader.GetInt32("id");
                    //Tipo de usuario
                    Global.TipoGlobal = reader.GetInt32("tipo");
                      if(Global.TipoGlobal > 0){
                        if(Global.TipoGlobal == 1)
                            Global.Usuario = "Administrador";

                        if(Global.TipoGlobal == 2)
                            Global.Usuario = "Colaborador";

                        if(Global.TipoGlobal == 3)
                            Global.Usuario = "Usuário Comum";
                      }
                }
            }
            reader.Close();
            conexao.Close();
            return listarUsuarios;
        }

    }
}