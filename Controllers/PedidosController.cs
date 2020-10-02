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

    public class PedidosController : ControllerBase
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController()
        {
            _pedidoRepository = new PedidoRepository();
        }
        // GET: api/<PedidosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedido = _pedidoRepository.Listar();

                if (pedido.Count == 0)
                    return NoContent();

                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<PedidosController>
        [HttpPost]
        public IActionResult Post([FromBody] List<PedidoItem>  pedidoItens)
        {

            try
            {
                Pedido pedido = _pedidoRepository.Adicionar(pedidoItens);

                return Ok(pedido)
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {

            try
            {

            }
            catch (Exception)
            {

                throw;
            }

        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
