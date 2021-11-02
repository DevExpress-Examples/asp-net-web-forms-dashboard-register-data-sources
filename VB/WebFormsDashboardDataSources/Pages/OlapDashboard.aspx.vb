Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters
Imports System

Namespace WebFormsDashboardDataSources.Pages
	Partial Public Class OlapDashboard
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboardOlap.SetDashboardStorage(dashboardFileStorage)

			' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
			'ASPxDashboardOlap.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

			ASPxDashboardOlap.SetDataSourceStorage(CreateDataSourceStorage())
			ASPxDashboardOlap.InitialDashboardId = "dashboardOlap"
			AddHandler ASPxDashboardOlap.ConfigureDataConnection, AddressOf ASPxDashboardOlap_ConfigureDataConnection
		End Sub
		Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			' Registers an OLAP data source.
			Dim olapDataSource As New DashboardOlapDataSource("OLAP Data Source", "olapConnection")
			dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml())

			Return dataSourceStorage
		End Function
		Private Sub ASPxDashboardOlap_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			If e.ConnectionName = "olapConnection" Then
				Dim olapParams As New OlapConnectionParameters()
				olapParams.ConnectionString = "Provider=MSOLAP;Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" & "Initial catalog=Adventure Works DW Standard Edition;Cube name=Adventure Works;Query Timeout=100;"
				e.ConnectionParameters = olapParams
			End If
		End Sub
	End Class
End Namespace