'Model data per group.

Public Class Model

    'Structures.
    Structure objVertex
        Dim xpos As Single
        Dim ypos As Single
        Dim zpos As Single
    End Structure

    Structure objTexels
        Dim utex As Single
        Dim vtex As Single
    End Structure

    Structure objNormals
        Dim xnorm As Single
        Dim ynorm As Single
        Dim znorm As Single
    End Structure

    Structure objFaces
        Dim vert1pos As Integer
        Dim vert1tex As Integer
        Dim vert1norm As Integer
        Dim vert2pos As Integer
        Dim vert2tex As Integer
        Dim vert2norm As Integer
        Dim vert3pos As Integer
        Dim vert3tex As Integer
        Dim vert3norm As Integer
    End Structure

    'Class variables and lists.
    Public verticesAmount As New Integer
    Public meshVertexes As New List(Of objVertex)
    Public meshTexels As New List(Of objTexels)
    Public meshFaces As New List(Of objFaces)
    Public meshNormals As New List(Of objNormals)
    Public groupName As String

    'Public Sub InitializeModel(ByVal inputModel As Model)

    '    'Setup the model.
    '    Dim newVertiesAmount As New Integer

    '    inputModel.verticesAmount.Add(newVertiesAmount)

    'End Sub

End Class
