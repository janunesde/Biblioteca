using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }       
        
        /*
        [HttpPost]
        public IActionResult Login(string tipo, string senha)
        {
            if(tipo != "admin" || senha != "123")
            {
                ViewData["Erro"] = "Senha inválida";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("user", "admin");
                return RedirectToAction("Index");
            }
        }
      
      */  
        /// Login
        [HttpPost]
         public IActionResult Login(Login logando){             
            foreach (Login L in Logar.Login()){
                if (L.login == logando.login){
                        if (L.senha == logando.senha){
                        HttpContext.Session.SetString("Nome", L.nome);
                        if ((L.nome == Global.NomeDB) && (Global.TipoGlobal == 1)){                      
                               HttpContext.Session.SetInt32("Tipo", L.tipo);
                            } else if ((L.nome == Global.NomeDB) && (Global.TipoGlobal == 2)){
                                HttpContext.Session.SetInt32("Tipo", L.tipo);
                            } else{
                            HttpContext.Session.SetInt32("Tipo", L.tipo);                                
                        }
                        HttpContext.Session.SetString("logado", "yes");
                        return RedirectToAction("Index");                   
                    }
                    else{
                        continue;
                    }
                }else{
                    continue;
                }
            }            
            ViewBag.Erro = 2;
            return View("Erro");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
