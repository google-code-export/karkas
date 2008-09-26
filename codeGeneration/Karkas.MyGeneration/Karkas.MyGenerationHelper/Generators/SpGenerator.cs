using System;
using System.Collections.Generic;
using System.Text;
using Zeus;
using MyMeta;
using System.IO;

namespace Karkas.MyGenerationHelper.Generators
{


    public class SpGenerator : BaseGenerator
    {
        string[] diagramRutinleri = {
                                        "dbo.sp_helpdiagramdefinition",
                                        "dbo.sp_creatediagram",
                                        "dbo.sp_renamediagram",
                                        "dbo.sp_alterdiagram",
                                        "dbo.sp_dropdiagram",
                                        "dbo.fn_diagramobjects",
                                        "dbo.sp_upgraddiagrams",
                                        "dbo.sp_helpdiagrams"
                                };

        Utils utils = new Utils();
        string methodName = "";
        string schemaName = "";

        bool donusParamVarMi = false;
        string donucParamTipi = "";
        string donusParamAdi = "";
        IDatabase database = null;

        public void Render(IZeusOutput output, IProcedure proc)
        {
            if (proc.Schema == "sys")
            {
                return;
            }
            bool diagramRutiniMi = DiagramRutiniMi(proc);

            if (diagramRutiniMi)
            {
                return;
            }

            database = proc.Database;
            methodName = utils.SetPascalCase(proc.Name);
            schemaName = utils.SetPascalCase(proc.Schema);


            string baseNameSpace = utils.NamespaceIniAlSchemaIle(database, proc.Schema) + ".Dal";
            string classNameSpace = baseNameSpace + "." + schemaName;
            string outputFullFileNameGenerated = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, proc.Schema) + "\\Dal\\StoredProcedures", "usp_" + methodName + ".generated.cs");

            UsingleriYaz(output);



            output.autoTabLn("namespace " + classNameSpace);
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("public partial class StoredProcedures");
            BaslangicSusluParentezVeTabArtir(output);




            if (proc.ResultColumns.Count > 0)
            {
                RenderWithDataTable(output, proc);
            }
            else
            {
                RenderNormal(output, proc);
            }
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

        private bool DiagramRutiniMi(IProcedure proc)
        {
            foreach (string s in diagramRutinleri)
            {
                if (s == proc.Schema + "." + proc.Name)
                {
                    return true;
                }
            }
            return false;
        }
        private void generateParametersMethodSignature(IZeusOutput output, IProcedure proc)
        {
            output.autoTabLn("(");
            output.incTab();
            for (int i = 0; i < proc.Parameters.Count; i++)
            {
                IParameter param = proc.Parameters[i];
                if (i == proc.Parameters.Count - 1)
                {
                    typeGoreDegerYaz(output, param);
                    output.autoTabLn("");
                }
                else
                {
                    typeGoreDegerYaz(output, param);
                    if (param.Direction != ParamDirection.ReturnValue)
                    {
                        output.autoTabLn(",");
                    }
                }
            }
            output.autoTabLn(")");
        }

        private void generateParametersParameterBuilder(IZeusOutput output, IProcedure proc)
        {
            output.autoTabLn("ParameterBuilder builder = new ParameterBuilder();");

            foreach (IParameter param in proc.Parameters)
            {
                if (param.Direction == ParamDirection.ReturnValue)
                {
                    continue;
                }
                if (param.Direction == ParamDirection.Input)
                {
                    string yazi = string.Format(" builder.parameterEkle( \"{0}\",{1},{0});", param.Name, param.DbTargetType);
                    output.autoTabLn(yazi);
                }
                if (param.Direction == ParamDirection.Output)
                {
                    string yazi = string.Format(" builder.parameterEkle( \"{0}\",{1},{0},ParameterDirection.Output);", param.Name, param.DbTargetType);
                    output.autoTabLn(yazi);
                }
            }

        }

        private static void typeGoreDegerYaz(IZeusOutput output, IParameter param)
        {
            if (param.Direction == ParamDirection.Input)
            {
                output.autoTab(param.LanguageType + " " + param.Name);
            }
            else if (param.Direction == ParamDirection.Output)
            {
                output.autoTab(param.LanguageType + " " + param.Name);
            }
        }

        private void RenderNormal(IZeusOutput output, IProcedure proc)
        {
            string sonucDegeri = donusDegeriVarsaSetle(proc);
            output.autoTabLn(string.Format("public {0} {1}", sonucDegeri, methodName));
            generateParametersMethodSignature(output, proc);
            BaslangicSusluParentezVeTabArtir(output);
            generateParametersParameterBuilder(output, proc);

            output.autoTabLn("AdoTemplate template = new AdoTemplate();");
            output.autoTabLn(string.Format("template.Connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString(\"{0}\"));",database.Name));

            output.autoTabLn("SqlCommand cmd = new SqlCommand();");
            output.autoTabLn(string.Format("cmd.CommandText = \"{0}.{1}\";",proc.Schema,proc.Name));
            output.autoTabLn("cmd.CommandType = CommandType.StoredProcedure;");
            output.autoTabLn("cmd.Parameters.AddRange(builder.GetParameterArray());");
            output.autoTabLn("template.SorguHariciKomutCalistir(cmd);");

            if (donusParamVarMi)
            {
                output.autoTabLn(string.Format("return ({0}) cmd.Parameters[\"{1}\"].Value;", donucParamTipi, donusParamAdi));
            }
            else
            {
                output.autoTabLn("return;");
            }

            BitisSusluParentezVeTabAzalt(output);
        }

        private string donusDegeriVarsaSetle(IProcedure proc)
        {
            string donusDegeri = "void";
            foreach (IParameter param in proc.Parameters)
            {
                if (param.Direction == ParamDirection.ReturnValue)
                {
                    donusDegeri = param.LanguageType;
                    donusParamVarMi = true;
                    donusParamAdi = param.Name;
                    donucParamTipi = param.LanguageType;
                }
            }
            return donusDegeri;
        }
        private void RenderWithDataTable(IZeusOutput output, IProcedure proc)
        {
        }

        private void UsingleriYaz(IZeusOutput output)
        {
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");

        }
    }
}
