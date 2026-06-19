using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidades;

namespace Sistema.View
{
    public partial class frm_CadUsuario : Form
    {
        UsuarioEnt objTabela = new UsuarioEnt();

        public frm_CadUsuario()
        {
            InitializeComponent();
        }

        //Botão Novo
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
                        objTabela.Nome = txt_Nome.Text;
                        objTabela.Usuario = txt_Usuario.Text;
                        objTabela.Senha = txt_Senha.Text;

                        //Passando dados dos TexBox para o BD
                        int x = UsuarioModel.Inserir(objTabela);
                        if(x > 0) 
                        {
                            MessageBox.Show(string.Format("Usuário ({0}) Foi Inserido!", txt_Nome.Text));
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
                        int x = UsuarioModel.Excluir(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário ({0}) Foi Excluido!", txt_Nome.Text));
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
                        objTabela.Nome = txt_Nome.Text;
                        objTabela.Usuario = txt_Usuario.Text;
                        objTabela.Senha = txt_Senha.Text;

                        //Passando dados dos TexBox para o BD
                        int x = UsuarioModel.Editar(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário ({0}) Foi Editado!", txt_Nome.Text));
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

                default:
                    break;
            }
        }

        //Método: Habilitar Campos
        private void HabilitarCampos()
        {
            txt_Nome.Enabled = true;
            txt_Usuario.Enabled = true;
            txt_Senha.Enabled = true;
        }

        //Método Desabilitar Campo
        private void DesabilitarCampo() 
        {
            txt_Nome.Enabled = false;
            txt_Usuario.Enabled = false;
            txt_Senha.Enabled = false;
        }

        //Método: Limpar Campos
        private void LimparCampos()
        {
            txt_Codigo.Text = "";
            txt_Nome.Text = "";
            txt_Usuario.Text = "";
            txt_Senha.Text = "";
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

        //Método: Listar GridView
        private void ListarGrid()
        {
            try
            {
                //Objeto tipo List (Listar itens na gridView)
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModel().Lista();
                grid.AutoGenerateColumns = false;//Não gerar linhas automatizadas.
                grid.DataSource = lista;//DataSource rebe lista de dados
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar Dados!" + ex.Message);
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_CadUsuario_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Codigo.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txt_Nome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txt_Usuario.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txt_Senha.Text = grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }
    }
}
