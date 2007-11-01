
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
    public partial class KisiEkBilgilerBsWrapper 
    {
        KisiEkBilgilerBs bs = new KisiEkBilgilerBs();
		

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(KisiEkBilgiler p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(KisiEkBilgiler k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(KisiEkBilgiler k)
        {
            bs.Sil(k);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<KisiEkBilgiler> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public KisiEkBilgiler SorgulaKisiKeyIle(Guid p1)
		{
			return bs.SorgulaKisiKeyIle(p1);
		}


    }
}
