<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ASPxperience_Menu_BuildMenuFromDB_BuildMenuFromDB" %>

<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web"
    TagPrefix="dxwm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Binding a menu to a database</title>
</head>
<body>
    <form id="form1" runat="server">
         
    <div>
        <dxwm:ASPxMenu ID="ASPxMenu1" runat="server"></dxwm:ASPxMenu>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/MenuDB.mdb"
                SelectCommand="SELECT * FROM [MenuData]"></asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
