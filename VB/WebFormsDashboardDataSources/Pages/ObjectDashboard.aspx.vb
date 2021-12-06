Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports System

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class ObjectDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardObjectDS.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            'ASPxDashboardObjectDS.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Create data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Register an Object data source.
            Dim objDataSource As DashboardObjectDataSource = New DashboardObjectDataSource("Object Data Source")
            objDataSource.DataId = "objectDataSource"
            dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardObjectDS.SetDataSourceStorage(dataSourceStorage)
            AddHandler ASPxDashboardObjectDS.DataLoading, AddressOf Me.ASPxDashboardObjectDS_DataLoading
            ASPxDashboardObjectDS.InitialDashboardId = "dashboardObjectDS"
        End Sub

        Private Sub ASPxDashboardObjectDS_DataLoading(ByVal sender As Object, ByVal e As DataLoadingWebEventArgs)
            If Equals(e.DataId, "objectDataSource") Then
                e.Data = Invoices.CreateData()
            End If
        End Sub
    End Class
End Namespace
