Imports DevExpress.Xpo

Namespace WebFormsDashboardDataSources

    <Persistent("Categories"), DeferredDeletion(False)>
    Public Class Category
        Inherits XPCustomObject

        Private categoryIdField As Integer

        Private categoryNameField As String

        Private descriptionField As String

        <Key>
        Public Property CategoryID As Integer
            Get
                Return categoryIdField
            End Get

            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CategoryID", categoryIdField, value)
            End Set
        End Property

        Public Property CategoryName As String
            Get
                Return categoryNameField
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("CategoryName", categoryNameField, value)
            End Set
        End Property

        Public Property Description As String
            Get
                Return descriptionField
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", descriptionField, value)
            End Set
        End Property
    End Class
End Namespace
