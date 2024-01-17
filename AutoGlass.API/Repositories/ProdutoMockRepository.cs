
using AutoGlass.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AutoGlass.API.Repositories
{
    public class ProdutoMockRepository : IProdutoRepository
    {

        /*
         * OBS: Não tive tempo de implementar os métodos mockados para a realização dos testes unitários, mas deixo aqui a estrutura mínima para a implementação deles.
         */

        public bool AddProduto(Produto produto)
        {
            return true;
        }

        public bool DeleteProduto(int id)
        {
            return true;
        }

        public Produto GetProduto(int id)
        {
            Produto produto = new Produto();
            produto.Ativo = false;
            return produto;
        }

        public List<Produto> GetProdutos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            listaProdutos.Add(new Produto());
            return listaProdutos;
        }

        public List<Produto> GetProdutosByFilters(string? descricao, bool? ativo, string? descricaoFornecedor, string? CNPJFornecedor)
        {
            List<Produto> listaProdutos = new List<Produto>();
            return listaProdutos;
        }

        public bool UpdateProduto(Produto produto)
        {
            return true;
        }
    }
}
