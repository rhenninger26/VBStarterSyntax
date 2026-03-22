Public Interface ISorter
    ReadOnly Property Name As String
    Sub Sort(arr() As Integer)
End Interface

Public MustInherit Class BaseSorter
    Implements ISorter

    Public MustOverride ReadOnly Property Name As String Implements ISorter.Name
    Public MustOverride Sub Sort(arr() As Integer) Implements ISorter.Sort

    Protected Sub Swap(arr() As Integer, i As Integer, j As Integer)
        Dim temp As Integer = arr(i)
        arr(i) = arr(j)
        arr(j) = temp
    End Sub
End Class

Public Class OddEvenSorter
    Inherits BaseSorter

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Odd-Even (Brick) Sort"
        End Get
    End Property

    Public Overrides Sub Sort(arr() As Integer)
        Dim n As Integer = arr.Length
        Dim sorted As Boolean = False
        While Not sorted
            sorted = True
            For i As Integer = 0 To n - 2 Step 2
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    sorted = False
                End If
            Next

            For i As Integer = 1 To n - 2 Step 2
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    sorted = False
                End If
            Next
        End While
    End Sub
End Class

Public Class BubbleSorter
    Inherits BaseSorter

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Bubble Sort"
        End Get
    End Property

    Public Overrides Sub Sort(arr() As Integer)
        Dim n As Integer = arr.Length
        For i As Integer = 0 To n - 2
            For j As Integer = 0 To n - 2 - i
                If arr(j) > arr(j + 1) Then
                    Swap(arr, j, j + 1)
                End If
            Next
        Next
    End Sub
End Class

Public Class InsertionSorter
    Inherits BaseSorter

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Insertion Sort"
        End Get
    End Property

    Public Overrides Sub Sort(arr() As Integer)
        Dim n As Integer = arr.Length
        For i As Integer = 1 To n - 1
            Dim key As Integer = arr(i)
            Dim j As Integer = i - 1
            While j >= 0 AndAlso arr(j) > key
                arr(j + 1) = arr(j)
                j -= 1
            End While
            arr(j + 1) = key
        Next
    End Sub
End Class

Public Class SelectionSorter
    Inherits BaseSorter

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Selection Sort"
        End Get
    End Property

    Public Overrides Sub Sort(arr() As Integer)
        Dim n As Integer = arr.Length
        For i As Integer = 0 To n - 2
            Dim minIndex As Integer = i
            For j As Integer = i + 1 To n - 1
                If arr(j) < arr(minIndex) Then
                    minIndex = j
                End If
            Next
            If minIndex <> i Then
                Swap(arr, i, minIndex)
            End If
        Next
    End Sub
End Class

Public Class SorterFactory
    Public Shared Function CreateAll() As ISorter()
        Return New ISorter() {
            New OddEvenSorter(),
            New BubbleSorter(),
            New InsertionSorter(),
            New SelectionSorter()
        }
    End Function

    Public Shared Function CreateByChoice(choice As String) As ISorter
        Select Case choice
            Case "1"
                Return New OddEvenSorter()
            Case "2"
                Return New BubbleSorter()
            Case "3"
                Return New InsertionSorter()
            Case "4"
                Return New SelectionSorter()
            Case Else
                Return Nothing
        End Select
    End Function
End Class
