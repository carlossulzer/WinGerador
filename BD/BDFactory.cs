namespace WinGerador.BD
{
	internal class BDFactory
	{
		private static BDAdapter _currentAdapter;

		public static BDAdapter GetAdapter(string _banco)
		{
			if (_currentAdapter == null)
			{
				if (_banco == "SQL Server")
					_currentAdapter = new MSSqlAdapter();
				else if (_banco == "Oracle")
					_currentAdapter = new OracleAdapter();
			}
			return _currentAdapter;
		}
	}
}
