using System.Data;
using System.Collections;

namespace WinGerador.BD
{
	internal abstract class BDAdapter
	{
		public abstract DataSet GetData(string sql, string conn, string _tabela);
		public abstract DataSet GetCampos(string Tabela, string conexao);
		public abstract DataSet GetTabelas(string conexao);
	}
}
