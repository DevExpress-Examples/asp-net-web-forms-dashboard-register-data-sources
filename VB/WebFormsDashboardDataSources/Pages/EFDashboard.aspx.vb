Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Hosting
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.EntityFramework

Namespace WebFormsDashboardDataSources.Pages
	Partial Public Class EFDashboard
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboardEf.SetDashboardStorage(dashboardFileStorage)

			' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
			'ASPxDashboardEf.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

			ASPxDashboardEf.SetDataSourceStorage(CreateDataSourceStorage())
			'ASPxDashboardEf.InitialDashboardId = "dashboardEf";

		End Sub
		Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			' Registers an Entity Framework data source.
			Dim efDataSource As New DashboardEFDataSource("EF Core Data Source")
			efDataSource.ConnectionParameters = New EFConnectionParameters(GetType(OrdersContext))
			dataSourceStorage.RegisterDataSource("efDataSource", efDataSource.SaveToXml())

			Return dataSourceStorage
		End Function
	End Class
End Namespace