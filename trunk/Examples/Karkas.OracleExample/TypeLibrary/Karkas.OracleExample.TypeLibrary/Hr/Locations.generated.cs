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
	[DebuggerDisplay("LocationId = {LocationId}CountryId = {CountryId}")]
	public partial class 	Locations: BaseTypeLibrary
	{
		private decimal locationId;
		private string streetAddress;
		private string postalCode;
		private string city;
		private string stateProvince;
		private string countryId;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public decimal LocationId
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
		public string StreetAddress
		{
			[DebuggerStepThrough]
			get
			{
				return streetAddress;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (streetAddress!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				streetAddress = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string PostalCode
		{
			[DebuggerStepThrough]
			get
			{
				return postalCode;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (postalCode!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				postalCode = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string City
		{
			[DebuggerStepThrough]
			get
			{
				return city;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (city!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				city = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string StateProvince
		{
			[DebuggerStepThrough]
			get
			{
				return stateProvince;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (stateProvince!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				stateProvince = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string CountryId
		{
			[DebuggerStepThrough]
			get
			{
				return countryId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (countryId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				countryId = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string LocationIdAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return locationId.ToString(); 
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
		public const string LocationId = "LOCATION_ID";
		public const string StreetAddress = "STREET_ADDRESS";
		public const string PostalCode = "POSTAL_CODE";
		public const string City = "CITY";
		public const string StateProvince = "STATE_PROVINCE";
		public const string CountryId = "COUNTRY_ID";
	}
		public Locations ShallowCopy()
		{
			Locations obj = new Locations();
			obj.locationId = locationId;
			obj.streetAddress = streetAddress;
			obj.postalCode = postalCode;
			obj.city = city;
			obj.stateProvince = stateProvince;
			obj.countryId = countryId;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "City"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.OracleExample.TypeLibrary.Hr";
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
		public static string StreetAddress
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".StreetAddress"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "StreetAddress";
				}
			}
		}
		public static string PostalCode
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".PostalCode"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "PostalCode";
				}
			}
		}
		public static string City
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".City"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "City";
				}
			}
		}
		public static string StateProvince
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".StateProvince"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "StateProvince";
				}
			}
		}
		public static string CountryId
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".CountryId"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "CountryId";
				}
			}
		}
	}
}
}
