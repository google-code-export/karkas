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
	[DebuggerDisplay("EmployeeId = {EmployeeId}StartDate = {StartDate}JobId = {JobId}DepartmentId = {DepartmentId}")]
	public partial class 	JobHistory: BaseTypeLibrary
	{
		private decimal employeeId;
		private DateTime startDate;
		private DateTime endDate;
		private string jobId;
		private Nullable<decimal> departmentId;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public decimal EmployeeId
		{
			[DebuggerStepThrough]
			get
			{
				return employeeId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (employeeId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				employeeId = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime StartDate
		{
			[DebuggerStepThrough]
			get
			{
				return startDate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (startDate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				startDate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime EndDate
		{
			[DebuggerStepThrough]
			get
			{
				return endDate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (endDate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				endDate = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string JobId
		{
			[DebuggerStepThrough]
			get
			{
				return jobId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (jobId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				jobId = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> DepartmentId
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
		[XmlIgnore, SoapIgnore]
		public string EmployeeIdAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return employeeId.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				EmployeeId = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"EmployeeId",string.Format(CEVIRI_YAZISI,"EmployeeId","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string StartDateAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return startDate.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					DateTime _a = Convert.ToDateTime(value);
				StartDate = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"StartDate",string.Format(CEVIRI_YAZISI,"StartDate","DateTime")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string EndDateAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return endDate.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					DateTime _a = Convert.ToDateTime(value);
				EndDate = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"EndDate",string.Format(CEVIRI_YAZISI,"EndDate","DateTime")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string DepartmentIdAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return departmentId != null ? departmentId.ToString() : ""; 
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

	public class PropertyIsimleri
	{
		public const string EmployeeId = "EMPLOYEE_ID";
		public const string StartDate = "START_DATE";
		public const string EndDate = "END_DATE";
		public const string JobId = "JOB_ID";
		public const string DepartmentId = "DEPARTMENT_ID";
	}
		public JobHistory ShallowCopy()
		{
			JobHistory obj = new JobHistory();
			obj.employeeId = employeeId;
			obj.startDate = startDate;
			obj.endDate = endDate;
			obj.jobId = jobId;
			obj.departmentId = departmentId;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "EndDate"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "JobId"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.OracleExample.TypeLibrary.Hr";
		public static string EmployeeId
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".EmployeeId"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "EmployeeId";
				}
			}
		}
		public static string StartDate
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".StartDate"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "StartDate";
				}
			}
		}
		public static string EndDate
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".EndDate"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "EndDate";
				}
			}
		}
		public static string JobId
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".JobId"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "JobId";
				}
			}
		}
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
	}
}
}
