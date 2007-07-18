<%@ Page Language="C#" MasterPageFile="~/SimetriMain.Master" AutoEventWireup="true"
    Codebehind="KisiSayfalama.aspx.cs" Inherits="Simetri.Core.WebApp.OrnekSayfalar.KisiSayfalama"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">

<table>
    <tr>
        <td> Adı</td>
        <td> <asp:TextBox runat="server" ID="adiTextBox" /> </td>
    </tr>
    <tr>
        <td> Soyadı</td>
        <td> <asp:TextBox runat="server" ID="soyadiTextBox" /> </td>
    </tr>
    

</table>
    <asp:Button ID="araButton" runat="server" Text="Ara" /><br />

    <asp:GridView ID="GridView1" runat="server" DataSourceID="ods1" AllowPaging="True" PageSize="3" AllowSorting="True">
    </asp:GridView>
    <asp:ObjectDataSource ID="ods1" runat="server" EnablePaging="True" SelectMethod="KisiGetirAdiVeSoyadiIle"
        TypeName="Simetri.Core.Example.Dal.Ortak.KisiDal" MaximumRowsParameterName="pageSize"
        SelectCountMethod="kayitSayisiBulAdiVeSoyadiIle">
        <SelectParameters>
            <asp:ControlParameter ControlID="adiTextBox" Name="pAdi" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="soyadiTextBox" Name="pSoyadi" PropertyName="Text"
                Type="String" />
            <asp:Parameter Name="pageSize" Type="Int32" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="orderBy" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
