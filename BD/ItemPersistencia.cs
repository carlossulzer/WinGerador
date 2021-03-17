namespace WinGerador.BD
{
	public class ItemPersistencia
	{

		private object _valor;
		public object Valor
		{
			get
			{
				return _valor;
			}
			set
			{
				_valor = value;
			}
		}

		private string _nome;
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
			}
		}

		private bool _isNull;
		public bool ISNull
		{
			get
			{
				return _isNull;
			}
			set
			{
				_isNull = value;
			}
		}
		
		public ItemPersistencia(string nome, object valor)
		{
			this.Nome = nome;
			this.Valor = valor;
		}

		public ItemPersistencia(string nome, object valor, bool isNull)
		{
			this.Nome = nome;
			this.Valor = valor;
			this.ISNull = isNull;
		}
	}
}
