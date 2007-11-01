using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class KisiIletisim : BaseTypeLibrary
    {
		
		private Guid id;
		private int iletisimTuruTipNo;
		private string iletisim;
		private Guid kisiKey;
		private Nullable<bool> aktifMi;
		private Nullable<int> oncelik;
		
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
		
		protected override void ValidationListesiniOlusturCodeGeneration()
		{
		}



    }
}
