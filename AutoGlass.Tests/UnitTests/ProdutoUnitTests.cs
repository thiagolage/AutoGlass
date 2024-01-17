using AutoGlass.API.Controllers;
using AutoGlass.API.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Tests.UnitTests
{
    public class ProdutoUnitTests
    {
        ProdutoMockRepository _repository = new ProdutoMockRepository();

        [Fact]
        public void CriarProduto()
        {
            //Arrange
            Produto novoProduto = new Produto();
            novoProduto.Id = 0;
            novoProduto.Descricao = "Teste de Criação";
            novoProduto.Ativo = true;

            //Act
            bool resultado = _repository.AddProduto(novoProduto);

            //Assert
            Assert.True(resultado);
        }

        [Fact]
        public void GetListaProdutos()
        {
            //Arrange

            //Act
            List<Produto> resultado = _repository.GetProdutos();

            //Assert
            Assert.True(resultado.Count > 0);
        }

        [Fact]
        public void ExcluirProduto()
        {
            //Arrange

            //Act
            Produto? resultado = null;
            bool exclusao = _repository.DeleteProduto(1);
            if (exclusao)
                resultado = _repository.GetProduto(1);

            //Assert - Como a exlusão é lógica, o registro ainda deve permanecer no banco, porém com o status Ativo = false
            Assert.True(resultado!.Ativo = false);
        }

        [Fact]
        public void AtualizarProduto()
        {
            //Arrange
            Produto produto = _repository.GetProduto(1);
            produto.Descricao = "Produto Atualizado";

            //Act
            bool resultado = _repository.UpdateProduto(produto);

            //Assert
            Assert.True(resultado);
        }
    }
}
