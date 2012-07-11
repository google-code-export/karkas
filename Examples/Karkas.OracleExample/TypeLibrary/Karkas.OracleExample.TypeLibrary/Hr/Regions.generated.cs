using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.OracleExample.TypeLibrary.Hr

{
	[Serializable]
	[DebuggerDisplay("RegionId = {RegionId}")]
	public partial class 	Regions: BaseTypeLibrary
	{
		private decimal regionId;
		private string regionName;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public decimal RegionId
		{
			[DebuggerStepThrough]
			get
			{
				return regionId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (regionId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				regionId = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string RegionName
		{
			[DebuggerStepThrough]
			get
			{
				return regionName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (regionName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				regionName = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string RegionIdAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return regionId.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				RegionId = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"RegionId",string.Format(CEVIRI_YAZISI,"RegionId","decimal")));
				}
			}
		}

	public class PropertyIsimleri
	{
		public const string RegionId = "REGION_ID";
		public const string RegionName = "REGION_NAME";
	}
		public Regions ShallowCopy()
		{
			Regions obj = new Regions();
			obj.regionId = regionId;
			obj.regionName = regionName;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.OracleExample.TypeLibrary.Hr";
		public static string RegionId
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".RegionId"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "RegionId";
				}
			}
		}
		public static string RegionName
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".RegionName"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "RegionName";
				}
			}
		}
	}
}
}
