﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
namespace Karkas.Ornek.Dal.Ornekler
{
	public partial class StoredProcedures
	{
		public static DataTable MusteriSorgulaHepsiniGetir
		(
			
			)
			{
				ParameterBuilder builder = new ParameterBuilder();
				
				AdoTemplate template = new AdoTemplate();
				template.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString("KARKAS_ORNEK"));
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "ORNEKLER.MUSTERI_SORGULA_HEPSINI_GETIR";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddRange(builder.GetParameterArray());
				DataTable _tmpDataTable = template.DataTableOlustur(cmd);
				return _tmpDataTable;
			}
		}
	}
