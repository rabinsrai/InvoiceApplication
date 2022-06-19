<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectProducts.aspx.cs" Inherits="InvoiceChildParent.SelectProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataGrid ID="dtgProducts" runat="server" 
            onselectedindexchanged="dtgProducts_SelectedIndexChanged">
            <Columns>
                <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
            </Columns>
        </asp:DataGrid>
        </div>
    </form>
</body>
</html>
