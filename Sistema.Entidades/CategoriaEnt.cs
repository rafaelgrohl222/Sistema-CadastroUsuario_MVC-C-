using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class CategoriaEnt
    {


        private int idCategoria;
        private string nomeCategoria;
        private bool ativo;

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NomeCategoria { get => nomeCategoria; set => nomeCategoria = value; }
        public bool Ativo { get => ativo; set => ativo = value; }
    }
}
