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
    public partial class UlkeDal : BaseDal<Ulke,short>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  No,Adi,KisaAdi FROM TT_ORTAK.ULKE";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM TT_ORTAK.ULKE WHERE No = @No";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE TT_ORTAK.ULKE SET 
				Adi = @Adi,KisaAdi = @KisaAdi
				WHERE No = @No ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO TT_ORTAK.ULKE 
				   (Adi,KisaAdi) VALUES (@Adi,@KisaAdi);SELECT scope_identity();";
			}
        }
		public List<Ulke> SorgulaHepsiniGetir()
		{
			List<Ulke> liste = new List<Ulke>();
			SorguCalistir(liste);
            return liste;
		}
		public Ulke SorgulaNoIle(short p1)
		{
			List<Ulke> liste = new List<Ulke>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Ulke row)
        {
		
					row.No = dr.GetInt16(0);
					row.Adi = dr.GetString(1);
					if (!dr.IsDBNull(2))
					{
						row.KisaAdi = dr.GetString(2);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Ulke row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@KisaAdi",SqlDbType.VarChar, row.KisaAdi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Ulke row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.SmallInt, row.No);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@KisaAdi",SqlDbType.VarChar, row.KisaAdi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Ulke row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@No",SqlDbType.SmallInt, row.No);
        }



    }
}
