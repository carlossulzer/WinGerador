using System;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Windows.Forms;

using Sisnet.SisnetCobranca.Kernel.Cadastro;

using Sisnet.SisnetCobranca.Kernel.Financeiro;

 

namespace Sisnet.SisnetCobranca.WindowsGUI.Cadastro

{

	/// <summary>

	/// Summary description for FrmAtendimento.

	/// </summary>

	public class FrmAtendimento : Form

	{

		private Panel pnlToolBar;

		private Panel pnlFormulario;

		private TabPage tbpCadastrar;

		private TabPage tbpPesquisar;

		protected DataSet dsAtendimentos;

		protected DataSet dsClientes;

		protected DataSet dsServicos;

		protected DataSet dsLancamentos;

		private ToolBar tlbBotoes;

		private ToolBarButton tbbNovo;

		private ToolBarButton tbbSalvar;

		private ToolBarButton tbbExcluir;

		private ToolBarButton tbbAlterar;

		private Label lblDataSetIndex;

		private ToolBarButton tbbAnterior;

		private ToolBarButton tbbProximo;

		private ToolBarButton tbbCancelar;

		private System.Windows.Forms.ImageList imlBotoes;

		private System.Windows.Forms.ToolBarButton tbbSeparador1;

		private System.Windows.Forms.ToolBarButton tbbSeparador2;

		private System.Windows.Forms.ToolBarButton tbbSeparador3;

		private System.Windows.Forms.ToolBarButton tbbSeparador4;

		private System.Windows.Forms.ToolBarButton tbbSeparador5;

		private System.Windows.Forms.ToolBarButton tbbSeparador6;

		private System.Windows.Forms.TabControl tbcAtendimento;

		private System.Windows.Forms.DataGrid dgrAtendimentos;

		private System.Windows.Forms.Label lblIdAtendimento;

		private System.Windows.Forms.Label lblCliente;

		private System.Windows.Forms.Label lblServico;

		private System.Windows.Forms.Label lblDataAtendimento;

		private System.Windows.Forms.Label lblValor;

		private System.Windows.Forms.TextBox txtDataAtendimento;

		private System.Windows.Forms.TextBox txtValor;

		private System.Windows.Forms.ComboBox cbbClientes;

		private System.Windows.Forms.ComboBox cbbServicos;

		private System.Windows.Forms.TextBox txtDataCobranca;

		private System.Windows.Forms.Label lblDataVencimento;

		private System.Windows.Forms.Panel pnlLancamentos;

		private System.Windows.Forms.Panel pnlCadastroLancamentos;

		private System.Windows.Forms.ToolBar tblCadastroLancamentos;

		private System.Windows.Forms.ToolBarButton tbbNovoLancamento;

		private System.Windows.Forms.ToolBarButton tbbSeparadorLancemento1;

		private System.Windows.Forms.ToolBarButton tbbAlterarLancamento;

		private System.Windows.Forms.ToolBarButton tbbSeparadorLancemento2;

		private System.Windows.Forms.ToolBarButton tbbSalvarLancamento;

		private System.Windows.Forms.ToolBarButton tbbSeparadorLancemento3;

		private System.Windows.Forms.ToolBarButton tbbCancelarLancamento;

		private System.Windows.Forms.ToolBarButton tbbSeparadorLancemento4;

		private System.Windows.Forms.ToolBarButton tbbExcluirLancamento;

		private System.Windows.Forms.ToolBarButton tbbSeparadorLancemento5;

		private System.Windows.Forms.Label lblIdLancamento;

		private System.Windows.Forms.Label lblParcela;

		private System.Windows.Forms.TextBox txtParcela;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.TextBox txtStatus;

		private System.Windows.Forms.Label lblStatus;

		private System.Windows.Forms.TextBox txtDataPagamento;

		private System.Windows.Forms.Label lblDataSetLancamentoIndex;

		private System.Windows.Forms.DataGrid dgrLancamentos;

		private System.ComponentModel.IContainer components;

		private DataGridTableStyle estiloGridLancamentos = new DataGridTableStyle();

		private DataGridTextBoxColumn colunaGridLancamentos = new DataGridTextBoxColumn();     

		private DataGridTableStyle estiloGridAtendimentos = new DataGridTableStyle();

		private DataGridTextBoxColumn colunaGridAtendimentos = new DataGridTextBoxColumn();     

 

 

		public FrmAtendimento()

		{

			InitializeComponent();

			lblDataSetIndex.Text = "0";

			CarregarTela();

			this.ListarClientes();

			this.ListarServicos();

                  

                  

			cbbClientes.DisplayMember = "nome";

			cbbClientes.ValueMember = "id_cliente";

			//cbbClientes.Items.Insert(0,"Teste");

			cbbClientes.DataSource = dsClientes.Tables[0].DefaultView;

                  

			cbbServicos.DisplayMember = "nome";

			cbbServicos.ValueMember = "id_servico";

			//cbbServicos.Items.Insert(0,"");

			cbbServicos.DataSource = dsServicos.Tables[0].DefaultView;

			this.Cursor = Cursors.Default;

		}

 

            

		/// <summary>

		/// Clean up any resources being used.

		/// </summary>

		protected override void Dispose( bool disposing )

		{

			if( disposing )

			{

				if(components != null)

				{

					components.Dispose();

				}

			}

			base.Dispose( disposing );

		}

 

		#region Windows Form Designer generated code

		/// <summary>

		/// Required method for Designer support - do not modify

		/// the contents of this method with the code editor.

		/// </summary>

		private void InitializeComponent()

		{

			this.components = new System.ComponentModel.Container();

			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmAtendimento));

			this.pnlToolBar = new System.Windows.Forms.Panel();

			this.tlbBotoes = new System.Windows.Forms.ToolBar();

			this.tbbNovo = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparador1 = new System.Windows.Forms.ToolBarButton();

			this.tbbAlterar = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparador2 = new System.Windows.Forms.ToolBarButton();

			this.tbbSalvar = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparador3 = new System.Windows.Forms.ToolBarButton();

			this.tbbCancelar = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparador4 = new System.Windows.Forms.ToolBarButton();

			this.tbbExcluir = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparador5 = new System.Windows.Forms.ToolBarButton();

			this.tbbAnterior = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparador6 = new System.Windows.Forms.ToolBarButton();

			this.tbbProximo = new System.Windows.Forms.ToolBarButton();

			this.imlBotoes = new System.Windows.Forms.ImageList(this.components);

			this.lblIdAtendimento = new System.Windows.Forms.Label();

			this.pnlFormulario = new System.Windows.Forms.Panel();

			this.tbcAtendimento = new System.Windows.Forms.TabControl();

			this.tbpCadastrar = new System.Windows.Forms.TabPage();

			this.lblDataSetLancamentoIndex = new System.Windows.Forms.Label();

			this.lblIdLancamento = new System.Windows.Forms.Label();

			this.pnlLancamentos = new System.Windows.Forms.Panel();

			this.dgrLancamentos = new System.Windows.Forms.DataGrid();

			this.pnlCadastroLancamentos = new System.Windows.Forms.Panel();

			this.tblCadastroLancamentos = new System.Windows.Forms.ToolBar();

			this.tbbNovoLancamento = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparadorLancemento1 = new System.Windows.Forms.ToolBarButton();

			this.tbbAlterarLancamento = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparadorLancemento2 = new System.Windows.Forms.ToolBarButton();

			this.tbbSalvarLancamento = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparadorLancemento3 = new System.Windows.Forms.ToolBarButton();

			this.tbbCancelarLancamento = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparadorLancemento4 = new System.Windows.Forms.ToolBarButton();

			this.tbbExcluirLancamento = new System.Windows.Forms.ToolBarButton();

			this.tbbSeparadorLancemento5 = new System.Windows.Forms.ToolBarButton();

			this.txtDataPagamento = new System.Windows.Forms.TextBox();

			this.txtDataCobranca = new System.Windows.Forms.TextBox();

			this.label1 = new System.Windows.Forms.Label();

			this.txtStatus = new System.Windows.Forms.TextBox();

			this.txtParcela = new System.Windows.Forms.TextBox();

			this.txtValor = new System.Windows.Forms.TextBox();

			this.lblDataVencimento = new System.Windows.Forms.Label();

			this.lblParcela = new System.Windows.Forms.Label();

			this.lblValor = new System.Windows.Forms.Label();

			this.lblStatus = new System.Windows.Forms.Label();

			this.txtDataAtendimento = new System.Windows.Forms.TextBox();

			this.cbbServicos = new System.Windows.Forms.ComboBox();

			this.cbbClientes = new System.Windows.Forms.ComboBox();

			this.lblDataAtendimento = new System.Windows.Forms.Label();

			this.lblServico = new System.Windows.Forms.Label();

			this.lblCliente = new System.Windows.Forms.Label();

			this.lblDataSetIndex = new System.Windows.Forms.Label();

			this.tbpPesquisar = new System.Windows.Forms.TabPage();

			this.dgrAtendimentos = new System.Windows.Forms.DataGrid();

			this.pnlToolBar.SuspendLayout();

			this.pnlFormulario.SuspendLayout();

			this.tbcAtendimento.SuspendLayout();

			this.tbpCadastrar.SuspendLayout();

			this.pnlLancamentos.SuspendLayout();

			((System.ComponentModel.ISupportInitialize)(this.dgrLancamentos)).BeginInit();

			this.pnlCadastroLancamentos.SuspendLayout();

			this.tbpPesquisar.SuspendLayout();

			((System.ComponentModel.ISupportInitialize)(this.dgrAtendimentos)).BeginInit();

			this.SuspendLayout();

			// 

			// pnlToolBar

			// 

			this.pnlToolBar.Controls.Add(this.tlbBotoes);

			this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;

			this.pnlToolBar.Location = new System.Drawing.Point(0, 0);

			this.pnlToolBar.Name = "pnlToolBar";

			this.pnlToolBar.Size = new System.Drawing.Size(632, 48);

			this.pnlToolBar.TabIndex = 0;

			// 

			// tlbBotoes

			// 

			this.tlbBotoes.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {

																						 this.tbbNovo,

																						 this.tbbSeparador1,

																						 this.tbbAlterar,

																						 this.tbbSeparador2,

																						 this.tbbSalvar,

																						 this.tbbSeparador3,

																						 this.tbbCancelar,

																						 this.tbbSeparador4,

																						 this.tbbExcluir,

																						 this.tbbSeparador5,

																						 this.tbbAnterior,

																						 this.tbbSeparador6,

																						 this.tbbProximo});

			this.tlbBotoes.ButtonSize = new System.Drawing.Size(49, 34);

			this.tlbBotoes.DropDownArrows = true;

			this.tlbBotoes.ImageList = this.imlBotoes;

			this.tlbBotoes.Location = new System.Drawing.Point(0, 0);

			this.tlbBotoes.Name = "tlbBotoes";

			this.tlbBotoes.ShowToolTips = true;

			this.tlbBotoes.Size = new System.Drawing.Size(632, 40);

			this.tlbBotoes.TabIndex = 0;

			this.tlbBotoes.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbBotoes_ButtonClick);

			// 

			// tbbNovo

			// 

			this.tbbNovo.ImageIndex = 0;

			this.tbbNovo.Text = "Novo";

			// 

			// tbbSeparador1

			// 

			this.tbbSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbAlterar

			// 

			this.tbbAlterar.ImageIndex = 1;

			this.tbbAlterar.Text = "Alterar";

			// 

			// tbbSeparador2

			// 

			this.tbbSeparador2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbSalvar

			// 

			this.tbbSalvar.ImageIndex = 2;

			this.tbbSalvar.Text = "Salvar";

			// 

			// tbbSeparador3

			// 

			this.tbbSeparador3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbCancelar

			// 

			this.tbbCancelar.ImageIndex = 3;

			this.tbbCancelar.Text = "Cancelar";

			// 

			// tbbSeparador4

			// 

			this.tbbSeparador4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbExcluir

			// 

			this.tbbExcluir.ImageIndex = 4;

			this.tbbExcluir.Text = "Excluir";

			// 

			// tbbSeparador5

			// 

			this.tbbSeparador5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbAnterior

			// 

			this.tbbAnterior.ImageIndex = 5;

			// 

			// tbbSeparador6

			// 

			this.tbbSeparador6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbProximo

			// 

			this.tbbProximo.ImageIndex = 6;

			// 

			// imlBotoes

			// 

			this.imlBotoes.ImageSize = new System.Drawing.Size(14, 14);

			this.imlBotoes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBotoes.ImageStream")));

			this.imlBotoes.TransparentColor = System.Drawing.Color.Transparent;

			// 

			// lblIdAtendimento

			// 

			this.lblIdAtendimento.BackColor = System.Drawing.Color.Red;

			this.lblIdAtendimento.Location = new System.Drawing.Point(432, 16);

			this.lblIdAtendimento.Name = "lblIdAtendimento";

			this.lblIdAtendimento.TabIndex = 2;

			this.lblIdAtendimento.Visible = false;

			// 

			// pnlFormulario

			// 

			this.pnlFormulario.Controls.Add(this.tbcAtendimento);

			this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;

			this.pnlFormulario.Location = new System.Drawing.Point(0, 48);

			this.pnlFormulario.Name = "pnlFormulario";

			this.pnlFormulario.Size = new System.Drawing.Size(632, 398);

			this.pnlFormulario.TabIndex = 1;

			// 

			// tbcAtendimento

			// 

			this.tbcAtendimento.Controls.Add(this.tbpCadastrar);

			this.tbcAtendimento.Controls.Add(this.tbpPesquisar);

			this.tbcAtendimento.Dock = System.Windows.Forms.DockStyle.Fill;

			this.tbcAtendimento.Location = new System.Drawing.Point(0, 0);

			this.tbcAtendimento.Name = "tbcAtendimento";

			this.tbcAtendimento.SelectedIndex = 0;

			this.tbcAtendimento.Size = new System.Drawing.Size(632, 398);

			this.tbcAtendimento.TabIndex = 0;

			this.tbcAtendimento.SelectedIndexChanged += new System.EventHandler(this.tbcAtendimento_SelectedIndexChanged);

			// 

			// tbpCadastrar

			// 

			this.tbpCadastrar.Controls.Add(this.lblDataSetLancamentoIndex);

			this.tbpCadastrar.Controls.Add(this.lblIdLancamento);

			this.tbpCadastrar.Controls.Add(this.pnlLancamentos);

			this.tbpCadastrar.Controls.Add(this.txtDataAtendimento);

			this.tbpCadastrar.Controls.Add(this.cbbServicos);

			this.tbpCadastrar.Controls.Add(this.cbbClientes);

			this.tbpCadastrar.Controls.Add(this.lblDataAtendimento);

			this.tbpCadastrar.Controls.Add(this.lblServico);

			this.tbpCadastrar.Controls.Add(this.lblCliente);

			this.tbpCadastrar.Controls.Add(this.lblDataSetIndex);

			this.tbpCadastrar.Controls.Add(this.lblIdAtendimento);

			this.tbpCadastrar.Location = new System.Drawing.Point(4, 22);

			this.tbpCadastrar.Name = "tbpCadastrar";

			this.tbpCadastrar.Size = new System.Drawing.Size(624, 372);

			this.tbpCadastrar.TabIndex = 0;

			this.tbpCadastrar.Text = "Cadastrar";

			this.tbpCadastrar.Click += new System.EventHandler(this.tbpCadastrar_Click);

			// 

			// lblDataSetLancamentoIndex

			// 

			this.lblDataSetLancamentoIndex.BackColor = System.Drawing.Color.Red;

			this.lblDataSetLancamentoIndex.Location = new System.Drawing.Point(432, 112);

			this.lblDataSetLancamentoIndex.Name = "lblDataSetLancamentoIndex";

			this.lblDataSetLancamentoIndex.TabIndex = 38;

			this.lblDataSetLancamentoIndex.Visible = false;

			// 

			// lblIdLancamento

			// 

			this.lblIdLancamento.BackColor = System.Drawing.Color.Red;

			this.lblIdLancamento.Location = new System.Drawing.Point(432, 80);

			this.lblIdLancamento.Name = "lblIdLancamento";

			this.lblIdLancamento.TabIndex = 37;

			this.lblIdLancamento.Visible = false;

			// 

			// pnlLancamentos

			// 

			this.pnlLancamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

			this.pnlLancamentos.Controls.Add(this.dgrLancamentos);

			this.pnlLancamentos.Controls.Add(this.pnlCadastroLancamentos);

			this.pnlLancamentos.Dock = System.Windows.Forms.DockStyle.Bottom;

			this.pnlLancamentos.Location = new System.Drawing.Point(0, 156);

			this.pnlLancamentos.Name = "pnlLancamentos";

			this.pnlLancamentos.Size = new System.Drawing.Size(624, 216);

			this.pnlLancamentos.TabIndex = 36;

			// 

			// dgrLancamentos

			// 

			this.dgrLancamentos.CaptionText = "Lançamentos";

			this.dgrLancamentos.DataMember = "";

			this.dgrLancamentos.Dock = System.Windows.Forms.DockStyle.Fill;

			this.dgrLancamentos.HeaderForeColor = System.Drawing.SystemColors.ControlText;

			this.dgrLancamentos.Location = new System.Drawing.Point(184, 0);

			this.dgrLancamentos.Name = "dgrLancamentos";

			this.dgrLancamentos.Size = new System.Drawing.Size(436, 212);

			this.dgrLancamentos.TabIndex = 36;

			this.dgrLancamentos.Click += new System.EventHandler(this.dgrLancamentos_Click);

			this.dgrLancamentos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgrLancamentos_MouseUp);

			this.dgrLancamentos.CurrentCellChanged += new System.EventHandler(this.dgrLancamentos_CurrentCellChanged);

			// 

			// pnlCadastroLancamentos

			// 

			this.pnlCadastroLancamentos.Controls.Add(this.tblCadastroLancamentos);

			this.pnlCadastroLancamentos.Controls.Add(this.txtDataPagamento);

			this.pnlCadastroLancamentos.Controls.Add(this.txtDataCobranca);

			this.pnlCadastroLancamentos.Controls.Add(this.label1);

			this.pnlCadastroLancamentos.Controls.Add(this.txtStatus);

			this.pnlCadastroLancamentos.Controls.Add(this.txtParcela);

			this.pnlCadastroLancamentos.Controls.Add(this.txtValor);

			this.pnlCadastroLancamentos.Controls.Add(this.lblDataVencimento);

			this.pnlCadastroLancamentos.Controls.Add(this.lblParcela);

			this.pnlCadastroLancamentos.Controls.Add(this.lblValor);

			this.pnlCadastroLancamentos.Controls.Add(this.lblStatus);

			this.pnlCadastroLancamentos.Dock = System.Windows.Forms.DockStyle.Left;

			this.pnlCadastroLancamentos.Location = new System.Drawing.Point(0, 0);

			this.pnlCadastroLancamentos.Name = "pnlCadastroLancamentos";

			this.pnlCadastroLancamentos.Size = new System.Drawing.Size(184, 212);

			this.pnlCadastroLancamentos.TabIndex = 35;

			// 

			// tblCadastroLancamentos

			// 

			this.tblCadastroLancamentos.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {

																									  this.tbbNovoLancamento,

																									  this.tbbSeparadorLancemento1,

																									  this.tbbAlterarLancamento,

																									  this.tbbSeparadorLancemento2,

																									  this.tbbSalvarLancamento,

																									  this.tbbSeparadorLancemento3,

																									  this.tbbCancelarLancamento,

																									  this.tbbSeparadorLancemento4,

																									  this.tbbExcluirLancamento,

																									  this.tbbSeparadorLancemento5});

			this.tblCadastroLancamentos.ButtonSize = new System.Drawing.Size(49, 34);

			this.tblCadastroLancamentos.Dock = System.Windows.Forms.DockStyle.Left;

			this.tblCadastroLancamentos.DropDownArrows = true;

			this.tblCadastroLancamentos.ImageList = this.imlBotoes;

			this.tblCadastroLancamentos.Location = new System.Drawing.Point(0, 0);

			this.tblCadastroLancamentos.Name = "tblCadastroLancamentos";

			this.tblCadastroLancamentos.ShowToolTips = true;

			this.tblCadastroLancamentos.Size = new System.Drawing.Size(49, 212);

			this.tblCadastroLancamentos.TabIndex = 1;

			this.tblCadastroLancamentos.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tblCadastroLancamentos_ButtonClick);

			// 

			// tbbNovoLancamento

			// 

			this.tbbNovoLancamento.ImageIndex = 0;

			this.tbbNovoLancamento.Text = "Novo";

			// 

			// tbbSeparadorLancemento1

			// 

			this.tbbSeparadorLancemento1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbAlterarLancamento

			// 

			this.tbbAlterarLancamento.ImageIndex = 1;

			this.tbbAlterarLancamento.Text = "Alterar";

			// 

			// tbbSeparadorLancemento2

			// 

			this.tbbSeparadorLancemento2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbSalvarLancamento

			// 

			this.tbbSalvarLancamento.ImageIndex = 2;

			this.tbbSalvarLancamento.Text = "Salvar";

			// 

			// tbbSeparadorLancemento3

			// 

			this.tbbSeparadorLancemento3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbCancelarLancamento

			// 

			this.tbbCancelarLancamento.ImageIndex = 3;

			this.tbbCancelarLancamento.Text = "Cancelar";

			// 

			// tbbSeparadorLancemento4

			// 

			this.tbbSeparadorLancemento4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// tbbExcluirLancamento

			// 

			this.tbbExcluirLancamento.ImageIndex = 4;

			this.tbbExcluirLancamento.Text = "Excluir";

			// 

			// tbbSeparadorLancemento5

			// 

			this.tbbSeparadorLancemento5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;

			// 

			// txtDataPagamento

			// 

			this.txtDataPagamento.Enabled = false;

			this.txtDataPagamento.Location = new System.Drawing.Point(64, 144);

			this.txtDataPagamento.MaxLength = 10;

			this.txtDataPagamento.Name = "txtDataPagamento";

			this.txtDataPagamento.Size = new System.Drawing.Size(80, 20);

			this.txtDataPagamento.TabIndex = 39;

			this.txtDataPagamento.Text = "";

			// 

			// txtDataCobranca

			// 

			this.txtDataCobranca.Location = new System.Drawing.Point(64, 64);

			this.txtDataCobranca.MaxLength = 10;

			this.txtDataCobranca.Name = "txtDataCobranca";

			this.txtDataCobranca.Size = new System.Drawing.Size(80, 20);

			this.txtDataCobranca.TabIndex = 33;

			this.txtDataCobranca.Text = "";

			// 

			// label1

			// 

			this.label1.Location = new System.Drawing.Point(64, 128);

			this.label1.Name = "label1";

			this.label1.Size = new System.Drawing.Size(112, 23);

			this.label1.TabIndex = 40;

			this.label1.Text = "Data de Pagamento:";

			// 

			// txtStatus

			// 

			this.txtStatus.Enabled = false;

			this.txtStatus.Location = new System.Drawing.Point(64, 184);

			this.txtStatus.Name = "txtStatus";

			this.txtStatus.Size = new System.Drawing.Size(80, 20);

			this.txtStatus.TabIndex = 41;

			this.txtStatus.Text = "";

			// 

			// txtParcela

			// 

			this.txtParcela.Location = new System.Drawing.Point(64, 24);

			this.txtParcela.Name = "txtParcela";

			this.txtParcela.Size = new System.Drawing.Size(56, 20);

			this.txtParcela.TabIndex = 37;

			this.txtParcela.Text = "";

			// 

			// txtValor

			// 

			this.txtValor.Location = new System.Drawing.Point(64, 104);

			this.txtValor.Name = "txtValor";

			this.txtValor.Size = new System.Drawing.Size(80, 20);

			this.txtValor.TabIndex = 31;

			this.txtValor.Text = "";

			// 

			// lblDataVencimento

			// 

			this.lblDataVencimento.Location = new System.Drawing.Point(64, 48);

			this.lblDataVencimento.Name = "lblDataVencimento";

			this.lblDataVencimento.Size = new System.Drawing.Size(112, 23);

			this.lblDataVencimento.TabIndex = 34;

			this.lblDataVencimento.Text = "Data de Vencimento:";

			// 

			// lblParcela

			// 

			this.lblParcela.Location = new System.Drawing.Point(64, 8);

			this.lblParcela.Name = "lblParcela";

			this.lblParcela.TabIndex = 38;

			this.lblParcela.Text = "Parcela:";

			// 

			// lblValor

			// 

			this.lblValor.Location = new System.Drawing.Point(64, 88);

			this.lblValor.Name = "lblValor";

			this.lblValor.Size = new System.Drawing.Size(56, 23);

			this.lblValor.TabIndex = 26;

			this.lblValor.Text = "Valor:";

			// 

			// lblStatus

			// 

			this.lblStatus.Location = new System.Drawing.Point(64, 168);

			this.lblStatus.Name = "lblStatus";

			this.lblStatus.TabIndex = 42;

			this.lblStatus.Text = "Status:";

			// 

			// txtDataAtendimento

			// 

			this.txtDataAtendimento.Location = new System.Drawing.Point(8, 24);

			this.txtDataAtendimento.MaxLength = 10;

			this.txtDataAtendimento.Name = "txtDataAtendimento";

			this.txtDataAtendimento.Size = new System.Drawing.Size(80, 20);

			this.txtDataAtendimento.TabIndex = 30;

			this.txtDataAtendimento.Text = "";

			// 

			// cbbServicos

			// 

			this.cbbServicos.Location = new System.Drawing.Point(8, 104);

			this.cbbServicos.Name = "cbbServicos";

			this.cbbServicos.Size = new System.Drawing.Size(368, 21);

			this.cbbServicos.TabIndex = 29;

			// 

			// cbbClientes

			// 

			this.cbbClientes.Items.AddRange(new object[] {

															 "Selecione um Cliente"});

			this.cbbClientes.Location = new System.Drawing.Point(8, 64);

			this.cbbClientes.Name = "cbbClientes";

			this.cbbClientes.Size = new System.Drawing.Size(368, 21);

			this.cbbClientes.TabIndex = 28;

			// 

			// lblDataAtendimento

			// 

			this.lblDataAtendimento.Location = new System.Drawing.Point(8, 8);

			this.lblDataAtendimento.Name = "lblDataAtendimento";

			this.lblDataAtendimento.Size = new System.Drawing.Size(64, 23);

			this.lblDataAtendimento.TabIndex = 25;

			this.lblDataAtendimento.Text = "Data:";

			// 

			// lblServico

			// 

			this.lblServico.Location = new System.Drawing.Point(8, 88);

			this.lblServico.Name = "lblServico";

			this.lblServico.TabIndex = 24;

			this.lblServico.Text = "Serviço:";

			// 

			// lblCliente

			// 

			this.lblCliente.Location = new System.Drawing.Point(8, 48);

			this.lblCliente.Name = "lblCliente";

			this.lblCliente.TabIndex = 23;

			this.lblCliente.Text = "Cliente:";

			// 

			// lblDataSetIndex

			// 

			this.lblDataSetIndex.BackColor = System.Drawing.Color.Red;

			this.lblDataSetIndex.Location = new System.Drawing.Point(432, 48);

			this.lblDataSetIndex.Name = "lblDataSetIndex";

			this.lblDataSetIndex.TabIndex = 22;

			this.lblDataSetIndex.Visible = false;

			// 

			// tbpPesquisar

			// 

			this.tbpPesquisar.Controls.Add(this.dgrAtendimentos);

			this.tbpPesquisar.Location = new System.Drawing.Point(4, 22);

			this.tbpPesquisar.Name = "tbpPesquisar";

			this.tbpPesquisar.Size = new System.Drawing.Size(624, 372);

			this.tbpPesquisar.TabIndex = 1;

			this.tbpPesquisar.Text = "Pesquisar";

			this.tbpPesquisar.Click += new System.EventHandler(this.tbpPesquisar_Click);

			// 

			// dgrAtendimentos

			// 

			this.dgrAtendimentos.CaptionText = "Atendimentos";

			this.dgrAtendimentos.DataMember = "";

			this.dgrAtendimentos.Dock = System.Windows.Forms.DockStyle.Fill;

			this.dgrAtendimentos.HeaderForeColor = System.Drawing.SystemColors.ControlText;

			this.dgrAtendimentos.Location = new System.Drawing.Point(0, 0);

			this.dgrAtendimentos.Name = "dgrAtendimentos";

			this.dgrAtendimentos.Size = new System.Drawing.Size(624, 372);

			this.dgrAtendimentos.TabIndex = 0;

			this.dgrAtendimentos.DoubleClick += new System.EventHandler(this.dgrAtendimentos_DoubleClick);

			this.dgrAtendimentos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgrAtendimentos_MouseUp);

			// 

			// FrmAtendimento

			// 

			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

			this.ClientSize = new System.Drawing.Size(632, 446);

			this.Controls.Add(this.pnlFormulario);

			this.Controls.Add(this.pnlToolBar);

			this.Name = "FrmAtendimento";

			this.Text = "Atendimento de Atendimentos";

			this.pnlToolBar.ResumeLayout(false);

			this.pnlFormulario.ResumeLayout(false);

			this.tbcAtendimento.ResumeLayout(false);

			this.tbpCadastrar.ResumeLayout(false);

			this.pnlLancamentos.ResumeLayout(false);

			((System.ComponentModel.ISupportInitialize)(this.dgrLancamentos)).EndInit();

			this.pnlCadastroLancamentos.ResumeLayout(false);

			this.tbpPesquisar.ResumeLayout(false);

			((System.ComponentModel.ISupportInitialize)(this.dgrAtendimentos)).EndInit();

			this.ResumeLayout(false);

 

		}

		#endregion

 

 

		private void CarregarTela()

		{

			if (dsAtendimentos == null)

			{

				dsAtendimentos = ControladorAtendimento.RetornaListaAtendimento();

			}

                  

			int indice = Convert.ToInt32(lblDataSetIndex.Text) ;

                  

			if (dsAtendimentos.Tables[0].Rows.Count > 0)

			{

				this.ExibirRegistro(indice) ;

 

				tbbNovo.Enabled = true;

				tbbAlterar.Enabled = true;

				tbbSalvar.Enabled = false;

				tbbCancelar.Enabled = false;

				tbbExcluir.Enabled = true;

				tbbProximo.Enabled = true;

				tbbAnterior.Enabled = true;

 

				this.HabilitarBotoesLancamentos();

			}

			else

			{

				tbbNovo.Enabled = true;

				tbbAlterar.Enabled = false;

				tbbSalvar.Enabled = false;

				tbbCancelar.Enabled = false;

				tbbExcluir.Enabled = false;

				tbbProximo.Enabled = false;

				tbbAnterior.Enabled = false;

 

				tbbNovoLancamento.Enabled = false;

				tbbAlterarLancamento.Enabled = false;

				tbbSalvarLancamento.Enabled = false;

				tbbCancelarLancamento.Enabled = false;

				tbbExcluirLancamento.Enabled = false;

			}

		}

            

            

		private void ListarClientes()

		{

			dsClientes = ControladorCliente.RetornarListaCliente();

		}

 

		private void ListarServicos()

		{

			dsServicos = ControladorServico.RetornaListaServico();

		}

            

		private void tbcAtendimento_SelectedIndexChanged(object sender, EventArgs e)

		{

			if (tbcAtendimento.SelectedTab == tbpCadastrar)

			{

				if (lblIdAtendimento.Text != "0")

				{

					int indice = Convert.ToInt32(lblDataSetIndex.Text);

					this.ExibirRegistro(indice);

				}

			}

			else

			{

				if (!dgrAtendimentos.TableStyles.Contains(estiloGridAtendimentos))

				{

					estiloGridAtendimentos.MappingName = dsAtendimentos.Tables[0].TableName.ToString();

 

					colunaGridAtendimentos = new DataGridTextBoxColumn();

					colunaGridAtendimentos.MappingName = "nome_cliente";

					colunaGridAtendimentos.HeaderText  = "Cliente";

					colunaGridAtendimentos.Width    = 250;

					estiloGridAtendimentos.GridColumnStyles.Add(colunaGridAtendimentos);

 

					colunaGridAtendimentos = new DataGridTextBoxColumn();

					colunaGridAtendimentos.MappingName = "nome_servico";

					colunaGridAtendimentos.HeaderText  = "Serviço";

					colunaGridAtendimentos.Width    = 250;

					estiloGridAtendimentos.GridColumnStyles.Add(colunaGridAtendimentos);

 

					colunaGridAtendimentos = new DataGridTextBoxColumn();

					colunaGridAtendimentos.MappingName = "data_atendimento";

					colunaGridAtendimentos.HeaderText  = "Data";

					colunaGridAtendimentos.Width    = 80;

					estiloGridAtendimentos.GridColumnStyles.Add(colunaGridAtendimentos);

 

					dgrAtendimentos.TableStyles.Add(estiloGridAtendimentos);

				}

                        

				dgrLancamentos.SetDataBinding(dsLancamentos,"lancamento") ;

                        

				dgrAtendimentos.SetDataBinding(dsAtendimentos,"atendimento");

			}

		}

 

 

		private int ProcurarRegistroAtendimento()

		{

			int i;

 

			for (i=0; i<= dsAtendimentos.Tables[0].Rows.Count - 1;i++)

			{

				if (dsAtendimentos.Tables[0].Rows[i]["id_atendimento"].ToString() == lblIdAtendimento.Text)

				{

					break;

				}

			}

			return i;

		}

 

		private int ProcurarRegistroLancamento()

		{

			int i;

 

			for (i=0; i<= dsLancamentos.Tables[0].Rows.Count - 1;i++)

			{

				if (dsLancamentos.Tables[0].Rows[i]["id_lancamento"].ToString() == lblIdLancamento.Text)

				{

					break;

				}

			}

			return i;

		}

 

		private void ExibirRegistro(int indice)

		{

			if (dsAtendimentos.Tables[0].Rows.Count > 0)

			{

				if (indice >= 0 &&  indice <= dsAtendimentos.Tables[0].Rows.Count -1)

				{

					lblIdAtendimento.Text       = dsAtendimentos.Tables[0].Rows[indice]["id_atendimento"].ToString();

					txtDataAtendimento.Text      = Convert.ToDateTime(dsAtendimentos.Tables[0].Rows[indice]["data_atendimento"]).ToString("dd/MM/yyyy")  ;

					cbbClientes.SelectedValue    = dsAtendimentos.Tables[0].Rows[indice]["id_cliente"].ToString();

					cbbServicos.SelectedValue    = dsAtendimentos.Tables[0].Rows[indice]["id_servico"].ToString();

 

					lblDataSetIndex.Text = indice.ToString();

					this.ListarDataGridLancamentos(Convert.ToInt32(lblIdAtendimento.Text),0)  ;

				}

			}

			else

			{

				tbbNovo.Enabled = true;

				tbbAlterar.Enabled = false;

				tbbSalvar.Enabled = false;

				tbbCancelar.Enabled = false;

				tbbExcluir.Enabled = false;

				tbbProximo.Enabled = false;

				tbbAnterior.Enabled = false;

			}

                  

		}

 

		private void ExibirRegistroLancamento(int indice)

		{

			if (dsLancamentos.Tables[0].Rows.Count > 0)

			{

				if (indice >= 0 &&  indice <= dsLancamentos.Tables[0].Rows.Count -1)

				{

					lblIdLancamento.Text        = dsLancamentos.Tables[0].Rows[indice]["id_lancamento"].ToString();

					txtDataCobranca.Text         = Convert.ToDateTime(dsLancamentos.Tables[0].Rows[indice]["data_cobranca"]).ToString("dd/MM/yyyy");

					txtParcela.Text                    = dsLancamentos.Tables[0].Rows[indice]["numero_parcela"].ToString();

					txtValor.Text                      = dsLancamentos.Tables[0].Rows[indice]["valor"].ToString();

                             

					if (dsLancamentos.Tables[0].Rows[indice]["data_recebimento"] != DBNull.Value)

					{

						txtDataPagamento.Text = Convert.ToDateTime(dsLancamentos.Tables[0].Rows[indice]["data_recebimento"]).ToString("dd/MM/yyyy");     

					}

					if (dsLancamentos.Tables[0].Rows[indice]["status"] != DBNull.Value)

					{

						txtStatus.Text = dsLancamentos.Tables[0].Rows[indice]["status"].ToString();

					}

				}

			}

			else

			{

				tbbNovoLancamento.Enabled = true;

				tbbAlterarLancamento.Enabled = false;

				tbbSalvarLancamento.Enabled = false;

				tbbCancelarLancamento.Enabled = false;

				tbbExcluirLancamento.Enabled = false;

			}

		}

 

            

		private void ListarDataGridLancamentos(int idAtendimento, int indice)

		{

			dsLancamentos = ControladorLancamento.RetornaListaLancamento(idAtendimento);

                  

			if (!dgrLancamentos.TableStyles.Contains(estiloGridLancamentos))

			{

				estiloGridLancamentos.MappingName = dsLancamentos.Tables[0].TableName.ToString();

 

				colunaGridLancamentos = new DataGridTextBoxColumn();

				colunaGridLancamentos.MappingName = "numero_parcela";

				colunaGridLancamentos.HeaderText  = "Parcela";

				colunaGridLancamentos.Width     = 50;

				estiloGridLancamentos.GridColumnStyles.Add(colunaGridLancamentos);

 

				colunaGridLancamentos = new DataGridTextBoxColumn();

				colunaGridLancamentos.MappingName = "data_cobranca";

				colunaGridLancamentos.HeaderText  = "Vencimento";

				colunaGridLancamentos.Width     = 90;

				estiloGridLancamentos.GridColumnStyles.Add(colunaGridLancamentos);

 

				colunaGridLancamentos = new DataGridTextBoxColumn();

				colunaGridLancamentos.MappingName = "valor";

				colunaGridLancamentos.HeaderText  = "Valor";

				colunaGridLancamentos.Width     = 60;

				estiloGridLancamentos.GridColumnStyles.Add(colunaGridLancamentos);

 

				colunaGridLancamentos = new DataGridTextBoxColumn();

				colunaGridLancamentos.MappingName = "data_recebimento";

				colunaGridLancamentos.HeaderText  = "Pagamento";

				colunaGridLancamentos.Width     = 90;

				estiloGridLancamentos.GridColumnStyles.Add(colunaGridLancamentos);

 

				colunaGridLancamentos = new DataGridTextBoxColumn();

				colunaGridLancamentos.MappingName = "status";

				colunaGridLancamentos.HeaderText  = "Status";

				colunaGridLancamentos.Width     = 100;

				estiloGridLancamentos.GridColumnStyles.Add(colunaGridLancamentos);

 

				dgrLancamentos.TableStyles.Add(estiloGridLancamentos);

			}

                  

			dgrLancamentos.SetDataBinding(dsLancamentos,"lancamento") ;

 

			this.ExibirRegistroLancamento(indice) ;

		}

 

		private void LimparCampos()

		{

			lblIdAtendimento.Text   = "0";

			lblDataSetIndex.Text    = "0";

			txtDataAtendimento.Text = String.Empty;

		}

 

		private void LimparCamposLancamentos()

		{

			lblIdLancamento.Text               = "0";

			lblDataSetLancamentoIndex.Text  = "0";

			txtParcela.Text                          = String.Empty;

			txtDataCobranca.Text               = String.Empty;

			txtDataPagamento.Text              = String.Empty;

			txtStatus.Text                           = String.Empty;

			txtValor.Text                            = "0";

		}

 

 

		private void tlbBotoes_ButtonClick(object sender, ToolBarButtonClickEventArgs e)

		{

			if (e.Button == tbbNovo)

			{

				this.LimparCampos();

				this.LimparCamposLancamentos() ;

 

				tbbNovo.Enabled = false;

				tbbAlterar.Enabled = false;

				tbbSalvar.Enabled = true;

				tbbCancelar.Enabled = true;

				tbbExcluir.Enabled = false;

				tbbProximo.Enabled = false;

				tbbAnterior.Enabled = false;

 

				tbbNovoLancamento.Enabled = false;

				tbbAlterarLancamento.Enabled = false;

				tbbSalvarLancamento.Enabled = false;

				tbbCancelarLancamento.Enabled = false;

				tbbExcluirLancamento.Enabled = false;

			}

 

			if (e.Button == tbbAlterar)

			{

				tbbNovo.Enabled = false;

				tbbAlterar.Enabled = false;

				tbbSalvar.Enabled = true;

				tbbCancelar.Enabled = true;

				tbbExcluir.Enabled = false;

				tbbProximo.Enabled = false;

				tbbAnterior.Enabled = false;

 

				tbbNovoLancamento.Enabled = false;

				tbbAlterarLancamento.Enabled = false;

				tbbSalvarLancamento.Enabled = false;

				tbbCancelarLancamento.Enabled = false;

				tbbExcluirLancamento.Enabled = false;

			}

 

			if (e.Button == tbbSalvar)

			{

				DialogResult resposta = MessageBox.Show("Deseja Salvar as Alterações?","Atendimento ",MessageBoxButtons.YesNo,

					MessageBoxIcon.Question,

					MessageBoxDefaultButton.Button2);

				if(resposta == DialogResult.Yes)

				{

					if (this.Salvar())

					{

						tbbNovo.Enabled = true;

						tbbAlterar.Enabled = true;

						tbbSalvar.Enabled = false;

						tbbCancelar.Enabled = false;

						tbbExcluir.Enabled = true;

						tbbProximo.Enabled = true;

						tbbAnterior.Enabled = true;

 

						HabilitarBotoesLancamentos();

					}

				}

			}

 

			if (e.Button == tbbCancelar)

			{

				tbbNovo.Enabled = true;

				tbbAlterar.Enabled = true;

				tbbSalvar.Enabled = false;

				tbbCancelar.Enabled = false;

				tbbExcluir.Enabled = true;

				tbbProximo.Enabled = true;

				tbbAnterior.Enabled = true;

 

				int indice = Convert.ToInt32(lblDataSetIndex.Text); 

				this.ExibirRegistro(indice);

 

				HabilitarBotoesLancamentos();

			}

 

			if (e.Button == tbbExcluir)

			{

				DialogResult resposta = MessageBox.Show("Deseja Realmente Excluir?","Atendimento",MessageBoxButtons.YesNo,

					MessageBoxIcon.Question,

					MessageBoxDefaultButton.Button2);

				if(resposta == DialogResult.Yes)

				{

					if (this.Excluir())

					{

						if (dsAtendimentos.Tables[0].Rows.Count > 0)

						{

							tbbNovo.Enabled = true;

							tbbAlterar.Enabled = true;

							tbbSalvar.Enabled = false;

							tbbCancelar.Enabled = false;

							tbbExcluir.Enabled = true;

							tbbProximo.Enabled = true;

							tbbAnterior.Enabled = true;

 

							HabilitarBotoesLancamentos();

						}

					}

				}

			}

 

			if (e.Button == tbbAnterior)

			{

				int indice = Convert.ToInt32(lblDataSetIndex.Text) - 1;

				this.LimparCamposLancamentos() ;

				this.ExibirRegistro(indice);

 

				tbbNovo.Enabled = true;

				tbbAlterar.Enabled = true;

				tbbSalvar.Enabled = false;

				tbbCancelar.Enabled = false;

				tbbExcluir.Enabled = true;

				tbbProximo.Enabled = true;

				tbbAnterior.Enabled = true;

 

				HabilitarBotoesLancamentos();

			}

 

			if (e.Button == tbbProximo)

			{

				int indice = Convert.ToInt32(lblDataSetIndex.Text) + 1; 

				this.LimparCamposLancamentos() ;

				this.ExibirRegistro(indice);

 

				tbbNovo.Enabled = true;

				tbbAlterar.Enabled = true;

				tbbSalvar.Enabled = false;

				tbbCancelar.Enabled = false;

				tbbExcluir.Enabled = true;

				tbbProximo.Enabled = true;

				tbbAnterior.Enabled = true;

 

				HabilitarBotoesLancamentos();

                        

			}

		}

 

		private void HabilitarBotoesLancamentos()

		{

			if (dsLancamentos.Tables[0].Rows.Count > 0)

			{

				tbbNovoLancamento.Enabled = true;

				tbbAlterarLancamento.Enabled = true;

				tbbSalvarLancamento.Enabled = false;

				tbbCancelarLancamento.Enabled = false;

				tbbExcluirLancamento.Enabled = true;

			}

			else

			{

				tbbNovoLancamento.Enabled = true;

				tbbAlterarLancamento.Enabled = false;

				tbbSalvarLancamento.Enabled = false;

				tbbCancelarLancamento.Enabled = false;

				tbbExcluirLancamento.Enabled = false;

			}

		}

 

		private bool Excluir()

		{

			if (lblIdAtendimento.Text != "0")

			{

				try

				{

					ControladorAtendimento.Excluir(Convert.ToInt32(lblIdAtendimento.Text));

					dsAtendimentos.Tables[0].Rows.RemoveAt(Convert.ToInt32(lblDataSetIndex.Text));

					this.LimparCampos();

					this.ExibirRegistro(0);

					return true;

				}

				catch(Exception e)

				{

					MessageBox.Show(e.Message);

					return false;

				}

			}

			else

			{

				return false;

			}

		}

 

		private bool ExcluirLancamento()

		{

			if (lblIdLancamento.Text != "0")

			{

				try

				{

					ControladorLancamento.Excluir(Convert.ToInt32(lblIdLancamento.Text));

					this.LimparCamposLancamentos();

					this.ListarDataGridLancamentos(Convert.ToInt32(lblIdAtendimento.Text),0) ;

					return true;

				}

				catch(Exception e)

				{

					MessageBox.Show(e.Message);

					return false;

				}

			}

			else

			{

				return false;

			}

		}

            

		private bool Salvar()

		{

			try

			{

				int idAtendimento = Convert.ToInt32("0" + lblIdAtendimento.Text); 

				int idCliente = Convert.ToInt32(cbbClientes.SelectedValue); 

				int idServico = Convert.ToInt32(cbbServicos.SelectedValue); 

				DateTime dataAtendimento = Convert.ToDateTime(txtDataAtendimento.Text);

                        

				idAtendimento = ControladorAtendimento.AlterarAtendimento(idAtendimento,idCliente, idServico,1m,dataAtendimento);

 

                        

				if (lblIdAtendimento.Text == "0")

				{

					lblIdAtendimento.Text = idAtendimento.ToString();

					this.AdicionarLinha(dsAtendimentos.Tables[0].NewRow());

					this.ExibirRegistro(dsAtendimentos.Tables[0].Rows.Count -1); 

				}

				else

				{

					lblIdAtendimento.Text = idAtendimento.ToString();

					int indice = this.ProcurarRegistroAtendimento();

					this.AlterarLinha(indice);

					this.ExibirRegistro(indice); 

				}

				return true;

			}

			catch (Exception e)

			{

				MessageBox.Show(e.Message);

				return false;

			}

		}

 

		private bool SalvarLancamento()

		{

			try

			{

				int idAtendimento = Convert.ToInt32("0" + lblIdAtendimento.Text);

				int idLancamento  = Convert.ToInt32("0" + lblIdLancamento.Text); 

				DateTime dataCobranca = Convert.ToDateTime(txtDataCobranca.Text);

				decimal valor = Convert.ToDecimal(txtValor.Text) ;

				int numeroParcela = Convert.ToInt32(txtParcela.Text);

                        

				idLancamento = ControladorLancamento.AlterarLancamento(idLancamento,idAtendimento,numeroParcela,

					dataCobranca,dataCobranca,DateTime.MinValue,1);

                        

				lblIdLancamento.Text = idLancamento.ToString();

                        

				this.ListarDataGridLancamentos(idAtendimento, this.ProcurarRegistroLancamento());

				return true;

			}

			catch (Exception e)

			{

				MessageBox.Show(e.Message);

				return false;

			}

		}

 

		private void AdicionarLinha(DataRow drAtendimentos)

		{

			drAtendimentos["id_atendimento"]   = lblIdAtendimento.Text.Trim();

			drAtendimentos["id_cliente"]       = cbbClientes.SelectedValue;

			drAtendimentos["id_servico"]       = cbbServicos.SelectedValue;

			drAtendimentos["data_atendimento"] = txtDataAtendimento.Text.Trim();

                  

			dsAtendimentos.Tables[0].Rows.Add(drAtendimentos);

		}

 

		private void AlterarLinha(int indice)

		{

			dsAtendimentos.Tables[0].Rows[indice]["id_atendimento"]          = lblIdAtendimento.Text.Trim();

			dsAtendimentos.Tables[0].Rows[indice]["id_cliente"]              = cbbClientes.SelectedValue;

			dsAtendimentos.Tables[0].Rows[indice]["id_servico"]              = cbbServicos.SelectedValue;

			dsAtendimentos.Tables[0].Rows[indice]["data_atendimento"]  = txtDataAtendimento.Text.Trim();

		}

 

		private void dgrAtendimentos_DoubleClick(object sender, System.EventArgs e)

		{

			int indice = dgrAtendimentos.CurrentRowIndex;

			this.ExibirRegistro(indice);

			tbcAtendimento.SelectedTab = tbpCadastrar;

		}

 

		private void tbpCadastrar_Click(object sender, System.EventArgs e)

		{

            

		}

 

		private void tbpPesquisar_Click(object sender, System.EventArgs e)

		{

            

		}

 

		private void tblCadastroLancamentos_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)

		{

			if (e.Button == tbbNovoLancamento)

			{

				this.LimparCamposLancamentos();

 

				tbbNovoLancamento.Enabled = false;

				tbbAlterarLancamento.Enabled = false;

				tbbSalvarLancamento.Enabled = true;

				tbbCancelarLancamento.Enabled = true;

				tbbExcluirLancamento.Enabled = false;

			}

 

			if (e.Button == tbbAlterarLancamento)

			{

				tbbNovoLancamento.Enabled = false;

				tbbAlterarLancamento.Enabled = false;

				tbbSalvarLancamento.Enabled = true;

				tbbCancelarLancamento.Enabled = true;

				tbbExcluirLancamento.Enabled = false;

			}

 

			if (e.Button == tbbSalvarLancamento)

			{

				DialogResult resposta = MessageBox.Show("Deseja Salvar as Alterações?","Lançamentos ",MessageBoxButtons.YesNo,

					MessageBoxIcon.Question,

					MessageBoxDefaultButton.Button2);

				if(resposta == DialogResult.Yes)

				{

					if (this.SalvarLancamento())

					{

						tbbNovoLancamento.Enabled = true;

						tbbAlterarLancamento.Enabled = true;

						tbbSalvarLancamento.Enabled = false;

						tbbCancelarLancamento.Enabled = false;

						tbbExcluirLancamento.Enabled = true;

					}

				}

			}

 

			if (e.Button == tbbCancelarLancamento)

			{

				tbbNovoLancamento.Enabled = true;

				tbbAlterarLancamento.Enabled = true;

				tbbSalvarLancamento.Enabled = false;

				tbbCancelarLancamento.Enabled = false;

				tbbExcluirLancamento.Enabled = true;

 

				this.ListarDataGridLancamentos(Convert.ToInt32(lblIdAtendimento.Text),this.ProcurarRegistroLancamento()) ;

			}

 

			if (e.Button == tbbExcluirLancamento)

			{

				DialogResult resposta = MessageBox.Show("Deseja Realmente Excluir?","Lançamento",MessageBoxButtons.YesNo,

					MessageBoxIcon.Question,

					MessageBoxDefaultButton.Button2);

				if(resposta == DialogResult.Yes)

				{

					if (this.ExcluirLancamento())

					{

						if (dsLancamentos.Tables[0].Rows.Count > 0)

						{

							tbbNovoLancamento.Enabled = true;

							tbbAlterarLancamento.Enabled = true;

							tbbSalvarLancamento.Enabled = false;

							tbbCancelarLancamento.Enabled = false;

							tbbExcluirLancamento.Enabled = true;

						}

					}

				}

			}

		}

 

		private void dgrLancamentos_Click(object sender, System.EventArgs e)

		{

			if (tbbSalvarLancamento.Enabled == false)

			{

				this.ExibirRegistroLancamento(dgrLancamentos.CurrentRowIndex) ;

			}

		}

 

 

		private void dgrLancamentos_CurrentCellChanged(object sender, System.EventArgs e)

		{

			if (tbbSalvarLancamento.Enabled == false)

			{

				this.ExibirRegistroLancamento(dgrLancamentos.CurrentRowIndex) ;

			}

		}

 

		private void dgrLancamentos_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)

		{

			Point pt = new Point(e.X, e.Y);

			DataGrid.HitTestInfo hit = dgrLancamentos.HitTest(pt);

 

			if (hit.Type == DataGrid.HitTestType.Cell)

			{

				dgrLancamentos.CurrentCell = new DataGridCell(hit.Row,hit.Column);

				dgrLancamentos.Select(hit.Row);

			}

		}

 

		private void dgrAtendimentos_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)

		{

			Point pt = new Point(e.X, e.Y);

			DataGrid.HitTestInfo hit = dgrAtendimentos.HitTest(pt);

 

			if (hit.Type == DataGrid.HitTestType.Cell)

			{

				dgrAtendimentos.CurrentCell = new DataGridCell(hit.Row,hit.Column);

				dgrAtendimentos.Select(hit.Row);

			}

		}

 

	}

}

