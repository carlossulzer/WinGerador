using System;
using System.Collections;
using System.Globalization;

namespace WinGerador.BD
{
	public class Persistencia
	{
		private ArrayList ItensPersistencia = new ArrayList();
		
		private string _tabelaPersistencia;
		
		public string TabelaPersistencia
		{
			set
			{
				_tabelaPersistencia = value;
			}

			get
			{
				return _tabelaPersistencia;
			}
		}

		private string _condicaoPersistencia;
		public string CondicaoPersistencia
		{
			set
			{
				_condicaoPersistencia = value;
			}

			get
			{
				return _condicaoPersistencia;
			}
		}

		private int _quantidadeItens;
		public int QuantidadeItens
		{
			get
			{
				return _quantidadeItens;
			}
			set
			{
				_quantidadeItens = value;
			}
		}

		private bool _autoIncremento = true;
		public bool AutoIncremento
		{
			get
			{
				return _autoIncremento;
			}
			set
			{
				_autoIncremento = value;
			}
		}

		public Persistencia()
		{
		
		}

		public void AdicionarItemPersistencia(string nomeItem, object valorItem)
		{
			ItemPersistencia item = new ItemPersistencia(nomeItem, valorItem);
			this.ItensPersistencia.Add(item);
			this.QuantidadeItens++;
		}

		public void AdicionarItemPersistencia(string nomeItem, object valorItem, bool isNull)
		{
			ItemPersistencia item = new ItemPersistencia(nomeItem, valorItem, isNull);
			this.ItensPersistencia.Add(item);
			this.QuantidadeItens++;
		}

		private string MontarSqlInclusao()
		{
			string scriptInsert = "";
			scriptInsert += "INSERT INTO " + this.TabelaPersistencia;
			scriptInsert += " ( ";
			scriptInsert += this.ListarItens("N");
			scriptInsert += " ) ";
			scriptInsert += " VALUES ";
			scriptInsert += " ( ";
			scriptInsert += this.ListarItens("V");	
			scriptInsert += " ) ";

			if (this.AutoIncremento == true)
			{
				scriptInsert += "SELECT @@IDENTITY AS CHAVEINSERIDA";
			}
			
			return scriptInsert;
		}

		private int IncluirRegistro()
		{
			string sqlInclusao = this.MontarSqlInclusao();

			BDAdapter bd = BDFactory.GetAdapter("Oracle");
			return 0; //bd.GetIntValue(sqlInclusao);
		}
        
		private string MontarSqlAlteracao()
		{
			string scriptUpdate = "";
			scriptUpdate += "UPDATE " + this.TabelaPersistencia;
			scriptUpdate += " SET ";
			scriptUpdate += this.ListarItens("NV");
			scriptUpdate += " WHERE ";
			scriptUpdate += this.CondicaoPersistencia;

			return scriptUpdate;
		}

		private bool AlterarRegistro()
		{
			string sqlAlteracao = this.MontarSqlAlteracao();

			BDAdapter bd = BDFactory.GetAdapter("Oracle");

			
			//int registrosAlterados = bd.ExecuteCommand(sqlAlteracao);

			return true; // (registrosAlterados > 0);
		}

		private string MontarSqlExclusao()
		{
			string scriptDelete = "";
			scriptDelete += "DELETE FROM " + this.TabelaPersistencia;
			scriptDelete += " WHERE ";
			scriptDelete += this.CondicaoPersistencia;

			return scriptDelete;
		}

		public bool Excluir(string pkName, int pkValue)
		{
			this.CondicaoPersistencia = pkName + " = " + pkValue;
			string sqlExclusao = this.MontarSqlExclusao();

			BDAdapter bd = BDFactory.GetAdapter("Oracle");

			//int registrosExcluidos = bd.ExecuteCommand(sqlExclusao);

			return true; //(registrosExcluidos > 0);
		}

		private string ListarItens(string tipoAtributo)
		{
			string listaItens = "";
			int contador = 0;
			foreach(ItemPersistencia item in this.ItensPersistencia)
			{
				contador++;
				if (tipoAtributo == "N")
				{
					listaItens += item.Nome;	
				}
				else
				{
					if (tipoAtributo == "V")
					{
						if (item.ISNull == false && item.Valor != null)
						{
							string tipo = item.Valor.GetType().ToString();
							switch (tipo)
							{
								case "System.String":
								{
									listaItens += "'" + item.Valor.ToString().Replace("'","''") + "'";
									break;
								}
								case "System.Boolean":
								{
									if (Boolean.Parse(item.Valor.ToString()))
										listaItens += "1";
									else
										listaItens += "0";

									break;
								}
								case "System.DateTime":
								{
									string valor = this.FormatarData(Convert.ToDateTime(item.Valor,CultureInfo.CurrentCulture));
									listaItens += "'" + valor + "'";
									break;
								}
								case "System.Text.StringBuilder":
								{
									listaItens += "'" + item.Valor.ToString().Replace("'","''") + "'";
									break;
								}
								case "System.Decimal":
								{
									listaItens += item.Valor.ToString().Replace(",",".");
									break;
								}
								default:
								{
									listaItens += item.Valor.ToString();
									break;
								}
							}
						}
						else
						{
							listaItens += "NULL";
						}
					}
					else //tipoAtributo == "NV"
					{
						if (item.ISNull == false)
						{
							string tipoNV = item.Valor.GetType().ToString();
							switch (tipoNV)
							{
								case "System.String":
								{
									listaItens += item.Nome + " = '" + item.Valor.ToString().Replace("'","''") + "'";
									break;
								}
								case "System.Boolean":
								{
									if (Boolean.Parse(item.Valor.ToString()))
										listaItens += item.Nome + " = 1";
									else
										listaItens += item.Nome + " = 0";

									break;
								}
								case "System.DateTime":
								{
									string valorNV = this.FormatarData(Convert.ToDateTime(item.Valor,CultureInfo.CurrentCulture));
									listaItens += item.Nome + " = '" + valorNV + "'";
									break;
								}
								case "System.Text.StringBuilder":
								{
									listaItens += item.Nome + " = '" + item.Valor.ToString().Replace("'","''") + "'";
									break;
								}
								case "System.Decimal":
								{
									listaItens += item.Nome + " = " + item.Valor.ToString().Replace(",",".");
									break;
								}
								default:
								{
									listaItens += item.Nome + " = " + item.Valor.ToString();
									break;
								}
							}							
						}
						else
						{
							listaItens += item.Nome + " = NULL ";
						}

					}
				}

				if (contador < this.QuantidadeItens)
				{
					listaItens += ", ";
				}
			}

			return listaItens;
		}

		private string FormatarData(DateTime data)
		{
			return data.ToString();
		}

		public void Persistir(string pkName, int pkValue)
		{
			if (pkValue > 0)
			{
				this.CondicaoPersistencia = pkName + " = " + pkValue;
				this.AlterarRegistro();
			}
			else
			{
				this.IncluirRegistro();
			}
		}

	}
}