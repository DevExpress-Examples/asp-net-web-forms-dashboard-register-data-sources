Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports System

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class XpoDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardXpo.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            'ASPxDashboardXpo.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Creates data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Registers an XPO data source.
            Dim xpoDataSource As DashboardXpoDataSource = New DashboardXpoDataSource("XPO Data Source")
            xpoDataSource.ConnectionStringName = "NWindConnectionStringSQLite"
            xpoDataSource.SetEntityType(GetType(Category))
            dataSourceStorage.RegisterDataSource("xpoDataSource", xpoDataSource.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardXpo.SetDataSourceStorage(dataSourceStorage)
            ASPxDashboardXpo.InitialDashboardId = "dashboardXpo"
        End Sub
    End Class
End Namespace
