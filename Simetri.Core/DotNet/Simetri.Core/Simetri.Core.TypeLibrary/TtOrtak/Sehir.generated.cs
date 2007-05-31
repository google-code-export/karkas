
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class Sehir : BaseTypeLibrary
    {
		
		private int id;
		private short ulkeNo;
		private string adi;
		private bool turkiyeIcindeMi;
		
		public int Id
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
		
		public short UlkeNo
		{
			get
			{
				return ulkeNo;
			}
			set
			{
				ulkeNo = value;
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
		
		public bool TurkiyeIcindeMi
		{
			get
			{
				return turkiyeIcindeMi;
			}
			set
			{
				turkiyeIcindeMi = value;
			}
		}




        protected override void ValidationListesiniOlusturCodeGeneration()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
