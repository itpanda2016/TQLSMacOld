<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BirthdayLunarWeb.Admin.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ConfigrmDelete(id) {
            if (confirm("是否确认删除？")) {
                location.href = "RuleAct.aspx?act=delete&id=" + id;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        if (dtRulelist == null) {
    %>
    <p>请添加规则。</p>
    <%
        }
        else {
    %>
    <asp:Repeater ID="rptRulelist" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <td>ID</td>
                    <td>规则名称</td>
                    <td>消息类型</td>
                    <td>消息ID</td>
                    <td>过滤类型</td>
                    <td>过滤值</td>
                    <td>权重</td>
                    <td>创建时间</td>
                    <td>操作</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("id") %></td>
                <td><%# Eval("rulename") %></td>
                <td><%# Eval("msgtype") %></td>
                <td></td>
                <td><%# Eval("ruletype") %></td>
                <td><%# Eval("rulevalue") %></td>
                <td><%# Eval("rank") %></td>
                <td><%# Eval("idtime") %></td>
                <td>
                    <a href="RuleEdit.aspx?act=edit&id=<%# Eval("id") %>">编辑</a> | 
                    <a onclick="ConfigrmDelete(<%# Eval("id") %>)" href="javascript:;">删除</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <%
        } %>
</asp:Content>
