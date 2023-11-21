using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model.Intefaces;

namespace Vendas.Model.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        DB_VENDASContext _Context;
        public RepositorioCategoria(DB_VENDASContext oContexto)
        {
            _Context = oContexto;
        }
        public TBCategorias? Alterar(TBCategorias oCat)
        {
            TBCategorias? oCatAltera = _Context.TBCategorias.Find(oCat.ID);
            if (oCatAltera != null)
            {
                oCatAltera.Descrição = oCat.Descrição;
                _Context.TBCategorias.Update(oCatAltera);
                _Context.SaveChanges();
                return oCat;
            }
            else
            {
                return null;
            }
        }

        public async Task<TBCategorias> AlterarAsync(TBCategorias oCat)
        {
            TBCategorias? oCatAltera = await _Context.TBCategorias.FindAsync(oCat.ID);
            if (oCatAltera != null)
            {
                oCatAltera.Descrição = oCat.Descrição;
                _Context.TBCategorias.Update(oCatAltera);
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
            TBCategorias? oCat =  _Context.TBCategorias.Find(id);
            if (oCat != null)
            {
                _Context.TBCategorias.Remove(oCat);
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
            TBCategorias? oCat = await _Context.TBCategorias.FindAsync(id);
            if (oCat != null)
            {
                _Context.TBCategorias.Remove(oCat);
                await _Context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public TBCategorias Incluir(TBCategorias oCat)
        {
            _Context.TBCategorias.Add(oCat);
            _Context.SaveChanges();
            return oCat;
        }

        public async Task<TBCategorias> IncluiAsync(TBCategorias oCat)
        {
            _Context.TBCategorias.Add(oCat);
            await _Context.SaveChangesAsync();
            return oCat;
        }       

        public List<TBCategorias> ListarTodos()
        {
            return _Context.TBCategorias.ToList();
        }

        public async Task<List<TBCategorias>> ListarTodosAsync()
        {
            return await _Context.TBCategorias.ToListAsync();
        }
        
        public TBCategorias? SelecionarPelaChave(int id)
        {
            //TBCategorias oCat = _Context.TBCategorias.FirstOrDefault(x => x.ID == id);
            TBCategorias oCat = (from p in _Context.TBCategorias where p.ID == id select p).FirstOrDefault();
            return oCat;
        }

        public async Task<TBCategorias> SelecionarPelaChaveAsync(int id)
        {
            TBCategorias oCat = await _Context.TBCategorias.FirstOrDefaultAsync(x => x.ID == id);
            return oCat;
        }

        public bool VerificarExistenciaCategoria(int id)
        {
            return (_Context.TBCategorias?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        
        public Task<bool> VerificarExistenciaCategoriaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
