using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class KisiNufusBilgileri : BaseTypeLibrary
    {
		
		private Guid id;
		private Guid kisiKey;
		private Nullable<decimal> tCKimlikNo;
		private string ad;
		private string ikinciAdi;
		private string soyad;
		private Nullable<short> uyrukTipNo;
		private string cilt;
		private string sayfa;
		private string kutuk;
		private Nullable<int> dogumYeriNo;
		private Nullable<int> nufusaKayitliOlduguSehirNo;
		private Nullable<int> nufusaKayitliOlduguIlceNo;
		private Nullable<int> nufusaKayitliOlduguMahalleKoyKey;
		private string anaAdi;
		private string babaAdi;
		private DateTime dogumTarihi;
		private Nullable<byte> medeniDurumTuruTipNo;
		private Nullable<byte> dinTuruTipNo;
		private Nullable<byte> cinsiyetTuruTipNo;
		
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
		
		public Nullable<decimal> TCKimlikNo
		{
			get
			{
				return tCKimlikNo;
			}
			set
			{
				tCKimlikNo = value;
			}
		}
		
		public string Ad
		{
			get
			{
				return ad;
			}
			set
			{
				ad = value;
			}
		}
		
		public string IkinciAdi
		{
			get
			{
				return ikinciAdi;
			}
			set
			{
				ikinciAdi = value;
			}
		}
		
		public string Soyad
		{
			get
			{
				return soyad;
			}
			set
			{
				soyad = value;
			}
		}
		
		public Nullable<short> UyrukTipNo
		{
			get
			{
				return uyrukTipNo;
			}
			set
			{
				uyrukTipNo = value;
			}
		}
		
		public string Cilt
		{
			get
			{
				return cilt;
			}
			set
			{
				cilt = value;
			}
		}
		
		public string Sayfa
		{
			get
			{
				return sayfa;
			}
			set
			{
				sayfa = value;
			}
		}
		
		public string Kutuk
		{
			get
			{
				return kutuk;
			}
			set
			{
				kutuk = value;
			}
		}
		
		public Nullable<int> DogumYeriNo
		{
			get
			{
				return dogumYeriNo;
			}
			set
			{
				dogumYeriNo = value;
			}
		}
		
		public Nullable<int> NufusaKayitliOlduguSehirNo
		{
			get
			{
				return nufusaKayitliOlduguSehirNo;
			}
			set
			{
				nufusaKayitliOlduguSehirNo = value;
			}
		}
		
		public Nullable<int> NufusaKayitliOlduguIlceNo
		{
			get
			{
				return nufusaKayitliOlduguIlceNo;
			}
			set
			{
				nufusaKayitliOlduguIlceNo = value;
			}
		}
		
		public Nullable<int> NufusaKayitliOlduguMahalleKoyKey
		{
			get
			{
				return nufusaKayitliOlduguMahalleKoyKey;
			}
			set
			{
				nufusaKayitliOlduguMahalleKoyKey = value;
			}
		}
		
		public string AnaAdi
		{
			get
			{
				return anaAdi;
			}
			set
			{
				anaAdi = value;
			}
		}
		
		public string BabaAdi
		{
			get
			{
				return babaAdi;
			}
			set
			{
				babaAdi = value;
			}
		}
		
		public DateTime DogumTarihi
		{
			get
			{
				return dogumTarihi;
			}
			set
			{
				dogumTarihi = value;
			}
		}
		
		public Nullable<byte> MedeniDurumTuruTipNo
		{
			get
			{
				return medeniDurumTuruTipNo;
			}
			set
			{
				medeniDurumTuruTipNo = value;
			}
		}
		
		public Nullable<byte> DinTuruTipNo
		{
			get
			{
				return dinTuruTipNo;
			}
			set
			{
				dinTuruTipNo = value;
			}
		}
		
		public Nullable<byte> CinsiyetTuruTipNo
		{
			get
			{
				return cinsiyetTuruTipNo;
			}
			set
			{
				cinsiyetTuruTipNo = value;
			}
		}
		
		protected override void ValidationListesiniOlusturCodeGeneration()
		{
		}



    }
}
