using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class KisiAdres
    {
		
		private Guid id;
		private Guid kisiKey;
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
		


    }
}
