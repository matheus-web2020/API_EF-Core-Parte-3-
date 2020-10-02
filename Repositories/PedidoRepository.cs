using EF_Core_API.Context;
using EF_Core_API.Domains;
using EF_Core_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_API.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidoItens)
        {
            try
            {
                //Criação do objeto do tipo Pedido passando seus valores
                Pedido pedido = new Pedido
                {

                    Status = "Pedido efetuado",
                    OrderDate = DateTime.Now
                };
                
                //Faz a lista de pedidos itens e adiciona  a lista de pedidosItens
                foreach(var item in pedidoItens)
                {
                    //Adiciona o pedidoItem a lista
                    pedido.PedidoItens.Add(new PedidoItem
                    {

                        IdPedido = pedido.Id, //Id do pedido criado acima
                        IdProduto = item.IdProduto,//Id do Produto Instanciado
                        Quantidade = item.Quantidade//Quantidade Instanciada
                    });
                }
                //Adiciona um pedido
                _ctx.Pedidos.Add(pedido);
                //Salva as alterações
                _ctx.SaveChanges();


                return pedido;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
    }
}
