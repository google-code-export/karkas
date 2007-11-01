
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
    public partial class KisiNufusBilgileriBs 
    {
        KisiNufusBilgileriDal dal = new KisiNufusBilgileriDal();
        public void Ekle(KisiNufusBilgileri k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(KisiNufusBilgileri k)
        {
            dal.Guncelle(k);
        }
        public void Sil(KisiNufusBilgileri k)
        {
            dal.Sil(k);
        }

        public List<KisiNufusBilgileri> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public KisiNufusBilgileri SorgulaIDIle(Guid p1)
		{
			return dal.SorgulaIDIle(p1);
		}


    }
}
