using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Sql;
using System;

namespace WebFormsDashboardDataSources.Pages {
    public partial class SqlDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardSql.SetDashboardStorage(dashboardFileStorage);

            // Uncomment this string to allow end users to create new data sources based on predefined connection strings.
            //ASPxDashboardSql.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            // Create data source storage.
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Register an SQL data source.
            DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("SQL Data Source", "NWindConnectionString");
            SelectQuery query = SelectQueryFluentBuilder
                .AddTable("SalesPerson")
                .SelectAllColumnsFromTable()
                .Build("Sales Person");
            sqlDataSource.Queries.Add(query);
            dataSourceStorage.RegisterDataSource("sqlDataSource", sqlDataSource.SaveToXml());

            // Set the configured data source storage.
            ASPxDashboardSql.SetDataSourceStorage(dataSourceStorage);

            ASPxDashboardSql.InitialDashboardId = "dashboardSql";
        }
    }
}