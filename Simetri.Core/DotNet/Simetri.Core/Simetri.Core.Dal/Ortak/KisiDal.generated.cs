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
    public partial class KisiDal : BaseDal<Kisi,Guid>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,TcKimlikNo,Adi,Soyadi,IkinciAdi FROM ORTAK.KISI";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORTAK.KISI WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORTAK.KISI SET 
				TcKimlikNo = @TcKimlikNo,Adi = @Adi,Soyadi = @Soyadi,IkinciAdi = @IkinciAdi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORTAK.KISI 
				   (ID,TcKimlikNo,Adi,Soyadi,IkinciAdi) VALUES (@ID,@TcKimlikNo,@Adi,@Soyadi,@IkinciAdi)";
			}
        }
		public List<Kisi> SorgulaHepsiniGetir()
		{
			List<Kisi> liste = new List<Kisi>();
			SorguCalistir(liste);
            return liste;
		}
		public Kisi SorgulaIDIle(Guid p1)
		{
			List<Kisi> liste = new List<Kisi>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Kisi row)
        {
		
					row.Id = dr.GetGuid(0);
					if (!dr.IsDBNull(1))
					{
						row.TcKimlikNo = dr.GetDecimal(1);
					}
					
					if (!dr.IsDBNull(2))
					{
						row.Adi = dr.GetString(2);
					}
					
					if (!dr.IsDBNull(3))
					{
						row.Soyadi = dr.GetString(3);
					}
					
					if (!dr.IsDBNull(4))
					{
						row.IkinciAdi = dr.GetString(4);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@TcKimlikNo",SqlDbType.Decimal, row.TcKimlikNo);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi);
			builder.parameterEkle("@IkinciAdi",SqlDbType.VarChar, row.IkinciAdi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@TcKimlikNo",SqlDbType.Decimal, row.TcKimlikNo);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi);
			builder.parameterEkle("@IkinciAdi",SqlDbType.VarChar, row.IkinciAdi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
        }



    }
}
