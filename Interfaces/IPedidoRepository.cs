using EF_Core_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_API.Interfaces
{
    interface IPedidoRepository
    {
        List<Pedido> Listar();

        Pedido Adicionar(List<PedidoItem> pedidoItens);

        Pedido BuscarPorId(Guid id);
    }
}
