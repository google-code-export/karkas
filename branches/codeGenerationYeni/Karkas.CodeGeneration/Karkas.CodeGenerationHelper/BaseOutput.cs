using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper
{
    public class BaseOutput : IOutput
    {
        public int tabLevel
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void autoTabLn(string p)
        {
            throw new NotImplementedException();
        }

        public void autoTab(string p)
        {
            throw new NotImplementedException();
        }

        public void incTab()
        {
            throw new NotImplementedException();
        }

        public void decTab()
        {
            throw new NotImplementedException();
        }

        public void writeln(string p)
        {
            throw new NotImplementedException();
        }

        public void save(string p, bool p_2)
        {
            throw new NotImplementedException();
        }

        public void clear()
        {
            throw new NotImplementedException();
        }

        public void setPreserveSource(string outputFullFileNameGenerated, string p, string p_2)
        {
            throw new NotImplementedException();
        }

        public void saveEnc(string outputFullFileNameGenerated, string p, string p_2)
        {
            throw new NotImplementedException();
        }

        public void getPreservedData(string p)
        {
            throw new NotImplementedException();
        }

        public void preserve(string p)
        {
            throw new NotImplementedException();
        }

        public string getPreserveBlock(string p)
        {
            throw new NotImplementedException();
        }

        public void write(string p)
        {
            throw new NotImplementedException();
        }
    }
}
