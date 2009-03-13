using System;
using System.Collections;
using Zeus;
using Zeus.Data;
using Zeus.UserInterface;
using MyMeta;
using Karkas.MyGenerationHelper;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.MyGenerationHelper.Interfaces;

namespace Karkas.MyGenerationHelper.Generators
{

    public class BsWrapperGenerator : BaseGenerator
    {
        string classNameTypeLibrary = "";
        string classNameDal = "";
        string classNameBs = "";
        string classNameBsWrapper = "";
        string schemaName = "";
        string classNameSpace = "";
        string memberVariableName = "";
        string propertyVariableName = "";

        string baseNameSpace = "";



        string pkAdi = "";
        string pkType = "";

        private static Utils utils = new Utils();
        public void Render(IZeusOutput output, IContainer container)
        {
            output.tabLevel = 0;

            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            string baseNameSpaceDal = baseNameSpace + ".Dal";
            string baseNameSpaceBs = baseNameSpace + ".Bs";

            IDatabase database = container.Database;



            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, container.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            baseNameSpaceDal = baseNameSpace + ".Dal";
            baseNameSpaceBs = baseNameSpace + ".Bs";

            classNameTypeLibrary = utils.GetPascalCase(container.Name);
            classNameDal = utils.GetPascalCase(container.Name) + "Dal";
            classNameBs = utils.GetPascalCase(container.Name) + "Bs";
            classNameBsWrapper = utils.GetPascalCase(container.Name) + "BsWrapper";

            schemaName = utils.GetPascalCase(container.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;


            string baseNameSpaceTypeLibraryWithSchema = baseNameSpace + ".TypeLibrary." + schemaName;
            string baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
            string baseNameSpaceBsWrapperWithSchema = baseNameSpace + ".BsWrapper." + schemaName;
            string baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;

            pkType = utils.PrimaryKeyTipiniBul(container);
            pkAdi = utils.PrimaryKeyAdiniBul(container);


            usingleriYaz(output, schemaName, baseNameSpaceTypeLibraryWithSchema, baseNameSpaceDalWithSchema, baseNameSpaceBsWithSchema);
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceBsWrapperWithSchema);
            output.autoTabLn("");
            BaslangicSusluParentezVeTabArtir(output);
            ClassBaslangicYaz(output,classNameTypeLibrary, classNameBs, classNameBsWrapper);
            if (container is TableContainer)
            {
                SilKomutuYazPkIle(output);
                SorgulaPKAdiIleYaz(output, classNameTypeLibrary, pkType, pkAdi);
            }

            output.autoTabLn("");
            output.autoTabLn("");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            string outputFullFileNameGenerated = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, container.Schema) + "\\BsWrapper\\" + baseNameSpace + ".BsWrapper\\" + schemaName, classNameTypeLibrary + "BsWrapper.generated.cs");
            string outputFullFileName = Path.Combine(utils.DizininiAlDatabaseVeSchemaIle(database, container.Schema) + "\\BsWrapper\\" + baseNameSpace + ".BsWrapper\\" + schemaName, classNameTypeLibrary + "BsWrapper.cs");
            output.saveEnc(outputFullFileNameGenerated, "o", "utf8");
            output.clear();

            if (!File.Exists(outputFullFileName))
            {
                usingleriYaz(output, schemaName, baseNameSpaceTypeLibraryWithSchema, baseNameSpaceDalWithSchema, baseNameSpaceBsWithSchema);
                output.autoTab("namespace ");
                output.autoTab(baseNameSpaceBsWrapperWithSchema);
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTab("public partial class ");
                output.autoTabLn(classNameBsWrapper);
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.save(outputFullFileName, false);
                output.clear();
            }


        }

        private static void usingleriYaz(IZeusOutput output, string schemaName, string baseNameSpaceTypeLibraryWithSchema, string baseNameSpaceDalWithSchema, string baseNameSpaceBsWithSchema)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using System.ComponentModel;");
            output.autoTabLn("using System.Web;");
            output.autoTabLn("using System.Web.Caching;");
            output.autoTabLn("using Karkas.Web.Helpers.HelperClasses;");
            output.autoTabLn("using Karkas.Core.DataUtil.BaseClasses;");

            output.autoTabLn(string.Format("using {0};", baseNameSpaceTypeLibraryWithSchema));
            output.autoTabLn(string.Format("using {0};",baseNameSpaceDalWithSchema));
            output.autoTabLn(string.Format("using {0};",baseNameSpaceBsWithSchema));
        }



        private void ClassBaslangicYaz(IZeusOutput output, string classNameTypeLibrary, string classNameBs, string classNameBsWrapper)
        {
            
            output.autoTabLn("[DataObject]");
            output.autoTab("public partial class ");
            output.autoTab(classNameBsWrapper);
            output.autoTab(string.Format(": BaseBsWrapper<{0},{0}Dal,{0}Bs>", classNameTypeLibrary));
            output.autoTabLn("");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("");
            output.autoTabLn(string.Format("{0} _bs = new {0}();", classNameBs));

            output.autoTabLn(string.Format("public override {0} bs", classNameBs));
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("return _bs;");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

        }



        private void SorgulaPKAdiIleYaz(IZeusOutput output, string classNameTypeLibrary, string pkType, string pkAdi)
        {
            output.autoTabLn("[DataObjectMethod(DataObjectMethodType.Select)]");
            output.autoTabLn(string.Format("public {0} Sorgula{1}Ile({2} p1)",classNameTypeLibrary,pkAdi,pkType));
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return bs.Sorgula{0}Ile(p1);",pkAdi));
            BitisSusluParentezVeTabAzalt(output);
        }






        private void SilKomutuYazPkIle(IZeusOutput output)
        {
            output.autoTabLn(string.Format("public void Sil({0} {1})", pkType, pkAdi));
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("bs.Sil(" + pkAdi + ");");
            BitisSusluParentezVeTabAzalt(output);
        }



    }




}



