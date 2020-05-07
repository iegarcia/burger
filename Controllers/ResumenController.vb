Imports System.Web.Mvc

Namespace Controllers
    Public Class ResumenController
        Inherits Controller

        ' GET: Resumen
        Function Index() As ActionResult
            Return View("Resumen")
        End Function
    End Class
End Namespace