using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace WinGerador.BD
{
	internal class MSSqlAdapter: BDAdapter
	{
		public override DataSet GetData(string sql, string conn, string _tabela)
		{
			SqlConnection conexao = new SqlConnection(conn);
			
			DataSet ds;
			using (conexao)
			{
				SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao);
				ds = new DataSet();
				adapter.Fill(ds, _tabela);
			}

			return ds;
		}

		public override DataSet GetCampos(string Tabela, string conexao)
		{
			string sql = " Select " +
				"   c.TABLE_NAME as ctabela,"+
				"   c.COLUMN_NAME as cnome, " +
				"   c.DATA_TYPE as ctipo, " +
				"   tc.CONSTRAINT_TYPE as cchave " +
				" From "  +
				"   INFORMATION_SCHEMA.COLUMNS c inner join INFORMATION_SCHEMA.TABLES t " + 
				"   on c.TABLE_NAME = t.TABLE_NAME left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu " +
				"   on c.TABLE_NAME = ccu.TABLE_NAME and c.COLUMN_NAME = ccu.COLUMN_NAME " +
				"   left outer join INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc " +
				"   on ccu.CONSTRAINT_NAME = rc.CONSTRAINT_NAME "  +
				"   left outer join INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc " +
				"   on ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME " +
				" Where " +
				"   t.TABLE_NAME != 'dtproperties' and "+
				"   t.TABLE_NAME = '"+ Tabela +"'";

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
			string getSchemaTableText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER  BY TABLE_TYPE";
			SqlConnection conn = new SqlConnection(conexao);		
			SqlDataAdapter da = new SqlDataAdapter(getSchemaTableText, conn);
			DataSet schemaTable = new DataSet();
			da.Fill(schemaTable);
			return schemaTable;
		}



	}
}
