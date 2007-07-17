
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Simetri.Core.DataUtil;
using Simetri.Core.TypeLibrary;
using Simetri.Core.TypeLibrary.Ortak;


namespace Simetri.Core.Example.Dal.Ortak
{
    public partial class KisiDal : BaseDal<Kisi,Guid>
    {


        protected override string SelectString
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
					
					
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
				
				
				
				
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
				
				
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Kisi row)
        {
				
        }

        protected override string SelectCountString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }




    }
}
