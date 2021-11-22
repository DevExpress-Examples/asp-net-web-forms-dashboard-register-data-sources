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
            ASPxDashboardSql.SetDataSourceStorage(CreateDataSourceStorage())
            ASPxDashboardSql.InitialDashboardId = "dashboardSql"
        End Sub

        Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Registers an SQL data source.
            Dim sqlDataSource As DashboardSqlDataSource = New DashboardSqlDataSource("SQL Data Source", "NWindConnectionString")
            Dim query As SelectQuery = SelectQueryFluentBuilder.AddTable("SalesPerson").SelectAllColumnsFromTable().Build("Sales Person")
            sqlDataSource.Queries.Add(query)
            dataSourceStorage.RegisterDataSource("sqlDataSource", sqlDataSource.SaveToXml())
            Return dataSourceStorage
        End Function
    End Class
End Namespace
