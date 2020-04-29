Imports System.Web.Mvc

Namespace Controllers
    Public Class ResumenController
        Inherits Controller

        ' GET: Resumen
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace