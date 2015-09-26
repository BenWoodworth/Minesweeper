<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.nWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nMines = New System.Windows.Forms.NumericUpDown()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTrySolve = New System.Windows.Forms.Button()
        Me.gameBoard = New Minesweeper.BoardControl()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.nWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nMines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'nWidth
        '
        Me.nWidth.Location = New System.Drawing.Point(56, 7)
        Me.nWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nWidth.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nWidth.Name = "nWidth"
        Me.nWidth.Size = New System.Drawing.Size(78, 20)
        Me.nWidth.TabIndex = 1
        Me.nWidth.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Width"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Height"
        '
        'nHeight
        '
        Me.nHeight.Location = New System.Drawing.Point(56, 29)
        Me.nHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nHeight.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nHeight.Name = "nHeight"
        Me.nHeight.Size = New System.Drawing.Size(78, 20)
        Me.nHeight.TabIndex = 3
        Me.nHeight.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mines"
        '
        'nMines
        '
        Me.nMines.Location = New System.Drawing.Point(56, 51)
        Me.nMines.Maximum = New Decimal(New Integer() {80, 0, 0, 0})
        Me.nMines.Name = "nMines"
        Me.nMines.Size = New System.Drawing.Size(78, 20)
        Me.nMines.TabIndex = 5
        Me.nMines.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'btnNewGame
        '
        Me.btnNewGame.Location = New System.Drawing.Point(140, 7)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(79, 64)
        Me.btnNewGame.TabIndex = 7
        Me.btnNewGame.Text = "Start New Game"
        Me.btnNewGame.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.gameBoard)
        Me.Panel1.Location = New System.Drawing.Point(12, 90)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(430, 295)
        Me.Panel1.TabIndex = 8
        '
        'btnTrySolve
        '
        Me.btnTrySolve.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTrySolve.Enabled = False
        Me.btnTrySolve.Location = New System.Drawing.Point(350, 7)
        Me.btnTrySolve.Name = "btnTrySolve"
        Me.btnTrySolve.Size = New System.Drawing.Size(92, 64)
        Me.btnTrySolve.TabIndex = 9
        Me.btnTrySolve.Text = "Try Solve..."
        Me.btnTrySolve.UseVisualStyleBackColor = True
        '
        'gameBoard
        '
        Me.gameBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gameBoard.Location = New System.Drawing.Point(4, 4)
        Me.gameBoard.Margin = New System.Windows.Forms.Padding(4)
        Me.gameBoard.Name = "gameBoard"
        Me.gameBoard.Size = New System.Drawing.Size(150, 150)
        Me.gameBoard.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(307, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Project By Ben Woodworth"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(454, 397)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnTrySolve)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nMines)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nHeight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nWidth)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(338, 299)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        CType(Me.nWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nMines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gameBoard As Minesweeper.BoardControl
    Friend WithEvents nWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nMines As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnNewGame As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnTrySolve As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
