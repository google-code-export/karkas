
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class KisiEkBilgiler
    {
		
		private Guid kisiKey;
		private int vergiDairesiTipNo;
		private string vergiNo;
		private int sosyalGuvenlikTipNo;
		private string sosyalGuvenlikNo;
		private int pasaportTipNo;
		private string pasaportNo;
		
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
		
		public int VergiDairesiTipNo
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
		
		public int SosyalGuvenlikTipNo
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
		
		public int PasaportTipNo
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
		


    }
}
