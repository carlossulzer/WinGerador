namespace WinGerador
{
	internal class CamposDIC
	{
		public const string TABLE_CAMPO = "TABELAS";
		public const string COL_TABELA = "TABELA";
		public const string COL_CAMPO = "CAMPO";
		public const string COL_TIPO = "TIPO";
		public const string COL_CHAVE = "CHAVE";

		public static string GetAllColumnsForSelect()
		{
			string allColumns = "";
			allColumns += CamposDIC.COL_TABELA + ",";
			allColumns += CamposDIC.COL_CAMPO + ",";
			allColumns += CamposDIC.COL_TIPO + ",";
			allColumns += CamposDIC.COL_CHAVE ;

			return allColumns;
		}
	}
}
