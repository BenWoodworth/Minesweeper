Public Class BoardControl
    Dim board_ As Board = New Board(9, 9, BoardValue.Blank)

    Public Property Board As Board
        Get
            Return board_
        End Get
        Set(ByVal value As Board)
            board_ = value
            Me.Size = New Size(value.Width * 16, value.Height * 16)
            Refresh()
        End Set
    End Property

    Private Sub BoardControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub

    Dim pen0 As Pen = New Pen(Color.FromArgb(0, 0, 0))
    Dim pen128 As Pen = New Pen(Color.FromArgb(128, 128, 128))
    Dim pen192 As Pen = New Pen(Color.FromArgb(192, 192, 192))
    Dim pen255 As Pen = New Pen(Color.FromArgb(255, 255, 255))
    Dim font_ As New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
    Private Sub BoardControl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim gfx As Graphics = e.Graphics
        Size = New Size(Board.Width * 16 + 6, Board.Height * 16 + 6)

        e.Graphics.DrawLine(pen128, New Point(0, 0), New Point(Width - 2, 0))
        e.Graphics.DrawLine(pen128, New Point(0, 1), New Point(Width - 3, 1))
        e.Graphics.DrawLine(pen128, New Point(0, 2), New Point(Width - 4, 2))
        e.Graphics.DrawLine(pen128, New Point(0, 3), New Point(0, Height - 2))
        e.Graphics.DrawLine(pen128, New Point(1, 3), New Point(1, Height - 3))
        e.Graphics.DrawLine(pen128, New Point(2, 3), New Point(2, Height - 4))

        e.Graphics.DrawLine(pen255, New Point(Width - 1, Height), New Point(Width - 1, 1))
        e.Graphics.DrawLine(pen255, New Point(Width - 2, Height), New Point(Width - 2, 2))
        e.Graphics.DrawLine(pen255, New Point(Width - 3, Height), New Point(Width - 3, 3))
        e.Graphics.DrawLine(pen255, New Point(Width - 4, Height - 1), New Point(1, Height - 1))
        e.Graphics.DrawLine(pen255, New Point(Width - 4, Height - 2), New Point(2, Height - 2))
        e.Graphics.DrawLine(pen255, New Point(Width - 4, Height - 3), New Point(3, Height - 3))

        e.Graphics.FillRectangle(pen192.Brush, New Rectangle(0, Height - 1, 1, 1))
        e.Graphics.FillRectangle(pen192.Brush, New Rectangle(1, Height - 2, 1, 1))
        e.Graphics.FillRectangle(pen192.Brush, New Rectangle(2, Height - 3, 1, 1))
        e.Graphics.FillRectangle(pen192.Brush, New Rectangle(Width - 1, 0, 1, 1))
        e.Graphics.FillRectangle(pen192.Brush, New Rectangle(Width - 2, 1, 1, 1))
        e.Graphics.FillRectangle(pen192.Brush, New Rectangle(Width - 3, 2, 1, 1))
        

        For x = 0 To Board.Width - 1
            For y = 0 To Board.Height - 1
                drawButton(e.Graphics, New Point(x * 16 + 3, y * 16 + 3), Board(x, y))
            Next
        Next
    End Sub
    Private Sub drawButton(ByRef gfx As Graphics, ByVal pos As Point, ByVal boardVal As BoardValue)
        If boardVal = BoardValue.Blank Or boardVal = BoardValue.MineFlag Or boardVal = BoardValue.UnknownFlag Then
            gfx.DrawLine(pen255, New Point(pos.X + 0, pos.Y), New Point(pos.X, pos.Y + 14))
            gfx.DrawLine(pen255, New Point(pos.X + 1, pos.Y), New Point(pos.X + 1, pos.Y + 13))
            gfx.DrawLine(pen255, New Point(pos.X + 2, pos.Y), New Point(pos.X + 14, pos.Y))
            gfx.DrawLine(pen255, New Point(pos.X + 2, pos.Y + 1), New Point(pos.X + 13, pos.Y + 1))

            gfx.DrawLine(pen128, New Point(pos.X + 15, pos.Y + 1), New Point(pos.X + 15, pos.Y + 15))
            gfx.DrawLine(pen128, New Point(pos.X + 14, pos.Y + 2), New Point(pos.X + 14, pos.Y + 14))
            gfx.DrawLine(pen128, New Point(pos.X + 1, pos.Y + 15), New Point(pos.X + 15, pos.Y + 15))
            gfx.DrawLine(pen128, New Point(pos.X + 2, pos.Y + 14), New Point(pos.X + 14, pos.Y + 14))

            gfx.FillRectangle(pen192.Brush, New Rectangle(pos.X, pos.Y + 15, 1, 1))
            gfx.FillRectangle(pen192.Brush, New Rectangle(pos.X + 1, pos.Y + 14, 1, 1))
            gfx.FillRectangle(pen192.Brush, New Rectangle(pos.X + 15, pos.Y, 1, 1))
            gfx.FillRectangle(pen192.Brush, New Rectangle(pos.X + 14, pos.Y + 1, 1, 1))
            gfx.FillRectangle(pen192.Brush, New Rectangle(pos.X + 2, pos.Y + 2, 12, 12))

            If boardVal = BoardValue.MineFlag Then
                gfx.DrawString("X", font_, Brushes.Blue, New Point(pos.X + 1, pos.Y))
            ElseIf boardVal = BoardValue.UnknownFlag Then
                gfx.DrawString("?", font_, Brushes.Green, New Point(pos.X + 1, pos.Y))
            End If
        Else
            gfx.DrawLine(pen128, New Point(pos.X, pos.Y), New Point(pos.X, pos.Y + 15))
            gfx.DrawLine(pen128, New Point(pos.X + 1, pos.Y), New Point(pos.X + 15, pos.Y))
            gfx.FillRectangle(pen192.Brush, New Rectangle(pos.X + 1, pos.Y + 1, 15, 15))
            If boardVal > 0 Then
                gfx.DrawString(boardVal, font_, Brushes.Black, New Point(pos.X + 1, pos.Y))
            ElseIf boardVal = BoardValue.Mine Then
                gfx.DrawString("M", font_, Brushes.Red, New Point(pos.X + 1, pos.Y))
            End If
        End If
    End Sub

    Public Event SquareLeftClicked(ByVal pos As Point)
    Public Event SquareRightClicked(ByVal pos As Point)
    Private Sub BoardControl_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Dim pos As Point = New Point(Int(e.Location.X / (Me.Width / Board.Width)), Int(e.Location.Y / (Me.Height / Board.Height)))
        If e.Button = Windows.Forms.MouseButtons.Left Then
            RaiseEvent SquareLeftClicked(pos)
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            RaiseEvent SquareRightClicked(pos)
        End If
    End Sub
End Class
