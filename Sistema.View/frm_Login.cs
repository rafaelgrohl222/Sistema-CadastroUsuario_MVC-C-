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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "")
                {
                    MessageBox.Show("Preencher campo Usuário!");
                    txtUsuario.Focus();
                    return;
                }

                if (txtSenha.Text == "")
                {
                    MessageBox.Show("Preencher campo Senha!");
                    txtSenha.Focus();
                    return;
                }

                UsuarioEnt obj = new UsuarioEnt();
                obj.Usuario = txtUsuario.Text;
                obj.Senha = txtSenha.Text;

                obj = new UsuarioModel().Login(obj);

                if (obj.Usuario == null)
                {
                    lblMensagem.Text = "Usuário não encontrado!";
                    lblMensagem.ForeColor = Color.Red;
                    return;//Segue as fluxo fora do catch
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Logar!" + ex.Message);
            }

            frm_CadUsuario form = new frm_CadUsuario();
            this.Hide();//Ocutar frm_Login
            form.Show();//Abrir form frm_CadUsuario
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
