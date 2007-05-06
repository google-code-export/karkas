
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class Kisi
    {
		
		private Guid id;
		private decimal tcKimlikNo;
		private string adi;
		private string soyadi;
		private string ikinciAdi;
		
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
		
		public decimal TcKimlikNo
		{
			get
			{
				return tcKimlikNo;
			}
			set
			{
				tcKimlikNo = value;
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
		


    }
}
