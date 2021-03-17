using NUnit.Framework;
using Volga.Core.Dominio.CAS;
using Volga.Core.Services;
using Volga.Core.Services.CAS;

namespace Volga.Core.Testes
{
	[TestFixture]
	public class UsuarioTeste
	{
		CommandHandler _commandHandler = new CommandHandler();
		
		[Test]
		public void SalvareObterUsuario()
		{
			string login = "joao.silva"; 
			
			Usuario joao = new Usuario(login);

			SalvarUsuario salvar = new SalvarUsuario(joao);
			_commandHandler.Run(salvar);

			Assert.AreEqual(login, salvar.Usuario.Login);

			ObterUsuario obter = new ObterUsuario(login);
			_commandHandler.Run(obter);
			
			Usuario usuarioRetornado = obter.Usuario;

			Assert.AreEqual(joao, usuarioRetornado);
		}
		
		[Test]
		public void ListarUsuarios()
		{
			Usuario user1 = new Usuario("user1");

			SalvarUsuario salvarUser1 = new SalvarUsuario(user1);
			_commandHandler.Run(salvarUser1);

			Usuario user2 = new Usuario("user2");

			SalvarUsuario salvarUser2 = new SalvarUsuario(user2);
			_commandHandler.Run(salvarUser2);
			
            ObterListaDeUsuarios obterLista = new ObterListaDeUsuarios();
			_commandHandler.Run(obterLista);

			Assert.AreEqual(2, obterLista.ListaObtida.Count);

		}

		[Test]
		[ExpectedException(typeof(UsuarioInvalidoException))]
		public void ValidacaoDeUsuariosComMesmoLogin()
		{
			Usuario user1 = new Usuario("user1");

			SalvarUsuario salvarUser1 = new SalvarUsuario(user1);
			_commandHandler.Run(salvarUser1);

			Usuario user2 = new Usuario("user1");

			SalvarUsuario salvarUser2 = new SalvarUsuario(user2);

			_commandHandler.Run(salvarUser2);
		}

	}
}
