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
            using (SqlConnection con = new SqlConnection())///Conexão 
            {
                // Conexão com o banco de dados con = conexão
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                // Abre a conexão
                con.Open();

                //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                cn.CommandText = "INSERT INTO tbl_produtos ([nomeProduto], [descricao], [valor]) VALUES (@nomeProduto, @descricao, @valor)";

                // Parâmetros
                cn.Parameters.Add("nomeProduto", SqlDbType.VarChar).Value = objTabela.NomeProduto;//Parametro Que vem do compo p/ add BD
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = objTabela.Descricao;
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;
                cn.Parameters.Add("idCategoria", SqlDbType.Int).Value = objTabela.IdCategoria;

                // Associa o comando à conexão
                cn.Connection = con;

                // Executa o comando
                int qtd = cn.ExecuteNonQuery();

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
                cn.Parameters.Add("valor", SqlDbType.Decimal).Value = objTabela.Valor;
                cn.Parameters.Add("idCategoria", SqlDbType.Int).Value = objTabela.IdCategoria;
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

        // Lista todos os produtos com suas respectivas categorias.
        public List<ProdutoEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())//Conexão 
            {
                // Associado ao Banco de Dados
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;//Comando SQL

                // Abre a conexão
                con.Open();

                // Lista os produtos juntamente com o nome da categoria - Inner Join
                cn.CommandText = @"SELECT
                        p.id,
                        p.nomeProduto,
                        p.descricao,
                        p.valor,
                        p.idCategoria,
                        c.nomeCategoria
                   FROM tbl_produtos p
                   LEFT JOIN tbl_categoria c
                       ON p.idCategoria = c.idCategoria
                   ORDER BY p.id DESC";

                //(comandos p/ inserir)       INSERIR DADOS tabela (valores campos) valores ()
                //cn.CommandText = "SELECT * from tbl_produtos ORDER BY id DESC";

                // Associa o comando à conexão
                cn.Connection = con;

                SqlDataReader dr;//Realizar consultas

                List<ProdutoEnt> lista = new List<ProdutoEnt>();

                // Executa a consulta
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

                        // Código da categoria
                        if (dr["idCategoria"] != DBNull.Value)
                            dado.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                        else
                            dado.IdCategoria = 0;

                        // Nome da categoria
                        if (dr["nomeCategoria"] != DBNull.Value)
                            dado.NomeCategoria = Convert.ToString(dr["nomeCategoria"]);
                        else
                            dado.NomeCategoria = "";

                        // Adiciona o objeto na lista
                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}
