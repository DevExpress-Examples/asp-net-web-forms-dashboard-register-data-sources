Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.Excel
Imports System
Imports System.Web.Hosting

Namespace WebFormsDashboardDataSources.Pages
	Partial Public Class ExcelDashboard
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboardExcel.SetDashboardStorage(dashboardFileStorage)

			' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
			'ASPxDashboardExcel.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

			ASPxDashboardExcel.SetDataSourceStorage(CreateDataSourceStorage())
			AddHandler ASPxDashboardExcel.ConfigureDataConnection, AddressOf ASPxDashboardExcel_ConfigureDataConnection
			ASPxDashboardExcel.InitialDashboardId = "dashboardExcel"
		End Sub

		Private Sub ASPxDashboardExcel_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			If e.ConnectionName = "excelDataConnection" Then
				Dim excelParams = New ExcelDataSourceConnectionParameters(HostingEnvironment.MapPath("~/App_Data/Sales.xlsx"))
				e.ConnectionParameters = excelParams
			End If
		End Sub
		Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			' Registers an Excel data source.
			Dim excelDataSource As New DashboardExcelDataSource("Excel Data Source")
			excelDataSource.ConnectionName = "excelDataConnection"
			excelDataSource.SourceOptions = New ExcelSourceOptions(New ExcelWorksheetSettings("Sheet1"))
			dataSourceStorage.RegisterDataSource("excelDataSource", excelDataSource.SaveToXml())

			Return dataSourceStorage
		End Function
	End Class
End Namespace