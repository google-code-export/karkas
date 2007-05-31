
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class YabanciDilTip : BaseTypeLibrary
    {
		
		private short no;
		private string adi;
		
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




        protected override void ValidationListesiniOlusturCodeGeneration()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
