
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
    public partial class KisiAdresBs 
    {
        KisiAdresDal dal = new KisiAdresDal();
        public void Ekle(KisiAdres k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(KisiAdres k)
        {
            dal.Guncelle(k);
        }
        public void Sil(KisiAdres k)
        {
            dal.Sil(k);
        }

        public List<KisiAdres> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public KisiAdres SorgulaIDIle(Guid p1)
		{
			return dal.SorgulaIDIle(p1);
		}


    }
}
