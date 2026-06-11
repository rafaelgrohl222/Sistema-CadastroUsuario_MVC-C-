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
                    break;

                case "Editar":
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
        //Método: Limpar Campos
        private void LimparCampos()
        {
            txt_Nome.Text = "";
            txt_Usuario.Text = "";
            txt_Senha.Text = "";
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";//Recebe o valor "Salvar"
            iniciarOpc();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            opc = "Excluir";//Recebe o valor "Excluir"
            iniciarOpc();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            opc = "Editar";//Recebe o valor "Editar"
            iniciarOpc();
        }
    }
}
