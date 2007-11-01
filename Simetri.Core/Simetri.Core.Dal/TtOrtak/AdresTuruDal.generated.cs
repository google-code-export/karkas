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
    public partial class AdresTuruDal : BaseDal<AdresTuru,byte>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  No,Adi,IsAdresiTuruMu FROM TT_ORTAK.ADRES_TURU";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.ADRES_TURU WHERE No = @No";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.ADRES_TURU SET 
				Adi = @Adi,IsAdresiTuruMu = @IsAdresiTuruMu
				WHERE No = @No ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.ADRES_TURU 
				   (Adi,IsAdresiTuruMu) VALUES (@Adi,@IsAdresiTuruMu);SELECT scope_identity();";
			}
        }
		public List<AdresTuru> SorgulaHepsiniGetir()
		{
			List<AdresTuru> liste = new List<AdresTuru>();
			SorguCalistir(liste);
            return liste;
		}
		public AdresTuru SorgulaNoIle(byte p1)
		{
			List<AdresTuru> liste = new List<AdresTuru>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, AdresTuru row)
        {
		
					row.No = dr.GetByte(0);
					if (!dr.IsDBNull(1))
					{
						row.Adi = dr.GetString(1);
					}
					
					if (!dr.IsDBNull(2))
					{
						row.IsAdresiTuruMu = dr.GetBoolean(2);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, AdresTuru row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@IsAdresiTuruMu",SqlDbType.Bit, row.IsAdresiTuruMu);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, AdresTuru row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@IsAdresiTuruMu",SqlDbType.Bit, row.IsAdresiTuruMu);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, AdresTuru row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.TinyInt, row.No);
        }



    }
}
