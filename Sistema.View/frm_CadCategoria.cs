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
    public partial class frm_CadCategoria : Form
    {
        CategoriaEnt objTabela = new CategoriaEnt();

        public frm_CadCategoria()
        {
            InitializeComponent();
        }

        /// Representa os estados do formulário.
        private enum EstadoFormulario
        {
            Visualizando,
            Novo,
            Editando
        }
        private EstadoFormulario estadoAtual = EstadoFormulario.Visualizando;

        private void AtualizarEstadoFormulario()
        {
            switch (estadoAtual)
            {

                case EstadoFormulario.Visualizando:

                    // Desabilita os campos
                    DesabilitarCampo();

                    // Habilita os botões
                    btn_Novo.Enabled = true;
                    btn_Salvar.Enabled = false;
                    btn_Editar.Enabled = false;
                    btn_Excluir.Enabled = false;
                    btn_Cancelar.Enabled = false;

                    break;

                case EstadoFormulario.Novo:

                    // Habilita os campos
                    HabilitarCampos();

                    // Habilita os botões
                    btn_Novo.Enabled = false;
                    btn_Salvar.Enabled = true;
                    btn_Editar.Enabled = false;
                    btn_Excluir.Enabled = false;
                    btn_Cancelar.Enabled = true;

                    break;

                case EstadoFormulario.Editando:

                    // Habilitar os Campos
                    HabilitarCampos();

                    // Habilitar os Botões
                    btn_Novo.Enabled = false;
                    btn_Salvar.Enabled = false;
                    btn_Editar.Enabled = true;
                    btn_Excluir.Enabled = true;
                    btn_Cancelar.Enabled = true;

                    break;
            }
        }

        private void ListarGrid()
        {
            try
            {
                //Objeto tipo List (Listar itens na gridView)
                List<CategoriaEnt> lista = new List<CategoriaEnt>();
                lista = new CategoriaModel().Lista();
                grid_Categoria.AutoGenerateColumns = false;//Não gerar linhas automatizadas.
                grid_Categoria.DataSource = lista;//DataSource rebe lista de dados
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

        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            frm_CadUsuario form = new frm_CadUsuario();
            this.Hide();
            form.Show();
        }

        // Evento executado ao carregar o formulário.
        private void frm_CadCategoria_Load(object sender, EventArgs e)
        {
            // Define o estado inicial do formulário
            estadoAtual = EstadoFormulario.Visualizando;

            // Atualiza a interface conforme o estado atual
            AtualizarEstadoFormulario();

            // Carrega os registros no DataGridView
            ListarGrid();
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            // Define a operação - Recebe o valor "Novo"
            opc = "Novo";
            // Executa a operação selecionada
            iniciarOpc();

            // Define o estado do formulário
            estadoAtual = EstadoFormulario.Novo;

            // Atualiza a interface conforme o estado atual
            AtualizarEstadoFormulario();

            // Define o foco inicial
            txt_NomeCategoria.Focus();
        }

        //Método: Opções (Novo, Salvar, Excluir, Editar ou vazio)
        private string opc = "";
        private void iniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    // Habilita os campos para um novo cadastro
                    HabilitarCampos();
                    // Limpa os campos do formulário
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        // Preenche o objeto com os dados do formulário
                        objTabela.NomeCategoria = txt_NomeCategoria.Text;
                        objTabela.Ativo = chk_Ativo.Checked;

                        //Passando dados dos TexBox para o BD
                        int x = CategoriaModel.Inserir(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Categoria ({0}) Foi Inserido!", txt_NomeCategoria.Text));
                        }
                        else
                        {
                            MessageBox.Show("Categoria (Não) Inserido!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um Error ao Salvar! " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Excluir":
                    try
                    {
                        // Obtém o código da categoria
                        objTabela.IdCategoria = Convert.ToInt32(txt_IdCategoria.Text);

                        // Exclui o registro no banco de dados
                        int x = CategoriaModel.Excluir(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Categoria ({0}) Foi Excluida!", txt_NomeCategoria.Text), "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Categoria (Não) Excluido!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um Error ao Excluir! " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Editar":
                    try
                    {
                        // Preenche o objeto com os dados do formulário
                        objTabela.IdCategoria = Convert.ToInt32(txt_IdCategoria.Text);
                        objTabela.NomeCategoria = txt_NomeCategoria.Text;
                        objTabela.Ativo = chk_Ativo.Checked;

                        //Passando dados dos TexBox para o BD
                        int x = CategoriaModel.Editar(objTabela);
                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Categoria ({0}) Foi Editada!", txt_NomeCategoria.Text));
                        }
                        else
                        {
                            MessageBox.Show("Categoria (Não) Alterada!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um Error ao editar! " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Buscar":
                    try
                    {
                        objTabela.NomeCategoria = txt_Pesquisar.Text;
                        //Objeto tipo List (Listar itens na gridView)
                        List<CategoriaEnt> lista = new List<CategoriaEnt>();
                        lista = new CategoriaModel().Buscar(objTabela);
                        grid_Categoria.AutoGenerateColumns = false;//Não gerar linhas automatizadas.
                        grid_Categoria.DataSource = lista;//DataSource rebe lista de dados
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
            txt_NomeCategoria.Enabled = true;
            chk_Ativo.Enabled = true;
        }

        //Método Desabilitar Campo
        private void DesabilitarCampo()
        {
            txt_NomeCategoria.Enabled = false;
            chk_Ativo.Enabled = false;
        }

        //Método: Limpar Campos
        private void LimparCampos()
        {
            // Limpar o código da categoria
            txt_IdCategoria.Text = "";

            // Limpar o nome da categoria
            txt_NomeCategoria.Text = "";

            // Define a categoria como ativa por padrão
            chk_Ativo.Checked = true;
        }

        // //Botão Salvar - Evento responsável por salvar o cadastro da categoria.
        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            // Verifica se o Nome da Categoria foi informado
            if (txt_NomeCategoria.Text == "")
            {
                MessageBox.Show("Informe o nome da categoria.");
                txt_NomeCategoria.Focus();
                return;
            }
            // Define a operação
            opc = "Salvar";

            // Executa a operação selecionada
            iniciarOpc();

            // Define o estado do formulário
            estadoAtual = EstadoFormulario.Visualizando;

            // Atualiza a interface conforme o estado atual
            AtualizarEstadoFormulario();

            // Atualiza o DataGridView
            ListarGrid();

            // Limpa os campos do formulário
            LimparCampos();
        }

        // Evento responsável por carregar os dados da categoria selecionada.
        private void grid_Categoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi realizado em uma linha válida
            if (e.RowIndex < 0)
                return;

            DataGridViewRow linha = grid_Categoria.Rows[e.RowIndex];

            // Verifica se a linha possui dados
            if (linha.Cells[0].Value == null)
                return;

            // Carrega os dados da linha selecionada
            txt_IdCategoria.Text = linha.Cells[0].Value.ToString();
            txt_NomeCategoria.Text = linha.Cells[1].Value.ToString();
            chk_Ativo.Checked = Convert.ToBoolean(linha.Cells[2].Value);

            // Define o estado do formulário
            estadoAtual = EstadoFormulario.Editando;

            // Atualiza a interface conforme o estado atual
            AtualizarEstadoFormulario();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            // Verifica se existe um registro selecionado
            if (txt_IdCategoria.Text == "")
            {
                MessageBox.Show("Selecione um registro na Grid para Editar!");
                return;
            }

            // Define a operação
            opc = "Editar";

            // Executa a operação selecionada
            iniciarOpc();

            // Define o estado do formulário
            estadoAtual = EstadoFormulario.Visualizando;

            // Atualiza a interface conforme o estado atual
            AtualizarEstadoFormulario();

            // Atualiza o DataGridView
            ListarGrid();

            // Limpa os campos do formulário
            LimparCampos();
        }

        // // Botão Excluir - Evento responsável por excluir uma categoria.
        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            // Verifica se existe um registro selecionado
            if (txt_IdCategoria.Text == "")
            {
                MessageBox.Show("Selecione um registro na Grid para Excluir!");
                txt_IdCategoria.Focus();
                return;
            }

            // Solicita a confirmação da exclusão
            DialogResult resposta = MessageBox.Show("Deseja realmente excluir a categoria?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica a resposta do usuário
            if (resposta == DialogResult.No)
                return;

            // Define a operação
            opc = "Excluir";

            // Executa a operação selecionada
            iniciarOpc();

            // Define o estado do formulário
            estadoAtual = EstadoFormulario.Visualizando;

            // Atualiza a interface conforme o estado atual
            AtualizarEstadoFormulario();

            // Atualiza o DataGridView
            ListarGrid();

            // Limpa os campos do formulário
            LimparCampos();
        }

        //Botão Cancelar - // Evento responsável por cancelar a operação atual e retornar o formulário
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            // Retorna o formulário para o estado de visualização
            estadoAtual = EstadoFormulario.Visualizando;

            // Atualiza a interface conforme o estado atual
            AtualizarEstadoFormulario();

            // Limpa os campos do formulário
            LimparCampos();

            // Atualiza os registros da Grid
            ListarGrid();

            // Posicionar o cursor no campo Nome da categoria
            btn_Novo.Focus();
        }
    }
}
