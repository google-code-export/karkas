using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MyMeta;

namespace Simetri.MyGenerationHelper
{
    public class Utils
    {
        public ITables filterListAccordingToSchemaName(ITables tableList, string schemaName)
        {
            ITables newList = new MyMeta.Sql.SqlTables();

            foreach (ITable t in tableList)
            {
                if (t.Schema.Equals(schemaName,StringComparison.InvariantCultureIgnoreCase))
                {
                    newList.Add(t);
                }
            }

            return newList;

        }

        public string SetCamelCase(string name)
        {
            string text = "";
            bool flag = false;
            bool flag2 = true;
            bool flag3 = true;
            foreach (char ch in name)
            {
                if (char.IsLower(ch))
                {
                    flag3 = false;
                    break;
                }
            }
            foreach (char ch2 in name)
            {
                switch (ch2)
                {
                    case ' ':
                        if (!flag2)
                        {
                            flag = true;
                        }
                        break;

                    case '.':
                        if (!flag2)
                        {
                            flag = true;
                        }
                        break;

                    case '_':
                        if (!flag2)
                        {
                            flag = true;
                        }
                        break;

                    default:
                        if (flag)
                        {
                            text = text + ch2.ToString().ToUpperInvariant();
                            flag = false;
                        }
                        else if (flag2)
                        {
                            text = text + ch2.ToString().ToLowerInvariant();
                            flag2 = false;
                        }
                        else if (flag3)
                        {
                            text = text + ch2.ToString().ToLowerInvariant();
                        }
                        else
                        {
                            text = text + ch2.ToString();
                        }
                        break;
                }
            }
            return text;
        }





        public string SetPascalCase(string name)
        {
            string text = "";
            bool flag = true;
            bool flag2 = true;
            foreach (char ch in name)
            {
                if (char.IsLower(ch))
                {
                    flag2 = false;
                    break;
                }
            }
            foreach (char ch2 in name)
            {
                switch (ch2)
                {
                    case ' ':
                        flag = true;
                        break;

                    case '.':
                        flag = true;
                        break;

                    case '_':
                        flag = true;
                        break;

                    default:
                        if (flag)
                        {
                            text = text + ch2.ToString().ToUpperInvariant();
                            flag = false;
                        }
                        else if (flag2)
                        {
                            text = text + ch2.ToString().ToLowerInvariant();
                        }
                        else
                        {
                            text = text + ch2.ToString();
                        }
                        break;
                }
            }
            return text;
        }



    }
}
