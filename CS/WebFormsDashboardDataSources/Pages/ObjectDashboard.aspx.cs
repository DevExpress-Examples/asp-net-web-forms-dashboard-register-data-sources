using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using System;

namespace WebFormsDashboardDataSources.Pages {
    public partial class ObjectDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardObjectDS.SetDashboardStorage(dashboardFileStorage);

            // Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            //ASPxDashboardObjectDS.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            ASPxDashboardObjectDS.SetDataSourceStorage(CreateDataSourceStorage());
            ASPxDashboardObjectDS.InitialDashboardId = "dashboardObjectDS";
            ASPxDashboardObjectDS.DataLoading += ASPxDashboardObjectDS_DataLoading;
        }
        private DataSourceInMemoryStorage CreateDataSourceStorage() {
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Object Data Source");
            objDataSource.DataId = "objectDataSource";
            dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml());

            return dataSourceStorage;
        }

        private void ASPxDashboardObjectDS_DataLoading(object sender, DataLoadingWebEventArgs e) {
            if (e.DataId == "objectDataSource") {
                e.Data = Invoices.CreateData();
            }
        }
    }
}