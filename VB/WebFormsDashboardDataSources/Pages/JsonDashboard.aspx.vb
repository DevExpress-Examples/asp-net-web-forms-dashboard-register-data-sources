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
            ' Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            'ASPxDashboardJson.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Create a data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Register a JSON data source from a URL.
            Dim jsonDataSourceUrl As DashboardJsonDataSource = New DashboardJsonDataSource("JSON Data Source (URL)")
            jsonDataSourceUrl.ConnectionName = "jsonUrlConnection"
            jsonDataSourceUrl.RootElement = "Employee"
            dataSourceStorage.RegisterDataSource("jsonDataSourceUrl", jsonDataSourceUrl.SaveToXml())
            ' Register a JSON data source from a JSON file.
            Dim jsonDataSourceFile As DashboardJsonDataSource = New DashboardJsonDataSource("JSON Data Source (File)")
            jsonDataSourceFile.ConnectionName = "jsonFileConnection"
            jsonDataSourceFile.RootElement = "Customers"
            dataSourceStorage.RegisterDataSource("jsonDataSourceFile", jsonDataSourceFile.SaveToXml())
            ' Register a JSON data source from a JSON string.
            Dim jsonDataSourceString As DashboardJsonDataSource = New DashboardJsonDataSource("JSON Data Source (String)")
            jsonDataSourceString.ConnectionName = "jsonStringConnection"
            jsonDataSourceString.RootElement = "Customers"
            dataSourceStorage.RegisterDataSource("jsonDataSourceString", jsonDataSourceString.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardJson.SetDataSourceStorage(dataSourceStorage)
            AddHandler ASPxDashboardJson.ConfigureDataConnection, AddressOf Me.ASPxDashboardJson_ConfigureDataConnection
            ASPxDashboardJson.InitialDashboardId = "dashboardJson"
        End Sub

        Private Sub ASPxDashboardJson_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
            If Equals(e.ConnectionName, "jsonUrlConnection") Then
                Dim jsonParams As JsonSourceConnectionParameters = New JsonSourceConnectionParameters()
                jsonParams.JsonSource = New UriJsonSource(New Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/support.json"))
                e.ConnectionParameters = jsonParams
            End If

            If Equals(e.ConnectionName, "jsonFileConnection") Then
                Dim fileUri As Uri = New Uri(HostingEnvironment.MapPath("~/App_Data/customers.json"), UriKind.RelativeOrAbsolute)
                Dim jsonParams As JsonSourceConnectionParameters = New JsonSourceConnectionParameters()
                jsonParams.JsonSource = New UriJsonSource(fileUri)
                e.ConnectionParameters = jsonParams
            End If

            If Equals(e.ConnectionName, "jsonStringConnection") Then
                Dim json As String = "{""Customers"":[{""Id"":""ALFKI"",""CompanyName"":""Alfreds Futterkiste"",""ContactName"":""Maria Anders"",""ContactTitle"":""Sales Representative"",""Address"":""Obere Str. 57"",""City"":""Berlin"",""PostalCode"":""12209"",""Country"":""Germany"",""Phone"":""030-0074321"",""Fax"":""030-0076545""}],""ResponseStatus"":{}}"
                Dim jsonParams As JsonSourceConnectionParameters = New JsonSourceConnectionParameters()
                jsonParams.JsonSource = New CustomJsonSource(json)
                e.ConnectionParameters = jsonParams
            End If
        End Sub
    End Class
End Namespace
