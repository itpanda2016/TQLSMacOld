<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RuleEdit.aspx.cs" Inherits="BirthdayLunarWeb.Admin.RuleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#fm").submit(function () {
                if ($("#rulename").val() == "") {
                    alert("规则名称不能为空。");
                    $("#rulename").focus();
                    return false;
                }
                if ($("#rank").val() < 0) {
                    alert("权重值为 正整数。");
                    $("#rank").focus();
                    return false;
                }
                if ($("#msgvalue").val() == 0) {
                    alert("发送的消息还没有选择。");
                    $("#msgvalue").focus();
                    return false;
                }
            });
        })
        function CheckMsgType(e) {
            //alert($(e).attr("value"));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="fm" action="RuleAct.aspx" method="post">
        <div class="form-inline">
            <label for="rulename">规则名称</label>
            <input type="text" class="form-control" id="rulename" name="rulename" value="<%=rule.RuleName %>" />
        </div>
        <div class="form-inline">
            <label for="rank">规则权重</label>
            <%--<input type="text" class="form-control" id="rank" name="rank" value="" />--%>
            <select id="rank" name="rank" class="form-control">
                <option value="-1">--请选择--</option>
                <%
                    for (int i = 0; i <= rankFW; i++) {
                        if (rule.Rank == i)
                            Response.Write("<option value=\"" + i + "\" selected=\"selected\">" + i + "</option>");
                        else
                            Response.Write("<option value=\"" + i + "\">" + i + "</option>");
                    }
                %>
            </select>
            <span class="alert-danger">权重越小，优先级越高，系统发送消息时，会从权重值小的开始匹配规则。</span>
        </div>
        <%--<p class="alert alert-info">权重越小，优先级越高，系统发送消息时，会从权重值小的开始匹配规则。</p>--%>
        <hr />
        <label>消息类型</label>
        <%
            if (mCount != null) {
        %>
        <div class="radio">
            <label class="radio-inline">
                <input onclick="CheckMsgType(this)" type="radio" checked="checked" name="msgtyle" value="mpnews" <%if (mCount.mpnews_count == 0) { %> disabled="disabled" <%} %> />
                图文（<%=mCount.mpnews_count %>）
            </label>
            <%--            <label class="radio-inline">
                <input type="radio" name="msgtyle" value="video" <%if (mCount.video_count == 0) { %> disabled="disabled" <%} %> />
                视频（<%=mCount.video_count %>）
            </label>--%>
        </div>
        <%
            }
        %>
        <%--<div id="divText">
                <label>消息内容</label>
                <textarea class="form-control" rows="4" cols="15" name="msgvalue"></textarea>
            </div>--%>
        <div id="divMpnews">
            <%
                if (mpnewsList.itemlist.Length > 0) {
            %>
            <select class="form-control" name="msgvalue" id="msgvalue">
                <%
                    foreach (var item in mpnewsList.itemlist) {
                        if (rule.MsgValue == item.media_id) {
                %>
                <option selected="selected" value="<%=item.media_id %>"><%=item.content.articles[0].title %></option>
                <%}
                    else { %>
                <option value="<%=item.media_id %>"><%=item.content.articles[0].title %></option>
                <%
                    } %>
                <!--下面这一段直接放在发送消息那儿去获取，这儿不要-->
                <%--                    <%
                        foreach (var itemChild in item.content.articles) {
                    %>
                    <label id="mpnewsID"><%=itemChild.title %></label>
                    <%
                        }
                    %>--%>

                <%
                    }
                %>
            </select>
            <%
                } %>
        </div>

        <!--视频注释开始
        <div id="divOther" class="form-inline">
            <label>选择消息</label>
            <select class="form-control" name="msgvalue" id="msgvalue22">
                <option value="0">--请选择--</option>
                <%
            if (mList.errcode == 0) {
                foreach (var item in mList.itemlist) {
                    if (rule != null && rule.MsgValue == item.media_id) {
                %>
                <option selected="selected" value="<%=item.media_id %>">上传时间：<%=Common.Utility.UnixTimeToTime(item.update_time.ToString()).ToString("yyyy-MM-dd hh:mm:ss") %>|文件名：<%=item.filename %></option>

                <%
            }
            else {
                %>
                <option value="<%=item.media_id %>">上传时间：<%=Common.Utility.UnixTimeToTime(item.update_time.ToString()).ToString("yyyy-MM-dd hh:mm:ss") %>|文件名：<%=item.filename %></option>
                <%--<option value="2veOFPHPB2oJJ-SFdMF9UoYQkMnJf8gBGHde2huXkZ_syoA3P75D6RxoQCL5AeuPfGhE89AnOZDSyGTQBhnHxtA">消息ID</option>--%>
                <%
                    }
                }
            } %>
            </select>
        </div>
        <div class="form-inline">
            <label>消息标题</label>
            <input type="text" class="form-control" name="videotitle" maxlength="128" id="videotitle" value="<%=rule.VideoTitle %>" />
        </div>
        <div class="form-inline">
            <label>消息描述</label>
            <textarea class="form-control" rows="4" cols="55" name="videodescription" id="videodescription" maxlength="512"><%=rule.VideoDescription %></textarea>
        </div>
        视频暂时注释end-->

        <hr />
        <div id="filter" class="form-inline">
            <label>指定标签</label>
            <%--<select class="form-control" name="ruletype">
                    <option value="0">--请选择--</option>
                    <option value="tag">标签</option>
                </select>--%>
            <select class="form-control" name="rulevalue">
                <option value="0">--请选择--</option>
                <%
                    if (tagList.errcode == 0) {
                        foreach (var item in tagList.taglist) {
                            if (Convert.ToInt32(rule.RuleValue) == item.tagid) {
                %>
                <option selected="selected" value="<%=item.tagid %>"><%=item.tagname %>（<%=item.tagid %>）</option>
                <%
                    }
                    else {
                %>
                <option value="<%=item.tagid %>"><%=item.tagname %>（<%=item.tagid %>）</option>
                <%
                            }
                        }
                    } %>
                <%--<option value="20">大客户标签</option>--%>
            </select>
        </div>
        <div class="form-inline">
            <input type="hidden" name="act" value="<%=act %>" />
            <input type="hidden" name="id" value="<%=rule.ID %>" />
            <input type="submit" id="btnSave" value="保存" class="btn btn-success" />
        </div>
    </form>
</asp:Content>
