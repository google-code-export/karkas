
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ComponentModel;
using System.Web;
using System.Web.Caching;
using Simetri.Core.TypeLibrary;
using Simetri.Core.TypeLibrary.Ortak;
using Simetri.Core.Bs.Ortak;


namespace Simetri.Core.BsWrapper.Ortak
{
    [DataObject]
    public partial class FotografBsWrapper 
    {
        FotografBs bs = new FotografBs();
		

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(Fotograf p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(Fotograf k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(Fotograf k)
        {
            bs.Sil(k);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Fotograf> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public Fotograf SorgulaIDIle(Guid p1)
		{
			return bs.SorgulaIDIle(p1);
		}


    }
}
