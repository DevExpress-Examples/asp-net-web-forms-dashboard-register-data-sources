Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports System

Namespace WebFormsDashboardDataSources.Pages
	Partial Public Class ObjectDashboard
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboardObjectDS.SetDashboardStorage(dashboardFileStorage)

			' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
			'ASPxDashboardObjectDS.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

			ASPxDashboardObjectDS.SetDataSourceStorage(CreateDataSourceStorage())
			ASPxDashboardObjectDS.InitialDashboardId = "dashboardObjectDS"
			AddHandler ASPxDashboardObjectDS.DataLoading, AddressOf ASPxDashboardObjectDS_DataLoading
		End Sub
		Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			Dim objDataSource As New DashboardObjectDataSource("Object Data Source")
			dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())

			Return dataSourceStorage
		End Function

		Private Sub ASPxDashboardObjectDS_DataLoading(ByVal sender As Object, ByVal e As DataLoadingWebEventArgs)
			If e.DataSourceName.Contains("Object Data Source") Then
				e.Data = Invoices.CreateData()
			End If
		End Sub
	End Class
End Namespace