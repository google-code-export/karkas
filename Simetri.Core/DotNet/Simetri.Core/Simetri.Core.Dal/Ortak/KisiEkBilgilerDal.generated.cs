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
    public partial class KisiEkBilgilerDal : BaseDal<KisiEkBilgiler,Guid>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  KisiKey,VergiDairesiTipNo,VergiNo,SosyalGuvenlikTipNo,SosyalGuvenlikNo,PasaportTipNo,PasaportNo FROM ORTAK.KISI_EK_BILGILER";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORTAK.KISI_EK_BILGILER WHERE KisiKey = @KisiKey";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORTAK.KISI_EK_BILGILER SET 
				VergiDairesiTipNo = @VergiDairesiTipNo,VergiNo = @VergiNo,SosyalGuvenlikTipNo = @SosyalGuvenlikTipNo,SosyalGuvenlikNo = @SosyalGuvenlikNo,PasaportTipNo = @PasaportTipNo,PasaportNo = @PasaportNo
				WHERE KisiKey = @KisiKey ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORTAK.KISI_EK_BILGILER 
				   (KisiKey,VergiDairesiTipNo,VergiNo,SosyalGuvenlikTipNo,SosyalGuvenlikNo,PasaportTipNo,PasaportNo) VALUES (@KisiKey,@VergiDairesiTipNo,@VergiNo,@SosyalGuvenlikTipNo,@SosyalGuvenlikNo,@PasaportTipNo,@PasaportNo)";
			}
        }
		public List<KisiEkBilgiler> SorgulaHepsiniGetir()
		{
			List<KisiEkBilgiler> liste = new List<KisiEkBilgiler>();
			SorguCalistir(liste);
            return liste;
		}
		public KisiEkBilgiler SorgulaKisiKeyIle(Guid p1)
		{
			List<KisiEkBilgiler> liste = new List<KisiEkBilgiler>();
			SorguCalistir(liste," KisiKey = " + p1);

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

		
        protected override void ProcessRow(System.Data.IDataReader dr, KisiEkBilgiler row)
        {
		
					row.KisiKey = dr.GetGuid(0);
					if (!dr.IsDBNull(1))
					{
						row.VergiDairesiTipNo = dr.GetInt32(1);
					}
					
					if (!dr.IsDBNull(2))
					{
						row.VergiNo = dr.GetString(2);
					}
					
					if (!dr.IsDBNull(3))
					{
						row.SosyalGuvenlikTipNo = dr.GetInt32(3);
					}
					
					if (!dr.IsDBNull(4))
					{
						row.SosyalGuvenlikNo = dr.GetString(4);
					}
					
					if (!dr.IsDBNull(5))
					{
						row.PasaportTipNo = dr.GetInt32(5);
					}
					
					if (!dr.IsDBNull(6))
					{
						row.PasaportNo = dr.GetString(6);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, KisiEkBilgiler row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@VergiDairesiTipNo",SqlDbType.Int, row.VergiDairesiTipNo);
			builder.parameterEkle("@VergiNo",SqlDbType.VarChar, row.VergiNo);
			builder.parameterEkle("@SosyalGuvenlikTipNo",SqlDbType.Int, row.SosyalGuvenlikTipNo);
			builder.parameterEkle("@SosyalGuvenlikNo",SqlDbType.VarChar, row.SosyalGuvenlikNo);
			builder.parameterEkle("@PasaportTipNo",SqlDbType.Int, row.PasaportTipNo);
			builder.parameterEkle("@PasaportNo",SqlDbType.VarChar, row.PasaportNo);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, KisiEkBilgiler row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@VergiDairesiTipNo",SqlDbType.Int, row.VergiDairesiTipNo);
			builder.parameterEkle("@VergiNo",SqlDbType.VarChar, row.VergiNo);
			builder.parameterEkle("@SosyalGuvenlikTipNo",SqlDbType.Int, row.SosyalGuvenlikTipNo);
			builder.parameterEkle("@SosyalGuvenlikNo",SqlDbType.VarChar, row.SosyalGuvenlikNo);
			builder.parameterEkle("@PasaportTipNo",SqlDbType.Int, row.PasaportTipNo);
			builder.parameterEkle("@PasaportNo",SqlDbType.VarChar, row.PasaportNo);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, KisiEkBilgiler row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
        }



    }
}
