
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class IletisimTuru : BaseTypeLibrary
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




        protected override void ValidationListesiniOlusturCodeGeneration()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
