using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class KisiNufusBilgileri
    {
		
		private Guid id;
		private Guid kisiKey;
		private decimal tCKimlikNo;
		private string ad;
		private string ikinciAdi;
		private string soyad;
		private short uyrukTipNo;
		private string cilt;
		private string sayfa;
		private string kutuk;
		private int dogumYeriNo;
		private int nufusaKayitliOlduguSehirNo;
		private int nufusaKayitliOlduguIlceNo;
		private int nufusaKayitliOlduguMahalleKoyKey;
		private string anaAdi;
		private string babaAdi;
		private DateTime dogumTarihi;
		private byte medeniDurumTuruTipNo;
		private byte dinTuruTipNo;
		private byte cinsiyetTuruTipNo;
		private byte kanGrubuTuruTipNo;
		
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
		
		public decimal TCKimlikNo
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
		
		public short UyrukTipNo
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
		
		public int DogumYeriNo
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
		
		public int NufusaKayitliOlduguSehirNo
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
		
		public int NufusaKayitliOlduguIlceNo
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
		
		public int NufusaKayitliOlduguMahalleKoyKey
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
		
		public byte MedeniDurumTuruTipNo
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
		
		public byte DinTuruTipNo
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
		
		public byte CinsiyetTuruTipNo
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
		
		public byte KanGrubuTuruTipNo
		{
			get
			{
				return kanGrubuTuruTipNo;
			}
			set
			{
				kanGrubuTuruTipNo = value;
			}
		}
		


    }
}
