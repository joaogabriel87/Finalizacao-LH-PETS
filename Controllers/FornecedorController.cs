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
  
    public class FornecedorController : Controller
    {
        readonly private ApplicationDbContext _db;

        public FornecedorController(ApplicationDbContext db)
        {
            _db =db;
        }

        public IActionResult Index()
        {
            IEnumerable<ForncedorModel>fornecedor = _db.Fornecedor;
            return View(fornecedor);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastrar(ForncedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                _db.Fornecedor.Add(fornecedor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            ForncedorModel fornecedor = _db.Fornecedor.FirstOrDefault(x =>x.Id==id);

            if (id == null)
            {
                return NotFound();
            }
            
            return View(fornecedor);
        }
        
        [HttpPost]
        public IActionResult Editar(ForncedorModel fornecedorr)
        {
            if (ModelState.IsValid)
            {
                _db.Fornecedor.Update(fornecedorr);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedorr);
        }

        public ActionResult Excluir(int? id)
        {
             if (id == null || id==0)
            {
                return NotFound();
            }

            ForncedorModel fornecedor = _db.Fornecedor.FirstOrDefault(x =>x.Id==id);

            if (id == null)
            {
                return NotFound();
            }
            
            return View(fornecedor);
        }

        [HttpPost]
        public IActionResult Excluir(ForncedorModel fornecedor)
        {
            if (fornecedor == null)
            {
                return NotFound();
            }

            _db.Fornecedor.Remove(fornecedor);
            _db.SaveChanges();   
            return RedirectToAction("Index");      
        }
   
    }
}