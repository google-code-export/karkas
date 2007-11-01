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
    public partial class IlceDal : BaseDal<Ilce,int>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,SehirNo,Adi,AktifMi FROM TT_ORTAK.ILCE";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.ILCE WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.ILCE SET 
				SehirNo = @SehirNo,Adi = @Adi,AktifMi = @AktifMi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.ILCE 
				   (ID,SehirNo,Adi,AktifMi) VALUES (@ID,@SehirNo,@Adi,@AktifMi)";
			}
        }
		public List<Ilce> SorgulaHepsiniGetir()
		{
			List<Ilce> liste = new List<Ilce>();
			SorguCalistir(liste);
            return liste;
		}
		public Ilce SorgulaIDIle(int p1)
		{
			List<Ilce> liste = new List<Ilce>();
			SorguCalistir(liste," ID = " + p1);

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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Ilce row)
        {
		
					row.Id = dr.GetInt32(0);
					row.SehirNo = dr.GetInt32(1);
					row.Adi = dr.GetString(2);
					if (!dr.IsDBNull(3))
					{
						row.AktifMi = dr.GetBoolean(3);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Ilce row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
			builder.parameterEkle("@SehirNo",SqlDbType.Int, row.SehirNo);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Ilce row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
			builder.parameterEkle("@SehirNo",SqlDbType.Int, row.SehirNo);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Ilce row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
        }



    }
}
