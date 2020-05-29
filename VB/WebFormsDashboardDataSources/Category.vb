Imports DevExpress.Xpo

Namespace WebFormsDashboardDataSources
	<Persistent("Categories"), DeferredDeletion(False)>
	Public Class Category
		Inherits XPCustomObject

'INSTANT VB NOTE: The field categoryId was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private categoryId_Conflict As Integer
'INSTANT VB NOTE: The field categoryName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private categoryName_Conflict As String
'INSTANT VB NOTE: The field description was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private description_Conflict As String
		<Key>
		Public Property CategoryID() As Integer
			Get
				Return categoryId_Conflict
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("CategoryID", categoryId_Conflict, value)
			End Set
		End Property
		Public Property CategoryName() As String
			Get
				Return categoryName_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CategoryName", categoryName_Conflict, value)
			End Set
		End Property
		Public Property Description() As String
			Get
				Return description_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Description", description_Conflict, value)
			End Set
		End Property
	End Class
End Namespace
