<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="BsynchroTaskMarianna.Accounts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div>
            <h2>Account Page</h2>
            
            <asp:Button ID="btnOpenAccount" runat="server" Text="Open Account" OnClick="btnOpenAccount_Click" />
            <asp:TextBox ID="txtCustomerId" runat="server" placeholder="Customer ID" />
            <asp:TextBox ID="txtInitialCredit" runat="server" placeholder="Initial Credit" />
            <br />
            
            <asp:Button ID="btnGetAccountInfo" runat="server" Text="Get Account Info" OnClick="btnGetAccountInfo_Click" />
            <asp:TextBox ID="txtAccountId" runat="server" placeholder="Account ID" />
            <br />

            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
