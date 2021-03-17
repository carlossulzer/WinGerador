using Volga.Core.DAO.CAS;
using Volga.Core.Dominio.CAS;
using Volga.Core.Services;

namespace Volga.Core.Services.CAS
{
	public class ObterUsuario: Command
	{
		private readonly string _login;
		private Usuario _user;
		
		public ObterUsuario(string login)
		{
			_login = login;
		}

		public Usuario Usuario
		{
			get { return _user; }
		}

		internal override void Execute()
		{
			UsuarioDAO userDAO = new UsuarioDAO();
			_user = userDAO.ObterUsuarioPeloLogin(_login);
		}

	}
}
