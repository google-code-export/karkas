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
    public partial class CinsiyetDal : BaseDal<Cinsiyet,byte>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  No,KisaAd,UzunAd FROM TT_ORTAK.CINSIYET";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.CINSIYET WHERE No = @No";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.CINSIYET SET 
				KisaAd = @KisaAd,UzunAd = @UzunAd
				WHERE No = @No ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.CINSIYET 
				   (KisaAd,UzunAd) VALUES (@KisaAd,@UzunAd);SELECT scope_identity();";
			}
        }
		public List<Cinsiyet> SorgulaHepsiniGetir()
		{
			List<Cinsiyet> liste = new List<Cinsiyet>();
			SorguCalistir(liste);
            return liste;
		}
		public Cinsiyet SorgulaNoIle(byte p1)
		{
			List<Cinsiyet> liste = new List<Cinsiyet>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Cinsiyet row)
        {
		
					row.No = dr.GetByte(0);
					if (!dr.IsDBNull(1))
					{
						row.KisaAd = dr.GetString(1);
					}
					
					if (!dr.IsDBNull(2))
					{
						row.UzunAd = dr.GetString(2);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Cinsiyet row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@KisaAd",SqlDbType.Char, row.KisaAd);
			builder.parameterEkle("@UzunAd",SqlDbType.Char, row.UzunAd);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Cinsiyet row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
			builder.parameterEkle("@KisaAd",SqlDbType.Char, row.KisaAd);
			builder.parameterEkle("@UzunAd",SqlDbType.Char, row.UzunAd);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Cinsiyet row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
        }



    }
}
