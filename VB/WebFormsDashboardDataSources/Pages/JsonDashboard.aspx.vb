Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.Json
Imports System
Imports System.Web.Hosting

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class JsonDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardJson.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            'ASPxDashboardJson.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Creates data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Registers a JSON data source from URL.
            Dim jsonDataSourceUrl As DashboardJsonDataSource = New DashboardJsonDataSource("JSON Data Source (URL)")
            jsonDataSourceUrl.JsonSource = New UriJsonSource(New Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/support.json"))
            jsonDataSourceUrl.RootElement = "Employee"
            dataSourceStorage.RegisterDataSource("jsonDataSourceUrl", jsonDataSourceUrl.SaveToXml())
            ' Registers a JSON data source from a JSON file.
            Dim jsonDataSourceFile As DashboardJsonDataSource = New DashboardJsonDataSource("JSON Data Source (File)")
            jsonDataSourceFile.ConnectionName = "jsonConnection"
            jsonDataSourceFile.RootElement = "Customers"
            dataSourceStorage.RegisterDataSource("jsonDataSourceFile", jsonDataSourceFile.SaveToXml())
            ' Registers a JSON data source from JSON string.
            Dim jsonDataSourceString As DashboardJsonDataSource = New DashboardJsonDataSource("JSON Data Source (String)")
            Dim json As String = "{""Customers"":[{""Id"":""ALFKI"",""CompanyName"":""Alfreds Futterkiste"",""ContactName"":""Maria Anders"",""ContactTitle"":""Sales Representative"",""Address"":""Obere Str. 57"",""City"":""Berlin"",""PostalCode"":""12209"",""Country"":""Germany"",""Phone"":""030-0074321"",""Fax"":""030-0076545""}],""ResponseStatus"":{}}"
            jsonDataSourceString.JsonSource = New CustomJsonSource(json)
            jsonDataSourceString.RootElement = "Customers"
            dataSourceStorage.RegisterDataSource("jsonDataSourceString", jsonDataSourceString.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardJson.SetDataSourceStorage(dataSourceStorage)
            AddHandler ASPxDashboardJson.ConfigureDataConnection, AddressOf Me.ASPxDashboardJson_ConfigureDataConnection
            ASPxDashboardJson.InitialDashboardId = "dashboardJson"
        End Sub

        Private Sub ASPxDashboardJson_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
            If Equals(e.ConnectionName, "jsonConnection") Then
                Dim fileUri As Uri = New Uri(HostingEnvironment.MapPath("~/App_Data/customers.json"), UriKind.RelativeOrAbsolute)
                Dim jsonParams As JsonSourceConnectionParameters = New JsonSourceConnectionParameters()
                jsonParams.JsonSource = New UriJsonSource(fileUri)
                e.ConnectionParameters = jsonParams
            End If
        End Sub
    End Class
End Namespace
