﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
namespace Karkas.Ornek.Dal.Ornekler
{
    public partial class StoredProcedures
    {
        public int MusteriEkle
        (
            string @Adi,
            string @Soyadi,
            string @IkinciAdi,
            DateTime @DogumTarihi
            )
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@Adi", SqlDbType.VarChar, @Adi);
            builder.parameterEkle("@Soyadi", SqlDbType.VarChar, @Soyadi);
            builder.parameterEkle("@IkinciAdi", SqlDbType.VarChar, @IkinciAdi);
            builder.parameterEkle("@DogumTarihi", SqlDbType.DateTime, @DogumTarihi);
            AdoTemplate template = new AdoTemplate();
            template.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString("KARKAS_ORNEK"));
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ORNEKLER.MUSTERI_EKLE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(builder.GetParameterArray());
            template.SorguHariciKomutCalistir(cmd);
            return (int)cmd.Parameters["@RETURN_VALUE"].Value;
        }
    }
}