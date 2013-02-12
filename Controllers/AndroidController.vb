Namespace MvcApplication2
    Public Class AndroidController
        Inherits System.Web.Mvc.Controller
        '  <AcceptVerbs(HttpVerbs.Post)>
        Function LoadData() As ActionResult
            Dim FilePath As String = Request.RequestContext.HttpContext.Request.MapPath("android.txt").ToLower.Replace("home\", "").Replace("android\", "").Replace("loaddata\", "").Replace("savedata\", "")
            If My.Computer.FileSystem.FileExists(FilePath) = False Then My.Computer.FileSystem.WriteAllText(FilePath, "", False)
            Response.Clear()
            Response.Write(My.Computer.FileSystem.ReadAllText(FilePath))
            Response.End()
            Return View()
        End Function

        Function Index() As ActionResult
            Return View()
        End Function

        ' <AcceptVerbs(HttpVerbs.Post)>
        Function SaveData(ByVal data As String) As ActionResult
            Dim FilePath As String = Request.RequestContext.HttpContext.Request.MapPath("android.txt").ToLower.Replace("home\", "").Replace("android\", "").Replace("loaddata\", "").Replace("savedata\", "")
            My.Computer.FileSystem.WriteAllText(FilePath, data, False)
            Response.Clear()
            Response.Write("Saved")
            Response.End()
            Return View()
        End Function

    End Class
End Namespace