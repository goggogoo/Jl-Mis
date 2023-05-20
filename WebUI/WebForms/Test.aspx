<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebUI.WebForms.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="读数" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="生成类" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="输出" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="base64加密" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="解密" />
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="des加密" />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="解密" />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Button" />
            <br />
            <asp:TextBox ID="TextBox4" runat="server" Height="176px" TextMode="MultiLine" Width="645px"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" Height="176px" TextMode="MultiLine" Width="645px"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <asp:GridView ID="GridView1" runat="server" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="IDD" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
