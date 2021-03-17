namespace Volga.Core.Dominio.CAS
{
	public class Usuario
	{
		private int _idUsuario;
		private string _login;
		private string _nomeCompleto;
		private string _email;
		private bool _bloqueado;
		private bool _obrigarTrocadeSenha;

		public Usuario()
		{
		}

		public Usuario(	string login)
		{
			_login = login;
		}

		public int IdUsuario
		{
			get { return _idUsuario; }
			set { _idUsuario = value; }
		}

		public string Login
		{
			get { return _login; }
			set { _login = value; }
		}

		public string NomeCompleto
		{
			get { return _nomeCompleto; }
			set { _nomeCompleto = value; }
		}

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public bool Bloqueado
		{
			get { return _bloqueado; }
			set { _bloqueado = value; }
		}

		public bool ObrigarTrocaDeSenha
		{
			get { return _obrigarTrocadeSenha; }
			set { _obrigarTrocadeSenha = value; }
		}


	}
}
