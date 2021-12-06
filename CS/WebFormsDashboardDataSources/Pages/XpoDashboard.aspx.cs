using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using System;

namespace WebFormsDashboardDataSources.Pages {
    public partial class XpoDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardXpo.SetDashboardStorage(dashboardFileStorage);

            // Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            //ASPxDashboardXpo.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            // Create data source storage.
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Register an XPO data source.
            DashboardXpoDataSource xpoDataSource = new DashboardXpoDataSource("XPO Data Source");
            xpoDataSource.ConnectionStringName = "NWindConnectionStringSQLite";
            xpoDataSource.SetEntityType(typeof(Category));
            dataSourceStorage.RegisterDataSource("xpoDataSource", xpoDataSource.SaveToXml());

            // Set the configured data source storage.
            ASPxDashboardXpo.SetDataSourceStorage(dataSourceStorage);

            ASPxDashboardXpo.InitialDashboardId = "dashboardXpo";
        }
    }
}