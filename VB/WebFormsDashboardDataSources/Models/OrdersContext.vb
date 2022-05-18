Imports System.Data.Entity

Namespace WebFormsDashboardDataSources

    Public Partial Class OrdersContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=OrdersContext")
        End Sub

        Public Overridable Property OrderDetails As DbSet(Of OrderDetail)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of OrderDetail)().Property(Function(e) e.UnitPrice).HasPrecision(10, 4)
        End Sub
    End Class
End Namespace
