using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.TypeLibrary.Ortak
{
    public partial class Fotograf
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
		


    }
}
