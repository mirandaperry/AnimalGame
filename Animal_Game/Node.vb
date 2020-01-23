Public Class Node

    Public isAnswer As Boolean
    Public YesNode As Node
    Public NoNode As Node
    Public Question As String
    Public Answer As String

    Public Sub New(Answer As String)
        Me.Answer = Answer
        Me.isAnswer = True
    End Sub

    Public Sub AddQuestion(NewAnswer As String, NewQuestion As String)
        isAnswer = False
        Question = NewQuestion
        NoNode = New Node(Answer)
        YesNode = New Node(NewAnswer)
    End Sub

End Class
