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

        public int SelectCountMethod(int pageSize, int startRowIndex)
        {
            AdoTemplate template = new AdoTemplate();
            string sql = "SELECT COUNT(*) FROM ORTAK.KISI";
            return (int)template.TekDegerGetir(sql);

        }
        public int SelectCountMethod()
        {
            AdoTemplate template = new AdoTemplate();
            string sql = "SELECT COUNT(*) FROM ORTAK.KISI";
            return (int)template.TekDegerGetir(sql);
        }

    }
}
