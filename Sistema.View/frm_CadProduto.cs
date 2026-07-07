using Sistema.Entidades;
using Sistema.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.View
{
    public partial class frm_CadProduto : Form
    {
        ProdutoEnt objTabela = new ProdutoEnt();

        public frm_CadProduto()
        {
            InitializeComponent();
        }

        private void ListarGrid()
        {
            try
            {
                //Objeto tipo List (Listar itens na gridView)
                List<ProdutoEnt> lista = new List<ProdutoEnt>();
                lista = new ProdutoModel().Lista();
                grid.AutoGenerateColumns = false;//Não gerar linhas automatizadas.
                grid.DataSource = lista;//DataSource rebe lista de dados
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar Dados!" + ex.Message);
            }
        }

        private void btn_Produtos_Click(object sender, EventArgs e)
        {
            frm_CadProduto form = new frm_CadProduto();
            this.Hide();
            form.Show();

        }

        private void frm_CadProduto_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            opc = "Novo";//Recebe o valor "Novo"
            iniciarOpc();
        }

        //Método: Opções (Novo, Salvar, Excluir, Editar ou vazio)
        private string opc = "";
        private void iniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        objTabela.NomeProduto = txt_NomeProduto.Text;
                        objTabela.Descricao = txt_Descricao.Text;
                        objTabela.Valor = Convert.ToDecimal(txt_Valor.Text);

                        //Passando dados dos TexBox para o BD
                        int x = ProdutoModel.Inserir(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto ({0}) Foi Inserido!", txt_NomeProduto.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Inserido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um Error ao Salvar! " + ex.Message);
                    }
                    break;

                case "Excluir":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txt_Codigo.Text);

                        //Passando dados dos TexBox para o BD
                        int x = ProdutoModel.Excluir(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto ({0}) Foi Excluido!", txt_NomeProduto.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Excluido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um Error ao Excluir! " + ex.Message);
                    }
                    break;

                case "Editar":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txt_Codigo.Text);
                        objTabela.NomeProduto = txt_NomeProduto.Text;
                        objTabela.Descricao = txt_Descricao.Text;
                        objTabela.Valor = Convert.ToDecimal(txt_Valor.Text);

                        //Passando dados dos TexBox para o BD
                        int x = ProdutoModel.Editar(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto ({0}) Foi Editado!", txt_NomeProduto.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Alterado!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um Error ao Editar! " + ex.Message);
                    }
                    break;

                case "Buscar":
                        try
                        {
                            objTabela.NomeProduto = txt_Buscar.Text;
                            //Objeto tipo List (Listar itens na gridView)
                            List<ProdutoEnt> lista = new List<ProdutoEnt>();
                            lista = new ProdutoModel().Buscar(objTabela);
                            grid.AutoGenerateColumns = false;//Não gerar linhas automatizadas.
                            grid.DataSource = lista;//DataSource rebe lista de dados
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao Listar Dados!" + ex.Message);
                        }
                        break;

                default:
                    break;
            }
        }

        //Método: Habilitar Campos
        private void HabilitarCampos()
        {
            txt_NomeProduto.Enabled = true;
            txt_Descricao.Enabled = true;
            txt_Valor.Enabled = true;
        }

        //Método Desabilitar Campo
        private void DesabilitarCampo()
        {
            txt_NomeProduto.Enabled = false;
            txt_Descricao.Enabled = false;
            txt_Valor.Enabled = false;
        }

        //Método: Limpar Campos
        private void LimparCampos()
        {
            txt_Codigo.Text = "";
            txt_NomeProduto.Text = "";
            txt_Descricao.Text = "";
            txt_Valor.Text = "";
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";//Recebe o valor "Salvar"
            iniciarOpc();
            ListarGrid();//Atualizar a lista na gridView
            DesabilitarCampo();//Desabilitar campo
            LimparCampos();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (txt_Codigo.Text == "")
            {
                MessageBox.Show("Selecione um Registro na Grid, para Exclui!");
                return;
            }

            opc = "Excluir";//Recebe o valor "Excluir"
            iniciarOpc();
            ListarGrid();//Atualizar a lista na gridView
            DesabilitarCampo();//Desabilitar campo
            LimparCampos();// Limpar Campo
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (txt_Codigo.Text == "")
            {
                MessageBox.Show("Selecione um Registro na Grid, para Editar!");
                return;
            }

            opc = "Editar";//Recebe o valor "Editar"
            iniciarOpc();
            ListarGrid();//Atualizar a lista na gridView
            DesabilitarCampo();//Desabilitar campo
            LimparCampos();// Limpar Campo
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)//Verificação valor menor que 0
                return;

            DataGridViewRow linha = grid.Rows[e.RowIndex];

            if (linha.Cells[0].Value == null)//proteção extra contra valores nulos
                return;

            txt_Codigo.Text = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_NomeProduto.Text = grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Descricao.Text = grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Valor.Text = grid.Rows[e.RowIndex].Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            if (txt_Buscar.Text == "")
            {
                ListarGrid();
                return;
            }
            opc = "Buscar";
            iniciarOpc();
        }

        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            frm_CadUsuario form = new frm_CadUsuario();
            this.Hide();
            form.Show();
        }
    }
}
