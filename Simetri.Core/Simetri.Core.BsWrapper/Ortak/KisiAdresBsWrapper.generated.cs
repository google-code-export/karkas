
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
    public partial class KisiAdresBsWrapper 
    {
        KisiAdresBs bs = new KisiAdresBs();
		

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(KisiAdres p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(KisiAdres k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(KisiAdres k)
        {
            bs.Sil(k);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<KisiAdres> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public KisiAdres SorgulaIDIle(Guid p1)
		{
			return bs.SorgulaIDIle(p1);
		}


    }
}
