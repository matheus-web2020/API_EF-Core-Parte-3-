using EF_Core_API.Context;
using EF_Core_API.Domains;
using EF_Core_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto"></param>
        public void Adicionar(Produto produto)
        {
            try
            {

                _ctx.Produtos.Add(produto);

                _ctx.SaveChanges();

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produto pelo seu id
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <returns></returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return _ctx.Produtos.FirstOrDefault(c => c.Id == id );
                return _ctx.Produtos.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void Editar(Produto produto)
        {
            try
            {
                //Busca o produto pelo Id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se o produto realmente existe
                //Se ele não existir ele gera uma exeption(exeção)
                //if (produtoTemp == null)
                //throw new Exception("Produto não encontrado");

                //Se ele existir irá alterar essas propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera o produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salva o contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista os produtos que foram cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                Produto produtoTemp = BuscarPorId(id);

                //Verifica se o produto realmente existe
                //Se ele não existir ele gera uma exeption(exeção)
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Produtos.Remove(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
