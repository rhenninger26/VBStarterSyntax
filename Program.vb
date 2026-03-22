' Shows several basic sorting algorithms and a small console menu so you can run and inspect each algorithm
Module Program
    Sub Main()
        Dim sample() As Integer = {42, 34, 7, 23, 32, 5, 62}
        While True
            Console.Clear()
            Console.WriteLine("Basic VB sorting algorithms - pick one to run:")
            Console.WriteLine("1 - Odd-Even (Brick) Sort")
            Console.WriteLine("2 - Bubble Sort")
            Console.WriteLine("3 - Insertion Sort")
            Console.WriteLine("4 - Selection Sort")
            Console.WriteLine("5 - Run all (compare results)")
            Console.WriteLine("Q - Quit")
            Console.Write(vbCrLf & "Choice: ")
            Dim choice As String = Console.ReadLine().Trim().ToUpper()

            If choice = "Q" Then
                Exit While
            End If

            Dim arrCopy() As Integer

            Select Case choice
                Case "1"
                    arrCopy = CType(sample.Clone(), Integer())
                    Console.WriteLine(vbCrLf & "Before: " & ArrayToString(arrCopy))
                    OddEvenSort(arrCopy)
                    Console.WriteLine("After : " & ArrayToString(arrCopy))
                Case "2"
                    arrCopy = CType(sample.Clone(), Integer())
                    Console.WriteLine(vbCrLf & "Before: " & ArrayToString(arrCopy))
                    BubbleSort(arrCopy)
                    Console.WriteLine("After : " & ArrayToString(arrCopy))
                Case "3"
                    arrCopy = CType(sample.Clone(), Integer())
                    Console.WriteLine(vbCrLf & "Before: " & ArrayToString(arrCopy))
                    InsertionSort(arrCopy)
                    Console.WriteLine("After : " & ArrayToString(arrCopy))
                Case "4"
                    arrCopy = CType(sample.Clone(), Integer())
                    Console.WriteLine(vbCrLf & "Before: " & ArrayToString(arrCopy))
                    SelectionSort(arrCopy)
                    Console.WriteLine("After : " & ArrayToString(arrCopy))
                Case "5"
                    Console.WriteLine()
                    RunAndShow("Odd-Even (Brick) Sort", sample, AddressOf OddEvenSort)
                    RunAndShow("Bubble Sort", sample, AddressOf BubbleSort)
                    RunAndShow("Insertion Sort", sample, AddressOf InsertionSort)
                    RunAndShow("Selection Sort", sample, AddressOf SelectionSort)
                Case Else
                    Console.WriteLine(vbCrLf & "Unrecognized choice.")
            End Select

            Console.WriteLine(vbCrLf & "Press Enter to continue...")
            Console.ReadLine()
        End While
    End Sub

    ' Helper to run a sort and print results
    Sub RunAndShow(name As String, original() As Integer, sorter As Action(Of Integer()))
        Dim arr() As Integer = CType(original.Clone(), Integer())
        Console.WriteLine(name)
        Console.WriteLine("  Before: " & ArrayToString(arr))
        sorter(arr)
        Console.WriteLine("  After : " & ArrayToString(arr) & vbCrLf)
    End Sub

    Function ArrayToString(arr() As Integer) As String
        Return "[" & String.Join(", ", arr) & "]"
    End Function

    Sub OddEvenSort(arr() As Integer)
        Dim n As Integer = arr.Length
        Dim sorted As Boolean = False
        While Not sorted
            sorted = True
            ' Even-indexed pairs (0,1), (2,3), ...
            For i As Integer = 0 To n - 2 Step 2
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    sorted = False
                End If
            Next

            ' Odd-indexed pairs (1,2), (3,4), ...
            For i As Integer = 1 To n - 2 Step 2
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    sorted = False
                End If
            Next
        End While
    End Sub

    Sub BubbleSort(arr() As Integer)
        Dim n As Integer = arr.Length
        For i As Integer = 0 To n - 2
            For j As Integer = 0 To n - 2 - i
                If arr(j) > arr(j + 1) Then
                    Swap(arr, j, j + 1)
                End If
            Next
        Next
    End Sub

    Sub InsertionSort(arr() As Integer)
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

    Sub SelectionSort(arr() As Integer)
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

    Sub Swap(arr() As Integer, i As Integer, j As Integer)
        Dim temp As Integer = arr(i)
        arr(i) = arr(j)
        arr(j) = temp
    End Sub
End Module