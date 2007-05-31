using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class Adres : BaseTypeLibrary
    {
		
		private Guid adresKey;
		private Guid firmaEkIsyeriKey;
		private Nullable<Guid> firmaKey;
		private Nullable<Guid> kisiKey;
		private Nullable<byte> adresTuruTipNo;
		private string serbestAdres;
		private Nullable<short> ulkeTipNo;
		private Nullable<short> ilTipNo;
		private Nullable<int> ilceTipNo;
		private string mahalle;
		private string bulvar;
		private string cadde;
		private string sokak;
		private string belediyeAdi;
		private string bucak;
		private string koy;
		private string mezra;
		private string site;
		private string blok;
		private string mevkiAdi;
		private string disKapÄ±No;
		private string icKapiNo;
		private string postaKodu;
		private Nullable<DateTime> baslangicTarihi;
		private Nullable<DateTime> bitisTarihi;
		private Nullable<short> durumNo;
		
		public Guid AdresKey
		{
			get
			{
				return adresKey;
			}
			set
			{
				adresKey = value;
			}
		}
		
		public Guid FirmaEkIsyeriKey
		{
			get
			{
				return firmaEkIsyeriKey;
			}
			set
			{
				firmaEkIsyeriKey = value;
			}
		}
		
		public Nullable<Guid> FirmaKey
		{
			get
			{
				return firmaKey;
			}
			set
			{
				firmaKey = value;
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
		
		public string SerbestAdres
		{
			get
			{
				return serbestAdres;
			}
			set
			{
				serbestAdres = value;
			}
		}
		
		public Nullable<short> UlkeTipNo
		{
			get
			{
				return ulkeTipNo;
			}
			set
			{
				ulkeTipNo = value;
			}
		}
		
		public Nullable<short> IlTipNo
		{
			get
			{
				return ilTipNo;
			}
			set
			{
				ilTipNo = value;
			}
		}
		
		public Nullable<int> IlceTipNo
		{
			get
			{
				return ilceTipNo;
			}
			set
			{
				ilceTipNo = value;
			}
		}
		
		public string Mahalle
		{
			get
			{
				return mahalle;
			}
			set
			{
				mahalle = value;
			}
		}
		
		public string Bulvar
		{
			get
			{
				return bulvar;
			}
			set
			{
				bulvar = value;
			}
		}
		
		public string Cadde
		{
			get
			{
				return cadde;
			}
			set
			{
				cadde = value;
			}
		}
		
		public string Sokak
		{
			get
			{
				return sokak;
			}
			set
			{
				sokak = value;
			}
		}
		
		public string BelediyeAdi
		{
			get
			{
				return belediyeAdi;
			}
			set
			{
				belediyeAdi = value;
			}
		}
		
		public string Bucak
		{
			get
			{
				return bucak;
			}
			set
			{
				bucak = value;
			}
		}
		
		public string Koy
		{
			get
			{
				return koy;
			}
			set
			{
				koy = value;
			}
		}
		
		public string Mezra
		{
			get
			{
				return mezra;
			}
			set
			{
				mezra = value;
			}
		}
		
		public string Site
		{
			get
			{
				return site;
			}
			set
			{
				site = value;
			}
		}
		
		public string Blok
		{
			get
			{
				return blok;
			}
			set
			{
				blok = value;
			}
		}
		
		public string MevkiAdi
		{
			get
			{
				return mevkiAdi;
			}
			set
			{
				mevkiAdi = value;
			}
		}
		
		public string DisKapÄ±No
		{
			get
			{
				return disKapÄ±No;
			}
			set
			{
				disKapÄ±No = value;
			}
		}
		
		public string IcKapiNo
		{
			get
			{
				return icKapiNo;
			}
			set
			{
				icKapiNo = value;
			}
		}
		
		public string PostaKodu
		{
			get
			{
				return postaKodu;
			}
			set
			{
				postaKodu = value;
			}
		}
		
		public Nullable<DateTime> BaslangicTarihi
		{
			get
			{
				return baslangicTarihi;
			}
			set
			{
				baslangicTarihi = value;
			}
		}
		
		public Nullable<DateTime> BitisTarihi
		{
			get
			{
				return bitisTarihi;
			}
			set
			{
				bitisTarihi = value;
			}
		}
		
		public Nullable<short> DurumNo
		{
			get
			{
				return durumNo;
			}
			set
			{
				durumNo = value;
			}
		}
		
		protected override void ValidationListesiniOlusturCodeGeneration()
		{
		}



    }
}
