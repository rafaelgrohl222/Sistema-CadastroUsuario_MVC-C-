using Sistema.DAO;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{
    public class CategoriaModel
    {
            public static int Inserir(CategoriaEnt objTabela)
            {
                return new CategoriaDao().Inserir(objTabela);
            }

            public List<CategoriaEnt> Lista()
            {
                return new CategoriaDao().Lista();
            }

            public static int Excluir(CategoriaEnt objTabela)
            {
                return new CategoriaDao().Excluir(objTabela);
            }

            public static int Editar(CategoriaEnt objTabela)
            {
                return new CategoriaDao().Editar(objTabela);
            }

            public List<CategoriaEnt> Buscar(CategoriaEnt objTabela)
            {
                return new CategoriaDao().Buscar(objTabela);
            }
    }
}
