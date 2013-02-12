
Public Module vBulletin

End Module



Friend NotInheritable Class TextUtil
    Private Sub New()
    End Sub

    Friend Shared Function JustBefore(ByVal Str As String, ByVal Seq As String) As String
        Dim Orgi As String = Str
        Try
            Str = Str.ToLower()
            Seq = Seq.ToLower()

            Return Orgi.Substring(0, Str.Length - (Str.Length - Str.IndexOf(Seq)))
        Catch generatedExceptionName As Exception
            Return ""
        End Try
    End Function

    Friend Shared Function JustAfter(ByVal Str As String, ByVal Seq As String, ByVal SeqEnd As String) As String
        Dim Orgi As String = Str
        Try
            Str = Str.ToLower()
            Seq = Seq.ToLower()
            SeqEnd = SeqEnd.ToLower()

            Dim i As Integer = Str.IndexOf(Seq)

            If i < 0 Then
                Return Nothing
            End If

            i = i + Seq.Length

            Dim j As Integer = Str.IndexOf(SeqEnd, i)
            Dim [end] As Integer

            If j > 0 Then
                [end] = j - i
            Else
                [end] = Str.Length - i
            End If

            Return Orgi.Substring(i, [end])
        Catch generatedExceptionName As Exception
            Return ""
        End Try
    End Function
    Friend Shared Function JustAfter(ByVal Str As String, ByVal Seq As String, ByVal SeqEnd1 As String, ByVal SeqEnd2 As String) As String
        Dim Orgi As String = Str
        Try
            Str = Str.ToLower()
            Seq = Seq.ToLower()
            SeqEnd1 = SeqEnd1.ToLower()
            SeqEnd2 = SeqEnd2.ToLower()

            Dim i As Integer = Str.IndexOf(Seq)

            If i < 0 Then
                Return Nothing
            End If

            i = i + Seq.Length

            Dim j As Integer = Str.IndexOf(SeqEnd1, i)
            Dim [end] As Integer

            If j > 0 Then
                Dim j2 As Integer = Str.IndexOf(SeqEnd2, j - 1)
                If j2 > 0 Then
                    [end] = j2 - i + SeqEnd2.Length
                Else
                    [end] = j - i
                End If

            Else
                [end] = Str.Length - i
            End If

            Return Orgi.Substring(i, [end])
        Catch generatedExceptionName As Exception
            Return ""
        End Try
    End Function
    Friend Shared Function JustAfter(ByVal Str As String, ByVal Seq As String) As String
        Dim Orgi As String = Str
        Try
            Str = Str.ToLower()
            Seq = Seq.ToLower()

            Dim i As Integer = Str.IndexOf(Seq)

            If i < 0 Then
                Return Nothing
            End If

            i = i + Seq.Length

            Return Orgi.Substring(i, Str.Length - i)
        Catch generatedExceptionName As Exception
            Return ""
        End Try
    End Function

    Friend Shared Function JustAfter(ByVal Str As String, ByVal Seq As String, ByVal SeqEnd As String, ByVal SeqLength As Integer) As String
        Dim Orgi As String = Str
        Try
            Str = Str.ToLower()
            Seq = Seq.ToLower()
            SeqEnd = SeqEnd.ToLower()
            Dim i As Integer = Str.IndexOf(Seq)

            If i < 0 Then
                Return Nothing
            End If

            i = i + Seq.Length

            Dim j As Integer = Str.IndexOf(SeqEnd, i)
            Dim [end] As Integer

            If j > 0 Then
                [end] = j - i
            Else
                [end] = Str.Length - i
            End If

            Return Orgi.Substring(i, [end] + SeqLength)
        Catch generatedExceptionName As Exception
            Return ""
        End Try
    End Function

    Public Shared Function ConvertHTMLToText(ByVal Text As String) As String
        Dim s As String = Web.HttpUtility.HtmlDecode(Text)
        Return Web.HttpUtility.HtmlDecode(Text)
    End Function

    Public Shared Function DeleteEmptyLines(ByVal Text As String) As String
        Dim Lines As String() = GetLines(Text)
        Dim NewText As String = ""
        For Each Line In Lines
            If Line.Trim <> "" Then
                If Line.Contains("class=""") Then Line = Line.Replace("class=""" & JustAfter(Line, "class=""", """") & """", "")
                If Line.Contains("style=""") Then Line = Line.Replace("style=""" & JustAfter(Line, "style=""", """") & """", "")
                NewText += Line.Trim & vbNewLine
            End If
        Next
        Return NewText
    End Function

    Public Shared Function DeleteUnusedLines(ByVal Text As String) As String
        Dim Lines As String() = GetLines(Text)
        Dim NewText As String = ""
        For Each Line In Lines
            If Line.Trim <> "" Then
                If Line.Contains("class=""") Then Line = Line.Replace("class=""" & JustAfter(Line, "class=""", """") & """", "")
                If Line.Contains("style=""") Then Line = Line.Replace("style=""" & JustAfter(Line, "style=""", """") & """", "")
                If Line.Contains("align=""") Then Line = Line.Replace("align=""" & JustAfter(Line, "align=""", """") & """", "")
                If Line.Contains("color=""") Then Line = Line.Replace("color=""" & JustAfter(Line, "color=""", """") & """", "")
                NewText += Line.Trim & vbNewLine
            End If
        Next
        Return NewText
    End Function
    Public Shared Function GetLines(ByVal Text As String) As String()
        Dim num2 As Integer
        Dim list As New ArrayList
        Dim i As Integer = 0
        Do While (i < [Text].Length)
            num2 = i
            Do While (num2 < [Text].Length)
                Dim ch As Char = [Text].Chars(num2)
                If ((ch = ChrW(13)) OrElse (ch = ChrW(10))) Then
                    Exit Do
                End If
                num2 += 1
            Loop
            Dim str2 As String = [Text].Substring(i, (num2 - i))
            list.Add(str2)
            If ((num2 < [Text].Length) AndAlso ([Text].Chars(num2) = ChrW(13))) Then
                num2 += 1
            End If
            If ((num2 < [Text].Length) AndAlso ([Text].Chars(num2) = ChrW(10))) Then
                num2 += 1
            End If
            i = num2
        Loop
        If (([Text].Length > 0) AndAlso (([Text].Chars(([Text].Length - 1)) = ChrW(13)) OrElse ([Text].Chars(([Text].Length - 1)) = ChrW(10)))) Then
            list.Add("")
        End If
        Return DirectCast(list.ToArray(GetType(String)), String())
    End Function
End Class