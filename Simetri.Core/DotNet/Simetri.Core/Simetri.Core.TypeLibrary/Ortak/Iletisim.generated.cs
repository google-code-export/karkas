using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class Iletisim : BaseTypeLibrary
    {
		
		private Guid iletisimKey;
		private Nullable<int> iletisimTuruTipNo;
		private string iletisimNumarasi;
		private Nullable<byte> telefonHatSayisi;
		private Nullable<Guid> firmaKey;
		private Nullable<Guid> kisiKey;
		private Nullable<byte> gecerlilikSirasi;
		private Nullable<DateTime> baslangicTarih;
		private Nullable<DateTime> bitisTarih;
		private Nullable<short> durumNo;
		
		public Guid IletisimKey
		{
			get
			{
				return iletisimKey;
			}
			set
			{
				iletisimKey = value;
			}
		}
		
		public Nullable<int> IletisimTuruTipNo
		{
			get
			{
				return iletisimTuruTipNo;
			}
			set
			{
				iletisimTuruTipNo = value;
			}
		}
		
		public string IletisimNumarasi
		{
			get
			{
				return iletisimNumarasi;
			}
			set
			{
				iletisimNumarasi = value;
			}
		}
		
		public Nullable<byte> TelefonHatSayisi
		{
			get
			{
				return telefonHatSayisi;
			}
			set
			{
				telefonHatSayisi = value;
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
		
		public Nullable<byte> GecerlilikSirasi
		{
			get
			{
				return gecerlilikSirasi;
			}
			set
			{
				gecerlilikSirasi = value;
			}
		}
		
		public Nullable<DateTime> BaslangicTarih
		{
			get
			{
				return baslangicTarih;
			}
			set
			{
				baslangicTarih = value;
			}
		}
		
		public Nullable<DateTime> BitisTarih
		{
			get
			{
				return bitisTarih;
			}
			set
			{
				bitisTarih = value;
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
