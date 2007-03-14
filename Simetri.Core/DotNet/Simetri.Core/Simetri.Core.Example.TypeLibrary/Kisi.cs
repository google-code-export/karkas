using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Example.TypeLibrary
{
    public partial class Kisi
    {

        private string adi;

        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        private string soyadi;

        public string Soyadi
        {
            get { return soyadi; }
            set { soyadi = value; }
        }

        private int? yasi;

        public int? Yasi
        {
            get { return yasi; }
            set { yasi = value; }
        }
    }
}
