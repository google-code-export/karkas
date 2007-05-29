using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class KisiEkBilgiler : BaseTypeLibrary
    {
		
		private Guid kisiKey;
		private Nullable<int> vergiDairesiTipNo;
		private string vergiNo;
		private Nullable<int> sosyalGuvenlikTipNo;
		private string sosyalGuvenlikNo;
		private Nullable<int> pasaportTipNo;
		private string pasaportNo;
		private Nullable<bool> sigaraKullanimi;
		private Nullable<byte> ehliyetKey;
		private Nullable<byte> kanGrubuTipNo;
		
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
		
		public Nullable<int> VergiDairesiTipNo
		{
			get
			{
				return vergiDairesiTipNo;
			}
			set
			{
				vergiDairesiTipNo = value;
			}
		}
		
		public string VergiNo
		{
			get
			{
				return vergiNo;
			}
			set
			{
				vergiNo = value;
			}
		}
		
		public Nullable<int> SosyalGuvenlikTipNo
		{
			get
			{
				return sosyalGuvenlikTipNo;
			}
			set
			{
				sosyalGuvenlikTipNo = value;
			}
		}
		
		public string SosyalGuvenlikNo
		{
			get
			{
				return sosyalGuvenlikNo;
			}
			set
			{
				sosyalGuvenlikNo = value;
			}
		}
		
		public Nullable<int> PasaportTipNo
		{
			get
			{
				return pasaportTipNo;
			}
			set
			{
				pasaportTipNo = value;
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
		
		public Nullable<bool> SigaraKullanimi
		{
			get
			{
				return sigaraKullanimi;
			}
			set
			{
				sigaraKullanimi = value;
			}
		}
		
		public Nullable<byte> EhliyetKey
		{
			get
			{
				return ehliyetKey;
			}
			set
			{
				ehliyetKey = value;
			}
		}
		
		public Nullable<byte> KanGrubuTipNo
		{
			get
			{
				return kanGrubuTipNo;
			}
			set
			{
				kanGrubuTipNo = value;
			}
		}
		
		protected override void ValidationListesiniOlusturCodeGeneration()
		{
		}



    }
}
