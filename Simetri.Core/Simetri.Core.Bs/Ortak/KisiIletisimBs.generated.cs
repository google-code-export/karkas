
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
    public partial class KisiIletisimBs 
    {
        KisiIletisimDal dal = new KisiIletisimDal();
        public void Ekle(KisiIletisim k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(KisiIletisim k)
        {
            dal.Guncelle(k);
        }
        public void Sil(KisiIletisim k)
        {
            dal.Sil(k);
        }

        public List<KisiIletisim> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public KisiIletisim SorgulaIDIle(Guid p1)
		{
			return dal.SorgulaIDIle(p1);
		}


    }
}
