using Sistema.DAO;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{
    public class ProdutoModel
    {
        //Model Produtos
        public static int Inserir(ProdutoEnt objTabela)
        {
            return new ProdutoDao().Inserir(objTabela);
        }

        public List<ProdutoEnt> Lista()
        {
            return new ProdutoDao().Lista();
        }

        public static int Excluir(ProdutoEnt objTabela)
        {
            return new ProdutoDao().Excluir(objTabela);
        }

        public static int Editar(ProdutoEnt objTabela)
        {
            return new ProdutoDao().Editar(objTabela);
        }

        public List<ProdutoEnt> Buscar(ProdutoEnt objTabela)
        {
            return new ProdutoDao().Buscar(objTabela);
        }
    }
}
