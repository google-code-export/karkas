
using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.TtOrtak
{
    public partial class Ilce : BaseTypeLibrary
    {
		
		private int id;
		private int sehirNo;
		private string adi;
		private bool aktifMi;
		
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
		
		public int SehirNo
		{
			get
			{
				return sehirNo;
			}
			set
			{
				sehirNo = value;
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
		
		public bool AktifMi
		{
			get
			{
				return aktifMi;
			}
			set
			{
				aktifMi = value;
			}
		}




        protected override void ValidationListesiniOlusturCodeGeneration()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
