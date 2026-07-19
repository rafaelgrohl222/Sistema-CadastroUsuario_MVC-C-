using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class ProdutoEnt
    {
        //Entidades do Produto
        private int id;
        private string nomeProduto;
        private string descricao;
        private decimal valor;

        //Entidades da Categoria
        private int idCategoria;
        private string nomeCategoria;

        //Entidades do Produto
        public int Id { get => id; set => id = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public decimal Valor { get => valor; set => valor = value; }

        //Entidades da Categoria
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NomeCategoria { get => nomeCategoria; set => nomeCategoria = value; }
    }
}
