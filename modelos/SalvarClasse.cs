using Volga.Core.DAO.CAS;
using Volga.Core.Dominio.CAS;
using Volga.Core.Services;

namespace Volga.Core.Services.CAS
{
	public class SalvarUsuario: Command
	{
		Usuario _usuario;
		UsuarioDAO _userDAO = new UsuarioDAO();

		public SalvarUsuario(Usuario contextUser)
		{
			_usuario = contextUser;
		}

		public Usuario Usuario
		{
			get { return _usuario; }
		}

		internal override void Execute()
		{
			_userDAO.PersistirUsuario(_usuario);
		}

	}
}
