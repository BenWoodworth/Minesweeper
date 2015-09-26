Public Class EventBoard
    Public Property KnownBoard As Board
    Public Property ActualBoard As Board
    Public ReadOnly Property BoardSize As Size
        Get
            Return KnownBoard.Size
        End Get
    End Property

    Public ReadOnly Property RemainingMines As Integer
        Get
            Dim result As Integer = 0
            For x = 0 To BoardSize.Width - 1
                For y = 0 To BoardSize.Height - 1
                    If ActualBoard(x, y) = BoardValue.Mine AndAlso Not KnownBoard(x, y) = BoardValue.MineFlag Then result += 1
                Next
            Next
            Return result
        End Get
    End Property

    Sub New(ByVal mines As Integer, ByVal size As Size, ByVal firstGuess As Point)
        ActualBoard = New Board(size, 0)
        KnownBoard = New Board(size, BoardValue.Blank)

        If mines >= size.Width * size.Height Then mines = size.Width * size.Height - 1

        Randomize()
        Dim guess As Point
        Do Until mines = 0
            guess = New Point(Int(Rnd() * size.Width), Int(Rnd() * size.Height))
            If guess <> firstGuess AndAlso ActualBoard(guess) = 0 Then
                ActualBoard(guess) = BoardValue.Mine
                mines -= 1
            End If
        Loop

        For x = 0 To ActualBoard.Width - 1
            For y = 0 To ActualBoard.Height - 1
                If ActualBoard(x, y) >= 0 Then
                    Dim newVal As Integer = 0
                    For Each pt As Point In surroundingSquares(New Point(x, y))
                        If ActualBoard(pt) = BoardValue.Mine Then newVal += 1
                    Next
                    ActualBoard(x, y) = newVal
                End If
            Next
        Next
    End Sub

    Public Function surroundingSquares(ByVal pt As Point) As Point()
        Dim result As New List(Of Point)
        Dim xMax As Integer = ActualBoard.Size.Width
        Dim yMax As Integer = ActualBoard.Size.Height
        For x = pt.X - 1 To pt.X + 1
            For y = pt.Y - 1 To pt.Y + 1
                If Not (x = pt.X And y = pt.Y) AndAlso x < xMax AndAlso y < yMax AndAlso x >= 0 AndAlso y >= 0 Then
                    result.Add(New Point(x, y))
                End If
            Next
        Next
        Return result.ToArray
    End Function

    Private Sub revealSquare(ByVal pt As Point)
        Dim val As Integer = ActualBoard(pt)
        If val >= 0 Or val = BoardValue.Mine Then
            KnownBoard(pt) = ActualBoard(pt)
            If (Not KnownBoard(pt) = BoardValue.MineFlag) And (Not KnownBoard(pt) = BoardValue.UnknownFlag) Then
                If val = 0 Then
                    For Each p As Point In surroundingSquares(pt)
                        If KnownBoard(p) = BoardValue.Blank Then revealSquare(p)
                    Next
                ElseIf val > 0 Then
                    For Each p As Point In surroundingSquares(pt)
                        If ActualBoard(p) = 0 Then revealSquare(p)
                    Next
                End If
            End If
        End If
    End Sub

    Public Function eventLeftClick(ByVal pt As Point) As EventOutcome
        If KnownBoard(pt) = BoardValue.Blank Then
            Dim val As BoardValue = ActualBoard(pt)
            revealSquare(pt)
            If val >= 0 Then
                Return EventOutcome.Safe
            ElseIf val = BoardValue.Mine Then
                Return EventOutcome.Mine
            Else
                Return EventOutcome.Invalid
            End If
        Else
            Return EventOutcome.Invalid
        End If
    End Function
    Public Sub eventRightClick(ByVal pt As Point)
        Dim val As BoardValue = KnownBoard(pt)
        If val = BoardValue.MineFlag Then
            KnownBoard(pt) = BoardValue.UnknownFlag
        ElseIf val = BoardValue.UnknownFlag Then
            KnownBoard(pt) = BoardValue.Blank
        ElseIf val = BoardValue.Blank Then
            KnownBoard(pt) = BoardValue.MineFlag
        End If
    End Sub
End Class
Public Enum EventOutcome
    Safe = 1
    Mine = 2
    Invalid = 4
End Enum
