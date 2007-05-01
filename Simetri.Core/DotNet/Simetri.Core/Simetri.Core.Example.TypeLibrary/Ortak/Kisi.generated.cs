
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Example.TypeLibrary.Ortak
{
    public partial class Kisi
    {
		
		private Guid kisiKey;
		private string tCKimlikNo;
		private string adi;
		private string ikinciAdi;
		private string soyadi;
		private DateTime kayitTarihi;
		private byte cinsiyetTipNo;
		private short uyrukNo;
		private short durumNo;
		
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
		
		public string TCKimlikNo
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
		
		public string Adi
		{
			get
			{
				return adi;
			}
			set
			{
				adi = value;
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
		
		public string Soyadi
		{
			get
			{
				return soyadi;
			}
			set
			{
				soyadi = value;
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
		
		public byte CinsiyetTipNo
		{
			get
			{
				return cinsiyetTipNo;
			}
			set
			{
				cinsiyetTipNo = value;
			}
		}
		
		public short UyrukNo
		{
			get
			{
				return uyrukNo;
			}
			set
			{
				uyrukNo = value;
			}
		}
		
		public short DurumNo
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
		


    }
}
