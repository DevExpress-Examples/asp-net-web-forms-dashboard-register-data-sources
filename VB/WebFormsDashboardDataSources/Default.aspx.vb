﻿Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.EntityFramework
Imports DevExpress.DataAccess.Excel
Imports DevExpress.DataAccess.Json
Imports DevExpress.DataAccess.Sql
Imports DevExpress.Security.Resources
Imports System
Imports System.Web.Hosting

Namespace WebFormsDashboardDataSources
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboard1.SetDashboardStorage(dashboardFileStorage)

			' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
			'ASPxDashboard1.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

			Dim dataSourceStorage As New DataSourceInMemoryStorage()


			ASPxDashboard1.SetDataSourceStorage(CreateDataSourceStorage())

			AddHandler ASPxDashboard1.ConfigureDataConnection, AddressOf ASPxDashboard1_ConfigureDataConnection

			AccessSettings.DataResources.TrySetRules(UrlAccessRule.Allow(),DirectoryAccessRule.Allow())

			AddHandler ASPxDashboard1.DataLoading, AddressOf ASPxDashboard1_DataLoading
		End Sub

		Private Sub ASPxDashboard1_DataLoading(ByVal sender As Object, ByVal e As DataLoadingWebEventArgs)
			If e.DataSourceName.Contains("Object Data Source") Then
				e.Data = Invoices.CreateData()
			End If
		End Sub

		Private Sub ASPxDashboard1_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			Select Case e.ConnectionName

				Case "olapConnection"
				Dim olapParams As New OlapConnectionParameters()
				olapParams.ConnectionString = "Provider=MSOLAP;Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" & "Initial catalog=Adventure Works DW Standard Edition;Cube name=Adventure Works;Query Timeout=100;"
				e.ConnectionParameters = olapParams

				Case "jsonConnection"
				Dim fileUri As New Uri(HostingEnvironment.MapPath("~/App_Data/customers.json"), UriKind.RelativeOrAbsolute)
				Dim jsonParams As New JsonSourceConnectionParameters()
				jsonParams.JsonSource = New UriJsonSource(fileUri)
				e.ConnectionParameters = jsonParams
			End Select
			If e.DataSourceName.Contains("Extract Data Source") Then
				Dim extractParams As New ExtractDataSourceConnectionParameters()
				extractParams.FileName = HostingEnvironment.MapPath("~/App_Data/SalesPersonExtract.dat")
				e.ConnectionParameters = extractParams
			End If
			If e.DataSourceName.Contains("Excel Data Source") Then
				Dim excelParams As New ExcelDataSourceConnectionParameters(HostingEnvironment.MapPath("~/App_Data/Sales.xlsx"))
				e.ConnectionParameters = excelParams
			End If
		End Sub

		Public Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			' Registers an SQL data source.
			Dim sqlDataSource As New DashboardSqlDataSource("SQL Data Source", "NWindConnectionString")
			Dim query As SelectQuery = SelectQueryFluentBuilder.AddTable("SalesPerson").SelectAllColumnsFromTable().Build("Sales Person")
			sqlDataSource.Queries.Add(query)
			dataSourceStorage.RegisterDataSource("sqlDataSource", sqlDataSource.SaveToXml())

			' Registers an Object data source.
			Dim objDataSource As New DashboardObjectDataSource("Object Data Source")
			dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())

			' Registers an Excel data source.
			Dim excelDataSource As New DashboardExcelDataSource("Excel Data Source")
			excelDataSource.SourceOptions = New ExcelSourceOptions(New ExcelWorksheetSettings("Sheet1"))
			dataSourceStorage.RegisterDataSource("excelDataSource", excelDataSource.SaveToXml())

			' Registers an OLAP data source.
			Dim olapDataSource As New DashboardOlapDataSource("OLAP Data Source", "olapConnection")
			dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml())

			' Registers an Entity Framework data source.
			Dim efDataSource As New DashboardEFDataSource("EF Core Data Source")
			efDataSource.ConnectionParameters = New EFConnectionParameters(GetType(OrdersContext))
			dataSourceStorage.RegisterDataSource("efDataSource", efDataSource.SaveToXml())

			' Registers an Extract data source.
			Dim extractDataSource As New DashboardExtractDataSource("Extract Data Source")
			extractDataSource.Name = "Extract Data Source"
			dataSourceStorage.RegisterDataSource("extractDataSource ", extractDataSource.SaveToXml())

			' Registers a JSON data source from URL.
			Dim jsonDataSourceUrl As New DashboardJsonDataSource("JSON Data Source (URL)")
			jsonDataSourceUrl.JsonSource = New UriJsonSource(New Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"))
			jsonDataSourceUrl.RootElement = "Customers"
			jsonDataSourceUrl.Fill()
			dataSourceStorage.RegisterDataSource("jsonDataSourceUrl", jsonDataSourceUrl.SaveToXml())

			' Registers a JSON data source from a JSON file.
			Dim jsonDataSourceFile As New DashboardJsonDataSource("JSON Data Source (File)")
			jsonDataSourceFile.ConnectionName = "jsonConnection"
			jsonDataSourceFile.RootElement = "Customers"
			jsonDataSourceFile.Fill()
			dataSourceStorage.RegisterDataSource("jsonDataSourceFile", jsonDataSourceFile.SaveToXml())

			' Registers a JSON data source from JSON string.
			Dim jsonDataSourceString As New DashboardJsonDataSource("JSON Data Source (String)")
			Dim json As String = "{""Customers"":[{""Id"":""ALFKI"",""CompanyName"":""Alfreds Futterkiste"",""ContactName"":""Maria Anders"",""ContactTitle"":""Sales Representative"",""Address"":""Obere Str. 57"",""City"":""Berlin"",""PostalCode"":""12209"",""Country"":""Germany"",""Phone"":""030-0074321"",""Fax"":""030-0076545""}],""ResponseStatus"":{}}"
			jsonDataSourceString.JsonSource = New CustomJsonSource(json)
			jsonDataSourceString.RootElement = "Customers"
			jsonDataSourceString.Fill()
			dataSourceStorage.RegisterDataSource("jsonDataSourceString", jsonDataSourceString.SaveToXml())

			' Registers an XPO data source.
			Dim xpoDataSource As New DashboardXpoDataSource("XPO Data Source")
			xpoDataSource.ConnectionStringName = "NWindConnectionStringSQLite"
			xpoDataSource.SetEntityType(GetType(Category))
			dataSourceStorage.RegisterDataSource("xpoDataSource", xpoDataSource.SaveToXml())

			Return dataSourceStorage
		End Function
	End Class
End Namespace
