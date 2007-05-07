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
    public partial class FotografDal : BaseDal<Fotograf,Guid>
    {


        protected override string SelectString
        {
            get 
			{ 
				return @"SELECT  ID,KisiKey,FotografVerisi FROM ORTAK.FOTOGRAF";
			}
        }

        protected override string DeleteString
        {
            get 
			{ 
				return @"DELETE   FROM ORTAK.FOTOGRAF WHERE ID = @ID";
			}
        }
        protected override string UpdateString
        {
            get 
			{ 
				return @"UPDATE ORTAK.FOTOGRAF SET 
				KisiKey = @KisiKey,FotografVerisi = @FotografVerisi
				WHERE ID = @ID ";
			}
        }

       protected override string InsertString
        {
            get 
			{ 
				return @"INSERT INTO ORTAK.FOTOGRAF 
				   (ID,KisiKey,FotografVerisi) VALUES (@ID,@KisiKey,@FotografVerisi)";
			}
        }
		public List<Fotograf> SorgulaHepsiniGetir()
		{
			List<Fotograf> liste = new List<Fotograf>();
			SorguCalistir(liste);
            return liste;
		}
		public Fotograf SorgulaIDIle(Guid p1)
		{
			List<Fotograf> liste = new List<Fotograf>();
			SorguCalistir(liste,String.Format(" ID = '{0}'", p1));

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

		
        protected override void ProcessRow(System.Data.IDataReader dr, Fotograf row)
        {
		
					row.Id = dr.GetGuid(0);
					row.KisiKey = dr.GetGuid(1);
					row.FotografVerisi = (Byte[])dr.GetValue(2);		
        }
        protected override void InsertCommandParametersAdd(SqlCommand cmd, Fotograf row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);

			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@FotografVerisi",SqlDbType.Image, row.FotografVerisi);
        }
        protected override void UpdateCommandParametersAdd(SqlCommand cmd, Fotograf row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
			builder.parameterEkle("@KisiKey",SqlDbType.UniqueIdentifier, row.KisiKey);
			builder.parameterEkle("@FotografVerisi",SqlDbType.Image, row.FotografVerisi);
        }
        protected override void DeleteCommandParametersAdd(SqlCommand cmd, Fotograf row)
        {
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ID",SqlDbType.UniqueIdentifier, row.Id);
        }



    }
}
