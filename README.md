*Files to look at*:

* [Default.aspx.cs](./CS/WebFormsDashboardDataSources/Default.aspx.cs)
* [Default.aspx.vb](./VB/WebFormsDashboardDataSources/Default.aspx.vb)

## How to Register Data Sources for ASP.NET Web Forms Dashboard Control

The following example displays how to provide a Web Dashboard with a set of predefined data sources available for end users.

![](web-dashboard-data-sources.png)

Supported data sources:

- [SQL data source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardSqlDataSource/)
- [OLAP data source (XMLA only)](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardOLAPDataSource/)
- [Excel data source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardExcelDataSource/)
- [Object data source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardObjectDataSource/)
- [Entity Framework data source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardEFDataSource/)
- [Extract data source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardExtractDataSource/)
- [JSON data source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardJsonDataSource/)
- [XPO data source](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardXpoDataSource/)

The [ASPxDashboard.SetDataSourceStorage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.ASPxDashboard.SetDataSourceStorage(DevExpress.DashboardWeb.IDataSourceStorage)) method is used to register the added data sources in a data source storage. 
