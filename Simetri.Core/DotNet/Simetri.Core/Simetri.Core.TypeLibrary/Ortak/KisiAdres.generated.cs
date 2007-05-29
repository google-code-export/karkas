using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class KisiAdres : BaseTypeLibrary
    {
		
		private Guid id;
		private Guid kisiKey;
		private Nullable<int> sehirNo;
		private Nullable<int> ilceNo;
		private string adres;
		private Nullable<byte> adresTuruTipNo;
		private Nullable<int> oncelik;
		private Nullable<bool> aktifMi;
		
		public Guid Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}
		
		public Guid KisiKey
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
		
		public Nullable<int> SehirNo
		{
			get
			{
				return sehirNo;
			}
			set
			{
				sehirNo = value;
			}
		}
		
		public Nullable<int> IlceNo
		{
			get
			{
				return ilceNo;
			}
			set
			{
				ilceNo = value;
			}
		}
		
		public string Adres
		{
			get
			{
				return adres;
			}
			set
			{
				adres = value;
			}
		}
		
		public Nullable<byte> AdresTuruTipNo
		{
			get
			{
				return adresTuruTipNo;
			}
			set
			{
				adresTuruTipNo = value;
			}
		}
		
		public Nullable<int> Oncelik
		{
			get
			{
				return oncelik;
			}
			set
			{
				oncelik = value;
			}
		}
		
		public Nullable<bool> AktifMi
		{
			get
			{
				return aktifMi;
			}
			set
			{
				aktifMi = value;
			}
		}
		
		protected override void ValidationListesiniOlusturCodeGeneration()
		{
		}



    }
}
