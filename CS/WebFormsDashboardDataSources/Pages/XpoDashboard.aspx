﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XpoDashboard.aspx.cs" Inherits="WebFormsDashboardDataSources.Pages.XpoDashboard" %>
<%@ Register Assembly="DevExpress.Dashboard.v20.2.Web.WebForms, Version=20.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: absolute; top: 0; bottom: 0; left: 0; right: 0">
            <dx:ASPxDashboard ID="ASPxDashboardXpo" runat="server" Width="100%" Height="100%">
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>
