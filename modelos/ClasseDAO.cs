using System.Collections;
using Volga.Core.Dominio.CAS;

namespace Volga.Core.DAO.CAS
{
	internal class UsuarioDAO
	{
		
		public void PersistirUsuario(Usuario usuario)
		{
			
		}

		public Usuario ObterUsuarioPeloLogin(string login)
		{
			return new Usuario();
		}

		public IList ObterListaDeTodosOsUsuarios()
		{
			return new ArrayList();
		}

		public Usuario Materializar(int id)
		{
			return new Usuario();
		}

	}
}