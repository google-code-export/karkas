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
    public partial class KanGrubuDal : BaseDal<KanGrubu,byte>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  No,Adi FROM TT_ORTAK.KAN_GRUBU";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.KAN_GRUBU WHERE No = @No";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.KAN_GRUBU SET 
				Adi = @Adi
				WHERE No = @No ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.KAN_GRUBU 
				   (Adi) VALUES (@Adi);SELECT scope_identity();";
			}
        }
		public List<KanGrubu> SorgulaHepsiniGetir()
		{
			List<KanGrubu> liste = new List<KanGrubu>();
			SorguCalistir(liste);
            return liste;
		}
		public KanGrubu SorgulaNoIle(byte p1)
		{
			List<KanGrubu> liste = new List<KanGrubu>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, KanGrubu row)
        {
		
					row.No = dr.GetByte(0);
					row.Adi = dr.GetString(1);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, KanGrubu row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, KanGrubu row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, KanGrubu row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
        }



    }
}
