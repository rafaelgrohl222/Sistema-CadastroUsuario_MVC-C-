using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades;

namespace Sistema.DAO
{
    public class UsuarioDAO
    {
        public int Inserir(UsuarioEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                con.ConnectionString = "Properties.Settings.Defaut.banco";//Associado ao BD
            }//Parei na auta 19 0min
        }
    }
}
