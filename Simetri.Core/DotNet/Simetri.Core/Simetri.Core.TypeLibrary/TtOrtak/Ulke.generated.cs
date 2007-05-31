
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class Ulke : BaseTypeLibrary
    {
		
		private short no;
		private string adi;
		private string kisaAdi;
		
		public short No
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
		
		public string KisaAdi
		{
			get
			{
				return kisaAdi;
			}
			set
			{
				kisaAdi = value;
			}
		}




        protected override void ValidationListesiniOlusturCodeGeneration()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
