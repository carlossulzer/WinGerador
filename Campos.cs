namespace WinGerador
{
	public class Campos
	{
		private string _tabela;
		private string _campo;
		private string _tipo;
		private string _chave;

		public Campos()
		{
		}


		public Campos(string tabela, string campo, string tipo, string chave)
		{
			_tabela = tabela;
			_campo  = campo;
			_tipo   = tipo;
			_chave  = chave;
		}


		public string Tabela
		{
			get { return _tabela; }
			set { _tabela = value; }
		}

		public string Campo
		{
			get { return _campo; }
			set { _campo = value; }
		}

		public string Tipo
		{
			get { return _tipo; }
			set { _tipo = value; }
		}

		public string Chave
		{
			get { return _chave; }
			set { _chave = value; }
		}

	}
}
