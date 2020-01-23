Imports System.IO
Imports Newtonsoft.Json

Module AnimalGame

    Public HeadNode As Node
    Public CurrentNode As Node

    Public Const FILE_NAME = "store.json"

    Public Sub Main()
        If Not File.Exists(FILE_NAME) Then
            HeadNode = New Node("A DOG")
            File.WriteAllText(FILE_NAME, JsonConvert.SerializeObject(HeadNode))
        End If

        While True
            HeadNode = JsonConvert.DeserializeObject(Of Node)(File.ReadAllText(FILE_NAME))
            CurrentNode = HeadNode
            Console.WriteLine("THINK OF AN ANIMAL. I'LL TRY TO FIND IT OUT BY ASKING QUESTIONS")
            Dim inGame = True
            While inGame
                Dim answer As String
                If CurrentNode.isAnswer = False Then
                    Console.WriteLine(CurrentNode.Question)
                Else
                    Console.WriteLine($"IS IT {CurrentNode.Answer}?")
                End If
                answer = Console.ReadLine().ToUpper()
                If answer = "YES" Then
                    If CurrentNode.isAnswer Then
                        Console.WriteLine($"SEE HOW SMART I'M GETTING?")
                        inGame = False
                    Else
                        CurrentNode = CurrentNode.YesNode
                    End If
                ElseIf answer = "NO" Then
                    If CurrentNode.isAnswer Then
                        Console.WriteLine($"I GIVE UP! WHAT IS IT?")
                        Dim newAnswer = Console.ReadLine.ToUpper
                        Console.WriteLine($"PLEASE TYPE IN A QUESTION WHOSE ANSWER IS YES FOR {newAnswer} AND NO FOR {CurrentNode.Answer}")
                        Dim newQuestion = Console.ReadLine.ToUpper.Replace("?", "") & "?"
                        CurrentNode.AddQuestion(newAnswer, newQuestion)
                        Console.WriteLine($"I'LL DO BETTER NEXT TIME")
                        File.WriteAllText(FILE_NAME, JsonConvert.SerializeObject(HeadNode))
                        inGame = False
                    Else
                        CurrentNode = CurrentNode.NoNode
                    End If
                Else
                    Console.WriteLine("PLEASE ANSWER YES/NO")
                End If
            End While
        End While
    End Sub
End Module
