using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Simetri.Core.DataUtil;
using Simetri.Core.TypeLibrary;
using Simetri.Core.TypeLibrary.Ortak;


namespace Simetri.Core.Dal.Ortak
{
    public partial class KisiIletisimDal : BaseDal<KisiIletisim,Guid>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,IletisimTuruTipNo,Iletisim,KisiKey,AktifMi,Oncelik FROM ORTAK.KISI_ILETISIM";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORTAK.KISI_ILETISIM WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORTAK.KISI_ILETISIM SET 
				IletisimTuruTipNo = @IletisimTuruTipNo,Iletisim = @Iletisim,KisiKey = @KisiKey,AktifMi = @AktifMi,Oncelik = @Oncelik
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORTAK.KISI_ILETISIM 
				   (ID,IletisimTuruTipNo,Iletisim,KisiKey,AktifMi,Oncelik) VALUES (@ID,@IletisimTuruTipNo,@Iletisim,@KisiKey,@AktifMi,@Oncelik)";
			}
        }
		public List<KisiIletisim> SorgulaHepsiniGetir()
		{
			List<KisiIletisim> liste = new List<KisiIletisim>();
			SorguCalistir(liste);
            return liste;
		}
		public KisiIletisim SorgulaIDIle(Guid p1)
		{
			List<KisiIletisim> liste = new List<KisiIletisim>();
			SorguCalistir(liste,String.Format(" ID = '{0}'", p1));

            if (liste.Count > 0)
            {
                return liste[0];
            }
            else
            {
                return null;
            }
		}
 
        protected override bool IdentityVarMi
        {
            get
            {
                return false;
            }
        }

		
        protected override void ProcessRow(System.Data.IDataReader dr, KisiIletisim row)
        {
		
					row.Id = dr.GetGuid(0);
					row.IletisimTuruTipNo = dr.GetInt32(1);
					row.Iletisim = dr.GetString(2);
					row.KisiKey = dr.GetGuid(3);
					if (!dr.IsDBNull(4))
					{
						row.AktifMi = dr.GetBoolean(4);
					}
					
					if (!dr.IsDBNull(5))
					{
						row.Oncelik = dr.GetInt32(5);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, KisiIletisim row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@IletisimTuruTipNo",SqlDbType.Int, row.IletisimTuruTipNo);
			builder.parameterEkle("@Iletisim",SqlDbType.VarChar, row.Iletisim);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
			builder.parameterEkle("@Oncelik",SqlDbType.Int, row.Oncelik);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, KisiIletisim row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@IletisimTuruTipNo",SqlDbType.Int, row.IletisimTuruTipNo);
			builder.parameterEkle("@Iletisim",SqlDbType.VarChar, row.Iletisim);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
			builder.parameterEkle("@Oncelik",SqlDbType.Int, row.Oncelik);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, KisiIletisim row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
        }



    }
}
