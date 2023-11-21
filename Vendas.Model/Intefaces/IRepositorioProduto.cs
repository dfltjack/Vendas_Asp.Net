using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Model.Intefaces
{
    public interface IRepositorioProduto
    {
        Task<List<TBProdutos>> ListarTodosAsync();
        List<TBProdutos> ListarTodos();

        Task<TBProdutos> SelecionarPelaChaveAsync(int id);
        TBProdutos SelecionarPelaChave(int id);

        Task<TBProdutos> IncluiAsync(TBProdutos oCat);
        TBProdutos Incluir(TBProdutos oCat);

        Task<TBProdutos> AlterarAsync(TBProdutos oCat);
        TBProdutos Alterar(TBProdutos oCat);

        Task<bool> ExcluirAsync(int id);
        bool Excluir(int id);

        bool VerificarExistenciaProduto(int id);
        Task<bool> VerificarExistenciaProdutoAsync(int id);
    }
}
