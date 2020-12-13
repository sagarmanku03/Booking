<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
             ShowHeaderWhenEmpty="true"
             OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
              OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
            ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Id"> 
           
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

            <Columns>
                <asp:TemplateField HeaderText="Booking ID">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Id") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtId" Text='<%# Eval("Id") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtIdFooter"  runat="server" />
                    </FooterTemplate>
                 </asp:TemplateField>
           
                <asp:TemplateField HeaderText="Booking CustomerName">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("CustomerName") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCustomerName" Text='<%# Eval("CustomerName") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCustomerNameFooter"  runat="server" />
                    </FooterTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="Booking MovieName">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("MovieName") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMovieName" Text='<%# Eval("MovieName") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtMovieNameFooter"  runat="server" />
                    </FooterTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="Booking PhoneNo">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("PhoneNo") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPhoneNo" Text='<%# Eval("PhoneNo") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPhoneNoFooter"  runat="server" />
                    </FooterTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="Booking Address">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Address") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAddress" Text='<%# Eval("Address") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddressFooter"  runat="server" />
                    </FooterTemplate>
                 </asp:TemplateField>

               <asp:TemplateField>

                   <ItemTemplate>

                       <asp:ImageButton Imageurl="~/imz/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                        <asp:ImageButton Imageurl="~/imz/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />

                   </ItemTemplate>

                   <EditItemTemplate>
                       <asp:ImageButton Imageurl="~/imz/save.png" runat="server" CommandName="Save" ToolTip="Save" Width="20px" Height="20px" />
                        <asp:ImageButton Imageurl="~/imz/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                   </EditItemTemplate>
                   
                   <FooterTemplate>
                       <asp:ImageButton Imageurl="~/imz/add.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px" />
                   </FooterTemplate>

               </asp:TemplateField>
           </Columns>


        </asp:GridView>

        <br />
        <asp:Label ID="Lblsuccessmessage" Text="" runat="server" ForeColor="Green" />

                <br />
        <asp:Label ID="Lblerrormessage" Text="" runat="server" ForeColor="Red" />

            </div>
    </form>
</body>
</html>
