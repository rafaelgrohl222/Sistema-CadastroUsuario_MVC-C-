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
    public partial class frm_CadUsuario : Form
    {
        public frm_CadUsuario()
        {
            InitializeComponent();
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            opc = "Novo";//Recebe o valor "Novo"
            iniciarOpc();
        }

        private string opc = "";
        //Método: Opções (Novo ou vazio)
        private void iniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
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
