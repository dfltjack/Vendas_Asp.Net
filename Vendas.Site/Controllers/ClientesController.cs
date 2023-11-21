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

    public class ClientesController : Controller
    {
        private IRepositorioCliente _Repositorio;

        public ClientesController(IRepositorioCliente repositorio)
        {
            _Repositorio = repositorio;
        }
        //private readonly DB_VENDASContext _context;

        //public ClientesController(DB_VENDASContext context)
        //{
        //    _context = context;
        //}

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _Repositorio.ListarTodosAsync());

            //return _context.TBClientes != null ?
            //            View(await _context.TBClientes.ToListAsync()) :
            //            Problem("Entity set 'DB_VENDASContext.TBClientes'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBClientes oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
            if (oCat == null)
            {
                return NotFound();
            }
            return View(oCat);
            //var tBClientes = await _context.TBClientes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (tBClientes == null)
            //{
            //    return NotFound();
            //}

            //return View(tBClientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento,Nome,Telefone,Email")] TBClientes tBClientes)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(tBClientes);
                //await _context.SaveChangesAsync();

                await _Repositorio.IncluiAsync(tBClientes);

                return RedirectToAction(nameof(Index));
            }
            return View(tBClientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBClientes oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
            if (oCat == null)
            {
                return NotFound();
            }
            return View(oCat);

            //if (id == null || _context.TBClientes == null)
            //{
            //    return NotFound();
            //}

            //var tBClientes = await _context.TBClientes.FindAsync(id);
            //if (tBClientes == null)
            //{
            //    return NotFound();
            //}
            //return View(tBClientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Documento,Nome,Telefone,Email")] TBClientes tBClientes)
        {
            if( id == null)
            {
                return NotFound();
            }
            TBClientes oCat = await _Repositorio.SelecionarPelaChaveAsync(tBClientes.Id);
            if (id != tBClientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Repositorio.AlterarAsync(tBClientes);

                    //_context.Update(tBClientes);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!TBClientesExists(tBClientes.Id))
                    if (!_Repositorio.VerificarExistenciaCliente(tBClientes.Id))
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
            return View(tBClientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBClientes oCat = await _Repositorio.SelecionarPelaChaveAsync((int)id);
            if (oCat == null)
            {
                return NotFound();
            }
            return View(oCat);
            //if (id == null || _context.TBClientes == null)
            //{
            //    return NotFound();
            //}

            //var tBClientes = await _context.TBClientes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (tBClientes == null)
            //{
            //    return NotFound();
            //}

            //return View(tBClientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TBClientes oCat = await _Repositorio.SelecionarPelaChaveAsync(id);
            if (oCat == null)
            {
                return NotFound();
            }
            await _Repositorio.ExcluirAsync(id);
            return View(oCat);
            //if (_context.TBClientes == null)
            //{
            //    return Problem("Entity set 'DB_VENDASContext.TBClientes'  is null.");
            //}
            //var tBClientes = await _context.TBClientes.FindAsync(id);
            //if (tBClientes != null)
            //{
            //    _context.TBClientes.Remove(tBClientes);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool TBClientesExists(int id)
        //{
        //    return (_context.TBClientes?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
