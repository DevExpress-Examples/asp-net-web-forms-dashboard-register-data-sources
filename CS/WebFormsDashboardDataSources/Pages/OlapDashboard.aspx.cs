using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using System;

namespace WebFormsDashboardDataSources.Pages {
    public partial class OlapDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardOlap.SetDashboardStorage(dashboardFileStorage);

            // Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            //ASPxDashboardOlap.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            // Create data source storage.
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Register an OLAP data source.
            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource("OLAP Data Source", "olapConnection");
            dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml());

            // Set the configured data source storage.
            ASPxDashboardOlap.SetDataSourceStorage(dataSourceStorage);

            ASPxDashboardOlap.ConfigureDataConnection += ASPxDashboardOlap_ConfigureDataConnection;

            ASPxDashboardOlap.InitialDashboardId = "dashboardOlap";
        }
        private void ASPxDashboardOlap_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "olapConnection") {
                OlapConnectionParameters olapParams = new OlapConnectionParameters();
                olapParams.ConnectionString = "Provider=MSOLAP;Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;"
                    + "Initial catalog=Adventure Works DW Standard Edition;Cube name=Adventure Works;Query Timeout=100;";
                e.ConnectionParameters = olapParams;
            }         
        }
    }
}