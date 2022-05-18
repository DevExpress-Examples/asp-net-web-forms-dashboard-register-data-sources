Imports System
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.EntityFramework

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class EFDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardEf.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            'ASPxDashboardEf.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Create a data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Register an Entity Framework data source.
            Dim efDataSource As DashboardEFDataSource = New DashboardEFDataSource("EF Core Data Source")
            efDataSource.ConnectionParameters = New EFConnectionParameters(GetType(OrdersContext))
            dataSourceStorage.RegisterDataSource("efDataSource", efDataSource.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardEf.SetDataSourceStorage(dataSourceStorage)
            ASPxDashboardEf.InitialDashboardId = "dashboardEf"
        End Sub
    End Class
End Namespace
