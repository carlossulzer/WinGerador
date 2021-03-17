using System;

namespace Volga.Core.Dominio.CAS
{
	public class UsuarioInvalidoException: ApplicationException
	{
		public UsuarioInvalidoException()
		{
		}

		public UsuarioInvalidoException(string message) : base(message)
		{
		}
	}
}
