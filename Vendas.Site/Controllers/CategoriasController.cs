using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vendas.Model;
using Vendas.Model.Intefaces;
using Vendas.Model.Repositorios;

namespace Vendas.Site.Controllers
{
    public class CategoriasController : Controller
    {
        private IRepositorioCategoria _Repositorio;
        public CategoriasController(IRepositorioCategoria repositorio)
        {
            _Repositorio = repositorio;
        }
        //private readonly DB_VENDASContext _context;

        //public CategoriasController(DB_VENDASContext context)
        //{
        //    _context = context;
        //}

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _Repositorio.ListarTodosAsync());

            //return _context.TBCategorias != null ?
            //            View(await _context.TBCategorias.ToListAsync()) :
            //            Problem("Entity set 'DB_VENDASContext.TBCategorias'  is null.");
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBCategorias oCat = await _Repositorio.SelecionarPelaChaveAsync((int) id);
            if(oCat == null)
            {
                return NotFound();
            }
            return View(oCat);

            //var tBCategorias = await _context.TBCategorias
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (tBCategorias == null)
            //{
            //    return NotFound();
            //}

            //return View(tBCategorias);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descrição")] TBCategorias tBCategorias)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(tBCategorias);
                //await _context.SaveChangesAsync();

                await _Repositorio.IncluiAsync(tBCategorias); 
                
                return RedirectToAction(nameof(Index));
            }
            return View(tBCategorias);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBCategorias oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
            if (oCat == null)
            {
                return NotFound();
            }
            return View(oCat);
            //if (id == null || _context.TBCategorias == null)
            //{
            //    return NotFound();
            //}

            //var tBCategorias = await _context.TBCategorias.FindAsync(id);
            //if (tBCategorias == null)
            //{
            //    return NotFound();
            //}
            //return View(tBCategorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descrição")] TBCategorias tBCategorias)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBCategorias oCat = await _Repositorio.SelecionarPelaChaveAsync(tBCategorias.ID);
            if (oCat == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    await _Repositorio.AlterarAsync(tBCategorias);
                    //_context.Update(tBCategorias);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!TBCategoriasExists(tBCategorias.ID))
                    if(!_Repositorio.VerificarExistenciaCategoria(tBCategorias.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tBCategorias);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            TBCategorias oCat = await _Repositorio.SelecionarPelaChaveAsync((int) id);
            if (oCat == null)
            {
                return NotFound();
            }
            return View(oCat);

            //if (id == null || _context.TBCategorias == null)
            //{
            //    return NotFound();
            //}

            //var tBCategorias = await _context.TBCategorias
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (tBCategorias == null)
            //{
            //    return NotFound();
            //}

            //return View(tBCategorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBCategorias oCat = await _Repositorio.SelecionarPelaChaveAsync(id);
            if (oCat == null)
            {
                return NotFound();
            }
            await _Repositorio.ExcluirAsync(id);
            return View(oCat);

            //if (_context.TBCategorias == null)
            //{
            //    return Problem("Entity set 'DB_VENDASContext.TBCategorias'  is null.");
            //}
            //var tBCategorias = await _context.TBCategorias.FindAsync(id);
            //if (tBCategorias != null)
            //{
            //    _context.TBCategorias.Remove(tBCategorias);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool TBCategoriasExists(int id)
        //{
        //    return (_context.TBCategorias?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
