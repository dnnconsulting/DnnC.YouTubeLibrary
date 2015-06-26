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
Imports DotNetNuke.Entities.Modules

Public Class DnnC_YouTubeLibraryModuleBase
    Inherits PortalModuleBase

    Public ReadOnly Property ItemId() As Integer
        Get
            Dim qs = Request.QueryString("tid")
            If qs IsNot Nothing Then
                Return Convert.ToInt32(qs)
            End If
            Return -1
        End Get
    End Property

    Public ReadOnly Property Action() As String
        Get
            Dim qs = Request.QueryString("act")
            If qs IsNot Nothing Then
                Return qs
            End If
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property CurrentPage() As Integer
        Get
            Dim qs = Request.QueryString("currentpage")
            If qs IsNot Nothing Then
                Return Convert.ToInt32(qs)
            End If
            Return -1
        End Get
    End Property

End Class
