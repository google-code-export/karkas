﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrnekImageButton.aspx.cs" Inherits="Ornekler_OrnekImageButton" %>

<%@ Register src="~/UserControls/AritOnayLinkButton.ascx" tagname="AritOnayLinkButton" tagprefix="arit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    </div>
    <arit:AritOnayLinkButton text="deneme" OnClick="Deneme_Click"  ID="AritOnayLinkButton1" runat="server" />
    </form>
</body>
</html>
