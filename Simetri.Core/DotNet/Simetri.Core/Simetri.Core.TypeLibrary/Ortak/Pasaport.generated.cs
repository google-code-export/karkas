using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class Pasaport : BaseTypeLibrary
    {
		
		private Guid pasaportKey;
		private Nullable<Guid> kisiKey;
		private string pasaportNo;
		private DateTime temditTarihi;
		private Nullable<Guid> ulkeKey;
		private bool durum;
		private DateTime kayitTarihi;
		
		public Guid PasaportKey
		{
			get
			{
				return pasaportKey;
			}
			set
			{
				pasaportKey = value;
			}
		}
		
		public Nullable<Guid> KisiKey
		{
			get
			{
				return kisiKey;
			}
			set
			{
				kisiKey = value;
			}
		}
		
		public string PasaportNo
		{
			get
			{
				return pasaportNo;
			}
			set
			{
				pasaportNo = value;
			}
		}
		
		public DateTime TemditTarihi
		{
			get
			{
				return temditTarihi;
			}
			set
			{
				temditTarihi = value;
			}
		}
		
		public Nullable<Guid> UlkeKey
		{
			get
			{
				return ulkeKey;
			}
			set
			{
				ulkeKey = value;
			}
		}
		
		public bool Durum
		{
			get
			{
				return durum;
			}
			set
			{
				durum = value;
			}
		}
		
		public DateTime KayitTarihi
		{
			get
			{
				return kayitTarihi;
			}
			set
			{
				kayitTarihi = value;
			}
		}
		
		protected override void ValidationListesiniOlusturCodeGeneration()
		{
		}



    }
}
