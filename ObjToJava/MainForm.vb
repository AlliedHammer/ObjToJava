Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Path

Public Class MainForm

    'List of models.
    'Private objModel As New Model
    Private objModel As New List(Of Model)

    Private Sub InputBrowseButton_Click(sender As Object, e As EventArgs) Handles InputBrowseButton.Click

        'Browse for the file to be converted.
        Dim fileDiag As OpenFileDialog = New OpenFileDialog()
        Dim fileName As String

        'Setup the file dialog window.
        fileDiag.Title = "Select a valid OBJ file."
        fileDiag.InitialDirectory = "C:\"
        fileDiag.Filter = "Wavefront OBJ Files (*.obj)|*.obj"
        fileDiag.FilterIndex = 1
        fileDiag.RestoreDirectory = True

        'Check if there is an existing path or not.
        If InputTextBox.Text <> Nothing Then

            fileDiag.InitialDirectory = GetDirectoryName(InputTextBox.Text.ToString)

        End If

        'Check for a valid file.
        If fileDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'File was found.
            fileName = fileDiag.FileName

            'Clear input box and set its text to equal the file path.
            InputTextBox.Text = fileName.ToString()

            'Setup the output file path.
            With OutputTextBox

                .Clear()
                .Text = GetDirectoryName(fileName) & "\" & GetFileNameWithoutExtension(fileName) & ".java"

            End With

        End If

    End Sub

    Private Sub OutputBrowseButton_Click(sender As Object, e As EventArgs) Handles OutputBrowseButton.Click

        'Browse for the location to save the xml file.
        Dim fileDiag As SaveFileDialog = New SaveFileDialog()
        Dim fileName As String

        'Setup the file dialog window.
        fileDiag.Title = "Select a location to save the Java Class."
        fileDiag.InitialDirectory = "C:\"
        fileDiag.Filter = "Java Class (*.java)|*.java"
        fileDiag.FilterIndex = 1
        fileDiag.RestoreDirectory = True
        fileDiag.FileName = GetFileNameWithoutExtension(InputTextBox.Text.ToString) & ".java"

        'Check if there is an existing path or not.
        If OutputTextBox.Text <> Nothing Then

            fileDiag.InitialDirectory = GetDirectoryName(OutputTextBox.Text.ToString)

        End If

        'Check for a valid file.
        If fileDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'File was found.
            fileName = fileDiag.FileName

            'Clear input box and set its text to equal the file path.
            OutputTextBox.Text = fileName.ToString()

        End If

    End Sub

    Private Sub GetObjFileInfo(ByVal inputFilePath As String)

        'Open the specified OBJ file and collect the number of attributes.
        Dim fileReader As New StreamReader(inputFilePath, Encoding.Default)

        'If the file is not good.
        If Not File.Exists(inputFilePath) Then

            'Display error message.
            Dim badFileDiag As DialogResult = MessageBox.Show("Bad or no file detected!", _
                                                              "Error!", _
                                                              MessageBoxButtons.OK)
        Else

            'Read in the file.
            Dim line As String = ""
            Dim groupAmount As Integer = 0
            Dim hasGroups As Boolean = False
            Dim newGroup As New Model

            'Debugging variables.
            Dim positionsInModel As Integer = 0
            Dim texelsInModel As Integer = 0
            Dim normalsInModel As Integer = 0
            Dim facesInModel As Integer = 0
            Dim verticesInModel As Integer = 0
            Dim foundGroupName As String = Path.GetFileNameWithoutExtension(inputFilePath)

            'Add in the new group.
            newGroup.groupName = foundGroupName
            objModel.Add(newGroup)

            Do While fileReader.Peek() >= 0

                line = fileReader.ReadLine

                'Detect a position.
                If line.Contains("v ") Then

                    'Store the position data.

                    Dim posSplit As String() = line.Split(New [Char]() {" "})
                    Dim newVertexes As Model.objVertex

                    newVertexes.xpos = CSng(posSplit(1))
                    newVertexes.ypos = CSng(posSplit(2))
                    newVertexes.zpos = CSng(posSplit(3))

                    objModel(groupAmount).meshVertexes.Add(newVertexes)

                'Detect a texel.
                ElseIf line.Contains("vt") Then

                    'Store the texel data.

                    Dim texSplit As String() = line.Split(New [Char]() {" "})
                    Dim newTexels As Model.objTexels

                    newTexels.utex = CSng(texSplit(1))
                    newTexels.vtex = CSng(texSplit(2))

                    objModel(groupAmount).meshTexels.Add(newTexels)

                'Detect a normal.
                ElseIf line.Contains("vn") Then

                    'Store the normal data.

                    Dim normSplit As String() = line.Split(New [Char]() {" "})
                    Dim newNormals As Model.objNormals

                    newNormals.xnorm = CSng(normSplit(1))
                    newNormals.ynorm = CSng(normSplit(2))
                    newNormals.znorm = CSng(normSplit(3))

                    objModel(groupAmount).meshNormals.Add(newNormals)

                'Detect a face.
                ElseIf line.Contains("f ") Then

                    'Store the face data.

                    Dim faceSplit As String() = line.Split(New [Char]() {" ", "/"})
                    Dim newFaces As Model.objFaces

                    'Account for lack of normals.
                    If objModel(groupAmount).meshNormals.Count = 0 Then

                        newFaces.vert1pos = CInt(faceSplit(1))
                        newFaces.vert1tex = CInt(faceSplit(2))
                        newFaces.vert2pos = CInt(faceSplit(3))
                        newFaces.vert2tex = CInt(faceSplit(4))
                        newFaces.vert3pos = CInt(faceSplit(5))
                        newFaces.vert3tex = CInt(faceSplit(6))

                    Else

                        newFaces.vert1pos = CInt(faceSplit(1))
                        newFaces.vert1tex = CInt(faceSplit(2))
                        newFaces.vert1norm = CInt(faceSplit(3))
                        newFaces.vert2pos = CInt(faceSplit(4))
                        newFaces.vert2tex = CInt(faceSplit(5))
                        newFaces.vert2norm = CInt(faceSplit(6))
                        newFaces.vert3pos = CInt(faceSplit(7))
                        newFaces.vert3tex = CInt(faceSplit(8))
                        newFaces.vert3norm = CInt(faceSplit(9))

                End If

                objModel(groupAmount).meshFaces.Add(newFaces)

                'Detect a group.
                ElseIf line.Contains("# g ") Then

                    'Setup the group name
                    Dim newGroupName As String = line.Replace("#", "").Replace(" ", "").Replace("g", "")

                    'Setup a new mesh group.
                    Dim newMeshGroup As New Model

                    'Determine if there is a new group or not.
                    If groupAmount = 0 And hasGroups = False Then

                        'Edit the group name at this index.
                        objModel(groupAmount).groupName = newGroupName
                        hasGroups = True
                        foundGroupName = newGroupName

                    Else

                        'Add in a new group and increment the group number.
                        newMeshGroup.groupName = newGroupName
                        objModel.Add(newMeshGroup)
                        groupAmount += 1
                        foundGroupName = newGroupName

                    End If

                End If

                'Count the total number of vertices in the group.
                objModel(groupAmount).verticesAmount = objModel(groupAmount).meshFaces.Count * 3

            Loop

            fileReader.Close()

            'Setup the debugging data.

            'Count up the total for all attributes.
            For Each meshItem As Model In objModel

                positionsInModel += meshItem.meshVertexes.Count
                texelsInModel += meshItem.meshTexels.Count
                normalsInModel += meshItem.meshNormals.Count
                facesInModel += meshItem.meshFaces.Count
                verticesInModel += meshItem.verticesAmount

            Next

            'Debugging infobox.
            Dim recordedMessage As DialogResult = MessageBox.Show("Positions: " & positionsInModel.ToString & Environment.NewLine _
                                                                  & "Texels: " & texelsInModel.ToString & Environment.NewLine _
                                                                  & "Normals: " & normalsInModel.ToString & Environment.NewLine _
                                                                  & "Faces: " & facesInModel.ToString & Environment.NewLine _
                                                                  & "Vertices: " & verticesInModel.ToString & Environment.NewLine _
                                                                  & "Groups: " & objModel.Count.ToString & Environment.NewLine, _
                                                                  "Message", MessageBoxButtons.OK)

            Dim recordedMessage2 As DialogResult = MessageBox.Show("Model Data: " & Environment.NewLine _
                    & "P1: " & objModel(0).meshVertexes(0).xpos & "x " & objModel(0).meshVertexes(0).ypos & "y " & objModel(0).meshVertexes(0).zpos & "z" & Environment.NewLine _
                    & "T1: " & objModel(0).meshTexels(0).utex & "u " & objModel(0).meshTexels(0).vtex & "v " & Environment.NewLine _
                    & "N1: " & objModel(0).meshNormals(0).xnorm & "x " & objModel(0).meshNormals(0).ynorm & "y " & objModel(0).meshNormals(0).znorm & "z" & Environment.NewLine _
                    & "F1v1: " & objModel(0).meshFaces(0).vert1pos & "p " & objModel(0).meshFaces(0).vert1tex & "t " & objModel(0).meshFaces(0).vert1norm & "n" & Environment.NewLine _
                    , "Message", MessageBoxButtons.OK)

        End If

    End Sub

    Private Sub WriteJavaClass(ByVal outputFilePath As String)

    'Begin writing the file.
    Dim javaFileWriter As New StreamWriter(outputFilePath)

    'Write the file comments.
    javaFileWriter.WriteLine("//Model: " & Path.GetFileNameWithoutExtension(outputFilePath))
    javaFileWriter.WriteLine("//Groups: " & objModel.Count.ToString)
    javaFileWriter.WriteLine(Environment.NewLine & "public class " & Path.GetFileNameWithoutExtension(outputFilePath))
    javaFileWriter.WriteLine("{")

    'Keep track of the loop.
    Dim amountOfMeshes = 0

    'Initialize a new list of faces.
    Dim modelVertexes As New List(Of Model.objVertex)

    'Begin writing the model information.
    For Each meshGroup As Model In objModel

        'Add all faces into the list.
        For Each groupVertices As Model.objVertex In meshGroup.meshVertexes

            modelVertexes.Add(groupVertices)

        Next

        'Write the attributes for the item.
        javaFileWriter.WriteLine(vbTab & "//Begin " & meshGroup.groupName & " information:")
        javaFileWriter.WriteLine(vbTab & "public static final int " & meshGroup.groupName & "Vertices = " & meshGroup.verticesAmount & ";")
        javaFileWriter.WriteLine(vbNewLine & vbTab & "public static final float[]" & meshGroup.groupName & "Positions =")
        javaFileWriter.WriteLine(vbTab & "{")

        'Find all the positions within the group.
        For i As Integer = 0 To meshGroup.meshFaces.Count - 1 Step 1

            'Calculate the positions to write.
            Dim vertexA As Integer = meshGroup.meshFaces(i).vert1pos - 1
            Dim vertexB As Integer = meshGroup.meshFaces(i).vert2pos - 1
            Dim vertexC As Integer = meshGroup.meshFaces(i).vert3pos - 1

             'Use this string for the end of the array.
            Dim endOfPositions As String = "f, "

            'Check if the end of the faces has been reached.
            If i = meshGroup.meshFaces.Count - 1 Then

                endOfPositions = "f"

            End If

            'Write the positions.

            '1st vertex positions.
            javaFileWriter.WriteLine(vbTab & vbTab & modelVertexes(vertexA).xpos & _
                           "f, " & modelVertexes(vertexA).ypos & "f, " & _
                           modelVertexes(vertexA).zpos & "f, ")

            '2nd vertex positions.
            javaFileWriter.WriteLine(vbTab & vbTab & modelVertexes(vertexB).xpos & _
                           "f, " & modelVertexes(vertexB).ypos & "f, " & _
                           modelVertexes(vertexB).zpos & "f, ")

            '3rd vertex positions.
            javaFileWriter.WriteLine(vbTab & vbTab & modelVertexes(vertexC).xpos & _
                           "f, " & modelVertexes(vertexC).ypos & "f, " & _
                           modelVertexes(vertexC).zpos & endOfPositions)
        Next

        'Close the position array.
        javaFileWriter.WriteLine(vbTab & "};")
        javaFileWriter.WriteLine(vbTab & "//End " & meshGroup.groupName & " information." & vbNewLine)

        'Indicate there has been a completed group.
        amountOfMeshes += 1

    Next

    javaFileWriter.WriteLine("}")
    javaFileWriter.Close()

    End Sub

    Private Sub ConvertButton_Click(sender As Object, e As EventArgs) Handles ConvertButton.Click

        'Convert the file.

        'Retrieve attribute information in order to create empty attribute lists.
        GetObjFileInfo(InputTextBox.Text)

        'Write the output file.
        WriteJavaClass(OutputTextBox.Text)

        'Clear the model data.
        objModel = New List(Of Model)

    End Sub

End Class
