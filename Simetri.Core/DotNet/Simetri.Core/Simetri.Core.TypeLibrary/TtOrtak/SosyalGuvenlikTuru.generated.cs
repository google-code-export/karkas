
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class SosyalGuvenlikTuru
    {
		
		private int no;
		private string kisaAd;
		private string uzunAd;
		
		public int No
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
