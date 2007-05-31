using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Simetri.Core.Web.UI.WebControls
{
    public class IntTextBox : TextBox
    {
        private int num = 0;
        public int Value
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            this.Attributes["onkeypress"] = "return CheckKeyPressInt(this, event)";
            base.OnPreRender(e);
        }

        public override string Text
        {
            get
            {
                return num.ToString();
            }
            set
            {
                try
                {
                    num = Convert.ToInt32(value);
                }
                catch
                {
                    num = 0;
                }
            }
        }

    }
}
