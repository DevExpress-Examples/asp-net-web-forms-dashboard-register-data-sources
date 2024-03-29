Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.Excel
Imports System
Imports System.Web.Hosting

Namespace WebFormsDashboardDataSources.Pages

    Public Partial Class ExcelDashboard
        Inherits Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As DashboardFileStorage = New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardExcel.SetDashboardStorage(dashboardFileStorage)
            ' Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            'ASPxDashboardExcel.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
            ' Create a data source storage.
            Dim dataSourceStorage As DataSourceInMemoryStorage = New DataSourceInMemoryStorage()
            ' Register an Excel data source.
            Dim excelDataSource As DashboardExcelDataSource = New DashboardExcelDataSource("Excel Data Source")
            excelDataSource.ConnectionName = "excelDataConnection"
            excelDataSource.SourceOptions = New ExcelSourceOptions(New ExcelWorksheetSettings("Sheet1"))
            dataSourceStorage.RegisterDataSource("excelDataSource", excelDataSource.SaveToXml())
            ' Set the configured data source storage.
            ASPxDashboardExcel.SetDataSourceStorage(dataSourceStorage)
            AddHandler ASPxDashboardExcel.ConfigureDataConnection, AddressOf Me.ASPxDashboardExcel_ConfigureDataConnection
            ASPxDashboardExcel.InitialDashboardId = "dashboardExcel"
        End Sub

        Private Sub ASPxDashboardExcel_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
            If Equals(e.ConnectionName, "excelDataConnection") Then
                Dim excelParams = New ExcelDataSourceConnectionParameters(HostingEnvironment.MapPath("~/App_Data/Sales.xlsx"))
                e.ConnectionParameters = excelParams
            End If
        End Sub
    End Class
End Namespace
