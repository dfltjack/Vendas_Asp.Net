//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Vendas.Model;
//using Vendas.Model.Intefaces;

//namespace Vendas.Site.Controllers
//{
//    public class ProdutosController : Controller
//    {
//        private IRepositorioProduto _Repositorio;


//        public ProdutosController(IRepositorioProduto repositorio)
//        {
//            _Repositorio = repositorio;
//        }
//        //private readonly DB_VENDASContext _context;

//        //public ProdutosController(DB_VENDASContext context)
//        //{
//        //    _context = context;
//        //}

//        // GET: Produtos
//        public async Task<IActionResult> Index()
//        {
//            return View(await _Repositorio.ListarTodosAsync());
//            //return _context.TBProdutos != null ?
//            //            View(await _context.TBProdutos.ToListAsync()) :
//            //            Problem("Entity set 'DB_VENDASContext.TBProdutos'  is null.");
//        }

//        // GET: Produtos/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
//            if (oCat == null)
//            {
//                return NotFound();
//            }
//            return View(oCat);
//            //if (id == null || _context.TBProdutos == null)
//            //{
//            //    return NotFound();
//            //}

//            //var tBProdutos = await _context.TBProdutos
//            //    .FirstOrDefaultAsync(m => m.Id == id);
//            //if (tBProdutos == null)
//            //{
//            //    return NotFound();
//            //}

//            //return View(tBProdutos);
//        }

//        // GET: Produtos/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create([Bind("Id,IdCategoria,Descrição,Unidade,Foto,MimeType,Preco")] TBProdutos tBProdutos, IFormFile fotoFile)
//{
//    if (ModelState.IsValid)
//    {
//        if (fotoFile != null && fotoFile.Length > 0)
//        {
//            using (var memoryStream = new MemoryStream())
//            {
//                await fotoFile.CopyToAsync(memoryStream);
//                tBProdutos.Foto = memoryStream.ToArray();
//            }
//        }

//        await _Repositorio.IncluiAsync(tBProdutos);
//        return RedirectToAction(nameof(Index));
//    }

//    return View(tBProdutos);
//}

//        //// POST: Produtos/Create
//        //// To protect from overposting attacks, enable the specific properties you want to bind to.
//        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Create([Bind("Id,IdCategoria,Descrição,Unidade,Foto,MimeType,Preco")] TBProdutos tBProdutos)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        //_context.Add(tBProdutos);
//        //        //await _context.SaveChangesAsync();
//        //        await _Repositorio.IncluiAsync(tBProdutos);

//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    return View(tBProdutos);
//        //}

//        // GET: Produtos/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
//            if (oCat == null)
//            {
//                return NotFound();
//            }
//            return View(oCat);

//            //if (id == null || _context.TBProdutos == null)
//            //{
//            //    return NotFound();
//            //}

//            //var tBProdutos = await _context.TBProdutos.FindAsync(id);
//            //if (tBProdutos == null)
//            //{
//            //    return NotFound();
//            //}
//            //return View(tBProdutos);
//        }

//        // POST: Produtos/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCategoria,Descrição,Unidade,Foto,MimeType,Preco")] TBProdutos tBProdutos)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync(tBProdutos.Id);
//            if (id != tBProdutos.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    await _Repositorio.AlterarAsync(tBProdutos);

//                    //_context.Update(tBProdutos);
//                    //await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    //if (!TBProdutosExists(tBProdutos.Id))
//                    if (!_Repositorio.VerificarExistenciaProduto(tBProdutos.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(tBProdutos);
//        }

//        // GET: Produtos/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
//            if (oCat == null)
//            {
//                return NotFound();
//            }
//            return View(oCat);
//            //if (id == null || _context.TBProdutos == null)
//            //{
//            //    return NotFound();
//            //}

//            //var tBProdutos = await _context.TBProdutos
//            //    .FirstOrDefaultAsync(m => m.Id == id);
//            //if (tBProdutos == null)
//            //{
//            //    return NotFound();
//            //}

//            //return View(tBProdutos);
//        }

//        // POST: Produtos/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if(id == null)
//            {
//                return NotFound();
//            }
//            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync(id);
//            if (oCat == null)
//            {
//                return NotFound();
//            }
//            await _Repositorio.ExcluirAsync(id);
//            return View(oCat);
//            //if (_context.TBProdutos == null)
//            //{
//            //    return Problem("Entity set 'DB_VENDASContext.TBProdutos'  is null.");
//            //}
//            //var tBProdutos = await _context.TBProdutos.FindAsync(id);
//            //if (tBProdutos != null)
//            //{
//            //    _context.TBProdutos.Remove(tBProdutos);
//            //}

//            //await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        //private bool TBProdutosExists(int id)
//        //{
//        //    return (_context.TBProdutos?.Any(e => e.Id == id)).GetValueOrDefault();
//        //}
//    }
//}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendas.Model;
using Vendas.Model.Intefaces;

namespace Vendas.Site.Controllers
{
    public class ProdutosController : Controller
    {
        private IRepositorioProduto _Repositorio;

        public ProdutosController(IRepositorioProduto repositorio)
        {
            _Repositorio = repositorio;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _Repositorio.ListarTodosAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
            if (oCat == null)
            {
                return NotFound();
            }

            return View(oCat);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCategoria,Descrição,Unidade,Foto,MimeType,Preco")] TBProdutos tBProdutos, IFormFile fotoFile)
        {
            if (ModelState.IsValid)
            {
                if (fotoFile != null && fotoFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await fotoFile.CopyToAsync(memoryStream);
                        tBProdutos.Foto = memoryStream.ToArray();
                    }
                }

                await _Repositorio.IncluiAsync(tBProdutos);
                return RedirectToAction(nameof(Index));
            }

            return View(tBProdutos);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
            if (oCat == null)
            {
                return NotFound();
            }

            return View(oCat);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCategoria,Descrição,Unidade,Foto,MimeType,Preco")] TBProdutos tBProdutos, IFormFile fotoFile)
        {
            if (id != tBProdutos.Id)
            {
                return NotFound();
            }

            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync(tBProdutos.Id);
            if (oCat == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fotoFile != null && fotoFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await fotoFile.CopyToAsync(memoryStream);
                            tBProdutos.Foto = memoryStream.ToArray();
                        }
                    }

                    await _Repositorio.AlterarAsync(tBProdutos);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_Repositorio.VerificarExistenciaProduto(tBProdutos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(tBProdutos);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
            if (oCat == null)
            {
                return NotFound();
            }

            return View(oCat);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TBProdutos oCat = await _Repositorio.SelecionarPelaChaveAsync(id);
            if (oCat == null)
            {
                return NotFound();
            }

            await _Repositorio.ExcluirAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}