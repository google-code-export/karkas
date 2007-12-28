using System;
using System.Collections.Generic;
using System.Text;
using Zeus;
using MyMeta;
using System.IO;

namespace Simetri.MyGenerationHelper.Generators
{
    public class AspxGenerator
    {
        Utils SimetriUtils = new Utils();
        SimetriXmlParser parser = new SimetriXmlParser();

        public void Render(IZeusOutput output, ITable table)
        {
            IDatabase database = table.Database;
            string baseNamespace = parser.ProjeNamespaceIsminiAl(database);
            string baseNamespaceWeb = baseNamespace + ".WebApp";
            string tableName = table.Name;
            string formName = tableName + "Form";


            output.writeln(RenderAsString(table, baseNamespaceWeb, tableName, formName));
            writeTableRows(output, table);
            output.writeln("</asp:Content>");
            string savePath = Path.Combine(SimetriUtils.ProjeDizininiAl(database), "WebApp\\" + table.Schema + "\\" + formName + ".aspx");
            output.save(savePath, true);
            output.clear();

        }


        public string RenderAsString(ITable table, string baseNamespaceWeb, string tableName, string formName)
        {
            IDatabase database = table.Database;

            string codeFile = string.Format("{0}Form.aspx.cs", formName);
            string inherits = baseNamespaceWeb + formName;
            string title = tableName + "Bilgi Girisi";

            string pageDirective = string.Format(@"<%@ Page Language=""C#"" MasterPageFile=""~/SimetriMain.Master"" AutoEventWireup=""true""
    UICulture=""tr-TR"" Culture=""tr-TR"" CodeFile=""{0}"" Inherits=""{1}""
    Title=""{2}"" %>", codeFile, inherits, title);

            string masterDirective = @"<%@ MasterType VirtualPath=""~/SimetriMain.Master"" %>";
            string contentPlaceHolder = "<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"cph\" runat=\"server\">";

            StringBuilder sb = new StringBuilder();
            sb.Append(pageDirective);
            sb.Append(Environment.NewLine);
            sb.Append(masterDirective);
            sb.Append(Environment.NewLine);
            sb.Append(contentPlaceHolder);


            return sb.ToString();
        }

        public void writeKaydetButton(IZeusOutput output)
        {
        }

        public void writeTableRows(IZeusOutput output, ITable table)
        {
            output.writeln("<table class=\"AnaTablo\">");
            output.incTab();
            foreach (IColumn column in table.Columns)
            {
                string propertyVariableName = SimetriUtils.SetPascalCase(column.Name);

                cellYazisiniGetir(output, column, propertyVariableName);

            }
            output.decTab();
            output.writeln(@"
        <tr>
            <td  colspan=""2"">
                <asp:Button runat=""server"" ID=""GuncelleButton"" OnClick=""GuncelleButton_Click"" SkinId=""Guncelle_Yazisiz"" />
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
            output.writeln("\t<tr>");
            output.writeln(kolonYapisinaGoreControlYaz(column, propertyVariableName));
            output.writeln("\t</tr>");
        }

        private string kolonYapisinaGoreControlYaz(IColumn column, string propertyVariableName)
        {

            StringBuilder sb = new StringBuilder();
            cellIcerigiIsimEkle(sb, propertyVariableName);
            if (column.LanguageType == "int")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "asp", "TextBox");
            }
            else if (column.LanguageType == "byte")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "asp", "TextBox");
            }
            else if (column.LanguageType == "bool")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "asp", "CheckBox");
            }
            else if (column.LanguageType == "DateTime")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "smt", "TarihGiris");
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
            else if (column.LanguageType == "short")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "asp", "TextBox");
            }
            else if (column.LanguageType == "long")
            {
                cellIcerigiControlEkle(sb, propertyVariableName, "asp", "TextBox");
            }
            else if (column.LanguageType == "decimal")
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
