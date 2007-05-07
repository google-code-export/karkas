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
		private byte adresTuruTipNo;
		private int oncelik;
		private bool aktifMi;
		
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
		
		public byte AdresTuruTipNo
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
		


    }
}
