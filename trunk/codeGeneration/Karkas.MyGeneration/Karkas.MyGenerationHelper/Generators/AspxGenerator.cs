using System;
using System.Collections.Generic;
using System.Text;
using Zeus;
using MyMeta;
using System.IO;

namespace Karkas.MyGenerationHelper.Generators
{
    public class AspxGenerator
    {
        Utils utils = new Utils();
        KarkasXmlParser parser = new KarkasXmlParser();

        string masterName = "Main";

        public void Render(IZeusOutput output, ITable pTable,string pMasterName)
        {
            IDatabase database = pTable.Database;
            string baseNameSpace = utils.NamespaceIniAlSchemaIle(database, pTable.Schema);
            string baseNamespaceWeb = baseNameSpace + ".WebApp";

            string className = utils.GetPascalCase(pTable.Name);
            string schemaName = utils.GetPascalCase(pTable.Schema);
            string classNameSpace = baseNamespaceWeb + "." + schemaName;
            string formName = className + "Form";


            output.writeln(RenderAsString(pTable, classNameSpace, className, formName));
            writeTableRows(output, pTable);
            output.writeln("</asp:Content>");
            string savePath = Path.Combine(utils.ProjeDizininiAl(database), "WebApp\\" + utils.GetPascalCase(pTable.Schema) + "\\" + formName + ".aspx");
            output.save(savePath, true);
            output.clear();

        }


        public string RenderAsString(ITable table, string pClassNameSpace, string tableName, string formName)
        {
            IDatabase database = table.Database;

            string codeFile = string.Format("{0}.aspx.cs", formName);
            string inherits = pClassNameSpace + "." + formName;
            string title = tableName + "Bilgi Girisi";

            string pageDirective = string.Format(@"<%@ Page Language=""C#"" MasterPageFile=""~/{3}.Master"" AutoEventWireup=""true""
    UICulture=""tr-TR"" Culture=""tr-TR"" CodeFile=""{0}"" Inherits=""{1}""
    Title=""{2}"" %>", codeFile, inherits, title,masterName);

            string masterDirective = string.Format(@"<%@ MasterType VirtualPath=""~/{0}.Master"" %>",masterName);
            string contentPlaceHolder = "<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"cph\" runat=\"server\">";

            StringBuilder sb = new StringBuilder();
            sb.Append(pageDirective);
            sb.Append(Environment.NewLine);
            sb.Append(masterDirective);
            sb.Append(Environment.NewLine);
            sb.Append(contentPlaceHolder);


            return sb.ToString();
        }


        public void writeTableRows(IZeusOutput output, ITable table)
        {
            output.writeln("<table class=\"AnaTablo\">");
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                string propertyVariableName = utils.GetPascalCase(column.Name);

                cellYazisiniGetir(output, column, propertyVariableName);

            }
            output.decTab();
            output.writeln(@"
        <tr>
            <td  colspan=""2"">
                <asp:Button runat=""server"" ID=""KaydetButton"" OnClick=""KaydetButton_Click"" SkinId=""Guncelle_Yazisiz"" />
            </td>
        </tr>
        ");
            output.writeln("</table>");

        }

        private void cellYazisiniGetir(IZeusOutput output, IColumn column, string propertyVariableName)
        {
            if ((column.LanguageType == "Guid") || (column.LanguageType == "byte[]"))
            {
                return;
            }
            bool tanimTablolariHaricindePrimaryKeyMi = ((column.IsInPrimaryKey) && !(column.Table.Schema.Contains("TT_")));
            if (tanimTablolariHaricindePrimaryKeyMi)
            {
                return;
            }
            // isimlendirme konvansiyonuna gore Key olan kolonlar baska bir tabloya 
            // referans veriyor. Onlarin farkli bir sekilde bulunmasi lazim.
            if (column.Name.Contains("Key"))
            {
                return;
            }

            output.writeln("\t<tr>");
            output.writeln(kolonYapisinaGoreControlYaz(column, propertyVariableName));
            output.writeln("\t</tr>");
        }

        private string kolonYapisinaGoreControlYaz(IColumn column, string propertyVariableName)
        {
            bool tanimTablosunaReferansEdiyorMu = column.Name.EndsWith("No");
            StringBuilder sb = new StringBuilder();
            cellIcerigiIsimEkle(sb, propertyVariableName);
            bool tamSayi = (column.LanguageType == "int") 
                || (column.LanguageType == "byte")
                || (column.LanguageType == "short")
                || (column.LanguageType == "long");

            if (tamSayi && tanimTablosunaReferansEdiyorMu && (!column.IsComputed)&& (!column.IsInPrimaryKey))   
            {
                  cellIcerigiControlEkle(sb, propertyVariableName, "asp", "DropDownList");
            }

            else if (tamSayi && (!column.IsComputed))
            {
                if (column.IsNullable)
                {
                    cellIcerigiControlEkle(sb, propertyVariableName, "smt", "SayiTextBox");
                }
                else
                {
                    cellIcerigiControlEkle(sb, propertyVariableName, "smt", "SayiTextBox","ZorunluMu=\"true\"" );
                }
            }
            else if (column.LanguageType == "bool")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "asp", "CheckBox");
            }
            else if (column.LanguageType == "DateTime")
            {
                if (column.IsNullable)
                {
                    cellIcerigiControlEkle(sb, propertyVariableName, "smt", "TarihTextBox");
                }
                else
                {
                    cellIcerigiControlEkle(sb, propertyVariableName, "smt", "TarihTextBox", "ZorunluMu=\"true\"");
                }
            }
            else if (column.LanguageType == "string")
            {
                if (column.CharacterMaxLength < 51)
                {
                    cellIcerigiControlEkle(sb, propertyVariableName, "asp", "TextBox");
                }
                else
                {
                    cellIcerigiControlEkle(sb, propertyVariableName, "asp", "TextBox", "TextMode=\"MultiLine\" MaxLength=\"300\"");
                }
            }
            else if (column.LanguageType == "decimal")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "smt", "ParaTextBox");
            }
            else
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "asp", "TextBox");
            }
            return sb.ToString();

        }

        private void cellIcerigiIsimEkle(StringBuilder sb, string propertyVariableName)
        {
            sb.Append("\t\t<td class=\"TdBaslik\">");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t");
            sb.Append("\t\t\t" + propertyVariableName + " : ");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t</td>");
            sb.Append(Environment.NewLine);

        }
        private void cellIcerigiControlEkle(StringBuilder sb, string propertyVariableName,string controlPrefix,string controlIsmi)
        {
            sb.Append("\t\t<td>");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t");
            sb.Append(string.Format("\t\t\t<{0}:{1} runat=\"server\" ID=\"{2}{1}\" />", controlPrefix, controlIsmi, propertyVariableName));
            sb.Append(Environment.NewLine);
            sb.Append("\t\t</td>");
            sb.Append(Environment.NewLine);

        }
        private void cellIcerigiControlEkle(StringBuilder sb, string propertyVariableName, string controlPrefix, string controlIsmi,string pExtraBilgi)
        {
            sb.Append("\t\t<td>");
            sb.Append(Environment.NewLine);
            sb.Append("\t\t");
            sb.Append(string.Format("\t\t\t<{0}:{1} runat=\"server\" ID=\"{2}{1}\" {3} />", controlPrefix, controlIsmi, propertyVariableName, pExtraBilgi));
            sb.Append(Environment.NewLine);
            sb.Append("\t\t</td>");
            sb.Append(Environment.NewLine);

        }
    }
}
