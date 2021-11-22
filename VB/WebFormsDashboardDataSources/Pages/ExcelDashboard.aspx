﻿<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="ExcelDashboard.aspx.vb" Inherits="WebFormsDashboardDataSources.Pages.ExcelDashboard" %>
<%@ Register Assembly="DevExpress.Dashboard.v21.1.Web.WebForms, Version=21.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: absolute; top: 0; bottom: 0; left: 0; right: 0">
            <dx:ASPxDashboard ID="ASPxDashboardExcel" runat="server" Width="100%" Height="100%" WorkingMode="ViewerOnly">
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>