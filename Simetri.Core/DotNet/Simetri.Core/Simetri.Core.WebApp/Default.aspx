<%@ Page Language="C#" MasterPageFile="~/SimetriMain.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Simetri.Core.WebApp.Default" Title="Untitled Page" %>
<%@ MasterType TypeName="Simetri.Core.WebApp.SimetriMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ods1" AllowPaging="True">
    </asp:GridView>
    <asp:ObjectDataSource ID="ods1" runat="server" EnablePaging="True" SelectMethod="KisiGetir"
        TypeName="Simetri.Core.Example.Dal.Ortak.KisiDal"
        MaximumRowsParameterName="pageSize" SelectCountMethod="SelectCountMethod" >
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="10" Name="pageSize" QueryStringField="pageSize"
                Type="Int32" />
            <asp:QueryStringParameter DefaultValue="5" Name="startRowIndex" QueryStringField="startRowIndex"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    
    
</asp:Content>
