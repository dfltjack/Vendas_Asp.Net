using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Model.Repositorios
{
    public class RepositorioProduto : IRepositorioProduto
    {
        DB_VENDASContext _Context;
        public RepositorioProduto(DB_VENDASContext oContexto)
        {
            _Context = oContexto;
        }

        public TBProdutos Alterar(TBProdutos oCat)
        {
            TBProdutos? oCatAltera = _Context.TBProdutos.Find(oCat.Id);
            if(oCatAltera != null)
            {
                oCatAltera.Descrição = oCat.Descrição;
                oCatAltera.IdCategoria = oCat.IdCategoria;
                oCatAltera.Unidade = oCat.Unidade;
                oCatAltera.Foto = oCat.Foto;
                oCatAltera.MimeType = oCat.MimeType;
                oCatAltera.Preco = oCat.Preco;
                _Context.TBProdutos.Update(oCatAltera);
                _Context.SaveChanges();
                return oCat;
            }
            else
            {
                return null;
            }
        }

        public async Task<TBProdutos> AlterarAsync(TBProdutos oCat)
        {
            TBProdutos? oCatAltera = await _Context.TBProdutos.FindAsync(oCat.Id);
            if (oCatAltera != null)
            {
                oCatAltera.Descrição = oCat.Descrição;
                oCatAltera.IdCategoria = oCat.IdCategoria;
                oCatAltera.Unidade = oCat.Unidade;
                oCatAltera.Foto = oCat.Foto;
                oCatAltera.MimeType = oCat.MimeType;
                oCatAltera.Preco = oCat.Preco;
                _Context.TBProdutos.Update(oCatAltera);
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
            TBProdutos? oCat = _Context.TBProdutos.Find(id);
            if (oCat != null)
            {
                _Context.TBProdutos.Remove(oCat);
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
            TBProdutos? oCat = _Context.TBProdutos.Find(id);
            if (oCat != null)
            {
                _Context.TBProdutos.Remove(oCat);
                await _Context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TBProdutos> IncluiAsync(TBProdutos oCat)
        {
            _Context.TBProdutos.Add(oCat);
            await _Context.SaveChangesAsync();
            return oCat;
        }        

        public TBProdutos Incluir(TBProdutos oCat)
        {
            _Context.TBProdutos.Add(oCat);
            _Context.SaveChanges();
            return oCat;
        }       

        public List<TBProdutos> ListarTodos()
        {
            return _Context.TBProdutos.ToList();
        }

        public async Task<List<TBProdutos>> ListarTodosAsync()
        {
            return await _Context.TBProdutos.ToListAsync();
        }

        public TBProdutos SelecionarPelaChave(int id)
        {
            //TBProdutos oCat = _Context.TBProdutos.FirstOrDefault(x => x.ID == id);
            TBProdutos oCat = (from p in _Context.TBProdutos where p.Id == id select p).FirstOrDefault();
            return oCat;
        }

        public async Task<TBProdutos> SelecionarPelaChaveAsync(int id)
        {
            TBProdutos oCat = await _Context.TBProdutos.FirstOrDefaultAsync(x => x.Id == id);
            return oCat;
        }

        public bool VerificarExistenciaProduto(int id)
        {
            {
                return (_Context.TBProdutos?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        }

        public async Task<bool> VerificarExistenciaProdutoAsync(int id)
        {
            throw new NotImplementedException();
        }
     }  
}
