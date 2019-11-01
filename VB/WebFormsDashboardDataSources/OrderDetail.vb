Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations

Namespace WebFormsDashboardDataSources

	Partial Public Class OrderDetail
		<Key>
		<Column(Order := 0)>
		<DatabaseGenerated(DatabaseGeneratedOption.None)>
		Public Property OrderID() As Integer

		<Column(Order := 1)>
		<DatabaseGenerated(DatabaseGeneratedOption.None)>
		Public Property Quantity() As Short

		<Column(Order := 2, TypeName := "smallmoney")>
		Public Property UnitPrice() As Decimal

		<Column(Order := 3)>
		Public Property Discount() As Single

		<Column(Order := 4)>
		<StringLength(40)>
		Public Property ProductName() As String

		<StringLength(217)>
		Public Property Supplier() As String
	End Class
End Namespace
