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
    public partial class YabanciDilTipDal : BaseDal<YabanciDilTip,short>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  No,Adi FROM TT_ORTAK.YABANCI_DIL_TIP";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.YABANCI_DIL_TIP WHERE No = @No";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.YABANCI_DIL_TIP SET 
				Adi = @Adi
				WHERE No = @No ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.YABANCI_DIL_TIP 
				   (No,Adi) VALUES (@No,@Adi)";
			}
        }
		public List<YabanciDilTip> SorgulaHepsiniGetir()
		{
			List<YabanciDilTip> liste = new List<YabanciDilTip>();
			SorguCalistir(liste);
            return liste;
		}
		public YabanciDilTip SorgulaNoIle(short p1)
		{
			List<YabanciDilTip> liste = new List<YabanciDilTip>();
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
                return false;
            }
        }

		
        protected override void ProcessRow(System.Data.IDataReader dr, YabanciDilTip row)
        {
		
					row.No = dr.GetInt16(0);
					row.Adi = dr.GetString(1);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, YabanciDilTip row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@No",SqlDbType.SmallInt, row.No);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, YabanciDilTip row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.SmallInt, row.No);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, YabanciDilTip row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.SmallInt, row.No);
        }



    }
}
