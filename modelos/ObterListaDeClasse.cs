using System.Collections;
using Volga.Core.DAO.CAS;

namespace Volga.Core.Services.CAS
{
	public class ObterListaDeUsuarios: Command
	{
		private UsuarioDAO usuarioDAO = new UsuarioDAO();
		private IList _listaObtida;
		public ObterListaDeUsuarios()
		{
		}

		internal override void Execute()
		{
			_listaObtida = usuarioDAO.ObterListaDeTodosOsUsuarios();
		}

		public IList ListaObtida
		{
			get { return _listaObtida; }
		}
	}
}
