using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.MyGenerationHelper.Interfaces
{
    public interface IZeusOutput
    {
        int tabLevel { get; set; }

        void autoTabLn(string p);

        void autoTab(string p);

        void incTab();

        void decTab();

        void writeln(string p);

        void save(string p, bool p_2);

        void clear();

        void setPreserveSource(string outputFullFileNameGenerated, string p, string p_2);

        void saveEnc(string outputFullFileNameGenerated, string p, string p_2);

        void getPreservedData(string p);

        void preserve(string p);

        string getPreserveBlock(string p);

        void write(string p);
    }
}
