using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections;

namespace WinGerador.BD
{
	internal class OracleAdapter: BDAdapter
	{
		public override DataSet GetData(string sql, string conn, string _tabela)
		{
			OracleConnection conexao = new OracleConnection(conn);
			
			DataSet ds;
			using (conexao)
			{
				OracleDataAdapter adapter = new OracleDataAdapter(sql, conexao);
				ds = new DataSet();
				adapter.Fill(ds, _tabela);
			}

			return ds;
		}

		public override DataSet GetCampos(string Tabela, string conexao)
		{
			string sql = " Select " +
				"   tab.TABLE_NAME as ctabela,"+
				"   tab.COLUMN_NAME as cnome, " +
				"   tab.DATA_TYPE as ctipo, " +
				"   co.CONSTRAINT_TYPE as cchave " +
				" From " +
				"   USER_TAB_COLUMNS TAB LEFT OUTER JOIN " +
				"	(USER_CONSTRAINTS CO INNER JOIN USER_CONS_COLUMNS CO1 ON "+
				"	CO.TABLE_NAME = CO1.TABLE_NAME AND CO.CONSTRAINT_NAME = CO1.CONSTRAINT_NAME) ON " +
				"	TAB.TABLE_NAME = CO.TABLE_NAME AND TAB.COLUMN_NAME = CO1.COLUMN_NAME " +
				" Where " +
				"   tab.TABLE_NAME = '"+ Tabela +"'";

			return this.GetData(sql, conexao, Tabela);
		}

		private static Campos CriarObjetoCampos(QueryResult dadosDosCampos)
		{
			return new Campos(
				dadosDosCampos[CamposDIC.COL_TABELA],
				dadosDosCampos[CamposDIC.COL_CAMPO],
				dadosDosCampos[CamposDIC.COL_TIPO],
				dadosDosCampos[CamposDIC.COL_CHAVE]
				);
		}

		public override DataSet GetTabelas(string conexao)
		{
			string getSchemaTableText = "SELECT SER_TAB_COLUMNS WHERE TABLE_TYPE = 'BASE TABLE' ORDER  BY TABLE_TYPE";
			OracleConnection conn = new OracleConnection(conexao);		
			OracleDataAdapter da = new OracleDataAdapter(getSchemaTableText, conn);
			DataSet schemaTable = new DataSet();
			da.Fill(schemaTable);
			return schemaTable;
		}


	}
}
