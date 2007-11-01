
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Simetri.Core.TypeLibrary;
using Simetri.Core.TypeLibrary.Ortak;
using Simetri.Core.Dal.Ortak;


namespace Simetri.Core.Bs.Ortak
{
    public partial class KisiEkBilgilerBs 
    {
        KisiEkBilgilerDal dal = new KisiEkBilgilerDal();
        public void Ekle(KisiEkBilgiler k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(KisiEkBilgiler k)
        {
            dal.Guncelle(k);
        }
        public void Sil(KisiEkBilgiler k)
        {
            dal.Sil(k);
        }

        public List<KisiEkBilgiler> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public KisiEkBilgiler SorgulaKisiKeyIle(Guid p1)
		{
			return dal.SorgulaKisiKeyIle(p1);
		}


    }
}
