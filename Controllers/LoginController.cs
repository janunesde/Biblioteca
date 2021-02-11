using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Biblioteca.Controllers
{
    
    public class LoginController : Controller
    {
        public IActionResult Cadastro()
        {
            UsuarioService usuarioService = new UsuarioService();            

             UsuarioService cadModel = new  UsuarioService();
           // cadModel.Usuario = usuario.ListarTodos();
            return View();
        }

         [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService usuarioService = new UsuarioService();

            if(u.Id == 0)
            {
                usuarioService.Inserir(u);
            }
            else
            {
                usuarioService.Atualizar(u);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem()
        {           
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.ListarTodos());
        }

        public IActionResult Edicao(int id)
        {
            UsuarioService usuarioService = new UsuarioService();
            UsuarioService em = new UsuarioService();
           // Usuario u = em.ObterPorId(id);

            UsuarioService cadModel = new UsuarioService();
            //cadModel.ListarTodos();
            //cadModel.Usuario = u;
            
            return View(cadModel);
        }
    }
}