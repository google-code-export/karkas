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
	[DebuggerDisplay("DepartmentId = {DepartmentId}ManagerId = {ManagerId}LocationId = {LocationId}")]
	public partial class 	Departments: BaseTypeLibrary
	{
		private decimal departmentId;
		private string departmentName;
		private Nullable<decimal> managerId;
		private Nullable<decimal> locationId;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public decimal DepartmentId
		{
			[DebuggerStepThrough]
			get
			{
				return departmentId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (departmentId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				departmentId = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string DepartmentName
		{
			[DebuggerStepThrough]
			get
			{
				return departmentName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (departmentName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				departmentName = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> ManagerId
		{
			[DebuggerStepThrough]
			get
			{
				return managerId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (managerId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				managerId = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> LocationId
		{
			[DebuggerStepThrough]
			get
			{
				return locationId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (locationId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				locationId = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string DepartmentIdAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return departmentId.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				DepartmentId = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"DepartmentId",string.Format(CEVIRI_YAZISI,"DepartmentId","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string ManagerIdAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return managerId != null ? managerId.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				ManagerId = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"ManagerId",string.Format(CEVIRI_YAZISI,"ManagerId","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string LocationIdAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return locationId != null ? locationId.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				LocationId = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"LocationId",string.Format(CEVIRI_YAZISI,"LocationId","decimal")));
				}
			}
		}

	public class PropertyIsimleri
	{
		public const string DepartmentId = "DEPARTMENT_ID";
		public const string DepartmentName = "DEPARTMENT_NAME";
		public const string ManagerId = "MANAGER_ID";
		public const string LocationId = "LOCATION_ID";
	}
		public Departments ShallowCopy()
		{
			Departments obj = new Departments();
			obj.departmentId = departmentId;
			obj.departmentName = departmentName;
			obj.managerId = managerId;
			obj.locationId = locationId;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "DepartmentName"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.OracleExample.TypeLibrary.Hr";
		public static string DepartmentId
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DepartmentId"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "DepartmentId";
				}
			}
		}
		public static string DepartmentName
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DepartmentName"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "DepartmentName";
				}
			}
		}
		public static string ManagerId
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ManagerId"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ManagerId";
				}
			}
		}
		public static string LocationId
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".LocationId"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "LocationId";
				}
			}
		}
	}
}
}
