using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;
using Simetri.Core.DataUtil;
using System.Data;
using System.Data.SqlClient;
using Simetri.Core.TypeLibrary.Ortak;

namespace Simetri.Core.Example.Dal.Ortak
{
    public partial class KisiDal : BaseDal<Kisi,Guid>
    {

        public DataTable KisiGetir(int pageSize,int startRowIndex)
        {
            AdoTemplate template = new AdoTemplate();
            string sql = "SELECT * FROM ORTAK.KISI";
            return template.DataTableOlusturSayfalamaYap(sql,pageSize,startRowIndex, "Adi");

        }

        public int SelectCountMethod()
        {
            AdoTemplate template = new AdoTemplate();
            string sql = "SELECT COUNT(*) FROM ORTAK.KISI";
            return (int)template.TekDegerGetir(sql);
        }

        public DataTable KisiGetirAdiVeSoyadiIle(string pAdi, string pSoyadi,
            int pageSize, int startRowIndex,string orderBy)
        {
            AdiVeSoyadiIleAra a = new AdiVeSoyadiIleAra(pAdi, pSoyadi);
            return a.KisiGetirAdiVeSoyadiIle(pageSize, startRowIndex, orderBy);
        }
        public int kayitSayisiBulAdiVeSoyadiIle(string pAdi, string pSoyadi, int pageSize, int startRowIndex,string orderBy)
        {
            AdiVeSoyadiIleAra a = new AdiVeSoyadiIleAra(pAdi, pSoyadi);
            return a.kayitSayisiBulAdiVeSoyadiIle();
        }

        private class AdiVeSoyadiIleAra
        {
            string selectSql = @"SELECT * FROM ORTAK.KISI WHERE Adi LIKE @Adi + '%' 
                            AND Soyadi LIKE @Soyadi + '%'";
            PagingTemplate pTemplate;
            public AdiVeSoyadiIleAra(string pAdi,string pSoyadi)
            {
                if (pAdi == null)
                {
                    pAdi = "";
                }
                if (pSoyadi == null)
                {
                    pSoyadi = "";
                }

                ParameterBuilder builder = new ParameterBuilder();
                builder.parameterEkle("@Adi", SqlDbType.VarChar, pAdi);
                builder.parameterEkle("@Soyadi", SqlDbType.VarChar, pSoyadi);

                pTemplate = new PagingTemplate(selectSql, builder.GetParameterArray());

            }


            public DataTable KisiGetirAdiVeSoyadiIle(int pageSize, int startRowIndex,string orderBy)
            {
                if (String.IsNullOrEmpty(orderBy))
                {
                    orderBy = "Adi";
                }
                return pTemplate.DataTableOlusturSayfalamaYap(pageSize, startRowIndex, orderBy);
            }
            public int kayitSayisiBulAdiVeSoyadiIle()
            {
                return pTemplate.KayitSayisiniBul();
            }
        }

    }
}
