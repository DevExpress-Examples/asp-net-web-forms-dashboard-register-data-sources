using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using System;

namespace WebFormsDashboardDataSources.Pages {
    public partial class ObjectDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardObjectDS.SetDashboardStorage(dashboardFileStorage);

            // Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            //ASPxDashboardObjectDS.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            // Create data source storage.
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Register an Object data source.
            DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Object Data Source");
            objDataSource.DataId = "objectDataSource";
            dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml());

            // Set the configured data source storage.
            ASPxDashboardObjectDS.SetDataSourceStorage(dataSourceStorage);

            ASPxDashboardObjectDS.DataLoading += ASPxDashboardObjectDS_DataLoading;
            ASPxDashboardObjectDS.InitialDashboardId = "dashboardObjectDS";
        }

        private void ASPxDashboardObjectDS_DataLoading(object sender, DataLoadingWebEventArgs e) {
            if (e.DataId == "objectDataSource") {
                e.Data = Invoices.CreateData();
            }
        }
    }
}