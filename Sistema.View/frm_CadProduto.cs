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
            // Carrega os produtos
            ListarGrid();

            // Carrega as categorias
            CarregarCategoria();
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

        // Opção da operação
        private string opc = "";

        //Método: Opções (Novo, Salvar, Excluir, Editar ou vazio)
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

                        // Recebe a categoria selecionada
                        objTabela.IdCategoria = Convert.ToInt32(cbo_Categoria.SelectedValue);

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

                        // Recebe a categoria selecionada
                        objTabela.IdCategoria = Convert.ToInt32(cbo_Categoria.SelectedValue);

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
                            grid.DataSource = lista;//conteúdo da lista passa para a Grid
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

            // Volta o ComboBox para "Selecione uma Categoria"
            cbo_Categoria.SelectedIndex = 0;
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (txt_NomeProduto.Text == "")
            {
                MessageBox.Show("Inserir NOME no campo vazio, para Salvar!");
                txt_NomeProduto.Focus();
                return;
            }
            if (txt_Descricao.Text == "")
            {
                MessageBox.Show("Inserir DESCRIÇÃO no campo vazio, para Salvar!");
                txt_Descricao.Focus();
                return;
            }
            if (txt_Valor.Text == "")
            {
                MessageBox.Show("Inserir VALOR no campo vazio, para Salvar!");
                txt_Valor.Focus();
                return;
            }
            if (Convert.ToInt32(cbo_Categoria.SelectedValue) == 0)
            {
                MessageBox.Show("Selecionar a CATEGORIA para Salvar!");
                cbo_Categoria.Focus();
                return;
            }

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
                MessageBox.Show("Selecione um registro na Grid para excluir!", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Realmente deseja excluir este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.No)
            {
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
                MessageBox.Show("Selecione um registro na Grid para editar!");
                return;
            }

            DialogResult resposta = MessageBox.Show("Realmente deseja editar este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.No)
            {
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
            // Verifica se o clique foi realizado em uma linha válida
            if (e.RowIndex < 0)
                return;

            DataGridViewRow linha = grid.Rows[e.RowIndex];

            // Verifica se a linha possui dados (proteção contra valores nulos)
            if (linha.Cells[0].Value == null)
                return;

            txt_Codigo.Text = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_NomeProduto.Text = grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Descricao.Text = grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Valor.Text = grid.Rows[e.RowIndex].Cells[3].Value.ToString();
            HabilitarCampos();

            // Seleciona automaticamente a categoria
            if (linha.Cells["idCategoria"].Value != DBNull.Value)
                cbo_Categoria.SelectedValue = Convert.ToInt32(linha.Cells["idCategoria"].Value);
            else
                cbo_Categoria.SelectedIndex = -1;

            // Habilita os campos para edição
            HabilitarCampos();
        }

        // Carrega as categorias cadastradas no ComboBox.
        private void CarregarCategoria()
        {
            try
            {
                // Cria uma lista de categorias
                List<CategoriaEnt> lista = new CategoriaModel().Lista();

                // Adiciona o item "Selecione..."
                lista.Insert(0, new CategoriaEnt()
                {
                    IdCategoria = 0,
                    NomeCategoria = "-- Selecione uma Categoria --"
                });

                // Configura o ComboBox
                cbo_Categoria.DataSource = lista;

                // Campo que será exibido
                cbo_Categoria.DisplayMember = "NomeCategoria";

                // Campo que será gravado
                cbo_Categoria.ValueMember = "IdCategoria";

                // Seleciona o primeiro item
                cbo_Categoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias!" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btn_Categoria_Click(object sender, EventArgs e)
        {
            frm_CadCategoria form = new frm_CadCategoria();
            this.Hide();
            form.Show();
        }
    }
}