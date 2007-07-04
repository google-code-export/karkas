using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Interop.Security.AzRoles;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Configuration;
using System.IO;

namespace Simetri.Core.Yetki
{
    public class AzmanHelper
    {
        private static AzmanHelper instance = new AzmanHelper();

        public static AzmanHelper Instance
        {
            get { return AzmanHelper.instance; }
        }


       
        const string AZ_MAN_STORE_KEY = "LocalPolicyStore";
        const string APPLICATION = "Ito";
        const int VALID_OPERATION = 0;
        readonly string store = ConfigurationManager.ConnectionStrings[AZ_MAN_STORE_KEY].ConnectionString;
        IAzAuthorizationStore azManStore;
        IAzApplication azApplication;
        IAzClientContext clientContext;
        //        OpItem[] operationCache;
        object[] scopes = { "" };
        private IAzApplication Application
        {
            get
            {
                if (this.azApplication == null)
                {
                    if (store == null)
                    {
                        throw new Exception(string.Format("Azman icin gerekli connection string yok, connection stringler icinde {0} olduguna emin olun", AZ_MAN_STORE_KEY));
                    }
                    azManStore = new AzAuthorizationStoreClass();
                    try
                    {
                        azManStore.Initialize(0, store, null);
                    }
                    catch (System.Runtime.InteropServices.COMException x)
                    {
                        throw new Exception("IAzAuthorizationStore.Initialize", x);
                    }
                    catch (FileNotFoundException ex)
                    {
                        throw new Exception("Authorization Manager, Azman'a Hatali Baglanti, lutfen baglanti yazisini kontrol ediniz,olmayan dosya", ex);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        throw new Exception("Authorization Manager, Azman'a Hatali Baglanti, lutfen baglanti yazisini kontrol ediniz, varolmayan dizin", ex);
                    }

                    try
                    {
                        azApplication = azManStore.OpenApplication(APPLICATION, null);
                    }
                    catch (System.Runtime.InteropServices.COMException x)
                    {
                        Release(azManStore);
                        azManStore = null;
                        throw new Exception("IAzAuthorizationStore.OpenApplication", x);
                    }
                }
                return this.azApplication;
            }
        }

        private void Release(IAzAuthorizationStore azManStore)
        {
            throw new Exception("The method or operation is not implemented.");
        }



        WindowsIdentity currentIdentity; //= OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name;

        private IAzClientContext GetClientContext(string username)
        {
            Regex rex = new Regex(@"^([\w]+)\\([\w]+)$");
            Match m = rex.Match(username);
            if (m.Success)
            {
                string domain = m.Groups[1].Value;
                string user = m.Groups[2].Value;
                try
                {
                    clientContext = this.Application.InitializeClientContextFromName(user, domain, null);
                }
                catch (System.Runtime.InteropServices.COMException x)
                {
                    throw new Exception("IAzApplication.InitializeClientContextFromName", x);
                }

            }
            else
            {
                //                throw new ValidationException(@"User name should be formed as ""domain\user");
            }
            return clientContext;
        }

        // TODO Bunu yaz
        private void CloseCurrentContext()
        {
        }

        private IAzClientContext GetClientContext()
        {
            try
            {
                clientContext = this.Application.InitializeClientContextFromToken(0, null);
            }
            catch (COMException x)
            {
                throw new Exception("IAzApplication.InitializeClientContextFromToken", x);

            }

            return clientContext;

        }

        private IAzClientContext GetClientContext(IIdentity identity)
        {
            WindowsIdentity windowsIdentity = identity as WindowsIdentity;
            if (windowsIdentity != null)
            {
                return GetClientContext(windowsIdentity);
            }
            else
            {
                return GetClientContext(identity.Name);
            }

        }

        private IAzClientContext GetClientContext(WindowsIdentity identity)
        {
            CloseCurrentContext();
            try
            {
                HandleRef handle = new HandleRef(this, identity.Token);
                clientContext = this.Application.InitializeClientContextFromToken((UInt64)handle.Handle, 0);
            }
            catch (COMException x)
            {
                throw new Exception("IAzApplication.InitializeClientContextFromName", x);
            }
            return clientContext;

        }
        // TODO Keith Brown Azman In the enterprise part III koduna bak ve bunu duzelt.

        public bool YetkiliMi(IIdentity identity, string operation)
        {
            return YetkiliMi(identity, GetOperationByName(operation));
        }
        /// <summary>
        /// Kullanici adi ve operation ile yetki kontrol eder.
        /// </summary>
        /// <param name="upnUsername"> username'in domain\username seklinde olmasi gerekiyor.</param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public bool YetkiliMi(string upnUsername, int operation)
        {

            object[] operations = { operation };
            object[] result = (object[])GetClientContext(upnUsername).AccessCheck(azApplication.Name, scopes, operations, null, null, null, null, null);
            return (int)result[0] == VALID_OPERATION;
        }

        

        public bool YetkiliMi(IIdentity identity, int operation)
        {
            if (identity.IsAuthenticated == false)
            {
                return false;
            }

            object[] operations = { operation };
            object[] result = (object[])GetClientContext(identity).AccessCheck(azApplication.Name, scopes, operations, null, null, null, null, null);
            return (int)result[0] == VALID_OPERATION;
        }
        // TODO bunun overload'i params alan yap
        // TODO dizi veya params alip, bool[] donduren yaz.
        // int[] yerine enum[] alani dusun.
        public bool HepsineYetkiliMi(IIdentity identity, int[] pOperations)
        {
            object[] operations = new object[pOperations.Length];
            for (int i = 0; i < pOperations.Length; i++)
            {
                operations[i] = pOperations[i];
            }
            object[] result = (object[])GetClientContext(identity).AccessCheck(azApplication.Name, scopes, operations, null, null, null, null, null);
            bool sonuc = true;
            for (int i = 0; i < result.Length; i++)
            {
                sonuc = sonuc && (int)result[i] == VALID_OPERATION;
            }

            return sonuc;
        }
        public bool EnAzBirineYetkiliMi(IIdentity identity, int[] pOperations)
        {
            object[] operations = new object[pOperations.Length];
            for (int i = 0; i < pOperations.Length; i++)
            {
                operations[i] = pOperations[i];
            }
            object[] result = (object[])GetClientContext(identity).AccessCheck(azApplication.Name, scopes, operations, null, null, null, null, null);
            bool sonuc = false;
            for (int i = 0; i < result.Length; i++)
            {
                sonuc = sonuc || (int)result[i] == VALID_OPERATION;
            }

            return sonuc;
        }

        private int GetOperationByName(string operation)
        {
            throw new Exception("The method or operation is not implemented.");
        } 

    }
}
