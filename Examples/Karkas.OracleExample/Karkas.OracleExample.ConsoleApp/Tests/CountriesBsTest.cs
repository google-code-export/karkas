using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.OracleExample.Dal.Hr;
using Karkas.OracleExample.TypeLibrary.Hr;
using Karkas.OracleExample.Bs.Hr;

namespace Karkas.OracleExample.ConsoleApp.Tests
{
    [TestFixture]
    class CountriesBsTest
    {
        [TestFixtureSetUp]
        public void herseyiSil()
        {
        }

        [Test]
        public void Ekle()
        {
            Countries a = new Countries();
            CountriesBs bs = new CountriesBs();
            a.CountryId = "TR";
            a.CountryName = "Turkey";

            bs.Ekle(a);
        }

        [Test]
        public void Guncelle()
        {
            CountriesBs bs = new CountriesBs();
            List<Countries> liste = bs.SorgulaHepsiniGetir();
            if (liste.Count > 0)
            {
                Countries m = liste[0];

                string pk = m.CountryId;

                m.CountryName = m.CountryName  + "2";
                bs.Guncelle(m);

                Countries veritabanindakiRow = bs.SorgulaCOUNTRY_IDIle(pk);
                Assert.AreEqual(veritabanindakiRow.CountryName, m.CountryName);
            }

        }

        //private Aciklama ornekAciklamaGetir()
        //{
        //    Aciklama a = new Aciklama();
        //    a.AciklamaKey = Guid.NewGuid();
        //    a.AciklamaProperty = "Ornek Aciklama";
        //    return a;
        //}
        //private void AciklamaKolonlariEsitMi(Aciklama p1, Aciklama p2)
        //{
        //    Assert.AreEqual(p1.AciklamaKey, p2.AciklamaKey);
        //    Assert.AreEqual(p1.AciklamaProperty, p2.AciklamaProperty);
        //}
        //[Test]
        //public void ornekMusteriEkleGuncelleSil()
        //{
        //    AciklamaBsWrapper wrapper = new AciklamaBsWrapper();
        //    Aciklama a = ornekAciklamaGetir();
        //    wrapper.Ekle(a);

        //    Aciklama veritabanindakiRow = wrapper.SorgulaAciklamaKeyIle(a.AciklamaKey);

        //    AciklamaKolonlariEsitMi(a, veritabanindakiRow);

        //    a.AciklamaProperty = a.AciklamaProperty + "d";
        //    wrapper.Guncelle(a);
        //    veritabanindakiRow = wrapper.SorgulaAciklamaKeyIle(a.AciklamaKey);
        //    AciklamaKolonlariEsitMi(a, veritabanindakiRow);

        //    wrapper.Sil(a);
        //    veritabanindakiRow = wrapper.SorgulaAciklamaKeyIle(a.AciklamaKey);
        //    Assert.IsNull(veritabanindakiRow);


        //}
    }
}
