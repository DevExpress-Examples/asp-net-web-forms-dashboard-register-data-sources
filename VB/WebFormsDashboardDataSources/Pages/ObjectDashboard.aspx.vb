Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports System

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class ObjectDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardObjectDS.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            'ASPxDashboardObjectDS.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ASPxDashboardObjectDS.SetDataSourceStorage(CreateDataSourceStorage())
            ASPxDashboardObjectDS.InitialDashboardId = "dashboardObjectDS"
            AddHandler ASPxDashboardObjectDS.DataLoading, AddressOf Me.ASPxDashboardObjectDS_DataLoading
        End Sub

        Private Function CreateDataSourceStorage() As DataSourceInMemoryStorage
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            Dim objDataSource As DashboardObjectDataSource = New DashboardObjectDataSource("Object Data Source")
            objDataSource.DataId = "objectDataSource"
            dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())
            Return dataSourceStorage
        End Function

        Private Sub ASPxDashboardObjectDS_DataLoading(ByVal sender As Object, ByVal e As DataLoadingWebEventArgs)
            If Equals(e.DataId, "objectDataSource") Then
                e.Data = Invoices.CreateData()
            End If
        End Sub
    End Class
End Namespace
