using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAO
{
    public class ProdutoDao
    {
        public int Inserir(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                cn.CommandText = "INSERT INTO tbl_produtos ([nomeProduto], [descricao], [valor]) VALUES (@nomeProduto, @descricao, @valor)";

                cn.Parameters.Add("nomeProduto", SqlDbType.VarChar).Value = objTabela.NomeProduto;//Parametro Que vem do compo p/ add BD
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = objTabela.Descricao;
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;

                cn.Connection = con;//Associando SqlCommand a conexão

                int qtd = cn.ExecuteNonQuery();//Executar os parametros e conferir quantidade cadastrada
                //Console.Write(qtd);
                return qtd;
            }
        }

        public List<ProdutoEnt> Buscar(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       SELECT DADOS tabela QUANDO nome aproximadamente para antes %@nome
                cn.CommandText = "SELECT * from tbl_produtos WHERE nomeProduto LIKE @nomeProduto";

                cn.Parameters.Add("nomeProduto", SqlDbType.VarChar).Value = "%" + objTabela.NomeProduto + "%";//Parametro Que vem do compo p/ add BD

                cn.Connection = con;//Associando SqlCommand a conexão

                SqlDataReader dr;//Realizar consultas
                List<ProdutoEnt> lista = new List<ProdutoEnt>();

                //verificar quantos linhas recebeu da lista
                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    //Faça a leitura dentro do data Read, e mostrar
                    while (dr.Read())
                    {
                        ProdutoEnt dado = new ProdutoEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.NomeProduto = Convert.ToString(dr["nomeProduto"]);
                        dado.Descricao = Convert.ToString(dr["descricao"]);
                        dado.Valor = Convert.ToDecimal(dr["valor"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public int Editar(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       UPDATE tabela campos where receber 
                cn.CommandText = "UPDATE tbl_produtos SET nomeProduto = @nomeProduto, descricao = @descricao, valor = @valor where id = @id";

                cn.Parameters.Add("nomeProduto", SqlDbType.VarChar).Value = objTabela.NomeProduto;//Parametro Que vem do compo p/ add BD
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = objTabela.Descricao;
                cn.Parameters.Add("valor", SqlDbType.VarChar).Value = objTabela.Valor;
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;

                cn.Connection = con;//Associando SqlCommand a conexão

                int qtd = cn.ExecuteNonQuery();//Executar os parametros e conferir quantidade cadastrada
                //Console.Write(qtd);
                return qtd;
            }
        }

        public int Excluir(ProdutoEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                cn.CommandText = "DELETE FROM tbl_produtos where id = @id";

                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;//Parametro Que vem do compo p/ add BD

                cn.Connection = con;//Associando SqlCommand a conexão

                int qtd = cn.ExecuteNonQuery();//Executar os parametros e conferir quantidade cadastrada
                //Console.Write(qtd);
                return qtd;
            }
        }

        public List<ProdutoEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                //Associado ao BD
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                con.Open();//Inicializar o conexão BD

                //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                cn.CommandText = "SELECT * from tbl_produtos ORDER BY id DESC";

                cn.Connection = con;//Associando SqlCommand a conexão

                SqlDataReader dr;//Realizar consultas
                List<ProdutoEnt> lista = new List<ProdutoEnt>();

                //verificar quantos linhas recebeu da lista
                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    //Faça a leitura dentro do data Read, e mostrar
                    while (dr.Read())
                    {
                        ProdutoEnt dado = new ProdutoEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.NomeProduto = Convert.ToString(dr["nomeProduto"]);
                        dado.Descricao = Convert.ToString(dr["descricao"]);
                        dado.Valor = Convert.ToDecimal(dr["valor"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}
