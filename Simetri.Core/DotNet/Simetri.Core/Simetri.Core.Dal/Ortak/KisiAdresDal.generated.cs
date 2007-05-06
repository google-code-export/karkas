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
    public partial class KisiAdresDal : BaseDal<KisiAdres,Guid>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,KisiKey,Adres,AdresTuruTipNo,Oncelik,AktifMi FROM ORTAK.KISI_ADRES";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORTAK.KISI_ADRES WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORTAK.KISI_ADRES SET 
				KisiKey = @KisiKey,Adres = @Adres,AdresTuruTipNo = @AdresTuruTipNo,Oncelik = @Oncelik,AktifMi = @AktifMi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORTAK.KISI_ADRES 
				   (ID,KisiKey,Adres,AdresTuruTipNo,Oncelik,AktifMi) VALUES (@ID,@KisiKey,@Adres,@AdresTuruTipNo,@Oncelik,@AktifMi)";
			}
        }
		public List<KisiAdres> SorgulaHepsiniGetir()
		{
			List<KisiAdres> liste = new List<KisiAdres>();
			SorguCalistir(liste);
            return liste;
		}
		public KisiAdres SorgulaIDIle(Guid p1)
		{
			List<KisiAdres> liste = new List<KisiAdres>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, KisiAdres row)
        {
		
					row.Id = dr.GetGuid(0);
					row.KisiKey = dr.GetGuid(1);
					if (!dr.IsDBNull(2))
					{
						row.Adres = dr.GetString(2);
					}
					
					if (!dr.IsDBNull(3))
					{
						row.AdresTuruTipNo = dr.GetByte(3);
					}
					
					if (!dr.IsDBNull(4))
					{
						row.Oncelik = dr.GetInt32(4);
					}
					
					if (!dr.IsDBNull(5))
					{
						row.AktifMi = dr.GetBoolean(5);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, KisiAdres row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@Adres",SqlDbType.VarChar, row.Adres);
			builder.parameterEkle("@AdresTuruTipNo",SqlDbType.TinyInt, row.AdresTuruTipNo);
			builder.parameterEkle("@Oncelik",SqlDbType.Int, row.Oncelik);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, KisiAdres row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@Adres",SqlDbType.VarChar, row.Adres);
			builder.parameterEkle("@AdresTuruTipNo",SqlDbType.TinyInt, row.AdresTuruTipNo);
			builder.parameterEkle("@Oncelik",SqlDbType.Int, row.Oncelik);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, KisiAdres row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
        }



    }
}
