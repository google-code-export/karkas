using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class Kisi
    {
		
		private Guid id;
		private Nullable<decimal> tcKimlikNo;
		private string adi;
		private string soyadi;
		private string ikinciAdi;
		private string windowsUserName;
		
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
		
		public Nullable<decimal> TcKimlikNo
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
		
		public string WindowsUserName
		{
			get
			{
				return windowsUserName;
			}
			set
			{
				windowsUserName = value;
			}
		}
		


    }
}
