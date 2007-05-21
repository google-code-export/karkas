
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
    public partial class KisiNufusBilgileriBsWrapper 
    {
        KisiNufusBilgileriBs bs = new KisiNufusBilgileriBs();
		

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(KisiNufusBilgileri p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(KisiNufusBilgileri k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(KisiNufusBilgileri k)
        {
            bs.Sil(k);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<KisiNufusBilgileri> SorgulaHepsiniGetir()
        {
            List<KisiNufusBilgileri> liste= null;


            if (HttpContext.Current.Cache[CacheConstants.KisiNufusBilgileri] == null)
            {
                liste = bs.SorgulaHepsiniGetir();
                HttpContext.Current.Cache.Insert(CacheConstants.KisiNufusBilgileri
                            , liste
                            , null
                            , Cache.NoAbsoluteExpiration
                            , CacheIcindeTutmaZamani);
                
            }
            else
            {
                liste = (List<KisiNufusBilgileri>) HttpContext.Current.Cache[CacheConstants.KisiNufusBilgileri];
            }
            return liste;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public KisiNufusBilgileri SorgulaIDIle(Guid p1)
		{
			return bs.SorgulaIDIle(p1);
		}

        //
        // Deneme
        private TimeSpan cacheIcindeTutmaZamani = new TimeSpan(0, 20, 0);
        public TimeSpan CacheIcindeTutmaZamani
        {
            get
            {
                return cacheIcindeTutmaZamani;
            }
            set
            {
                cacheIcindeTutmaZamani = value;
            }
        }

        //
        //
    }
}
