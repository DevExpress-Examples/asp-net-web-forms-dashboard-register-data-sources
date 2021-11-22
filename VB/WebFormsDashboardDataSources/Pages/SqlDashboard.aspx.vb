Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.Sql
Imports System

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class SqlDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardSql.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            'ASPxDashboardSql.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Create data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Register an SQL data source.
            Dim sqlDataSource As DashboardSqlDataSource = New DashboardSqlDataSource("SQL Data Source", "NWindConnectionString")
            Dim query As SelectQuery = SelectQueryFluentBuilder.AddTable("SalesPerson").SelectAllColumnsFromTable().Build("Sales Person")
            sqlDataSource.Queries.Add(query)
            dataSourceStorage.RegisterDataSource("sqlDataSource", sqlDataSource.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardSql.SetDataSourceStorage(dataSourceStorage)
            ASPxDashboardSql.InitialDashboardId = "dashboardSql"
        End Sub
    End Class
End Namespace
