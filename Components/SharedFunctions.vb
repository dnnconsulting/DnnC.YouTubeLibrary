' Copyright (c) 2014 DnnConsulting.nl
' Author : G Barlow
' All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
Imports System.IO

Public Class SharedFunctions

    Public Shared Function LoadTemplateFromFile(templateType As String) As String
        Dim retVal As String = String.Empty
        Dim f As String = String.Empty
        Dim sr As StreamReader

        If templateType.ToLower = "html" Then
            f = "~/DesktopModules/DnnC_YouTubeLibrary/ItemLayoutTemplate.html"
        ElseIf templateType.ToLower = "css" Then
            f = "~/DesktopModules/DnnC_YouTubeLibrary/ItemLayoutCss.html"
        Else
            f = "~/DesktopModules/DnnC_YouTubeLibrary/ItemLayoutTemplate.html"
        End If

        Try
            sr = File.OpenText(HttpContext.Current.Server.MapPath(f))
            retVal = sr.ReadToEnd()
            sr.Close()
        Catch ex As Exception

        Finally
            If Not sr Is Nothing Then
                sr.Close()
            End If
        End Try

        Return retVal
    End Function

End Class