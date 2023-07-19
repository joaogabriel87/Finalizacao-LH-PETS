using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LH_PETS.Data;
using LH_PETS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LH_PETS.Controllers
{

    public class ClienteController : Controller
    {
        readonly private ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)           
        {
            _db = db;
        }
       
        public IActionResult Index()
        {
            IEnumerable<ClienteModel>cliente = _db.Cliente;
            return View(cliente);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel clientes)
        {
            if (ModelState.IsValid)
            {
               _db.Cliente.Add(clientes);
               _db.SaveChanges();

               return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
           if (id == null || id == 0)
           {
            return NotFound();
           }
           ClienteModel cliente = _db.Cliente.FirstOrDefault(x =>x.Id==id);
           
           if (id == null)
           {
            return NotFound();
           }

           return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel clientes)
        {
            if (ModelState.IsValid)     
            {
                _db.Cliente.Update(clientes);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(clientes);
        }
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
             if (id == null || id == 0)
           {
            return NotFound();
           }
           ClienteModel cliente = _db.Cliente.FirstOrDefault(x =>x.Id==id);
           
           if (id == null)
           {
            return NotFound();
           }

           return View(cliente);
        }

        [HttpPost]
        public IActionResult Excluir(ClienteModel clientes)
        {
            if (clientes == null)
            {
                return NotFound();
            }

            _db.Cliente.Remove(clientes);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}