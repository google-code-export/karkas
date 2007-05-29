using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.TypeLibrary.Ortak
{
    [Serializable]
    public partial class Fotograf : BaseTypeLibrary
    {
		
		private Guid id;
		private Guid kisiKey;
		private byte[] fotografVerisi;
		
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
		
		public Guid KisiKey
		{
			get
			{
				return kisiKey;
			}
			set
			{
				kisiKey = value;
			}
		}
		
		public byte[] FotografVerisi
		{
			get
			{
				return fotografVerisi;
			}
			set
			{
				fotografVerisi = value;
			}
		}
		
		protected override void ValidationListesiniOlusturCodeGeneration()
		{
		}



    }
}
