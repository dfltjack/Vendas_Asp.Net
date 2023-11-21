using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Model.Intefaces
{
    public interface IRepositorioCategoria
    {
        
        Task<List<TBCategorias>> ListarTodosAsync();
        List<TBCategorias> ListarTodos();

        Task<TBCategorias> SelecionarPelaChaveAsync(int id);
        TBCategorias SelecionarPelaChave(int id);

        Task<TBCategorias> IncluiAsync(TBCategorias oCat);
        TBCategorias Incluir(TBCategorias oCat);

        Task<TBCategorias> AlterarAsync(TBCategorias oCat);
        TBCategorias Alterar(TBCategorias oCat);
        
        Task<bool> ExcluirAsync(int id);
        bool Excluir(int id);

        bool VerificarExistenciaCategoria(int id);
        Task<bool> VerificarExistenciaCategoriaAsync(int id);
    }
}
