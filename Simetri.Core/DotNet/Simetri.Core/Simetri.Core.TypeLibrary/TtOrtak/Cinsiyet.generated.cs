
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class Cinsiyet
    {
		
		private byte no;
		private string kisaAd;
		private string uzunAd;
		
		public byte No
		{
			get
			{
				return no;
			}
			set
			{
				no = value;
			}
		}
		
		public string KisaAd
		{
			get
			{
				return kisaAd;
			}
			set
			{
				kisaAd = value;
			}
		}
		
		public string UzunAd
		{
			get
			{
				return uzunAd;
			}
			set
			{
				uzunAd = value;
			}
		}
		


    }
}
