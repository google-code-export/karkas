
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class VergiDairesi
    {
		
		private int tipNo;
		private string adi;
		
		public int TipNo
		{
			get
			{
				return tipNo;
			}
			set
			{
				tipNo = value;
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
		


    }
}
