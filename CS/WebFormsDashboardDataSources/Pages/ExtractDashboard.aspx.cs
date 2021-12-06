using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using System;
using System.Web.Hosting;

namespace WebFormsDashboardDataSources.Pages {
    public partial class ExtractDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardExtract.SetDashboardStorage(dashboardFileStorage);

            // Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            //ASPxDashboardExtract.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            // Create data source storage.
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Register an Extract data source.
            DashboardExtractDataSource extractDataSource = new DashboardExtractDataSource("Extract Data Source");
            extractDataSource.ConnectionName = "extractDataConnection";
            dataSourceStorage.RegisterDataSource("extractDataSource ", extractDataSource.SaveToXml());

            // Set the configured data source storage.
            ASPxDashboardExtract.SetDataSourceStorage(dataSourceStorage);

            ASPxDashboardExtract.ConfigureDataConnection += ASPxDashboardExtract_ConfigureDataConnection;
            ASPxDashboardExtract.InitialDashboardId = "dashboardExtract";
        }

        private void ASPxDashboardExtract_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "extractDataConnection") {
                ExtractDataSourceConnectionParameters extractParams = new ExtractDataSourceConnectionParameters();
                extractParams.FileName = HostingEnvironment.MapPath(@"~/App_Data/SalesPersonExtract.dat");
                e.ConnectionParameters = extractParams;
            }
        }
    }
}