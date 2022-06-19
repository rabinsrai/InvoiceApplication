<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InvoiceChildParent.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Menu ID="Menu1" runat="server" onmenuitemclick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem NavigateUrl="~/InvoiceEntry.aspx" Text="Enter Invoice" 
                Value="Enter Invoice"></asp:MenuItem>
            <asp:MenuItem Text="Invoicing Reports" Value="Invoicing Reports"></asp:MenuItem>
            <asp:MenuItem Text="Master Entries" Value="Master Entries"></asp:MenuItem>
        </Items>
    </asp:Menu>
    </form>
</body>
</html>
