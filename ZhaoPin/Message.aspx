<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="ZhaoPin.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="Lib/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="Lib/bootstrap-3.3.5-dist/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Lib/bootstrap-3.3.5-dist/css/bootstrap.min.css" media="screen" />
</head>
<body class="container">
    <br />
    <div class="panel panel-success">
        <div class="panel-heading">
            <div class="panel-title">
                <p runat="server" id="msgTitle"></p>
            </div>
        </div>
        <div class="panel-body">
            <p runat="server" id="msgContent"></p>
            <p>
                <a href="javascript:;" runat="server" id="msgHref" title="">点击此处继续</a>
            </p>
        </div>
    </div>
</body>
</html>
