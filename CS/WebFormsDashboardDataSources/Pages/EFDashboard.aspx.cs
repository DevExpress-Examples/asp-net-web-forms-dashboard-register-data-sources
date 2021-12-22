using System;
using System.Web.Hosting;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.EntityFramework;

namespace WebFormsDashboardDataSources.Pages {
    public partial class EFDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardEf.SetDashboardStorage(dashboardFileStorage);

            // Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            //ASPxDashboardEf.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            // Create a data source storage.
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Register an Entity Framework data source.
            DashboardEFDataSource efDataSource = new DashboardEFDataSource("EF Data Source");
            efDataSource.ConnectionParameters = new EFConnectionParameters(typeof(OrdersContext));
            dataSourceStorage.RegisterDataSource("efDataSource", efDataSource.SaveToXml());

            // Set the configured data source storage.
            ASPxDashboardEf.SetDataSourceStorage(dataSourceStorage);
            
            ASPxDashboardEf.InitialDashboardId = "dashboardEf";
        }
    }
}
