using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WinGerador.BD;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WinGerador
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtConexao;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.GroupBox gbxBanco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClasse;
        private System.Windows.Forms.CheckedListBox cblTabelas;
        private System.Windows.Forms.TabControl tbcGerador;
        private System.Windows.Forms.TabPage tbpBanco;
        private System.Windows.Forms.TabPage tbpTabelas;
        private System.Windows.Forms.TabPage tbpModelos;
        private System.Windows.Forms.DataGrid gridDiretorios;
        private System.Windows.Forms.Label lbl_destino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLocDest;
        private System.Windows.Forms.Button btnLocMod;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjeto;
        private System.Windows.Forms.Button btlLocProj;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;

        private DataGridTableStyle estiloGridModelos = new DataGridTableStyle();
        private DataGridTextBoxColumn colunaGridModelo = new DataGridTextBoxColumn();

        private DataGridTableStyle estiloGridCampos = new DataGridTableStyle();
        private DataGridTextBoxColumn colunaGridCampos = new DataGridTextBoxColumn();

        private DataGridBoolColumn colunaGridCamposB = new DataGridBoolColumn();

        private DataGridComboBoxColumn colunaGridCamposC = new DataGridComboBoxColumn();

        private System.Windows.Forms.DataGrid gridCampos;
        private string _conexao = string.Empty;

        private DataSet camposDataSet = new DataSet("Campos");
        private DataTable camposTable = new DataTable("ListaCampos");
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cbxComandos;
        public WinGerador.ExtTextBox txtScript;
        private System.Windows.Forms.StatusBarPanel sbpTLinha;
        private System.Windows.Forms.StatusBarPanel sbpLinha;
        private System.Windows.Forms.StatusBarPanel sbpTColuna;
        private System.Windows.Forms.StatusBarPanel sbpColuna;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBar stbTextBox;

        string operacao;
        string _txtResult;
        DataTable _modelos;
        private WinGerador.ExtTextBox txtVisualizacao;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.ComboBox cbxBanco;
        private System.Windows.Forms.TextBox txtNameSpace;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtConexao = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.cbxBanco = new System.Windows.Forms.ComboBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.gbxBanco = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cblTabelas = new System.Windows.Forms.CheckedListBox();
            this.tbcGerador = new System.Windows.Forms.TabControl();
            this.tbpBanco = new System.Windows.Forms.TabPage();
            this.btlLocProj = new System.Windows.Forms.Button();
            this.txtProjeto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLocMod = new System.Windows.Forms.Button();
            this.btnLocDest = new System.Windows.Forms.Button();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_destino = new System.Windows.Forms.Label();
            this.gridDiretorios = new System.Windows.Forms.DataGrid();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.tbpTabelas = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtClasse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridCampos = new System.Windows.Forms.DataGrid();
            this.tbpModelos = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.stbTextBox = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.sbpTLinha = new System.Windows.Forms.StatusBarPanel();
            this.sbpLinha = new System.Windows.Forms.StatusBarPanel();
            this.sbpTColuna = new System.Windows.Forms.StatusBarPanel();
            this.sbpColuna = new System.Windows.Forms.StatusBarPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbxComandos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtVisualizacao = new WinGerador.ExtTextBox();
            this.txtScript = new WinGerador.ExtTextBox();
            this.gbxBanco.SuspendLayout();
            this.tbcGerador.SuspendLayout();
            this.tbpBanco.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiretorios)).BeginInit();
            this.tbpTabelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCampos)).BeginInit();
            this.tbpModelos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpTLinha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpLinha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpTColuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpColuna)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConexao
            // 
            this.txtConexao.Location = new System.Drawing.Point(80, 24);
            this.txtConexao.Name = "txtConexao";
            this.txtConexao.Size = new System.Drawing.Size(200, 23);
            this.txtConexao.TabIndex = 0;
            this.txtConexao.Text = "manutencao";
            // 
            // lblBanco
            // 
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(24, 28);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(56, 16);
            this.lblBanco.TabIndex = 1;
            this.lblBanco.Text = "Nome :";
            // 
            // cbxBanco
            // 
            this.cbxBanco.Items.AddRange(new object[] {
            "SQL Server",
            "Oracle"});
            this.cbxBanco.Location = new System.Drawing.Point(352, 23);
            this.cbxBanco.Name = "cbxBanco";
            this.cbxBanco.Size = new System.Drawing.Size(206, 24);
            this.cbxBanco.TabIndex = 2;
            this.cbxBanco.Tag = "";
            this.cbxBanco.Text = "SQL Server";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(576, 16);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(82, 40);
            this.btnConectar.TabIndex = 3;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // gbxBanco
            // 
            this.gbxBanco.Controls.Add(this.btnSair);
            this.gbxBanco.Controls.Add(this.label1);
            this.gbxBanco.Controls.Add(this.txtConexao);
            this.gbxBanco.Controls.Add(this.lblBanco);
            this.gbxBanco.Controls.Add(this.cbxBanco);
            this.gbxBanco.Controls.Add(this.btnConectar);
            this.gbxBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxBanco.Location = new System.Drawing.Point(7, 13);
            this.gbxBanco.Name = "gbxBanco";
            this.gbxBanco.Size = new System.Drawing.Size(753, 64);
            this.gbxBanco.TabIndex = 4;
            this.gbxBanco.TabStop = false;
            this.gbxBanco.Text = "Banco de dados";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(664, 16);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(80, 40);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo :";
            // 
            // cblTabelas
            // 
            this.cblTabelas.CheckOnClick = true;
            this.cblTabelas.Location = new System.Drawing.Point(8, 8);
            this.cblTabelas.MultiColumn = true;
            this.cblTabelas.Name = "cblTabelas";
            this.cblTabelas.Size = new System.Drawing.Size(752, 109);
            this.cblTabelas.TabIndex = 5;
            this.cblTabelas.SelectedIndexChanged += new System.EventHandler(this.cblTabelas_SelectedIndexChanged);
            // 
            // tbcGerador
            // 
            this.tbcGerador.Controls.Add(this.tbpBanco);
            this.tbcGerador.Controls.Add(this.tbpTabelas);
            this.tbcGerador.Controls.Add(this.tbpModelos);
            this.tbcGerador.Location = new System.Drawing.Point(8, 8);
            this.tbcGerador.Name = "tbcGerador";
            this.tbcGerador.SelectedIndex = 0;
            this.tbcGerador.Size = new System.Drawing.Size(776, 520);
            this.tbcGerador.TabIndex = 6;
            // 
            // tbpBanco
            // 
            this.tbpBanco.Controls.Add(this.btlLocProj);
            this.tbpBanco.Controls.Add(this.txtProjeto);
            this.tbpBanco.Controls.Add(this.label3);
            this.tbpBanco.Controls.Add(this.groupBox1);
            this.tbpBanco.Controls.Add(this.gbxBanco);
            this.tbpBanco.Location = new System.Drawing.Point(4, 22);
            this.tbpBanco.Name = "tbpBanco";
            this.tbpBanco.Size = new System.Drawing.Size(768, 494);
            this.tbpBanco.TabIndex = 0;
            this.tbpBanco.Text = "Banco de Dados";
            this.tbpBanco.UseVisualStyleBackColor = true;
            // 
            // btlLocProj
            // 
            this.btlLocProj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlLocProj.Location = new System.Drawing.Point(680, 439);
            this.btlLocProj.Name = "btlLocProj";
            this.btlLocProj.Size = new System.Drawing.Size(80, 23);
            this.btlLocProj.TabIndex = 8;
            this.btlLocProj.Text = "Localizar";
            this.btlLocProj.Click += new System.EventHandler(this.btlLocProj_Click);
            // 
            // txtProjeto
            // 
            this.txtProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjeto.Location = new System.Drawing.Point(11, 440);
            this.txtProjeto.Name = "txtProjeto";
            this.txtProjeto.Size = new System.Drawing.Size(661, 22);
            this.txtProjeto.TabIndex = 7;
            this.txtProjeto.Text = "C:\\carlos\\Programas\\WINDOWS\\WinGerador";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(8, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(368, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pasta onde será gravado a estrutura do projeto (modelo)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnLocMod);
            this.groupBox1.Controls.Add(this.btnLocDest);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.txtDestino);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbl_destino);
            this.groupBox1.Controls.Add(this.gridDiretorios);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.btnAlterar);
            this.groupBox1.Controls.Add(this.btnIncluir);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 320);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modelos";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(416, 288);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(96, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(520, 288);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLocMod
            // 
            this.btnLocMod.Enabled = false;
            this.btnLocMod.Location = new System.Drawing.Point(664, 248);
            this.btnLocMod.Name = "btnLocMod";
            this.btnLocMod.Size = new System.Drawing.Size(79, 23);
            this.btnLocMod.TabIndex = 9;
            this.btnLocMod.Text = "Localizar";
            this.btnLocMod.Click += new System.EventHandler(this.btnLocMod_Click);
            // 
            // btnLocDest
            // 
            this.btnLocDest.Enabled = false;
            this.btnLocDest.Location = new System.Drawing.Point(664, 216);
            this.btnLocDest.Name = "btnLocDest";
            this.btnLocDest.Size = new System.Drawing.Size(79, 23);
            this.btnLocDest.TabIndex = 7;
            this.btnLocDest.Text = "Localizar";
            this.btnLocDest.Click += new System.EventHandler(this.btnLocDest_Click);
            // 
            // txtModelo
            // 
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.Location = new System.Drawing.Point(80, 247);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(576, 22);
            this.txtModelo.TabIndex = 8;
            // 
            // txtDestino
            // 
            this.txtDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDestino.Location = new System.Drawing.Point(80, 216);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(576, 22);
            this.txtDestino.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Modelo :";
            // 
            // lbl_destino
            // 
            this.lbl_destino.Location = new System.Drawing.Point(8, 216);
            this.lbl_destino.Name = "lbl_destino";
            this.lbl_destino.Size = new System.Drawing.Size(64, 16);
            this.lbl_destino.TabIndex = 5;
            this.lbl_destino.Text = "Destino :";
            // 
            // gridDiretorios
            // 
            this.gridDiretorios.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.gridDiretorios.BackColor = System.Drawing.Color.Gainsboro;
            this.gridDiretorios.BackgroundColor = System.Drawing.Color.DarkGray;
            this.gridDiretorios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridDiretorios.CaptionBackColor = System.Drawing.Color.DarkKhaki;
            this.gridDiretorios.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gridDiretorios.CaptionForeColor = System.Drawing.Color.Black;
            this.gridDiretorios.CaptionVisible = false;
            this.gridDiretorios.DataMember = "";
            this.gridDiretorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gridDiretorios.ForeColor = System.Drawing.Color.Black;
            this.gridDiretorios.GridLineColor = System.Drawing.Color.Silver;
            this.gridDiretorios.HeaderBackColor = System.Drawing.Color.Black;
            this.gridDiretorios.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gridDiretorios.HeaderForeColor = System.Drawing.Color.White;
            this.gridDiretorios.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.gridDiretorios.Location = new System.Drawing.Point(8, 24);
            this.gridDiretorios.Name = "gridDiretorios";
            this.gridDiretorios.ParentRowsBackColor = System.Drawing.Color.LightGray;
            this.gridDiretorios.ParentRowsForeColor = System.Drawing.Color.Black;
            this.gridDiretorios.PreferredColumnWidth = 310;
            this.gridDiretorios.ReadOnly = true;
            this.gridDiretorios.SelectionBackColor = System.Drawing.Color.Firebrick;
            this.gridDiretorios.SelectionForeColor = System.Drawing.Color.White;
            this.gridDiretorios.Size = new System.Drawing.Size(736, 176);
            this.gridDiretorios.TabIndex = 10;
            this.gridDiretorios.CurrentCellChanged += new System.EventHandler(this.gridDiretorios_CurrentCellChanged);
            this.gridDiretorios.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridDiretorios_MouseUp);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(312, 288);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(96, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(208, 288);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(96, 23);
            this.btnAlterar.TabIndex = 2;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(104, 288);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(96, 23);
            this.btnIncluir.TabIndex = 1;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // tbpTabelas
            // 
            this.tbpTabelas.Controls.Add(this.button10);
            this.tbpTabelas.Controls.Add(this.button2);
            this.tbpTabelas.Controls.Add(this.txtClasse);
            this.tbpTabelas.Controls.Add(this.label2);
            this.tbpTabelas.Controls.Add(this.gridCampos);
            this.tbpTabelas.Controls.Add(this.cblTabelas);
            this.tbpTabelas.Location = new System.Drawing.Point(4, 22);
            this.tbpTabelas.Name = "tbpTabelas";
            this.tbpTabelas.Size = new System.Drawing.Size(768, 494);
            this.tbpTabelas.TabIndex = 1;
            this.tbpTabelas.Text = "Tabelas";
            this.tbpTabelas.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(8, 464);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(96, 23);
            this.button10.TabIndex = 10;
            this.button10.Text = "Criar Classes";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(676, 459);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(82, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "&Continuar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtClasse
            // 
            this.txtClasse.Location = new System.Drawing.Point(130, 124);
            this.txtClasse.Name = "txtClasse";
            this.txtClasse.Size = new System.Drawing.Size(224, 20);
            this.txtClasse.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(8, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome da Classe :";
            // 
            // gridCampos
            // 
            this.gridCampos.DataMember = "";
            this.gridCampos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridCampos.Location = new System.Drawing.Point(8, 152);
            this.gridCampos.Name = "gridCampos";
            this.gridCampos.Size = new System.Drawing.Size(752, 304);
            this.gridCampos.TabIndex = 6;
            // 
            // tbpModelos
            // 
            this.tbpModelos.Controls.Add(this.button9);
            this.tbpModelos.Controls.Add(this.button8);
            this.tbpModelos.Controls.Add(this.button6);
            this.tbpModelos.Controls.Add(this.button5);
            this.tbpModelos.Controls.Add(this.button4);
            this.tbpModelos.Controls.Add(this.button3);
            this.tbpModelos.Controls.Add(this.stbTextBox);
            this.tbpModelos.Controls.Add(this.cbxComandos);
            this.tbpModelos.Controls.Add(this.label6);
            this.tbpModelos.Controls.Add(this.txtNameSpace);
            this.tbpModelos.Controls.Add(this.label5);
            this.tbpModelos.Controls.Add(this.txtNome);
            this.tbpModelos.Controls.Add(this.lblModelo);
            this.tbpModelos.Controls.Add(this.txtVisualizacao);
            this.tbpModelos.Controls.Add(this.txtScript);
            this.tbpModelos.Location = new System.Drawing.Point(4, 22);
            this.tbpModelos.Name = "tbpModelos";
            this.tbpModelos.Size = new System.Drawing.Size(768, 494);
            this.tbpModelos.TabIndex = 2;
            this.tbpModelos.Text = "Modelos";
            this.tbpModelos.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(611, 192);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(147, 32);
            this.button9.TabIndex = 15;
            this.button9.Text = "Sair";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(611, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(147, 24);
            this.button8.TabIndex = 14;
            this.button8.Text = "Selecionar";
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // stbTextBox
            // 
            this.stbTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stbTextBox.Location = new System.Drawing.Point(0, 470);
            this.stbTextBox.Name = "stbTextBox";
            this.stbTextBox.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.sbpTLinha,
            this.sbpLinha,
            this.sbpTColuna,
            this.sbpColuna});
            this.stbTextBox.ShowPanels = true;
            this.stbTextBox.Size = new System.Drawing.Size(768, 24);
            this.stbTextBox.TabIndex = 13;
            this.stbTextBox.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 512;
            // 
            // sbpTLinha
            // 
            this.sbpTLinha.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sbpTLinha.Name = "sbpTLinha";
            this.sbpTLinha.Text = "Linha";
            this.sbpTLinha.Width = 70;
            // 
            // sbpLinha
            // 
            this.sbpLinha.Name = "sbpLinha";
            this.sbpLinha.Width = 50;
            // 
            // sbpTColuna
            // 
            this.sbpTColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sbpTColuna.Name = "sbpTColuna";
            this.sbpTColuna.Text = "Coluna";
            this.sbpTColuna.Width = 70;
            // 
            // sbpColuna
            // 
            this.sbpColuna.Name = "sbpColuna";
            this.sbpColuna.Width = 50;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(611, 160);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(147, 32);
            this.button6.TabIndex = 11;
            this.button6.Text = "Visualizar Código";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(611, 63);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 24);
            this.button5.TabIndex = 8;
            this.button5.Text = "Inserir Comando";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(611, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(147, 32);
            this.button4.TabIndex = 7;
            this.button4.Text = "Recuperar";
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(611, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 32);
            this.button3.TabIndex = 6;
            this.button3.Text = "Gravar Modelo";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbxComandos
            // 
            this.cbxComandos.Location = new System.Drawing.Point(19, 64);
            this.cbxComandos.Name = "cbxComandos";
            this.cbxComandos.Size = new System.Drawing.Size(583, 21);
            this.cbxComandos.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Comandos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(120, 40);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(482, 20);
            this.txtNameSpace.TabIndex = 3;
            this.txtNameSpace.Text = "SaoCamilo.DAO";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Name Space";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(120, 16);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(482, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.Text = "C:\\carlos\\Programas\\WINDOWS\\Wingerador_Modelos\\dao.mod";
            // 
            // lblModelo
            // 
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(16, 16);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(96, 24);
            this.lblModelo.TabIndex = 0;
            this.lblModelo.Text = "Nome do Modelo";
            this.lblModelo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVisualizacao
            // 
            this.txtVisualizacao.Location = new System.Drawing.Point(16, 262);
            this.txtVisualizacao.Multiline = true;
            this.txtVisualizacao.Name = "txtVisualizacao";
            this.txtVisualizacao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtVisualizacao.Size = new System.Drawing.Size(742, 200);
            this.txtVisualizacao.TabIndex = 10;
            this.txtVisualizacao.WordWrap = false;
            // 
            // txtScript
            // 
            this.txtScript.AcceptsTab = true;
            this.txtScript.Location = new System.Drawing.Point(16, 96);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(587, 159);
            this.txtScript.TabIndex = 9;
            this.txtScript.WordWrap = false;
            this.txtScript.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtScript_MouseDown);
            this.txtScript.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtScript_KeyDown);
            this.txtScript.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScript_KeyPress);
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            this.txtScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScript_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 539);
            this.Controls.Add(this.tbcGerador);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Classes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxBanco.ResumeLayout(false);
            this.gbxBanco.PerformLayout();
            this.tbcGerador.ResumeLayout(false);
            this.tbpBanco.ResumeLayout(false);
            this.tbpBanco.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiretorios)).EndInit();
            this.tbpTabelas.ResumeLayout(false);
            this.tbpTabelas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCampos)).EndInit();
            this.tbpModelos.ResumeLayout(false);
            this.tbpModelos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpTLinha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpLinha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpTColuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpColuna)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbdDestino = new FolderBrowserDialog();
            fbdDestino.ShowDialog();
            txtDestino.Text = fbdDestino.SelectedPath;
        }

        private void btnConectar_Click(object sender, System.EventArgs e)
        {
            if (cbxBanco.Text == "SQL Server")
                _conexao = @"Data Source=.\sqlexpress;Initial Catalog=" + txtConexao.Text + ";Integrated Security=True";
            else if (cbxBanco.Text == "Oracle")
                _conexao = "server=(local);database=" + txtConexao.Text + ";user id=sa";


            BDAdapter bd = BDFactory.GetAdapter(cbxBanco.Text);
            DataSet _tabelas = bd.GetTabelas(_conexao);

            int ct = 0;
            string _linha = string.Empty;
            cblTabelas.Items.Clear();
            for (ct = 0; ct <= _tabelas.Tables[0].Rows.Count - 1; ct++)
            {
                _linha = _tabelas.Tables[0].Rows[ct].ItemArray[0].ToString();
                cblTabelas.Items.Add(_linha);
            }

            CriaTabelaCampos();

            tbcGerador.SelectedIndex = 1;

        }

        private void Carrega_XML()
        {
            string _arq_xml = txtProjeto.Text + "\\diretorios.xml";
            string _fim = "\r";
            StringBuilder arq_xml = new StringBuilder(string.Empty);


            DataTable dtDiretorios = (DataTable)_modelos;
            if ((dtDiretorios == null) || (operacao == "Cancel"))
            {
                if (!File.Exists(_arq_xml))
                {
                    arq_xml.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" + _fim);

                    arq_xml.Append("<diretorios>" + _fim);
                    arq_xml.Append("		<dir>" + _fim);
                    arq_xml.Append("         <destino>" + txtProjeto.Text + "</destino>" + _fim);
                    arq_xml.Append("         <modelo>" + @"C:\Gerador\Modelo\..." + "</modelo>" + _fim);
                    arq_xml.Append("     </dir>" + _fim);
                    arq_xml.Append("</diretorios>" + _fim);

                    StreamWriter arq = new StreamWriter(_arq_xml);
                    // grava linha no txt
                    arq.Write(arq_xml.ToString());
                    // fecha o objeto instanciado
                    arq.Close();

                    DataSet dset = new DataSet();
                    dset.ReadXml(_arq_xml);
                    gridDiretorios.DataSource = dset;
                    gridDiretorios.DataMember = dset.Tables[0].TableName;

                    dtDiretorios = dset.Tables[0];
                    _modelos = dtDiretorios;
                }
                else
                {
                    DataSet dset = new DataSet();
                    dset.ReadXml(_arq_xml);
                    gridDiretorios.DataSource = dset;

                    gridDiretorios.DataMember = dset.Tables[0].TableName;

                    dtDiretorios = dset.Tables[0];
                    _modelos = dtDiretorios;

                }
            }
            else
            {
                gridDiretorios.DataSource = dtDiretorios;
            }

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Carrega_XML();
            modelo_Estilo();
            Habilita_Botoes(true);

            cbxComandos.Items.Add("Estrutura For (campos)");
            cbxComandos.Items.Add("Nome do Campo (For) - (todo minusculo)");
            cbxComandos.Items.Add("Nome do Campo (For) - (todo maiusculo)");
            cbxComandos.Items.Add("Tipo do Campo (For)");
            cbxComandos.Items.Add("Nome da Classe (inicial minuscula)");
            cbxComandos.Items.Add("Nome da Classe (inicial maiuscula)");
            cbxComandos.Items.Add("Nome da Classe (toda maiuscula)");
            cbxComandos.Items.Add("NameSpace");
            cbxComandos.Items.Add("Retorno de Linha + ';'");
            cbxComandos.Items.Add("Retorno de Linha simples");
            cbxComandos.Items.Add("Aspas");
            cbxComandos.Items.Add("Campo(s) da chave primária");
            cbxComandos.Items.Add("Condição 'IF'");

        }

        private void modelo_Estilo()
        {
            // Criação do Table Style

            estiloGridModelos.MappingName = _modelos.TableName;

            colunaGridModelo = new DataGridTextBoxColumn();
            colunaGridModelo.MappingName = "destino";
            colunaGridModelo.HeaderText = "Diretório de Destino";
            colunaGridModelo.Width = 310;
            estiloGridModelos.GridColumnStyles.Add(colunaGridModelo);

            colunaGridModelo = new DataGridTextBoxColumn();
            colunaGridModelo.MappingName = "modelo";
            colunaGridModelo.HeaderText = "Diretório do Modelo";
            colunaGridModelo.Width = 310;
            estiloGridModelos.GridColumnStyles.Add(colunaGridModelo);

            gridDiretorios.TableStyles.Clear();
            gridDiretorios.TableStyles.Add(estiloGridModelos);
            gridDiretorios.SetDataBinding(_modelos, string.Empty);
        }

        private void btnLocDest_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbdDestino = new FolderBrowserDialog();
            fbdDestino.ShowDialog();
            txtDestino.Text = fbdDestino.SelectedPath;
        }

        private void btnLocMod_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog fbdDestino = new OpenFileDialog();
            fbdDestino.ShowDialog();
            txtModelo.Text = fbdDestino.FileName;
        }

        private void btlLocProj_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbdDestino = new FolderBrowserDialog();
            fbdDestino.ShowDialog();
            txtProjeto.Text = fbdDestino.SelectedPath;
        }

        private void btnIncluir_Click(object sender, System.EventArgs e)
        {
            operacao = "incluir";
            Habilita_Botoes(false);
            txtDestino.Focus();
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            operacao = "excluir";
            if (_modelos.Rows.Count > 0)
            {
                _modelos.Rows[gridDiretorios.CurrentRowIndex].Delete();
                string _arq_xml = txtProjeto.Text + "\\diretorios.xml";
                DataTable dtXML = (DataTable)_modelos;
                DataSet dsXML = new DataSet();
                dsXML = (DataSet)dtXML.DataSet;
                // salva em xml
                dsXML.WriteXml(_arq_xml);
                Carrega_XML();
                Habilita_Botoes(true);
                if (_modelos.Rows.Count == 0)
                {
                    if (File.Exists(txtProjeto.Text + "\\diretorios.xml"))
                        File.Delete(txtProjeto.Text + "\\diretorios.xml");

                    txtDestino.Text = "";
                    txtModelo.Text = "";
                }
            }
        }

        private void gridDiretorios_CurrentCellChanged(object sender, System.EventArgs e)
        {
            txtDestino.Text = gridDiretorios[gridDiretorios.CurrentRowIndex, 0].ToString();
            txtModelo.Text = gridDiretorios[gridDiretorios.CurrentRowIndex, 1].ToString();
        }

        private void btnSair_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            operacao = "alterar";
            Habilita_Botoes(false);
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            DataTable dtDiretorios = (DataTable)_modelos;
            if (operacao == "incluir")
            {
                DataRow drLinhas = dtDiretorios.NewRow();

                drLinhas["destino"] = txtDestino.Text;
                drLinhas["modelo"] = txtModelo.Text;

                _modelos.Rows.Add(drLinhas);
            }

            Carrega_XML();
            string _arq_xml = txtProjeto.Text + "\\diretorios.xml";
            DataTable dtXML = (DataTable)_modelos;
            DataSet dsXML = new DataSet();
            dsXML = (DataSet)dtXML.DataSet;
            // salva em xml
            dsXML.WriteXml(_arq_xml);
            Habilita_Botoes(true);
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            if (operacao == "incluir")
            {
                txtDestino.Text = "";
                txtModelo.Text = "";
            }
            Habilita_Botoes(true);

        }

        private void Habilita_Botoes(Boolean _flag)
        {
            btnIncluir.Enabled = _flag;

            if (_modelos.Rows.Count > 0)
            {
                btnAlterar.Enabled = _flag;
                btnExcluir.Enabled = _flag;
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }

            btnSalvar.Enabled = !_flag;
            btnCancelar.Enabled = !_flag;
            txtDestino.ReadOnly = _flag;
            txtModelo.ReadOnly = _flag;
            btnLocDest.Enabled = !_flag;
            btnLocMod.Enabled = !_flag;
        }

        private void cblTabelas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int i;
            string _item;

            while (camposDataSet.Tables[0].Rows.Count > 0)
            {
                camposDataSet.Tables[0].Rows[0].Delete();
            }


            for (i = 0; i < cblTabelas.CheckedItems.Count; i++)
            {
                _item = cblTabelas.CheckedItems[i].ToString();
                if (txtClasse.Text == string.Empty)
                    txtClasse.Text = _item;

                BDAdapter bd = BDFactory.GetAdapter(cbxBanco.Text);

                DataSet _tabSelect = bd.GetCampos(_item, _conexao);

                // ----------------------------------------------------------------------------------------

                foreach (DataRow linhas in _tabSelect.Tables[0].Rows)
                {
                    DataRow drCampos = camposDataSet.Tables[0].NewRow();

                    drCampos["cselecionar"] = false;
                    drCampos["ctabela"] = linhas["ctabela"].ToString();
                    drCampos["cnome"] = linhas["cnome"].ToString();
                    drCampos["ctipo"] = linhas["ctipo"].ToString();
                    drCampos["cchave"] = linhas["cchave"].ToString();

                    if (linhas["cchave"].ToString() == "FOREIGN KEY")
                    {
                        drCampos["ccomponente"] = 1;
                    }
                    else
                    {
                        drCampos["ccomponente"] = 0;
                    }

                    camposDataSet.Tables[0].Rows.Add(drCampos);
                }

                gridCampos.DataSource = camposDataSet.Tables[0];
                Campos_Estilo();
            }
        }

        private void Campos_Estilo()
        {
            estiloGridCampos.MappingName = "ListaCampos";
            estiloGridCampos.GridColumnStyles.Clear();
            gridCampos.TableStyles.Clear();

            if (!gridCampos.TableStyles.Contains(estiloGridCampos))
            {
                colunaGridCamposB = new DataGridBoolColumn();
                colunaGridCamposB.MappingName = "cselecionar";
                colunaGridCamposB.HeaderText = "Selecionar";
                colunaGridCamposB.Width = 60;
                estiloGridCampos.GridColumnStyles.Add(colunaGridCamposB);

                colunaGridCampos = new DataGridTextBoxColumn();
                colunaGridCampos.MappingName = "ctabela";
                colunaGridCampos.HeaderText = "Tabela";
                colunaGridCampos.Width = 120;
                estiloGridCampos.GridColumnStyles.Add(colunaGridCampos);

                colunaGridCampos = new DataGridTextBoxColumn();
                colunaGridCampos.MappingName = "cnome";
                colunaGridCampos.HeaderText = "Campo";
                colunaGridCampos.Width = 100;
                estiloGridCampos.GridColumnStyles.Add(colunaGridCampos);

                colunaGridCampos = new DataGridTextBoxColumn();
                colunaGridCampos.MappingName = "ctipo";
                colunaGridCampos.HeaderText = "Tipo";
                colunaGridCampos.Width = 100;
                estiloGridCampos.GridColumnStyles.Add(colunaGridCampos);

                colunaGridCampos = new DataGridTextBoxColumn();
                colunaGridCampos.MappingName = "cchave";
                colunaGridCampos.HeaderText = "Chave";
                colunaGridCampos.Width = 100;
                estiloGridCampos.GridColumnStyles.Add(colunaGridCampos);

                colunaGridCamposC = new DataGridComboBoxColumn();
                colunaGridCamposC.MappingName = "ccomponente";
                colunaGridCamposC.HeaderText = "Tipo de Componente";
                estiloGridCampos.GridColumnStyles.Add(colunaGridCamposC);

            }

            gridCampos.TableStyles.Add(estiloGridCampos);
            gridCampos.SetDataBinding(gridCampos.DataSource, string.Empty);
        }


        private void CriaTabelaCampos()
        {
            if (camposTable.Columns.Count == 0)
            {

                //Adiciona checkbox no grid 
                DataColumn dtcCheck = new DataColumn("cselecionar");
                dtcCheck.DataType = System.Type.GetType("System.Boolean");
                dtcCheck.DefaultValue = false;
                dtcCheck.ReadOnly = false;
                camposTable.Columns.Add(dtcCheck);

                DataColumn dtcTabela = new DataColumn("ctabela");
                dtcTabela.DataType = System.Type.GetType("System.String");
                dtcTabela.DefaultValue = "";
                dtcTabela.ReadOnly = true;
                camposTable.Columns.Add(dtcTabela);

                DataColumn dtcNome = new DataColumn("cnome");
                dtcNome.DataType = System.Type.GetType("System.String");
                dtcNome.DefaultValue = "";
                dtcNome.ReadOnly = true;
                camposTable.Columns.Add(dtcNome);

                DataColumn dtctipo = new DataColumn("ctipo");
                dtctipo.DataType = System.Type.GetType("System.String");
                dtctipo.DefaultValue = "";
                dtctipo.ReadOnly = true;
                camposTable.Columns.Add(dtctipo);

                DataColumn dtcChave = new DataColumn("cchave");
                dtcChave.DataType = System.Type.GetType("System.String");
                dtcChave.DefaultValue = "";
                dtcChave.ReadOnly = true;
                camposTable.Columns.Add(dtcChave);

                DataColumn dtcComponente = new DataColumn("ccomponente");
                dtcComponente.DataType = System.Type.GetType("System.Int32");
                camposTable.Columns.Add(dtcComponente);

                camposDataSet.Tables.Add(camposTable);

                gridCampos.DataMember = camposDataSet.Tables[0].TableName;
                gridCampos.DataSource = camposTable;
            }
            Campos_Estilo();
        }

        private void gridDiretorios_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            DataGrid.HitTestInfo hit = gridDiretorios.HitTest(pt);

            if (hit.Type == DataGrid.HitTestType.Cell)
            {
                gridDiretorios.CurrentCell = new DataGridCell(hit.Row, hit.Column);
                gridDiretorios.Select(hit.Row);
            }
        }

        private void button2_Click_1(object sender, System.EventArgs e)
        {
            tbcGerador.SelectedIndex = 2;
        }


        private void button4_Click_1(object sender, System.EventArgs e)
        {
            if (txtNome.Text == string.Empty)
            {
                MessageBox.Show(@"Favor digitar o nome do modelo. Ex.: c:\\\modelo\\\modelo.mod");
                return;
            }

            recupera_modelo(txtNome.Text);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            string _fims = System.Environment.NewLine;
            string _texto = string.Empty;
            int _ln = 0;
            int _cl = 0;



            if (txtScript.Text != string.Empty)
            {
                _ln = Convert.ToInt32(stbTextBox.Panels[2].Text) - 1;
                _cl = Convert.ToInt32(stbTextBox.Panels[4].Text) - 1;

                _texto = txtScript.Lines[_ln].ToString();
            }

            if (cbxComandos.SelectedItem.ToString() == "Estrutura For (campos)")
            {
                if (_texto != string.Empty)
                    txtScript.Text += _fims;

                txtScript.Text += "Estrutura For (campos)" + _fims;
                txtScript.Text += "##{" + _fims;
                txtScript.Text += "    _campo " + _fims;
                txtScript.Text += "##}" + _fims;
            }

            if (cbxComandos.SelectedItem.ToString() == "Condição 'IF'")
            {
                if (_texto != string.Empty)
                    txtScript.Text += _fims;

                txtScript.Text += "##IF" + _fims;
                txtScript.Text += "if(condicao) " + _fims;
                txtScript.Text += "{" + _fims;
                txtScript.Text += "##	coloque o codigo desejado aqui" + _fims;
                txtScript.Text += "}" + _fims;
                txtScript.Text += "else" + _fims;
                txtScript.Text += "{" + _fims;
                txtScript.Text += "##	coloque o codigo desejado aqui" + _fims;
                txtScript.Text += "}" + _fims;
                txtScript.Text += "##ENDIF" + _fims;
            }


            if (cbxComandos.SelectedItem.ToString() == "Nome do Campo (For) - (todo minusculo)")
                inserirComando(" _campo ", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Nome do Campo (For) - (todo maiusculo)")
                inserirComando(" _CAMPO ", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Tipo do Campo (For)")
                inserirComando(" _tipo ", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Nome da Classe (inicial minuscula)")
                inserirComando(" _classe ", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Nome da Classe (inicial maiuscula)")
                inserirComando(" _Classe ", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Nome da Classe (toda maiuscula)")
                inserirComando(" _Classe ", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "NameSpace")
                inserirComando(" _namespace ", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Retorno de Linha + ';'")
                inserirComando("_retcpv", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Retorno de Linha simples")
                inserirComando("_retspv", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Aspas")
                inserirComando("_aspas", _texto, 1, _ln, _cl);

            else if (cbxComandos.SelectedItem.ToString() == "Campo(s) da chave primária")
                inserirComando("_chave_prim", _texto, 1, _ln, _cl);
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            if (txtNome.Text == string.Empty)
            {
                MessageBox.Show(@"Favor digitar o nome do modelo. Ex.: c:\\\modelo\\\modelo.mod");
                return;
            }

            if (txtNameSpace.Text == string.Empty)
            {
                MessageBox.Show("Favor digitar o Name Space da classe.");
                return;
            }

            visualiza_codigo(0);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (txtNome.Text == string.Empty)
                {
                    MessageBox.Show(@"Favor digitar o nome do modelo. Ex.: c:\\\modelo\\\modelo.mod");
                    return;
                }

                if (txtScript.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("O modelo não pode ser salvo se estiver vazio !");
                    return;
                }

                if (txtNameSpace.Text == string.Empty)
                {
                    MessageBox.Show("Favor digitar o Name Space da classe.");
                    return;
                }

                if (!Directory.Exists(txtNome.Text))
                {
                    string _dir = txtNome.Text.Substring(0, txtNome.Text.LastIndexOf(@"\"));
                    Directory.CreateDirectory(_dir);
                }
                StreamWriter arquivo = new StreamWriter(txtNome.Text);
                arquivo.WriteLine(txtNameSpace.Text);
                arquivo.Write(txtScript.Text.TrimEnd());
                arquivo.Close();
                MessageBox.Show("Arquivo gerado com sucesso !");
                txtNameSpace.Text = string.Empty;
                txtScript.Text = string.Empty;
                txtVisualizacao.Text = string.Empty;
            }
            catch (UnauthorizedAccessException err)
            {
                MessageBox.Show(err.Message);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private Boolean Campos_Selecionados()
        {
            int _select = 0;
            foreach (DataRow item in camposTable.Rows)
            {
                if (item["cselecionar"].ToString() == "True")
                {
                    _select++;
                }
            }
            if (_select > 0)
                return true;
            else
                return false;
        }


        private string Verifica_Comando(string slin)
        {

            if ((slin.Trim() == "##{") || (slin.Trim() == "{") || (slin.Trim() == "}") || (slin.Trim() == ""))
                return slin;

            if ((slin.Trim().Substring(0, 2) == "##}") || (slin.Trim() == "Estrutura For (campos)") ||
                 (slin.Trim() == "##IF") || (slin.Trim() == "##ENDIF"))
                return string.Empty;

            string _destino = txtNome.Text.Trim();
            int _pos1 = _destino.LastIndexOf("\\") + 1;
            int _pos2 = _destino.Length;
            int _cont = 0;

            string _classe = txtClasse.Text;
            string _chave = _destino.Substring(_pos1, _pos2 - _pos1);
            _chave = _chave.Substring(0, 1).ToUpper() + _chave.Substring(1, _chave.Length - 1);
            string _Classe = _classe.Substring(0, 1).ToUpper() + _classe.Substring(1, _classe.Length - 1);
            string _CLASSE = _classe.ToUpper();
            string _namespace = txtNameSpace.Text;
            string _fims = "\n"; //System.Environment.NewLine.ToString();
            string _fimc = ";\n"; //+System.Environment.NewLine.ToString();
            string _aspas = "\"";

            string[] schar = new string[08];
            string[] ssubs = new string[08];

            schar[0] = "_classe";       // Nome da Classe Minuscula
            schar[1] = "_namespace";    // Name Space
            schar[2] = "_retcpv";       // Retorno de Linha com ponto e virgula
            schar[3] = "_retspv";       // Retorno de Linha simples
            schar[4] = "_aspas";        // Aspas
            schar[5] = "_chave_prim";   // Chave primaria
            schar[6] = "_Classe";       // Nome da Classe Maiuscula
            schar[7] = "_CLASSE";       // Nome da Classe Maiuscula

            ssubs[0] = _classe;
            ssubs[1] = _namespace;
            ssubs[2] = _fimc;
            ssubs[3] = _fims;
            ssubs[4] = _aspas;
            ssubs[5] = string.Empty;
            ssubs[6] = _Classe;
            ssubs[7] = _CLASSE;

            for (_cont = 0; _cont <= schar.Length - 1; _cont++)
            {
                while (slin.IndexOf(schar[_cont], 0, slin.Length) > 0)
                {
                    slin = slin.Replace(schar[_cont], ssubs[_cont]);
                }
            }
            return slin;
        }

        private void txtScript_TextChanged(object sender, System.EventArgs e)
        {
            displayPanel(txtScript);
        }

        private void txtScript_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            displayPanel(txtScript);
        }

        private void txtScript_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            displayPanel(txtScript);
        }

        private void txtScript_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            displayPanel(txtScript);
        }


        private void displayPanel(ExtTextBox _text)
        {
            stbTextBox.Panels[2].Text = Convert.ToString(_text.Linha);
            stbTextBox.Panels[4].Text = Convert.ToString(_text.Coluna);
        }

        private void inserirComando(string _comando, string _texto, int _quebra, int _ln, int _cl)
        {
            string _fims = String.Empty;
            string _antes = string.Empty;
            string _depois = string.Empty;
            int _it = 0;
            string[] _linhas = new string[txtScript.Lines.Length];

            if (_quebra == 1)
                _fims = System.Environment.NewLine;
            else
                _fims = "";

            for (_it = 0; _it <= (txtScript.Lines.Length - 1); _it++)
            {
                if (_it == _ln)
                {
                    _antes = _texto.Substring(0, _cl);
                    _depois = _texto.Substring(_cl, _texto.Length - _cl);
                    _linhas[_it] = _antes + _comando + _depois;
                }
                else
                    _linhas[_it] = txtScript.Lines[_it];
            }
            txtScript.Lines = _linhas;

            GoTo(_ln, _cl);
        }

        private void button8_Click_1(object sender, System.EventArgs e)
        {
            OpenFileDialog fbdDestino = new OpenFileDialog();
            fbdDestino.ShowDialog();
            txtNome.Text = fbdDestino.FileName;

        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            if (cblTabelas.Items.Count == 0)
            {
                MessageBox.Show("Favor Conectar ao Banco de Dados e Selecionar Uma Tabela.");
                tbcGerador.SelectedIndex = 0;
                return;
            }

            if (cblTabelas.CheckedItems.Count == 0)
            {
                MessageBox.Show("Favor Selecionar Uma Tabela.");
                return;
            }

            if (!Campos_Selecionados())
            {
                MessageBox.Show("Selecione os campos que serão usados na geração !");
                return;
            }

            string _dirDestino = string.Empty;
            string _dirModelo = string.Empty;
            string _dir = string.Empty;

            foreach (DataRow _mod in _modelos.Rows)
            {
                _dirDestino = _mod["destino"].ToString() + @"\";
                _dirModelo = _mod["modelo"].ToString();

                if (!recupera_modelo(_dirModelo))
                    break;

                if (!visualiza_codigo(1))
                    break;

                // ------------------------------------------------------------------------------------

                if (!Directory.Exists(_dirDestino))
                {
                    Directory.CreateDirectory(_dir);
                }
                StreamWriter arquivo = new StreamWriter(_dirDestino + txtClasse.Text + ".cs");

                arquivo.Write(txtVisualizacao.Text.Trim());
                arquivo.Close();
                MessageBox.Show("Arquivo gerado com sucesso !");
                txtNameSpace.Text = string.Empty;
                txtScript.Text = string.Empty;
                txtVisualizacao.Text = string.Empty;
            }
        }

        private Boolean recupera_modelo(string _nomeModelo)
        {
            if (File.Exists(_nomeModelo))
            {
                StreamReader arq = new StreamReader(_nomeModelo);
                txtScript.Text = arq.ReadToEnd();
                arq.Close();

                txtNameSpace.Text = txtScript.Lines[0];
                int _it = 0;
                string[] _linhas = new string[txtScript.Lines.Length];
                for (_it = 0; _it <= (txtScript.Lines.Length - 1); _it++)
                {
                    if (_it > 0)
                        _linhas[_it - 1] = txtScript.Lines[_it];
                }
                txtScript.Lines = _linhas;
                return true;
            }
            else
            {
                MessageBox.Show("Arquivo " + _nomeModelo + " não encontrado !");
                return false;
            }
        }


        private Boolean visualiza_codigo(int _tipo)
        {

            if (!Campos_Selecionados())
            {
                MessageBox.Show("Selecione os campos que serão usados na geração !");
                return false;
            }

            if (txtClasse.Text == string.Empty)
            {
                MessageBox.Show("Favor informar o campo => Nome chave da classe !");
                return false;
            }

            if (_tipo == 0)
            {
                if (txtNameSpace.Text == string.Empty)
                {
                    MessageBox.Show("Favor digitar a estrutura da classe.");
                    return false;
                }
            }

            txtVisualizacao.Clear();

            int _pos1 = 0;
            int _lin = 0;
            int _it = 0;
            string _resultado = string.Empty;
            string _antes = string.Empty;
            string _depois = string.Empty;
            string _fims = System.Environment.NewLine;
            string _linha = string.Empty;
            string _linhaFor = string.Empty;
            string _linhaOrig = string.Empty;
            string _tipoCampo = string.Empty;
            string _caixa = String.Empty;
            int _nFor = 0;
            ArrayList _for = new ArrayList();
            ArrayList _escopo = new ArrayList();

            _txtResult = txtScript.Text;


            for (_it = 0; _it <= (txtScript.Lines.Length - 1); _it++)
            {
                _linha = txtScript.Lines[_it];

                if (_linha.Trim() == "Estrutura For (campos)")
                {
                    continue;
                }
                else if (_linha.Trim() == "##{")
                {
                    _nFor = 1;
                    continue;
                }
                else if (_linha.Trim() == "##}")
                {
                    _nFor = 2;
                }

                if (_nFor == 0)
                {
                    if (_linha.Trim() == String.Empty)
                        _escopo.Add("\r");
                    else
                        _escopo.Add(Verifica_Comando(_linha));
                }
                else if (_nFor == 1)
                {
                    _for.Add(_linha);
                    continue;
                }

                else if (_nFor == 2)
                {
                    foreach (DataRow item in camposTable.Rows)
                    {

                        if (item["cselecionar"].ToString() == "True")
                        {
                            for (_lin = 0; _lin != _for.Count; _lin++)
                            {
                                _linha = _for[_lin].ToString();
                                while ((_linha.IndexOf("_campo", 0, _linha.Length) > 0) || (_linha.IndexOf("_Campo", 0, _linha.Length) > 0) || (_linha.IndexOf("_CAMPO", 0, _linha.Length) > 0))
                                {
                                    _caixa = "B";
                                    _pos1 = _linha.IndexOf("_campo", 0, _linha.Length);

                                    if (_pos1 <= 0)
                                    {
                                        _pos1 = _linha.IndexOf("_Campo", 0, _linha.Length);

                                        if (_pos1 <= 0)
                                        {
                                            _pos1 = _linha.IndexOf("_CAMPO", 0, _linha.Length);
                                            _caixa = "B";
                                        }
                                        else
                                        {
                                            _caixa = "C";
                                        }
                                    }
                                    _antes = _linha.Substring(0, _pos1);
                                    _depois = _linha.Substring(_pos1 + 6);

                                    if (_caixa == "A")
                                        _linha = _antes + item["cnome"].ToString().ToUpper() + _depois;
                                    else if (_caixa == "B")
                                        _linha = _antes + item["cnome"].ToString().ToLower() + _depois;
                                    else if (_caixa == "C")
                                        _linha = _antes + item["cnome"].ToString().Substring(0, 1).ToUpper() + item["cnome"].ToString().Substring(1, item["cnome"].ToString().Length - 1) + _depois; // inicial maiuscula;



                                    _linha = Verifica_Comando(_linha);
                                }

                                while (_linha.IndexOf("_tipo", 0, _linha.Length) > 0)
                                {
                                    _pos1 = _linha.IndexOf("_tipo", 0, _linha.Length);
                                    _antes = _linha.Substring(0, _pos1);
                                    _depois = _linha.Substring(_pos1 + 5);

                                    if ((item["ctipo"].ToString() == "varchar") || (item["ctipo"].ToString() == "nvarchar") || (item["ctipo"].ToString() == "char"))
                                        _tipoCampo = "string";
                                    else
                                        _tipoCampo = item["ctipo"].ToString();

                                    _linha = _antes + _tipoCampo + _depois;
                                    _linha = Verifica_Comando(_linha);
                                }
                                _escopo.Add(_linha);
                            }
                        }
                    }
                    _for.Clear();
                    _nFor = 0;
                }

            }

            string[] _linhas = new string[_escopo.Count];
            _escopo.CopyTo(_linhas);
            txtVisualizacao.Lines = _linhas;

            return true;
        }

        public void GoTo(int line, int column)
        {
            //if (line < 1 || column < 1 || txtScript.Lines.Length < line)
            if (line < 1)
                return;

            if (column.Equals(0))
                column = 1;

            txtScript.SelectionStart = txtScript.GetFirstCharIndexFromLine(line - 1) + column - 1;
            txtScript.SelectionLength = 0;
            txtScript.ScrollToCaret();
        }

        public int CurrentColumn
        {
            get { return txtScript.SelectionStart - txtScript.GetFirstCharIndexOfCurrentLine() + 1; }
        }

        public int CurrentLine
        {
            get { return txtScript.GetLineFromCharIndex(txtScript.SelectionStart) + 1; }
        }

    }
}







