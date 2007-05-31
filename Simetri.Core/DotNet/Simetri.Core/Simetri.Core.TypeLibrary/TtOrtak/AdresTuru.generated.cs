
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class AdresTuru : BaseTypeLibrary
    {
		
		private byte no;
		private string adi;
		private bool isAdresiTuruMu;
		
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
		
		public bool IsAdresiTuruMu
		{
			get
			{
				return isAdresiTuruMu;
			}
			set
			{
				isAdresiTuruMu = value;
			}
		}




        protected override void ValidationListesiniOlusturCodeGeneration()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
