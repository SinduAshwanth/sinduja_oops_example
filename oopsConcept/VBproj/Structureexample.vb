Imports System.Xml
Imports Microsoft.AspNetCore.Http

Public Class Structureexample
    Structure Intergerstruct
        Public x As Integer
        Public y As Integer
    End Structure

    Public Sub Main()
        Dim ms As New Intergerstruct
        ms.x = 10
        ms.y = 20
        Dim sum As Integer = ms.x + ms.y
        Console.WriteLine("The sum is {0}", sum)
    End Sub

    Public Sub getProductData()
        Dim xr As XmlReader = XmlReader.Create("D:\GIT FOLDER\GIT_oops\incubator\oopsConcept\VBproj\Products.xml")
        Dim list As List(Of String)

        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "name" Then
                list.Add(xr.GetAttribute("name"))
            End If
        Loop
    End Sub
End Class
