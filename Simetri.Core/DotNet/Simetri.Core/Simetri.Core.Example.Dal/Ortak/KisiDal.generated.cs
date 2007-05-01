
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Simetri.Core.DataUtil;
using Simetri.Core.Example.TypeLibrary;
using Simetri.Core.Example.TypeLibrary.Ortak;


namespace Simetri.Core.Example.Dal.Ortak
{
    public partial class KisiDal : BaseDal<Kisi,Guid>
    {


        public override string SelectString
        {
            get 
			{ 
				return @"SELECT  KisiKey,TCKimlikNo,Adi,IkinciAdi,Soyadi,KayitTarihi,CinsiyetTipNo,UyrukNo,DurumNo FROM ORTAK.KISI";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORTAK.KISI WHERE KisiKey = @KisiKey";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORTAK.KISI SET 
				TCKimlikNo = @TCKimlikNo,Adi = @Adi,IkinciAdi = @IkinciAdi,Soyadi = @Soyadi,KayitTarihi = @KayitTarihi,CinsiyetTipNo = @CinsiyetTipNo,UyrukNo = @UyrukNo,DurumNo = @DurumNo
				WHERE KisiKey = @KisiKey ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORTAK.KISI 
				   (KisiKey,TCKimlikNo,Adi,IkinciAdi,Soyadi,KayitTarihi,CinsiyetTipNo,UyrukNo,DurumNo) VALUES (@KisiKey,@TCKimlikNo,@Adi,@IkinciAdi,@Soyadi,@KayitTarihi,@CinsiyetTipNo,@UyrukNo,@DurumNo)";
			}
        }
		public List<Kisi> SorgulaHepsiniGetir()
		{
			List<Kisi> liste = new List<Kisi>();
			SorguCalistir(liste,SelectString);
            return liste;
		}
		public Kisi SorgulaKisiKeyIle(Guid p1)
		{
			List<Kisi> liste = new List<Kisi>();
			SorguCalistir(liste,SelectString + " WHERE  KisiKey = " + p1);

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
		
					row.KisiKey = dr.GetGuid(0);
					if (!dr.IsDBNull(1))
					{
						row.TCKimlikNo = dr.GetString(1);
					}
					
					row.Adi = dr.GetString(2);
					if (!dr.IsDBNull(3))
					{
						row.IkinciAdi = dr.GetString(3);
					}
					
					row.Soyadi = dr.GetString(4);
					if (!dr.IsDBNull(5))
					{
						row.KayitTarihi = dr.GetDateTime(5);
					}
					
					if (!dr.IsDBNull(6))
					{
						row.CinsiyetTipNo = dr.GetByte(6);
					}
					
					if (!dr.IsDBNull(7))
					{
						row.UyrukNo = dr.GetInt16(7);
					}
					
					if (!dr.IsDBNull(8))
					{
						row.DurumNo = dr.GetInt16(8);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
					SqlParameter prmKisiKey  = new SqlParameter();
					prmKisiKey.ParameterName = "@KisiKey";					
					prmKisiKey.SqlDbType = SqlDbType.UniqueIdentifier;
					prmKisiKey.Value = row.KisiKey;
					cmd.Parameters.Add(prmKisiKey);
				
					SqlParameter prmTCKimlikNo  = new SqlParameter();
					prmTCKimlikNo.ParameterName = "@TCKimlikNo";					
					prmTCKimlikNo.SqlDbType = SqlDbType.Char;
					prmTCKimlikNo.Value = row.TCKimlikNo;
					cmd.Parameters.Add(prmTCKimlikNo);
				
					SqlParameter prmAdi  = new SqlParameter();
					prmAdi.ParameterName = "@Adi";					
					prmAdi.SqlDbType = SqlDbType.VarChar;
					prmAdi.Value = row.Adi;
					cmd.Parameters.Add(prmAdi);
				
					SqlParameter prmIkinciAdi  = new SqlParameter();
					prmIkinciAdi.ParameterName = "@IkinciAdi";					
					prmIkinciAdi.SqlDbType = SqlDbType.VarChar;
					prmIkinciAdi.Value = row.IkinciAdi;
					cmd.Parameters.Add(prmIkinciAdi);
				
					SqlParameter prmSoyadi  = new SqlParameter();
					prmSoyadi.ParameterName = "@Soyadi";					
					prmSoyadi.SqlDbType = SqlDbType.VarChar;
					prmSoyadi.Value = row.Soyadi;
					cmd.Parameters.Add(prmSoyadi);
				
					SqlParameter prmKayitTarihi  = new SqlParameter();
					prmKayitTarihi.ParameterName = "@KayitTarihi";					
					prmKayitTarihi.SqlDbType = SqlDbType.SmallDateTime;
					prmKayitTarihi.Value = row.KayitTarihi;
					cmd.Parameters.Add(prmKayitTarihi);
				
					SqlParameter prmCinsiyetTipNo  = new SqlParameter();
					prmCinsiyetTipNo.ParameterName = "@CinsiyetTipNo";					
					prmCinsiyetTipNo.SqlDbType = SqlDbType.TinyInt;
					prmCinsiyetTipNo.Value = row.CinsiyetTipNo;
					cmd.Parameters.Add(prmCinsiyetTipNo);
				
					SqlParameter prmUyrukNo  = new SqlParameter();
					prmUyrukNo.ParameterName = "@UyrukNo";					
					prmUyrukNo.SqlDbType = SqlDbType.SmallInt;
					prmUyrukNo.Value = row.UyrukNo;
					cmd.Parameters.Add(prmUyrukNo);
				
					SqlParameter prmDurumNo  = new SqlParameter();
					prmDurumNo.ParameterName = "@DurumNo";					
					prmDurumNo.SqlDbType = SqlDbType.SmallInt;
					prmDurumNo.Value = row.DurumNo;
					cmd.Parameters.Add(prmDurumNo);
				
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
					SqlParameter prmKisiKey  = new SqlParameter();
					prmKisiKey.ParameterName = "@KisiKey";					
					prmKisiKey.SqlDbType = SqlDbType.UniqueIdentifier;
					prmKisiKey.Value = row.KisiKey;
					cmd.Parameters.Add(prmKisiKey);
				
					SqlParameter prmTCKimlikNo  = new SqlParameter();
					prmTCKimlikNo.ParameterName = "@TCKimlikNo";					
					prmTCKimlikNo.SqlDbType = SqlDbType.Char;
					prmTCKimlikNo.Value = row.TCKimlikNo;
					cmd.Parameters.Add(prmTCKimlikNo);
				
					SqlParameter prmAdi  = new SqlParameter();
					prmAdi.ParameterName = "@Adi";					
					prmAdi.SqlDbType = SqlDbType.VarChar;
					prmAdi.Value = row.Adi;
					cmd.Parameters.Add(prmAdi);
				
					SqlParameter prmIkinciAdi  = new SqlParameter();
					prmIkinciAdi.ParameterName = "@IkinciAdi";					
					prmIkinciAdi.SqlDbType = SqlDbType.VarChar;
					prmIkinciAdi.Value = row.IkinciAdi;
					cmd.Parameters.Add(prmIkinciAdi);
				
					SqlParameter prmSoyadi  = new SqlParameter();
					prmSoyadi.ParameterName = "@Soyadi";					
					prmSoyadi.SqlDbType = SqlDbType.VarChar;
					prmSoyadi.Value = row.Soyadi;
					cmd.Parameters.Add(prmSoyadi);
				
					SqlParameter prmKayitTarihi  = new SqlParameter();
					prmKayitTarihi.ParameterName = "@KayitTarihi";					
					prmKayitTarihi.SqlDbType = SqlDbType.SmallDateTime;
					prmKayitTarihi.Value = row.KayitTarihi;
					cmd.Parameters.Add(prmKayitTarihi);
				
					SqlParameter prmCinsiyetTipNo  = new SqlParameter();
					prmCinsiyetTipNo.ParameterName = "@CinsiyetTipNo";					
					prmCinsiyetTipNo.SqlDbType = SqlDbType.TinyInt;
					prmCinsiyetTipNo.Value = row.CinsiyetTipNo;
					cmd.Parameters.Add(prmCinsiyetTipNo);
				
					SqlParameter prmUyrukNo  = new SqlParameter();
					prmUyrukNo.ParameterName = "@UyrukNo";					
					prmUyrukNo.SqlDbType = SqlDbType.SmallInt;
					prmUyrukNo.Value = row.UyrukNo;
					cmd.Parameters.Add(prmUyrukNo);
				
					SqlParameter prmDurumNo  = new SqlParameter();
					prmDurumNo.ParameterName = "@DurumNo";					
					prmDurumNo.SqlDbType = SqlDbType.SmallInt;
					prmDurumNo.Value = row.DurumNo;
					cmd.Parameters.Add(prmDurumNo);
				
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
					SqlParameter prmKisiKey  = new SqlParameter();
					prmKisiKey.ParameterName = "@KisiKey";					
					prmKisiKey.SqlDbType = SqlDbType.UniqueIdentifier;
					prmKisiKey.Value = row.KisiKey;
					cmd.Parameters.Add(prmKisiKey);
				
        }




    }
}
