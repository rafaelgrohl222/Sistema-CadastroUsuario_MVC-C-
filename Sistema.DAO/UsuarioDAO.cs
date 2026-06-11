using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades;
using System.Data;

namespace Sistema.DAO
{
    public class UsuarioDAO
    {
        public int Inserir(UsuarioEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

    //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                cn.CommandText = "INSERT INTO tbl_usuarios ([nome], [usuario], [senha]) VALUES (@nome, @usuario, @senha)";

                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;//Parametro Que vem do compo p/ add BD
                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = objTabela.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = objTabela.Senha;

                cn.Connection = con;//Associando SqlCommand a conexão

                int qtd = cn.ExecuteNonQuery();//Executar os parametros e conferir quantidade cadastrada
                //Console.Write(qtd);
                return qtd;
            }//Parei na auta 19 0min
        }
    }
}
