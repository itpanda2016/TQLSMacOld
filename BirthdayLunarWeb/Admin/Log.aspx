<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="BirthdayLunarWeb.Admin.Log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptLogs" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <tr style="font-weight:bold;">
                    <td style="width:10%;">日志编号</td>
                    <td style="width:15%;">发送时间</td>
                    <td style="width:75%">备注</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><%# Eval("sendtime") %></td>
                <td><%# Eval("remark") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
