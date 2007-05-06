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
    public partial class KisiNufusBilgileriDal : BaseDal<KisiNufusBilgileri,Guid>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,KisiKey,TCKimlikNo,Ad,IkinciAdi,Soyad,UyrukTipNo,Cilt,Sayfa,Kutuk,DogumYeriNo,NufusaKayitliOlduguSehirNo,NufusaKayitliOlduguIlceNo,NufusaKayitliOlduguMahalleKoyKey,AnaAdi,BabaAdi,DogumTarihi,MedeniDurumTuruTipNo,DinTuruTipNo,CinsiyetTuruTipNo,KanGrubuTuruTipNo FROM ORTAK.KISI_NUFUS_BILGILERI";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORTAK.KISI_NUFUS_BILGILERI WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORTAK.KISI_NUFUS_BILGILERI SET 
				KisiKey = @KisiKey,TCKimlikNo = @TCKimlikNo,Ad = @Ad,IkinciAdi = @IkinciAdi,Soyad = @Soyad,UyrukTipNo = @UyrukTipNo,Cilt = @Cilt,Sayfa = @Sayfa,Kutuk = @Kutuk,DogumYeriNo = @DogumYeriNo,NufusaKayitliOlduguSehirNo = @NufusaKayitliOlduguSehirNo,NufusaKayitliOlduguIlceNo = @NufusaKayitliOlduguIlceNo,NufusaKayitliOlduguMahalleKoyKey = @NufusaKayitliOlduguMahalleKoyKey,AnaAdi = @AnaAdi,BabaAdi = @BabaAdi,DogumTarihi = @DogumTarihi,MedeniDurumTuruTipNo = @MedeniDurumTuruTipNo,DinTuruTipNo = @DinTuruTipNo,CinsiyetTuruTipNo = @CinsiyetTuruTipNo,KanGrubuTuruTipNo = @KanGrubuTuruTipNo
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORTAK.KISI_NUFUS_BILGILERI 
				   (ID,KisiKey,TCKimlikNo,Ad,IkinciAdi,Soyad,UyrukTipNo,Cilt,Sayfa,Kutuk,DogumYeriNo,NufusaKayitliOlduguSehirNo,NufusaKayitliOlduguIlceNo,NufusaKayitliOlduguMahalleKoyKey,AnaAdi,BabaAdi,DogumTarihi,MedeniDurumTuruTipNo,DinTuruTipNo,CinsiyetTuruTipNo,KanGrubuTuruTipNo) VALUES (@ID,@KisiKey,@TCKimlikNo,@Ad,@IkinciAdi,@Soyad,@UyrukTipNo,@Cilt,@Sayfa,@Kutuk,@DogumYeriNo,@NufusaKayitliOlduguSehirNo,@NufusaKayitliOlduguIlceNo,@NufusaKayitliOlduguMahalleKoyKey,@AnaAdi,@BabaAdi,@DogumTarihi,@MedeniDurumTuruTipNo,@DinTuruTipNo,@CinsiyetTuruTipNo,@KanGrubuTuruTipNo)";
			}
        }
		public List<KisiNufusBilgileri> SorgulaHepsiniGetir()
		{
			List<KisiNufusBilgileri> liste = new List<KisiNufusBilgileri>();
			SorguCalistir(liste);
            return liste;
		}
		public KisiNufusBilgileri SorgulaIDIle(Guid p1)
		{
			List<KisiNufusBilgileri> liste = new List<KisiNufusBilgileri>();
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

		
        protected override void ProcessRow(System.Data.IDataReader dr, KisiNufusBilgileri row)
        {
		
					row.Id = dr.GetGuid(0);
					row.KisiKey = dr.GetGuid(1);
					if (!dr.IsDBNull(2))
					{
						row.TCKimlikNo = dr.GetDecimal(2);
					}
					
					if (!dr.IsDBNull(3))
					{
						row.Ad = dr.GetString(3);
					}
					
					if (!dr.IsDBNull(4))
					{
						row.IkinciAdi = dr.GetString(4);
					}
					
					if (!dr.IsDBNull(5))
					{
						row.Soyad = dr.GetString(5);
					}
					
					if (!dr.IsDBNull(6))
					{
						row.UyrukTipNo = dr.GetInt16(6);
					}
					
					row.Cilt = dr.GetString(7);
					row.Sayfa = dr.GetString(8);
					row.Kutuk = dr.GetString(9);
					if (!dr.IsDBNull(10))
					{
						row.DogumYeriNo = dr.GetInt32(10);
					}
					
					if (!dr.IsDBNull(11))
					{
						row.NufusaKayitliOlduguSehirNo = dr.GetInt32(11);
					}
					
					if (!dr.IsDBNull(12))
					{
						row.NufusaKayitliOlduguIlceNo = dr.GetInt32(12);
					}
					
					if (!dr.IsDBNull(13))
					{
						row.NufusaKayitliOlduguMahalleKoyKey = dr.GetInt32(13);
					}
					
					row.AnaAdi = dr.GetString(14);
					row.BabaAdi = dr.GetString(15);
					row.DogumTarihi = dr.GetDateTime(16);
					if (!dr.IsDBNull(17))
					{
						row.MedeniDurumTuruTipNo = dr.GetByte(17);
					}
					
					if (!dr.IsDBNull(18))
					{
						row.DinTuruTipNo = dr.GetByte(18);
					}
					
					if (!dr.IsDBNull(19))
					{
						row.CinsiyetTuruTipNo = dr.GetByte(19);
					}
					
					if (!dr.IsDBNull(20))
					{
						row.KanGrubuTuruTipNo = dr.GetByte(20);
					}
							
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, KisiNufusBilgileri row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@TCKimlikNo",SqlDbType.Decimal, row.TCKimlikNo);
			builder.parameterEkle("@Ad",SqlDbType.VarChar, row.Ad);
			builder.parameterEkle("@IkinciAdi",SqlDbType.VarChar, row.IkinciAdi);
			builder.parameterEkle("@Soyad",SqlDbType.VarChar, row.Soyad);
			builder.parameterEkle("@UyrukTipNo",SqlDbType.SmallInt, row.UyrukTipNo);
			builder.parameterEkle("@Cilt",SqlDbType.VarChar, row.Cilt);
			builder.parameterEkle("@Sayfa",SqlDbType.VarChar, row.Sayfa);
			builder.parameterEkle("@Kutuk",SqlDbType.VarChar, row.Kutuk);
			builder.parameterEkle("@DogumYeriNo",SqlDbType.Int, row.DogumYeriNo);
			builder.parameterEkle("@NufusaKayitliOlduguSehirNo",SqlDbType.Int, row.NufusaKayitliOlduguSehirNo);
			builder.parameterEkle("@NufusaKayitliOlduguIlceNo",SqlDbType.Int, row.NufusaKayitliOlduguIlceNo);
			builder.parameterEkle("@NufusaKayitliOlduguMahalleKoyKey",SqlDbType.Int, row.NufusaKayitliOlduguMahalleKoyKey);
			builder.parameterEkle("@AnaAdi",SqlDbType.VarChar, row.AnaAdi);
			builder.parameterEkle("@BabaAdi",SqlDbType.VarChar, row.BabaAdi);
			builder.parameterEkle("@DogumTarihi",SqlDbType.SmallDateTime, row.DogumTarihi);
			builder.parameterEkle("@MedeniDurumTuruTipNo",SqlDbType.TinyInt, row.MedeniDurumTuruTipNo);
			builder.parameterEkle("@DinTuruTipNo",SqlDbType.TinyInt, row.DinTuruTipNo);
			builder.parameterEkle("@CinsiyetTuruTipNo",SqlDbType.TinyInt, row.CinsiyetTuruTipNo);
			builder.parameterEkle("@KanGrubuTuruTipNo",SqlDbType.TinyInt, row.KanGrubuTuruTipNo);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, KisiNufusBilgileri row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@TCKimlikNo",SqlDbType.Decimal, row.TCKimlikNo);
			builder.parameterEkle("@Ad",SqlDbType.VarChar, row.Ad);
			builder.parameterEkle("@IkinciAdi",SqlDbType.VarChar, row.IkinciAdi);
			builder.parameterEkle("@Soyad",SqlDbType.VarChar, row.Soyad);
			builder.parameterEkle("@UyrukTipNo",SqlDbType.SmallInt, row.UyrukTipNo);
			builder.parameterEkle("@Cilt",SqlDbType.VarChar, row.Cilt);
			builder.parameterEkle("@Sayfa",SqlDbType.VarChar, row.Sayfa);
			builder.parameterEkle("@Kutuk",SqlDbType.VarChar, row.Kutuk);
			builder.parameterEkle("@DogumYeriNo",SqlDbType.Int, row.DogumYeriNo);
			builder.parameterEkle("@NufusaKayitliOlduguSehirNo",SqlDbType.Int, row.NufusaKayitliOlduguSehirNo);
			builder.parameterEkle("@NufusaKayitliOlduguIlceNo",SqlDbType.Int, row.NufusaKayitliOlduguIlceNo);
			builder.parameterEkle("@NufusaKayitliOlduguMahalleKoyKey",SqlDbType.Int, row.NufusaKayitliOlduguMahalleKoyKey);
			builder.parameterEkle("@AnaAdi",SqlDbType.VarChar, row.AnaAdi);
			builder.parameterEkle("@BabaAdi",SqlDbType.VarChar, row.BabaAdi);
			builder.parameterEkle("@DogumTarihi",SqlDbType.SmallDateTime, row.DogumTarihi);
			builder.parameterEkle("@MedeniDurumTuruTipNo",SqlDbType.TinyInt, row.MedeniDurumTuruTipNo);
			builder.parameterEkle("@DinTuruTipNo",SqlDbType.TinyInt, row.DinTuruTipNo);
			builder.parameterEkle("@CinsiyetTuruTipNo",SqlDbType.TinyInt, row.CinsiyetTuruTipNo);
			builder.parameterEkle("@KanGrubuTuruTipNo",SqlDbType.TinyInt, row.KanGrubuTuruTipNo);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, KisiNufusBilgileri row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
        }



    }
}
