using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary.Ortak;
using System.Data;
using Simetri.Core.Validation.ForPonos;
using Simetri.Core.TypeLibrary;
using Simetri.Core.Yetki;
using System.Threading;
using System.Security.Principal;

namespace Simetri.Core.DataUtil.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdoTemplate template = new AdoTemplate();


        }

        private static void yetkiDeneme()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            IIdentity identity = null;
            identity = LogOnUser.GetWindowsIdentity("stajyer", "itodomain", "123456");
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            identity = Thread.CurrentPrincipal.Identity;


            AzmanHelper helper = new AzmanHelper();
            if (helper.HepsineYetkiliMi(identity, new int[] { 1, 2 }))
            {
                Console.WriteLine("Kisi Silme Hakkiniz var");
            }
        }

        [YetkiAttribute(OrnekYetkiEnum.KisiSil)]
        [YetkiAttribute(OrnekYetkiEnum.KisiEkle)]
        public static void YetkiAttributeDeneme()
        {
        }



    }
}
