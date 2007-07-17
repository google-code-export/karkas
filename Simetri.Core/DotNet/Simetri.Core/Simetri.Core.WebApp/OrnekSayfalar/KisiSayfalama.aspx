<%@ Page Language="C#" MasterPageFile="~/SimetriMain.Master" AutoEventWireup="true"
    Codebehind="KisiSayfalama.aspx.cs" Inherits="Simetri.Core.WebApp.OrnekSayfalar.KisiSayfalama"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ods1" AllowPaging="True" PageSize="3">
    </asp:GridView>
    <asp:ObjectDataSource ID="ods1" runat="server" EnablePaging="True" SelectMethod="KisiGetir"
        TypeName="Simetri.Core.Example.Dal.Ortak.KisiDal" MaximumRowsParameterName="pageSize"
        SelectCountMethod="SelectCountMethod">
    </asp:ObjectDataSource>
</asp:Content>
