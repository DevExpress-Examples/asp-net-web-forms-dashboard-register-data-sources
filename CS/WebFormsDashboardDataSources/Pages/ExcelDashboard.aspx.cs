﻿using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Excel;
using System;
using System.Web.Hosting;

namespace WebFormsDashboardDataSources.Pages {
    public partial class ExcelDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardExcel.SetDashboardStorage(dashboardFileStorage);

            // Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            //ASPxDashboardExcel.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            ASPxDashboardExcel.SetDataSourceStorage(CreateDataSourceStorage());
            ASPxDashboardExcel.ConfigureDataConnection += ASPxDashboardExcel_ConfigureDataConnection;
            ASPxDashboardExcel.InitialDashboardId = "dashboardExcel";
        }

        private void ASPxDashboardExcel_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "excelDataConnection") {
                var excelParams = new ExcelDataSourceConnectionParameters(HostingEnvironment.MapPath(@"~/App_Data/Sales.xlsx"));
                e.ConnectionParameters = excelParams;
            }
        }
        private DataSourceInMemoryStorage CreateDataSourceStorage() {
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Registers an Excel data source.
            DashboardExcelDataSource excelDataSource = new DashboardExcelDataSource("Excel Data Source");
            excelDataSource.ConnectionName = "excelDataConnection";
            excelDataSource.SourceOptions = new ExcelSourceOptions(new ExcelWorksheetSettings("Sheet1"));
            dataSourceStorage.RegisterDataSource("excelDataSource", excelDataSource.SaveToXml());

            return dataSourceStorage;
        }
    }
}