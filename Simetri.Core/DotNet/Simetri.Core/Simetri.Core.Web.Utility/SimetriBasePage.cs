using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Simetri.Core.Web.Utility
{
    public abstract class SimetriBasePage : Page
    {
        protected override void OnError(EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Server.ClearError();
            MessageBox(ex.Message);
        }

        public void MessageBox(string pMessage)
        {
            Response.Write(pMessage);
        }
        public void MessageBox(string[] pMessageList)
        {
            foreach (string s in pMessageList)
            {
                MessageBox(s);
            }
        }
        public void MessageBox(List<String> pMessageList)
        {
            MessageBox(pMessageList.ToArray());
        }
    }
}
