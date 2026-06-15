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
            }
        }

        public List<UsuarioEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                cn.CommandText = "SELECT * from tbl_usuarios ORDER BY id DESC";

                cn.Connection = con;//Associando SqlCommand a conexão

                SqlDataReader dr;//Realizar consultas
                List<UsuarioEnt> lista = new List<UsuarioEnt>();

                //verificar quantos linhas recebeu da lista
                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    //Faça a leitura dentro do data Read, e mostrar
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }//Parei na auta 26 0min
        }
    }
}
