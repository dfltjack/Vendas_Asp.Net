
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model.Intefaces;

namespace Vendas.Model.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        DB_VENDASContext _Context;
        public RepositorioCliente(DB_VENDASContext oContexto)
        {
            _Context = oContexto;
        }

        public TBClientes Alterar(TBClientes oCat)
        {
            TBClientes? oCatAltera = _Context.TBClientes.Find(oCat.Id);
            if (oCatAltera != null)
            {
                oCatAltera.Nome = oCat.Nome;
                oCatAltera.Telefone = oCat.Telefone;
                oCatAltera.Documento = oCat.Documento;
                oCatAltera.Email = oCat.Email;
                _Context.TBClientes.Update(oCatAltera);
                _Context.SaveChanges();
                return oCat;
            }
            else
            {
                return null;
            }
        }

        public async Task<TBClientes> AlterarAsync(TBClientes oCat)
        {
            TBClientes? oCatAltera = await _Context.TBClientes.FindAsync(oCat.Id);
            if (oCatAltera != null)
            {
                oCatAltera.Nome = oCat.Nome;
                oCatAltera.Telefone = oCat.Telefone;
                oCatAltera.Documento = oCat.Documento;
                oCatAltera.Email = oCat.Email;
                _Context.TBClientes.Update(oCatAltera);
                await _Context.SaveChangesAsync();
                return oCat;
            }
            else
            {
                return null;
            }
        }

        public bool Excluir(int id)
        {
            TBClientes? oCat = _Context.TBClientes.Find(id);
            if (oCat != null)
            {
                _Context.TBClientes.Remove(oCat);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            TBClientes? oCat = _Context.TBClientes.Find(id);
            if (oCat != null)
            {
                _Context.TBClientes.Remove(oCat);
                await _Context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TBClientes> IncluiAsync(TBClientes oCat)
        {
            _Context.TBClientes.Add(oCat);
            await _Context.SaveChangesAsync();
            return oCat;
        }

        public TBClientes Incluir(TBClientes oCat)
        {
            _Context.TBClientes.Add(oCat);
            _Context.SaveChanges();
            return oCat;
        }

        public List<TBClientes> ListarTodos()
        {
            return _Context.TBClientes.ToList();
        }

        public async Task<List<TBClientes>> ListarTodosAsync()
        {
            return await _Context.TBClientes.ToListAsync();
        }

        public TBClientes SelecionarPelaChave(int id)
        {
            //TBClientes oCat = _Context.TBClientes.FirstOrDefault(x => x.ID == id);
            TBClientes oCat = (from p in _Context.TBClientes where p.Id == id select p).FirstOrDefault();
            return oCat;
        }

        public async Task<TBClientes> SelecionarPelaChaveAsync(int id)
        {
            TBClientes oCat = await _Context.TBClientes.FirstOrDefaultAsync(x => x.Id == id);
            return oCat;
        }

        public bool VerificarExistenciaCliente(int id)
        {
            {
                return (_Context.TBClientes?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        }

        public Task<bool> VerificarExistenciaClienteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
