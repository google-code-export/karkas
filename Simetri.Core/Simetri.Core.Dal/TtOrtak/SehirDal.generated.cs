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
    public partial class SehirDal : BaseDal<Sehir,int>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,UlkeNo,Adi,TurkiyeIcindeMi FROM TT_ORTAK.SEHIR";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.SEHIR WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.SEHIR SET 
				UlkeNo = @UlkeNo,Adi = @Adi,TurkiyeIcindeMi = @TurkiyeIcindeMi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.SEHIR 
				   (ID,UlkeNo,Adi,TurkiyeIcindeMi) VALUES (@ID,@UlkeNo,@Adi,@TurkiyeIcindeMi)";
			}
        }
		public List<Sehir> SorgulaHepsiniGetir()
		{
			List<Sehir> liste = new List<Sehir>();
			SorguCalistir(liste);
            return liste;
		}
		public Sehir SorgulaIDIle(int p1)
		{
			List<Sehir> liste = new List<Sehir>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Sehir row)
        {
		
					row.Id = dr.GetInt32(0);
					row.UlkeNo = dr.GetInt16(1);
					row.Adi = dr.GetString(2);
					row.TurkiyeIcindeMi = dr.GetBoolean(3);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Sehir row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
			builder.parameterEkle("@UlkeNo",SqlDbType.SmallInt, row.UlkeNo);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@TurkiyeIcindeMi",SqlDbType.Bit, row.TurkiyeIcindeMi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Sehir row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
			builder.parameterEkle("@UlkeNo",SqlDbType.SmallInt, row.UlkeNo);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@TurkiyeIcindeMi",SqlDbType.Bit, row.TurkiyeIcindeMi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Sehir row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.Int, row.Id);
        }



    }
}
