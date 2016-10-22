<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="SiteConfig.aspx.cs" Inherits="BirthdayLunarWeb.Admin.SiteConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="fm" method="post" action="SiteConfigAct.aspx">
        <div class="form-inline">
            <label for="lbl1">发送时间：</label>
            <select name="sendtime" id="lbl1" class="form-control">
                <%
                    for (int i = 1; i <= 24; i++) {
                        if (sendhour != 0 && sendhour == i) {
                %>
                <option selected="selected" value="<%=i %>"><%=i %></option>
                <%
                    }
                    else {
                %>
                <option value="<%=i %>"><%=i %></option>
                <%
                        }
                    }
                %>
            </select>
            <span>24小时制</span>
        </div>
        <div class="form-inline">
            <input type="hidden" value="save" name="act" />
            <input type="submit" value="保存" name="btnSave" class="btn btn-primary" />
        </div>
    </form>
</asp:Content>
