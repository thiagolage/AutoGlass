using AutoGlass.API.DTOs;
using AutoGlass.API.Repositories;
using AutoGlass.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        private readonly IMapper _mapper;

        public string msgValidacaoDataFabricacao = "Data de Fabricação não pode ser maior ou igual a Data de Validade";

        public ProdutosController(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listaProdutos = _repository.GetProdutos();

            List<ProdutoDTO> listaProdutosMapeados = new List<ProdutoDTO>();

            foreach (var produto in listaProdutos)
                listaProdutosMapeados.Add(_mapper.Map<ProdutoDTO>(produto));

            return Ok(listaProdutosMapeados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _repository.GetProduto(id);

            if(produto == null)
                return NotFound("Produto não encontrado");
                        
            return Ok(_mapper.Map<ProdutoDTO>(produto));
        }

        [HttpPost]
        public IActionResult Add([FromBody] Produto produto)
        {
            //Validação de datas
            if (produto.DataFabricacao < produto.DataValidade)
            {
                _repository.AddProduto(produto);
                //return Ok(produto);
                return Ok(_mapper.Map<ProdutoDTO>(produto));
            }
            else
                return BadRequest(msgValidacaoDataFabricacao);
            
        }

        [HttpPut]
        public IActionResult Update([FromBody] Produto produto)
        {
            //Validação de datas
            if (produto.DataFabricacao < produto.DataValidade)
            {
                _repository.UpdateProduto(produto);
                return Ok(_mapper.Map<ProdutoDTO>(produto));
            }
            else
                return BadRequest(msgValidacaoDataFabricacao);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _repository.DeleteProduto(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProdutoByFilters(string? descricao, bool? ativo, string? descricaoFornecedor, string? CNPJFornecedor)
        {
            var listaProdutos = _repository.GetProdutosByFilters(descricao, ativo, descricaoFornecedor, CNPJFornecedor);

            List<ProdutoDTO> listaProdutosMapeados = new List<ProdutoDTO>();

            foreach (var produto in listaProdutos)
                listaProdutosMapeados.Add(_mapper.Map<ProdutoDTO>(produto));

            return Ok(listaProdutosMapeados);
        }

    }
}
