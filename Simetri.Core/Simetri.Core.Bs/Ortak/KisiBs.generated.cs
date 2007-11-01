
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
    public partial class KisiBs 
    {
        KisiDal dal = new KisiDal();
        public void Ekle(Kisi k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(Kisi k)
        {
            dal.Guncelle(k);
        }
        public void Sil(Kisi k)
        {
            dal.Sil(k);
        }

        public List<Kisi> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public Kisi SorgulaIDIle(Guid p1)
		{
			return dal.SorgulaIDIle(p1);
		}


    }
}
