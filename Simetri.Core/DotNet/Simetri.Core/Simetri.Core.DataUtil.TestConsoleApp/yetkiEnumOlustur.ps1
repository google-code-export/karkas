$x = [xml] (type "azmanStore.xml")


"namespace Simetri.Core.DataUtil.TestConsoleApp"
"{"
"    public partial class OrnekYetkiEnum"
"    {"
foreach($op in $x.AzAdminManager.AzApplication.AzOperation)
{
    "	public const int " + $op.Name + " = " + $op.OperationID+ ";"
}
"    }"
"}"



