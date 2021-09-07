namespace Analizador
{
    partial class Form1
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
            this.txtEditorCodigo = new System.Windows.Forms.RichTextBox();
            this.txtNumLinea = new System.Windows.Forms.RichTextBox();
            this.PanelCodigo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.abrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.tablaTokens = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.RichTextBox();
            this.PanelCodigo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTokens)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEditorCodigo
            // 
            this.txtEditorCodigo.Location = new System.Drawing.Point(35, -1);
            this.txtEditorCodigo.Name = "txtEditorCodigo";
            this.txtEditorCodigo.Size = new System.Drawing.Size(352, 373);
            this.txtEditorCodigo.TabIndex = 0;
            this.txtEditorCodigo.Text = "";
            this.txtEditorCodigo.SelectionChanged += new System.EventHandler(this.TxtEditorCodigo_SelectionChanged);
            this.txtEditorCodigo.VScroll += new System.EventHandler(this.TxtEditorCodigo_VScroll);
            this.txtEditorCodigo.FontChanged += new System.EventHandler(this.TxtEditorCodigo_FontChanged);
            this.txtEditorCodigo.TextChanged += new System.EventHandler(this.TxtEditorCodigo_TextChanged);
            // 
            // txtNumLinea
            // 
            this.txtNumLinea.BackColor = System.Drawing.Color.White;
            this.txtNumLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumLinea.Cursor = System.Windows.Forms.Cursors.No;
            this.txtNumLinea.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNumLinea.Location = new System.Drawing.Point(0, 0);
            this.txtNumLinea.Name = "txtNumLinea";
            this.txtNumLinea.ReadOnly = true;
            this.txtNumLinea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtNumLinea.Size = new System.Drawing.Size(29, 376);
            this.txtNumLinea.TabIndex = 1;
            this.txtNumLinea.Text = "";
            this.txtNumLinea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtNumLinea_MouseDown);
            // 
            // PanelCodigo
            // 
            this.PanelCodigo.Controls.Add(this.txtEditorCodigo);
            this.PanelCodigo.Controls.Add(this.txtNumLinea);
            this.PanelCodigo.Location = new System.Drawing.Point(6, 19);
            this.PanelCodigo.Name = "PanelCodigo";
            this.PanelCodigo.Size = new System.Drawing.Size(390, 376);
            this.PanelCodigo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PanelCodigo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 401);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Código";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(18, 419);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 4;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.BtnAbrir_Click);
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.FileName = "openFileDialog1";
            // 
            // tablaTokens
            // 
            this.tablaTokens.AllowUserToAddRows = false;
            this.tablaTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Lexema,
            this.Linea});
            this.tablaTokens.Location = new System.Drawing.Point(6, 22);
            this.tablaTokens.Name = "tablaTokens";
            this.tablaTokens.Size = new System.Drawing.Size(443, 161);
            this.tablaTokens.TabIndex = 5;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Token";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 63;
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tablaTokens);
            this.groupBox2.Location = new System.Drawing.Point(444, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 189);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analizador léxico";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResultado);
            this.groupBox3.Location = new System.Drawing.Point(450, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 156);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Analizador sintáctico";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(6, 19);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(300, 131);
            this.txtResultado.TabIndex = 0;
            this.txtResultado.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.PanelCodigo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaTokens)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtEditorCodigo;
        private System.Windows.Forms.RichTextBox txtNumLinea;
        private System.Windows.Forms.Panel PanelCodigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.OpenFileDialog abrirArchivo;
        private System.Windows.Forms.DataGridView tablaTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtResultado;
    }
}

