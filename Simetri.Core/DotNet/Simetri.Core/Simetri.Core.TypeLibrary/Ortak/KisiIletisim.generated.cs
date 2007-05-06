
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class KisiIletisim
    {
		
		private Guid id;
		private int iletisimTuruTipNo;
		private string iletisim;
		private Guid kisiKey;
		private bool aktifMi;
		private int oncelik;
		
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
		
		public int IletisimTuruTipNo
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
		
		public string Iletisim
		{
			get
			{
				return iletisim;
			}
			set
			{
				iletisim = value;
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
		
		public bool AktifMi
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
		
		public int Oncelik
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
		


    }
}
