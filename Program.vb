' Shows several basic sorting algorithms and a small console menu so you can run and inspect each algorithm
Imports System.Diagnostics

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

            Select Case choice
                Case "1", "2", "3", "4"
                    Dim singleSorter As ISorter = SorterFactory.CreateByChoice(choice)
                    If singleSorter IsNot Nothing Then
                        RunAndShow(singleSorter, sample)
                    Else
                        Console.WriteLine(vbCrLf & "Unrecognized choice.")
                    End If
                Case "5"
                    Console.WriteLine()
                    Dim sorters As ISorter() = SorterFactory.CreateAll()
                    For Each s As ISorter In sorters
                        RunAndShow(s, sample)
                    Next
                Case Else
                    Console.WriteLine(vbCrLf & "Unrecognized choice.")
            End Select

            Console.WriteLine(vbCrLf & "Press Enter to continue...")
            Console.ReadLine()
        End While
    End Sub

    ' Helper to run a sort, print results and show elapsed time
    Sub RunAndShow(sorter As ISorter, original() As Integer)
        Dim arr() As Integer = CType(original.Clone(), Integer())
        Console.WriteLine(sorter.Name)
        Console.WriteLine("  Before: " & ArrayToString(arr))
        Dim sw As Stopwatch = Stopwatch.StartNew()
        sorter.Sort(arr)
        sw.Stop()
        Console.WriteLine("  After : " & ArrayToString(arr))
        Console.WriteLine("  Time  : " & sw.Elapsed.TotalMilliseconds.ToString("F3") & " ms" & vbCrLf)
    End Sub

    Function ArrayToString(arr() As Integer) As String
        Return "[" & String.Join(", ", arr) & "]"
    End Function
End Module
