using AutoGlass.API.Database;
using AutoGlass.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AutoGlassContext _db;

        public ProdutoRepository(AutoGlassContext db)
        {
            _db = db;
        }

        public Produto GetProduto(int id)
        {
            return _db.Produto.Find(id)!;
        }

        public List<Produto> GetProdutos()
        {
            return _db.Produto.OrderBy(x => x.Id).ToList();
        }

        public bool AddProduto(Produto produto)
        {
            _db.Produto.Add(produto);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateProduto(Produto produto)
        {
            _db.Produto.Update(produto);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteProduto(int id)
        {
            var produto = GetProduto(id);
            produto.Ativo = false;
            _db.Produto.Update(produto);

            _db.SaveChanges();
            return true;
        }

        public List<Produto> GetProdutosByFilters(string? descricao, bool? ativo, string? descricaoFornecedor, string? CNPJFornecedor)
        {
            var sentencaSQL = "SELECT * FROM [Produto] WHERE 1 = 1 ";

            if (descricao != null)
                sentencaSQL = sentencaSQL + $" AND Descricao LIKE '%{descricao}%' ";

            if (ativo != null)
                sentencaSQL = sentencaSQL + $"  AND Ativo = '{ativo}' ";

            if (descricaoFornecedor != null)
                sentencaSQL = sentencaSQL + $" AND DescricaoFornecedor LIKE '%{descricaoFornecedor}%' ";

            if (CNPJFornecedor != null)
                sentencaSQL = sentencaSQL + $" AND CNPJFornecedor LIKE '%{CNPJFornecedor}%' ";

            /*
             * Aqui eu deveria ter usado SqlParameter para evitar o risco de sofrer SQL Injection, mas preciso estudar a melhor forma para montar
             * a query de forma condicional, de acordo com os parâmetros passados. Não tive tempo hábil para isso.
             */

            var sqlRaw = _db.Produto.FromSqlRaw(sentencaSQL).IgnoreAutoIncludes().ToList();

            return sqlRaw;

        }
    }
}
