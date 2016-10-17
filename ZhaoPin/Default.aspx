<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ZhaoPin.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>铁骑力士集团-新建简历</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="Lib/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="Lib/bootstrap-3.3.5-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Lib/Frost.js"></script>
    <link rel="stylesheet" href="Lib/bootstrap-3.3.5-dist/css/bootstrap.min.css" media="screen" />
</head>
<body class="container">
    <!--<p class="alert alert-danger">系统升级，请稍后访问</p>-->
    <br />
    <p class="alert alert-info alert1">注意：如您的简历通过筛选，HR将通过简历上的联系方式与您联系。</p>
    <form class="form-horizontal" action="HandlerAction.ashx" method="post" id="zp" onsubmit="xyr_CheckInput()">
        <div class="form-group">
            <label for="resumes_name" class="col-sm-2 control-label">姓名：</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="resumes_name" name="name" title="姓名" />
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_mobile" class="col-sm-2 control-label">手机：</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="resumes_mobile" name="mobile" title="手机" />
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_email" class="col-sm-2 control-label">邮箱：</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="resumes_email" name="email" title="邮箱" />
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_school" class="col-sm-2 control-label">毕业院校：</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="resumes_school" name="school" title="毕业院校" placeholder="毕（在）业（读）院校" />
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_education" class="col-sm-2 control-label">学历：</label>
            <div class="col-sm-10">
                <select id="resumes_education" name="education" class="form-control" title="学历">
                    <option value="" selected="selected">--请选择--</option>
                    <option value="大专">大专</option>
                    <option value="本科">本科</option>
                    <option value="研究生">研究生</option>
                    <option value="硕士">硕士</option>
                    <option value="博士">博士</option>
                    <option value="其他">其他</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_work_year" class="col-sm-2 control-label">工作年限：</label>
            <div class="col-sm-10">
                <select id="resumes_work_year" name="workyear" class="form-control" title="工作年限">
                    <option value="" selected="selected">--请选择--</option>
                    <option value="学生">学生</option>
                    <option value="1-3年">1-3年</option>
                    <option value="3-5年">3-5年</option>
                    <option value="5-8年">5-8年</option>
                    <option value="8年以上">8年以上</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_now_company" class="col-sm-2 control-label">当前公司：</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="resumes_now_company" name="companynow" placeholder="如无可留空" />
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_now_position" class="col-sm-2 control-label">当前职位：</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="resumes_now_position" name="positionnow" placeholder="如无可留空" />
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_area" class="col-sm-2 control-label">应聘区域：</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="resumes_area" name="area" title="应聘区域" />
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_position" class="col-sm-2 control-label">应聘职位：</label>
            <div class="col-sm-10">
                <select name="position" id="resumes_position" class="form-control" title="应聘职位">
                    <option value="" selected="selected">--请选择--</option>
                    <%
                        foreach (var item in position) {
                    %>
                    <option value="<%=item %>"><%=item %></option>
                    <%
                        }
                    %>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label for="resumes_summary" class="col-sm-2 control-label">自我简介：</label>
            <div class="col-sm-10">
                <textarea class="form-control" id="resumes_summary" name="summary" rows="4" title="自我简介"></textarea>
            </div>
        </div>
        <input type="hidden" name="post_token" value="" />
        <input type="hidden" name="act" value="add" />
        <div class="text-center">
            <input type="button" class="btn btn-success btn-block" id="btn_post" value="保存" />
        </div>
    </form>
    <footer class="footer text-center">
        <p>Support by TQLS Information Centre.</p>
    </footer>
    <script type="text/javascript">
        $(function () {
            $("#btn_post").click(function () {
                if (xyr_CheckInput()) {
                    if (xyr_IsMobile("resumes_mobile")) {
                        $("#zp").submit();
                    }
                }
            });
        })
    </script>
</body>
</html>
