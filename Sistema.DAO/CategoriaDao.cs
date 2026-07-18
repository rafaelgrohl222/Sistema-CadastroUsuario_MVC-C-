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
    public class CategoriaDao
    {
        //Método Inserir
        public int Inserir(CategoriaEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "INSERT INTO tbl_categoria (nomeCategoria, ativo) VALUES (@nomeCategoria, @ativo)";

                cn.Parameters.Add("nomeCategoria", SqlDbType.VarChar).Value = objTabela.NomeCategoria;
                cn.Parameters.Add("ativo", SqlDbType.Bit).Value = Convert.ToBoolean(objTabela.Ativo);

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();

                return qtd;
            }
        }

        //Método Buscar
        public List<CategoriaEnt> Buscar(CategoriaEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * FROM tbl_categoria WHERE nomeCategoria LIKE @nomeCategoria";

                cn.Parameters.Add("nomeCategoria", SqlDbType.VarChar).Value = "%" + objTabela.NomeCategoria + "%";

                cn.Connection = con;

                SqlDataReader dr;

                List<CategoriaEnt> lista = new List<CategoriaEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CategoriaEnt dado = new CategoriaEnt();

                        dado.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                        dado.NomeCategoria = Convert.ToString(dr["nomeCategoria"]);
                        dado.Ativo = Convert.ToBoolean(dr["ativo"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }

        //Método Editar
        public int Editar(CategoriaEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "UPDATE tbl_categoria SET nomeCategoria = @nomeCategoria, ativo = @ativo WHERE idCategoria = @idCategoria";

                cn.Parameters.Add("nomeCategoria", SqlDbType.VarChar).Value = objTabela.NomeCategoria;
                cn.Parameters.Add("ativo", SqlDbType.Bit).Value = objTabela.Ativo;
                cn.Parameters.Add("idCategoria", SqlDbType.Int).Value = objTabela.IdCategoria;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();

                return qtd;
            }
        }

        //Método Excluir
        public int Excluir(CategoriaEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "DELETE FROM tbl_categoria WHERE idCategoria = @idCategoria";

                cn.Parameters.Add("idCategoria", SqlDbType.Int).Value = objTabela.IdCategoria;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();

                return qtd;
            }
        }

        //Método Lista
        public List<CategoriaEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=DESKTOP-A0D6SHM\\RAFAEL;Initial Catalog=bancomvc;Integrated Security=True";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * FROM tbl_categoria ORDER BY idCategoria DESC";

                cn.Connection = con;

                SqlDataReader dr;

                List<CategoriaEnt> lista = new List<CategoriaEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CategoriaEnt dado = new CategoriaEnt();

                        dado.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                        dado.NomeCategoria = Convert.ToString(dr["nomeCategoria"]);
                        dado.Ativo = Convert.ToBoolean(dr["ativo"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }
    }
}
