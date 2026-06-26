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

        public List<UsuarioEnt> Buscar(UsuarioEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       SELECT DADOS tabela QUANDO nome aproximadamente para antes %@nome
                cn.CommandText = "SELECT * from tbl_usuarios WHERE nome LIKE @nome";

                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = "%" + objTabela.Nome + "%";//Parametro Que vem do compo p/ add BD

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
            }
        }

        public int Editar(UsuarioEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       UPDATE tabela campos where receber 
                cn.CommandText = "UPDATE tbl_usuarios SET nome = @nome, usuario = @usuario, senha = @senha where id = @id";

                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;//Parametro Que vem do compo p/ add BD
                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = objTabela.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = objTabela.Senha;
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;

                cn.Connection = con;//Associando SqlCommand a conexão

                int qtd = cn.ExecuteNonQuery();//Executar os parametros e conferir quantidade cadastrada
                //Console.Write(qtd);
                return qtd;
            }
        }

        public int Excluir(UsuarioEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                cn.CommandText = "DELETE FROM tbl_usuarios where id = @id";

                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;//Parametro Que vem do compo p/ add BD

                cn.Connection = con;//Associando SqlCommand a conexão

                int qtd = cn.ExecuteNonQuery();//Executar os parametros e conferir quantidade cadastrada
                //Console.Write(qtd);
                return qtd;
            }
        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)  Selecionar toda tabela where=onde parâmetros
                cn.CommandText = "SELECT * from tbl_usuarios where usuario = @usuario AND senha = @senha";

                cn.Connection = con;//Associando SqlCommand a conexão

                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = obj.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = obj.Senha;

                SqlDataReader dr;//Realizar consultas

                //verificar quantos linhas recebeu da lista
                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    //Faça a leitura dentro do data Read, e mostrar
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();
                        
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                }
                else
                {
                    //Se não encontrar dados, continua nulo
                    obj.Usuario = null;
                    obj.Senha = null;
                }
                return obj;
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
            }
        }
    }
}
