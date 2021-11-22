﻿Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.Json
Imports System
Imports System.Web.Hosting

Namespace WebFormsDashboardDataSources.Pages
	Partial Public Class JsonDashboard
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboardJson.SetDashboardStorage(dashboardFileStorage)

			' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
			'ASPxDashboardJson.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

			ASPxDashboardJson.SetDataSourceStorage(CreateDataSourceStorage())
			AddHandler ASPxDashboardJson.ConfigureDataConnection, AddressOf ASPxDashboardJson_ConfigureDataConnection
			ASPxDashboardJson.InitialDashboardId = "dashboardJson"
		End Sub

		Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()
			' Registers a JSON data source from URL.
			Dim jsonDataSourceUrl As New DashboardJsonDataSource("JSON Data Source (URL)")
			jsonDataSourceUrl.JsonSource = New UriJsonSource(New Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/support.json"))
			jsonDataSourceUrl.RootElement = "Employee"
			dataSourceStorage.RegisterDataSource("jsonDataSourceUrl", jsonDataSourceUrl.SaveToXml())

			' Registers a JSON data source from a JSON file.
			Dim jsonDataSourceFile As New DashboardJsonDataSource("JSON Data Source (File)")
			jsonDataSourceFile.ConnectionName = "jsonConnection"
			jsonDataSourceFile.RootElement = "Customers"
			dataSourceStorage.RegisterDataSource("jsonDataSourceFile", jsonDataSourceFile.SaveToXml())

			' Registers a JSON data source from JSON string.
			Dim jsonDataSourceString As New DashboardJsonDataSource("JSON Data Source (String)")
			Dim json As String = "{""Customers"":[{""Id"":""ALFKI"",""CompanyName"":""Alfreds Futterkiste"",""ContactName"":""Maria Anders"",""ContactTitle"":""Sales Representative"",""Address"":""Obere Str. 57"",""City"":""Berlin"",""PostalCode"":""12209"",""Country"":""Germany"",""Phone"":""030-0074321"",""Fax"":""030-0076545""}],""ResponseStatus"":{}}"
			jsonDataSourceString.JsonSource = New CustomJsonSource(json)
			jsonDataSourceString.RootElement = "Customers"
			dataSourceStorage.RegisterDataSource("jsonDataSourceString", jsonDataSourceString.SaveToXml())

			Return dataSourceStorage
		End Function
		Private Sub ASPxDashboardJson_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			If e.ConnectionName = "jsonConnection" Then
				Dim fileUri As New Uri(HostingEnvironment.MapPath("~/App_Data/customers.json"), UriKind.RelativeOrAbsolute)
				Dim jsonParams As New JsonSourceConnectionParameters()
				jsonParams.JsonSource = New UriJsonSource(fileUri)
				e.ConnectionParameters = jsonParams
			End If
		End Sub
	End Class
End Namespace