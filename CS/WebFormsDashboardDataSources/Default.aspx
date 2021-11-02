<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsDashboardDataSources.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A list of dashboards</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Click to open a dashboard:</p>
            <ul>
                <li><a href="Pages/EFDashboard.aspx">Entity Framework</a></li>
                <li><a href="Pages/ExcelDashboard.aspx">Excel worksheet</a></li>
                <li><a href="Pages/ExtractDashboard.aspx">Data Extract</a></li>
                <li><a href="Pages/JsonDashboard.aspx">JSON</a></li>
                <li><a href="Pages/ObjectDashboard.aspx">Object</a></li>
                <li><a href="Pages/OlapDashboard.aspx">OLAP Cube</a></li>
                <li><a href="Pages/SqlDashboard.aspx">SQL Database</a></li>
                <li><a href="Pages/XpoDashboard.aspx">eXpress Persistent Objects (XPO)</a></li>
            </ul>
        </div>
    </form>
</body>
</html>
