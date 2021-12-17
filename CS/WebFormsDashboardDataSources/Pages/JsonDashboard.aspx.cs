using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Json;
using System;
using System.Web.Hosting;

namespace WebFormsDashboardDataSources.Pages {
    public partial class JsonDashboard : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardJson.SetDashboardStorage(dashboardFileStorage);

            // Uncomment the next line to allow users to create new data sources based on predefined connection strings.
            //ASPxDashboardJson.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());

            // Create a data source storage.
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Register a JSON data source from URL.
            DashboardJsonDataSource jsonDataSourceUrl = new DashboardJsonDataSource("JSON Data Source (URL)");
            jsonDataSourceUrl.JsonSource = new UriJsonSource(new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/support.json"));
            jsonDataSourceUrl.RootElement = "Employee";
            dataSourceStorage.RegisterDataSource("jsonDataSourceUrl", jsonDataSourceUrl.SaveToXml());

            // Register a JSON data source from a JSON file.
            DashboardJsonDataSource jsonDataSourceFile = new DashboardJsonDataSource("JSON Data Source (File)");
            jsonDataSourceFile.ConnectionName = "jsonConnection";
            jsonDataSourceFile.RootElement = "Customers";
            dataSourceStorage.RegisterDataSource("jsonDataSourceFile", jsonDataSourceFile.SaveToXml());

            // Register a JSON data source from a JSON string.
            DashboardJsonDataSource jsonDataSourceString = new DashboardJsonDataSource("JSON Data Source (String)");
            string json = "{\"Customers\":[{\"Id\":\"ALFKI\",\"CompanyName\":\"Alfreds Futterkiste\",\"ContactName\":\"Maria Anders\",\"ContactTitle\":\"Sales Representative\",\"Address\":\"Obere Str. 57\",\"City\":\"Berlin\",\"PostalCode\":\"12209\",\"Country\":\"Germany\",\"Phone\":\"030-0074321\",\"Fax\":\"030-0076545\"}],\"ResponseStatus\":{}}";
            jsonDataSourceString.JsonSource = new CustomJsonSource(json);
            jsonDataSourceString.RootElement = "Customers";
            dataSourceStorage.RegisterDataSource("jsonDataSourceString", jsonDataSourceString.SaveToXml());

            // Set the configured data source storage.
            ASPxDashboardJson.SetDataSourceStorage(dataSourceStorage);

            ASPxDashboardJson.ConfigureDataConnection += ASPxDashboardJson_ConfigureDataConnection;

            ASPxDashboardJson.InitialDashboardId = "dashboardJson";
        }
        private void ASPxDashboardJson_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "jsonConnection") {
                Uri fileUri = new Uri(HostingEnvironment.MapPath(@"~/App_Data/customers.json"), UriKind.RelativeOrAbsolute);
                JsonSourceConnectionParameters jsonParams = new JsonSourceConnectionParameters();
                jsonParams.JsonSource = new UriJsonSource(fileUri);
                e.ConnectionParameters = jsonParams;
            }
        }
    }
}
