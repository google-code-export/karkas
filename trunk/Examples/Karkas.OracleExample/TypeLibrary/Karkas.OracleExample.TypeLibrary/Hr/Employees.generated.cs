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
	[DebuggerDisplay("EmployeeId = {EmployeeId}JobId = {JobId}ManagerId = {ManagerId}DepartmentId = {DepartmentId}")]
	public partial class 	Employees: BaseTypeLibrary
	{
		private string fullName;
		private decimal employeeId;
		private string firstName;
		private string lastName;
		private string email;
		private string phoneNumber;
		private DateTime hireDate;
		private string jobId;
		private Nullable<decimal> salary;
		private Nullable<decimal> commissionPct;
		private Nullable<decimal> managerId;
		private Nullable<decimal> departmentId;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string FullName
		{
			[DebuggerStepThrough]
			get
			{
				return fullName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (fullName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				fullName = value;
			}
		}

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
		public string FirstName
		{
			[DebuggerStepThrough]
			get
			{
				return firstName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (firstName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				firstName = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string LastName
		{
			[DebuggerStepThrough]
			get
			{
				return lastName;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (lastName!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				lastName = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Email
		{
			[DebuggerStepThrough]
			get
			{
				return email;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (email!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				email = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string PhoneNumber
		{
			[DebuggerStepThrough]
			get
			{
				return phoneNumber;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (phoneNumber!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				phoneNumber = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime HireDate
		{
			[DebuggerStepThrough]
			get
			{
				return hireDate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (hireDate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				hireDate = value;
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
		public Nullable<decimal> Salary
		{
			[DebuggerStepThrough]
			get
			{
				return salary;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (salary!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				salary = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> CommissionPct
		{
			[DebuggerStepThrough]
			get
			{
				return commissionPct;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (commissionPct!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				commissionPct = value;
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
		public string HireDateAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return hireDate.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					DateTime _a = Convert.ToDateTime(value);
				HireDate = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"HireDate",string.Format(CEVIRI_YAZISI,"HireDate","DateTime")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string SalaryAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return salary != null ? salary.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				Salary = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"Salary",string.Format(CEVIRI_YAZISI,"Salary","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string CommissionPctAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return commissionPct != null ? commissionPct.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				CommissionPct = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"CommissionPct",string.Format(CEVIRI_YAZISI,"CommissionPct","decimal")));
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
		public const string FullName = "FULL_NAME";
		public const string EmployeeId = "EMPLOYEE_ID";
		public const string FirstName = "FIRST_NAME";
		public const string LastName = "LAST_NAME";
		public const string Email = "EMAIL";
		public const string PhoneNumber = "PHONE_NUMBER";
		public const string HireDate = "HIRE_DATE";
		public const string JobId = "JOB_ID";
		public const string Salary = "SALARY";
		public const string CommissionPct = "COMMISSION_PCT";
		public const string ManagerId = "MANAGER_ID";
		public const string DepartmentId = "DEPARTMENT_ID";
	}
		public Employees ShallowCopy()
		{
			Employees obj = new Employees();
			obj.fullName = fullName;
			obj.employeeId = employeeId;
			obj.firstName = firstName;
			obj.lastName = lastName;
			obj.email = email;
			obj.phoneNumber = phoneNumber;
			obj.hireDate = hireDate;
			obj.jobId = jobId;
			obj.salary = salary;
			obj.commissionPct = commissionPct;
			obj.managerId = managerId;
			obj.departmentId = departmentId;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "LastName"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Email"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "HireDate"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "JobId"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.OracleExample.TypeLibrary.Hr";
		public static string FullName
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".FullName"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "FullName";
				}
			}
		}
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
		public static string FirstName
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".FirstName"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "FirstName";
				}
			}
		}
		public static string LastName
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".LastName"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "LastName";
				}
			}
		}
		public static string Email
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Email"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "Email";
				}
			}
		}
		public static string PhoneNumber
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".PhoneNumber"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "PhoneNumber";
				}
			}
		}
		public static string HireDate
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".HireDate"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "HireDate";
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
		public static string Salary
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Salary"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "Salary";
				}
			}
		}
		public static string CommissionPct
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".CommissionPct"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "CommissionPct";
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
