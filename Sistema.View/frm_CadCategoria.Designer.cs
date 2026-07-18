
namespace Sistema.View
{
    partial class frm_CadCategoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Usuario = new System.Windows.Forms.Button();
            this.txt_Pesquisar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_IdCategoria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.grid_Categoria = new System.Windows.Forms.DataGridView();
            this.idCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.btn_Novo = new System.Windows.Forms.Button();
            this.txt_NomeCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_Ativo = new System.Windows.Forms.CheckBox();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.btn_Produtos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Categoria)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Usuario
            // 
            this.btn_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Usuario.Location = new System.Drawing.Point(314, 56);
            this.btn_Usuario.Name = "btn_Usuario";
            this.btn_Usuario.Size = new System.Drawing.Size(261, 23);
            this.btn_Usuario.TabIndex = 52;
            this.btn_Usuario.Text = "Usuário";
            this.btn_Usuario.UseVisualStyleBackColor = true;
            this.btn_Usuario.Click += new System.EventHandler(this.btn_Usuario_Click);
            // 
            // txt_Pesquisar
            // 
            this.txt_Pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pesquisar.Location = new System.Drawing.Point(244, 13);
            this.txt_Pesquisar.Name = "txt_Pesquisar";
            this.txt_Pesquisar.Size = new System.Drawing.Size(331, 22);
            this.txt_Pesquisar.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 50;
            this.label5.Text = "Buscar:";
            // 
            // txt_IdCategoria
            // 
            this.txt_IdCategoria.Enabled = false;
            this.txt_IdCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdCategoria.Location = new System.Drawing.Point(84, 13);
            this.txt_IdCategoria.Name = "txt_IdCategoria";
            this.txt_IdCategoria.Size = new System.Drawing.Size(66, 22);
            this.txt_IdCategoria.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "Código:";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(402, 159);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 47;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // grid_Categoria
            // 
            this.grid_Categoria.AllowUserToAddRows = false;
            this.grid_Categoria.AllowUserToDeleteRows = false;
            this.grid_Categoria.AllowUserToResizeRows = false;
            this.grid_Categoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Categoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Categoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCategoria,
            this.nomeCategoria,
            this.ativo});
            this.grid_Categoria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_Categoria.Location = new System.Drawing.Point(12, 199);
            this.grid_Categoria.MultiSelect = false;
            this.grid_Categoria.Name = "grid_Categoria";
            this.grid_Categoria.ReadOnly = true;
            this.grid_Categoria.RowHeadersVisible = false;
            this.grid_Categoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Categoria.Size = new System.Drawing.Size(563, 169);
            this.grid_Categoria.TabIndex = 46;
            this.grid_Categoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_Categoria_CellClick);
            // 
            // idCategoria
            // 
            this.idCategoria.DataPropertyName = "IdCategoria";
            this.idCategoria.FillWeight = 76.14214F;
            this.idCategoria.HeaderText = "Código";
            this.idCategoria.Name = "idCategoria";
            this.idCategoria.ReadOnly = true;
            // 
            // nomeCategoria
            // 
            this.nomeCategoria.DataPropertyName = "NomeCategoria";
            this.nomeCategoria.FillWeight = 111.9289F;
            this.nomeCategoria.HeaderText = "Categoria";
            this.nomeCategoria.Name = "nomeCategoria";
            this.nomeCategoria.ReadOnly = true;
            // 
            // ativo
            // 
            this.ativo.DataPropertyName = "Ativo";
            this.ativo.FillWeight = 111.9289F;
            this.ativo.HeaderText = "Ativo";
            this.ativo.Name = "ativo";
            this.ativo.ReadOnly = true;
            // 
            // btn_Editar
            // 
            this.btn_Editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.Location = new System.Drawing.Point(302, 159);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(75, 23);
            this.btn_Editar.TabIndex = 45;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Excluir.Location = new System.Drawing.Point(205, 159);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(75, 23);
            this.btn_Excluir.TabIndex = 44;
            this.btn_Excluir.Text = "Excluir";
            this.btn_Excluir.UseVisualStyleBackColor = true;
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Salvar.Location = new System.Drawing.Point(110, 159);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(75, 23);
            this.btn_Salvar.TabIndex = 43;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // btn_Novo
            // 
            this.btn_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Novo.Location = new System.Drawing.Point(12, 159);
            this.btn_Novo.Name = "btn_Novo";
            this.btn_Novo.Size = new System.Drawing.Size(75, 23);
            this.btn_Novo.TabIndex = 42;
            this.btn_Novo.Text = "Novo";
            this.btn_Novo.UseVisualStyleBackColor = true;
            this.btn_Novo.Click += new System.EventHandler(this.btn_Novo_Click);
            // 
            // txt_NomeCategoria
            // 
            this.txt_NomeCategoria.Enabled = false;
            this.txt_NomeCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NomeCategoria.Location = new System.Drawing.Point(100, 56);
            this.txt_NomeCategoria.Name = "txt_NomeCategoria";
            this.txt_NomeCategoria.Size = new System.Drawing.Size(180, 22);
            this.txt_NomeCategoria.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Categoria:";
            // 
            // chk_Ativo
            // 
            this.chk_Ativo.AutoSize = true;
            this.chk_Ativo.Location = new System.Drawing.Point(15, 100);
            this.chk_Ativo.Name = "chk_Ativo";
            this.chk_Ativo.Size = new System.Drawing.Size(50, 17);
            this.chk_Ativo.TabIndex = 53;
            this.chk_Ativo.Text = "Ativo";
            this.chk_Ativo.UseVisualStyleBackColor = true;
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fechar.Location = new System.Drawing.Point(500, 159);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(75, 23);
            this.btn_Fechar.TabIndex = 54;
            this.btn_Fechar.Text = "Fechar";
            this.btn_Fechar.UseVisualStyleBackColor = true;
            // 
            // btn_Produtos
            // 
            this.btn_Produtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Produtos.Location = new System.Drawing.Point(314, 96);
            this.btn_Produtos.Name = "btn_Produtos";
            this.btn_Produtos.Size = new System.Drawing.Size(261, 23);
            this.btn_Produtos.TabIndex = 55;
            this.btn_Produtos.Text = "Produtos";
            this.btn_Produtos.UseVisualStyleBackColor = true;
            this.btn_Produtos.Click += new System.EventHandler(this.btn_Produtos_Click);
            // 
            // frm_CadCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 380);
            this.Controls.Add(this.btn_Produtos);
            this.Controls.Add(this.btn_Fechar);
            this.Controls.Add(this.chk_Ativo);
            this.Controls.Add(this.btn_Usuario);
            this.Controls.Add(this.txt_Pesquisar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_IdCategoria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.grid_Categoria);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Excluir);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.btn_Novo);
            this.Controls.Add(this.txt_NomeCategoria);
            this.Controls.Add(this.label1);
            this.Name = "frm_CadCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Categoria";
            this.Load += new System.EventHandler(this.frm_CadCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Categoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Usuario;
        private System.Windows.Forms.TextBox txt_Pesquisar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_IdCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.DataGridView grid_Categoria;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Excluir;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Button btn_Novo;
        private System.Windows.Forms.TextBox txt_NomeCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_Ativo;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.Button btn_Produtos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativo;
    }
}