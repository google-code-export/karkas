using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using System.IO;

namespace Karkas.CodeGenerationHelper
{
    public class BaseOutput : IOutput
    {

        StringBuilder buffer = new StringBuilder(1000);
        private int _tabLevel = 0;

        public int tabLevel
        {
            get
            {
                return _tabLevel;
            }
            set
            {
                _tabLevel = value;
            }
        }

        private void writeNewLine()
        {
            buffer.Append(Environment.NewLine);
        }

        public void autoTabLn(string pLine)
        {
            autoTab(pLine);
            writeNewLine();
            
        }

        public void autoTab(string pLine)
        {
            for (int i = 1; i < _tabLevel; i++)
            {
                buffer.Append("\t");
            }
            buffer.Append(pLine);
        }

        public void increaseTab()
        {
            _tabLevel++;
        }

        public void decreaseTab()
        {
            _tabLevel--;
        }

        public void writeLine(string pLine)
        {
            write(pLine);
            writeNewLine();
        }

        public void write(string pLine)
        {
            buffer.Append(pLine);
        }

        private string findDirectoryNameFromFileName(string pFileName)
        {
            return new FileInfo(pFileName).Directory.FullName;
        }

        public void save(string pFileName, bool pIfExistsOverride)
        {
            string directoryName = findDirectoryNameFromFileName(pFileName);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            if (pIfExistsOverride)
            {
                File.WriteAllText(pFileName, buffer.ToString(),Encoding.UTF8);
            }
            else
            {
                if (!File.Exists(pFileName))
                {
                    File.WriteAllText(pFileName, buffer.ToString());
                }
            }
        }

        public void saveEncoding(string outputFullFileNameGenerated, string pOption, string pEncoding)
        {
            if (pOption == "o")
            {
                save(outputFullFileNameGenerated, true);
            }
            else
            {
                save(outputFullFileNameGenerated, false);
            }
        }

        public void clear()
        {
            buffer = new StringBuilder(1000);
        }

        public void setPreserveSource(string outputFullFileNameGenerated, string p, string p_2)
        {
            // TODO Simdilik bir sey yapmıcak
            //throw new NotImplementedException();
        }

        public void getPreservedData(string p)
        {
            // TODO Simdilik bir sey yapmıcak
            //throw new NotImplementedException();
        }

        public void preserve(string p)
        {
            // TODO Simdilik bir sey yapmıcak
            //throw new NotImplementedException();
        }

        public string getPreserveBlock(string p)
        {
            // TODO Simdilik bir sey yapmıcak
            //throw new NotImplementedException();
            return "";
        }

    }
}
