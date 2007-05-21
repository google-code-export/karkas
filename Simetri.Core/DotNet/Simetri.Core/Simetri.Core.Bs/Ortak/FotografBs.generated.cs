
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
    public partial class FotografBs 
    {
        FotografDal dal = new FotografDal();
        public void Ekle(Fotograf k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(Fotograf k)
        {
            dal.Guncelle(k);
        }
        public void Sil(Fotograf k)
        {
            dal.Sil(k);
        }

        public List<Fotograf> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public Fotograf SorgulaIDIle(Guid p1)
		{
			return dal.SorgulaIDIle(p1);
		}


    }
}
