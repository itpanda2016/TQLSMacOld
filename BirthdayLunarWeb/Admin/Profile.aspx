<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BirthdayLunarWeb.Admin.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="fm" method="post" action="Profile.aspx">
        <div class="form-inline">
            <label for="newpassword">输入新密码</label>
            <input type="password" class="form-control" id="newpassword" name="newpassword" />
        </div>
        <div class="form-inline">
            <label for="cfpassword">确认新密码</label>
            <input type="password" class="form-control" id="cfpassword" name="cfpassword" />
        </div>
        <div class="form-inline">
            <input type="hidden" name="act" value="changepassword" />
            <input type="submit" id="btnSubmit" value="修改" />
        </div>
    </form>
</asp:Content>
