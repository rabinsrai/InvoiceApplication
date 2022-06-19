<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceEntry.aspx.cs" Inherits="InvoiceChildParent.InvoiceEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            text-align: center;
        }
        .style3
        {
            color: #663300;
            font-weight: bold;
        }
        .style5
        {
            width: 193px;
        }
        .style6
        {
            width: 163px;
        }
        .style7
        {
            width: 137px;
        }
        .style8
        {
            width: 100%;
        }
        .style9
        {
            width: 383px;
        }
    </style>
</head>
<body>
    <div class="style2">
        <span class="style3" lang="en-us">Simple Invoicing Application</span>
    </div>
    <form id="form1" runat="server">
    <table class="style8">
        <tr>
            <td colspan="4">
                <span lang="en-us">Invoice summary</span></td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;
            <asp:Label ID="Label3" runat="server" Text="Invoice Number"></asp:Label>
            </td>
            <td class="style5">
                &nbsp;
            <asp:TextBox ID="txtInvoiceNumber" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;
            <span lang="en-us"><asp:Label ID="Label11" runat="server" Text="Comments"></asp:Label>
        </span>
            </td>
            <td>
        <span lang="en-us"><asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
        </span>
    
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;
                
        <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
            </td>
            <td class="style5">
                &nbsp;
            <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;
            <asp:Label ID="Label2" runat="server" Text="Customer Address"></asp:Label>
            </td>
            <td>
        <asp:TextBox ID="txtCustomerAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;
            <asp:Label ID="Label4" runat="server" Text="Invoice Date"></asp:Label>
            </td>
            <td class="style5">
                &nbsp;
            <span lang="en-us">
        <asp:TextBox ID="txtInvoiceDate" runat="server"></asp:TextBox>
        </span>
    
            </td>
            <td class="style6">
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <span lang="en-us">Invoice Details</span></td>
        </tr>
        <tr>
            <td class="style7">
        <span lang="en-us"><asp:Label ID="Label5" runat="server" Text="Product Name"></asp:Label>
        </span>
    
            </td>
            <td class="style5">
        <span lang="en-us"><asp:Label ID="lblProductName" runat="server" Text="Label"></asp:Label>
        </span>
            </td>
            <td class="style6">
        <span lang="en-us"><asp:Button ID="btnProductsSelect" runat="server" 
            onclick="btnProductsSelect_Click" Text="Select Products" />
        </span>
    
            </td>
            <td>
        <span lang="en-us">
        <asp:Label ID="lblProductDescription" runat="server"></asp:Label>
        </span>
    
            </td>
        </tr>
        <tr>
            <td class="style7">
        <span lang="en-us">
        <asp:Label ID="Label7" runat="server" Text="Unit Cost"></asp:Label>
        </span>
    
            </td>
            <td class="style5">
        <span lang="en-us">
        <asp:Label ID="lblProductUnitCost" runat="server" Text="Label"></asp:Label>
        </span>
    
            </td>
            <td class="style6">
        <span lang="en-us"><asp:Label ID="lblUnitCost" runat="server" Text="Quantity"></asp:Label>
        </span>
    
            </td>
            <td>
        <span lang="en-us"><asp:TextBox ID="TxtQuantity" runat="server" AutoPostBack="True" 
            ontextchanged="TxtQuantity_TextChanged"></asp:TextBox>
        </span>
    
            </td>
        </tr>
        <tr>
            <td class="style7">
        <span lang="en-us">
        <asp:Label ID="Label9" runat="server" Text="Total Amount to be paid"></asp:Label>
        </span>
    
            </td>
            <td class="style5">
        <span lang="en-us"><asp:Label ID="lblTotalAmountToBePaid" runat="server"></asp:Label>
        </span>
    
            </td>
            <td class="style6">
        <span lang="en-us">
        <asp:Label ID="Label10" runat="server" Text="Total Amount  paid"></asp:Label>
        </span>
    
            </td>
            <td>
        <span lang="en-us"><asp:TextBox ID="txtAmountPaid" runat="server"></asp:TextBox>
        </span>
    
            </td>
        </tr>
        <tr>
            <td class="style7">
        <span lang="en-us">
        <asp:Label ID="Label12" runat="server" Text="Tax Amount"></asp:Label>
        </span>
    
            </td>
            <td class="style5">
        <span lang="en-us">
        <asp:TextBox ID="txtTaxAmount" runat="server"></asp:TextBox>
        </span>
    
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Button ID="btnAddInvoiceDetails" runat="server" 
                    onclick="btnAddInvoiceDetails_Click" Text="Add/Update Details" 
                    Width="178px" />
            </td>
            <td class="style5">
        <span lang="en-us">
                <asp:Button ID="btnAddInvoice" runat="server" Text="Add/Update Invoice" 
           style="height: 26px" onclick="btnAddInvoice_Click" Width="175px" />
        </span>
    
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <table style="width:100%;">
                    <tr>
                        <td class="style9">
    <asp:DataGrid ID="dtgInvoice" runat="server" 
        onselectedindexchanged="dtgInvoice_SelectedIndexChanged" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" Width="370px" AutoGenerateColumns="False">
        <FooterStyle BackColor="#CCCC99" />
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" 
            Mode="NumericPages" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
            <asp:BoundColumn DataField="InvoiceNumber" HeaderText="InvoiceNumber">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="InvoiceComments" HeaderText="Invoice Description">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="CustomerName" HeaderText="Customer Name">
            </asp:BoundColumn>
        </Columns>
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
                        </td>
                        <td>
    <asp:DataGrid ID="dtgInvoiceDetails" runat="server" 
        BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" Width="395px" 
                                onselectedindexchanged="dtgInvoiceDetails_SelectedIndexChanged">
        <FooterStyle BackColor="#CCCC99" />
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" 
            Mode="NumericPages" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
        </Columns>
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
                        </td>
                    </tr>
                </table>
    
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text="Label"></asp:Label>
    </form>
</body>
</html>
