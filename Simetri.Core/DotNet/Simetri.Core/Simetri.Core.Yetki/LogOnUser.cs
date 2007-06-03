using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Simetri.Yetki
{
    public class LogOnUser
    {
        //LogonUser parameters
        [DllImport("advapi32.dll")]
        public static extern bool LogonUser(String lpszUsername,
                                                String lpszDomain,
                                                String lpszPassword,
                                                int dwLogonType,
                                                int dwLogonProvider,
                                                ref IntPtr phToken);

        //CloseHandle parameters. When you are finished, 
        //free the memory allocated for the handle.
        [DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        public static WindowsIdentity GetWindowsIdentity(string pUserName, string pDomain, string pPassword)
        {
            IntPtr tokenHandle = IntPtr.Zero;

            try
            {
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_NETWORK = 3;

                //Call LogonUser to obtain a
                //handle to an access token
                bool returnValue = LogonUser(pUserName, pDomain,
                             pPassword,
                            LOGON32_LOGON_NETWORK,
                           LOGON32_PROVIDER_DEFAULT,
                            ref tokenHandle);

                if (false == returnValue)
                {
                    return null;
                }

                ////Check the identity
                //Console.WriteLine("Before impersonation: " +
                //         WindowsIdentity.GetCurrent().Name);

                //Create a WindowsIdentity from the impersonation 
                //token, then impersonate the user.
                WindowsIdentity newId;
                newId = new WindowsIdentity(tokenHandle);
                return newId;
            }

            catch (Exception ex)
            {
                // TODO log the Exception Message.
                return null;
            }
        }

    }

}