using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Simetri.Core.DataUtil;
using Simetri.Core.TypeLibrary;
using Simetri.Core.TypeLibrary.TtOrtak;


namespace Simetri.Core.Dal.TtOrtak
{
    public partial class SosyalGuvenlikTuruDal : BaseDal<SosyalGuvenlikTuru,int>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  No,KisaAd,UzunAd FROM TT_ORTAK.SOSYAL_GUVENLIK_TURU";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.SOSYAL_GUVENLIK_TURU WHERE No = @No";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.SOSYAL_GUVENLIK_TURU SET 
				KisaAd = @KisaAd,UzunAd = @UzunAd
				WHERE No = @No ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.SOSYAL_GUVENLIK_TURU 
				   (KisaAd,UzunAd) VALUES (@KisaAd,@UzunAd);SELECT scope_identity();";
			}
        }
		public List<SosyalGuvenlikTuru> SorgulaHepsiniGetir()
		{
			List<SosyalGuvenlikTuru> liste = new List<SosyalGuvenlikTuru>();
			SorguCalistir(liste);
            return liste;
		}
		public SosyalGuvenlikTuru SorgulaNoIle(int p1)
		{
			List<SosyalGuvenlikTuru> liste = new List<SosyalGuvenlikTuru>();
			SorguCalistir(liste," No = " + p1);

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
                return true;
            }
        }

		
        protected override void ProcessRow(System.Data.IDataReader dr, SosyalGuvenlikTuru row)
        {
		
					row.No = dr.GetInt32(0);
					if (!dr.IsDBNull(1))
					{
						row.KisaAd = dr.GetString(1);
					}
					
					if (!dr.IsDBNull(2))
					{
						row.UzunAd = dr.GetString(2);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, SosyalGuvenlikTuru row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@KisaAd",SqlDbType.VarChar, row.KisaAd);
			builder.parameterEkle("@UzunAd",SqlDbType.VarChar, row.UzunAd);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, SosyalGuvenlikTuru row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.Int, row.No);
			builder.parameterEkle("@KisaAd",SqlDbType.VarChar, row.KisaAd);
			builder.parameterEkle("@UzunAd",SqlDbType.VarChar, row.UzunAd);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, SosyalGuvenlikTuru row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.Int, row.No);
        }



    }
}
