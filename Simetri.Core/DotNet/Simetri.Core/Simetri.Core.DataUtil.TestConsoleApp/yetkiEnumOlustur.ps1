$x = [xml] (type "Ito.WebApp/azmanStore.xml")

foreach($op in $x.AzAdminManager.AzApplication.AzOperation)
{
	$op.Name + " = " + $op.OperationID + " ,";
}


