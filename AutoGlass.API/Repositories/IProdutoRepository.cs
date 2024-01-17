using AutoGlass.Models;

namespace AutoGlass.API.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> GetProdutos();

        Produto GetProduto(int id);

        bool AddProduto(Produto produto);

        bool UpdateProduto(Produto produto);

        bool DeleteProduto(int id);

        List<Produto> GetProdutosByFilters(string? descricao, bool? ativo, string? descricaoFornecedor, string? CNPJFornecedor);
    }
}
