using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_API.Domains;
using EF_Core_API.Interfaces;
using EF_Core_API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF_Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        // GET: api/<ProdutosController>

        /// <summary>
        /// Lista os Produtos Cadastrados
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoRepository.Listar();
                if (produtos.Count == 0)
                    return NoContent();

                return Ok(produtos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // GET api/<ProdutosController>/5

        /// <summary>
        /// Faz a busca do Produto através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Produto</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            try
            {
                Produto produto = _produtoRepository.BuscarPorId(id);
                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST api/<ProdutosController>
        /// <summary>
        /// Adiciona um Produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>Produto adicionado</returns>
        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                _produtoRepository.Adicionar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT api/<ProdutosController>/5
        /// <summary>
        /// Altera um produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produto"></param>
        /// <returns>Produto alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {

            try
            {
                var prodTemp = _produtoRepository.BuscarPorId(id);
                if (prodTemp == null)
                    return NotFound();

                produto.Id = id;
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ProdutosController>/5

        /// <summary>
        /// Deleta um Produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Produto Deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
