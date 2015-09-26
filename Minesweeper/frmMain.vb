Public Class frmMain
    Const gameVersion As String = "Beta1"

    Dim eventBoard As EventBoard
    Dim firstClick As Boolean = True
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Minesweeper " & gameVersion

        gameBoard.Board = New Board(9, 9, BoardValue.Blank)
    End Sub

    Private Sub GameBoard_SquareLeftClicked(ByVal pos As System.Drawing.Point) Handles gameBoard.SquareLeftClicked
        If firstClick Then
            eventBoard = New EventBoard(nMines.Value, New Size(gameBoard.Board.Width, gameBoard.Board.Height), pos)
            firstClick = False
            btnTrySolve.Enabled = True
        End If
        eventBoard.eventLeftClick(pos)
        gameBoard.Board = eventBoard.KnownBoard
    End Sub
    Private Sub GameBoard_SquareRightClicked(ByVal pos As System.Drawing.Point) Handles gameBoard.SquareRightClicked
        If Not firstClick Then
            eventBoard.eventRightClick(pos)
            gameBoard.Board = eventBoard.KnownBoard
        End If
    End Sub

    Private Sub nWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nWidth.ValueChanged, nHeight.ValueChanged
        nMines.Maximum = nWidth.Value * nHeight.Value - 1
    End Sub

    Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        gameBoard.Board = New Board(nWidth.Value, nHeight.Value, BoardValue.Blank)
        firstClick = True
        btnTrySolve.Enabled = False
    End Sub

    Private Sub btnTrySolve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrySolve.Click
        Dim changes As Integer = -1
        Do While changes <> 0
            changes = 0
            For x = 0 To eventBoard.BoardSize.Width - 1
                For y = 0 To eventBoard.BoardSize.Height - 1
                    Dim knownMines As Integer = 0
                    Dim unknown As Integer = 0
                    Dim pts() As Point = eventBoard.surroundingSquares(New Point(x, y))
                    For Each p As Point In pts
                        Dim curVal As Integer = eventBoard.KnownBoard(p)
                        If curVal = BoardValue.MineFlag Then
                            knownMines += 1
                        End If
                        If curVal < 0 Then
                            unknown += 1
                        End If
                    Next
                    Dim val As Integer = eventBoard.KnownBoard(x, y)
                    If val > 0 AndAlso val = knownMines Then
                        For Each p As Point In pts
                            If eventBoard.KnownBoard(p) = BoardValue.Blank Or eventBoard.KnownBoard(p) = BoardValue.UnknownFlag Then
                                eventBoard.KnownBoard(p) = BoardValue.Blank
                                eventBoard.eventLeftClick(p)
                                changes += 1
                                Refresh()
                            End If
                        Next
                    End If
                    If val > 0 AndAlso val = unknown Then
                        For Each p As Point In pts
                            If eventBoard.KnownBoard(p) < 0 And eventBoard.KnownBoard(p) <> BoardValue.MineFlag Then
                                eventBoard.KnownBoard(p) = BoardValue.MineFlag
                                changes += 1
                            End If
                        Next
                    End If
                    If eventBoard.KnownBoard(x, y) = BoardValue.UnknownFlag Then
                        eventBoard.KnownBoard(x, y) = BoardValue.Blank
                    End If
                Next
            Next


            'Dim remaining As New List(Of Point)
            'For x = 0 To eventBoard.BoardSize.Width - 1
            '    For y = 0 To eventBoard.BoardSize.Height - 1
            '        For Each p As Point In eventBoard.surroundingSquares(New Point(x, y))
            '            If eventBoard.KnownBoard(p) = BoardValue.Blank Then
            '                remaining.Add(p)
            '                Exit For
            '            End If
            '        Next
            '    Next
            'Next
            'For Each p As Point In remaining
            '    Dim unknownFlags As Integer = 0
            '    For Each s As Point In eventBoard.surroundingSquares(p)
            '        eventBoard.KnownBoard(s) = BoardValue.UnknownFlag
            '        unknownFlags += 1
            '        'If eventBoard.KnownBoard(s) = BoardValue.UnknownFlag Then
            '        '    unknownFlags += 1
            '        'End If
            '    Next
            '    For Each p2 As Point In remaining
            '        Dim unknownFlagsB As Integer = 0
            '        Dim mineFlags As Integer = 0
            '        For Each s As Point In eventBoard.surroundingSquares(p2)
            '            If eventBoard.KnownBoard(s) = BoardValue.UnknownFlag Then
            '                unknownFlagsB += 1
            '            ElseIf eventBoard.KnownBoard(s) = BoardValue.MineFlag Then
            '                mineFlags += 1
            '            End If
            '        Next
            '        If p <> p2 AndAlso unknownFlags = unknownFlagsB AndAlso mineFlags = eventBoard.KnownBoard(p2) - 1 Then
            '            For Each s As Point In eventBoard.surroundingSquares(p2)
            '                If eventBoard.KnownBoard(s) = BoardValue.Blank Then
            '                    eventBoard.eventLeftClick(p)
            '                    changes += 1
            '                End If
            '            Next
            '        End If
            '    Next
            '    For Each s As Point In eventBoard.surroundingSquares(p)
            '        If eventBoard.KnownBoard(s) = BoardValue.UnknownFlag Then
            '            eventBoard.KnownBoard(s) = BoardValue.Blank
            '        End If
            '    Next
            'Next
        Loop
        gameBoard.Board = eventBoard.KnownBoard
    End Sub
End Class
