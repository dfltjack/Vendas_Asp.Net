using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Model.Intefaces
{
    public interface IRepositorioCliente
    {
        Task<List<TBClientes>> ListarTodosAsync();
        List<TBClientes> ListarTodos();

        Task<TBClientes> SelecionarPelaChaveAsync(int id);
        TBClientes SelecionarPelaChave(int id);

        Task<TBClientes> IncluiAsync(TBClientes oCat);
        TBClientes Incluir(TBClientes oCat);

        Task<TBClientes> AlterarAsync(TBClientes oCat);
        TBClientes Alterar(TBClientes oCat);

        Task<bool> ExcluirAsync(int id);
        bool Excluir(int id);

        bool VerificarExistenciaCliente(int id);
        Task<bool> VerificarExistenciaClienteAsync(int id);
    }
}
