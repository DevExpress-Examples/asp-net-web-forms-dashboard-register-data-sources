Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports System

Namespace WebFormsDashboardDataSources.Pages
	Partial Public Class XpoDashboard
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboardXpo.SetDashboardStorage(dashboardFileStorage)

			' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
			'ASPxDashboardXpo.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

			ASPxDashboardXpo.SetDataSourceStorage(CreateDataSourceStorage())
			ASPxDashboardXpo.InitialDashboardId = "dashboardXpo"
		End Sub

		Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			' Registers an XPO data source.
			Dim xpoDataSource As New DashboardXpoDataSource("XPO Data Source")
			xpoDataSource.ConnectionStringName = "NWindConnectionStringSQLite"
			xpoDataSource.SetEntityType(GetType(Category))
			dataSourceStorage.RegisterDataSource("xpoDataSource", xpoDataSource.SaveToXml())

			Return dataSourceStorage
		End Function
	End Class
End Namespace