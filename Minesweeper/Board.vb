Public Class Board
    Private Property valueBoard As BoardValue(,)

    Default Public Property GetValue(ByVal x As Integer, ByVal y As Integer) As BoardValue
        Get
            Return valueBoard(x, y)
        End Get
        Set(ByVal value As BoardValue)
            valueBoard(x, y) = value
        End Set
    End Property
    Default Public Property GetValue(ByVal pt As Point) As BoardValue
        Get
            Return valueBoard(pt.X, pt.Y)
        End Get
        Set(ByVal value As BoardValue)
            valueBoard(pt.X, pt.Y) = value
        End Set
    End Property
    Public ReadOnly Property Size As Size
        Get
            Return New Size(valueBoard.GetUpperBound(0) + 1, valueBoard.GetUpperBound(1) + 1)
        End Get
    End Property
    Public ReadOnly Property Width As Integer
        Get
            Return valueBoard.GetUpperBound(0) + 1
        End Get
    End Property
    Public ReadOnly Property Height As Integer
        Get
            Return valueBoard.GetUpperBound(1) + 1
        End Get
    End Property

    Sub New(ByVal size As Size, ByVal val As BoardValue)
        valueBoard = New Board(size.Width, size.Height, val).valueBoard
    End Sub
    Sub New(ByVal width As Integer, ByVal height As Integer, ByVal val As BoardValue)
        Dim result(width - 1, height - 1) As BoardValue
        For x = 0 To width - 1
            For y = 0 To height - 1
                result(x, y) = val
            Next
        Next
        valueBoard = New Board(result)
    End Sub
    Sub New(ByVal valArr As BoardValue(,))
        valueBoard = valArr.Clone
    End Sub

    Public Function clone() As Board
        Return Me.valueBoard
    End Function

    Public Shared Widening Operator CType(ByVal valueBoard As BoardValue(,)) As Board
        Return New Board(valueBoard)
    End Operator
    Public Shared Narrowing Operator CType(ByVal bd As Board) As BoardValue(,)
        Return bd.valueBoard.Clone
    End Operator
End Class
Public Enum BoardValue
    Blank = -1
    MineFlag = -2
    UnknownFlag = -3
    Mine = -4
End Enum