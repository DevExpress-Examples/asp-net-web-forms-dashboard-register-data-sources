Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports System
Imports System.Web.Hosting

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class ExtractDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardExtract.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            'ASPxDashboardExtract.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Creates data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Registers an Extract data source.
            Dim extractDataSource As DashboardExtractDataSource = New DashboardExtractDataSource("Extract Data Source")
            extractDataSource.ConnectionName = "extractDataConnection"
            dataSourceStorage.RegisterDataSource("extractDataSource ", extractDataSource.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardExtract.SetDataSourceStorage(dataSourceStorage)
            AddHandler ASPxDashboardExtract.ConfigureDataConnection, AddressOf Me.ASPxDashboardExtract_ConfigureDataConnection
            ASPxDashboardExtract.InitialDashboardId = "dashboardExtract"
        End Sub

        Private Sub ASPxDashboardExtract_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
            If Equals(e.ConnectionName, "extractDataConnection") Then
                Dim extractParams As ExtractDataSourceConnectionParameters = New ExtractDataSourceConnectionParameters()
                extractParams.FileName = HostingEnvironment.MapPath("~/App_Data/SalesPersonExtract.dat")
                e.ConnectionParameters = extractParams
            End If
        End Sub
    End Class
End Namespace
