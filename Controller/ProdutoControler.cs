using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprendendo_MVC.Model;
using Aprendendo_MVC.View;

namespace Aprendendo_MVC.Controller
{
    public class ProdutoControler
    {
        //instanciar objeto prroduto e produtoView
        Produto produto = new Produto();
        ProdutoView produtoView = new ProdutoView();

        public void ListarProdutos()
        {
            List<Produto> produtos = produto.Ler();
            produtoView.Listar(produtos);
        }

        public void CadastrarProduto()
        {
            Produto novo = produtoView.Cadastrar();
            produto.Inserir(novo);
        }
    }
}