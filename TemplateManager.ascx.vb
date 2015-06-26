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
Imports DotNetNuke
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports DotNetNuke.UI.Utilities
Imports DotNetNuke.Common.Globals

Public Class TemplateManager
    Inherits DnnC_YouTubeLibraryModuleBase

#Region " Event methods"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadTemplates()
        End If
    End Sub

    Private Sub cmdReturn_Click(sender As Object, e As EventArgs) Handles cmdReturn.Click
        Response.Redirect(NavigateURL())
    End Sub

    Private Sub cmdLoadDefaultHtml_Click(sender As Object, e As EventArgs) Handles cmdLoadDefaultHtml.Click
        txtTemplate.Text = SharedFunctions.LoadTemplateFromFile("html")
    End Sub

    Private Sub cmdLoadDefaultCss_Click(sender As Object, e As EventArgs) Handles cmdLoadDefaultCss.Click
        txtCss.Text = SharedFunctions.LoadTemplateFromFile("css")
    End Sub

    Private Sub cmdSave1_Click(sender As Object, e As EventArgs) Handles cmdSave1.Click
        Savedata()
    End Sub

    Private Sub cmdSave2_Click(sender As Object, e As EventArgs) Handles cmdSave2.Click
        Savedata()
    End Sub

    Private Sub cmdSaveReturn1_Click(sender As Object, e As EventArgs) Handles cmdSaveReturn1.Click
        Savedata()
        Response.Redirect(NavigateURL())
    End Sub

    Private Sub cmdSaveReturn2_Click(sender As Object, e As EventArgs) Handles cmdSaveReturn2.Click
        Savedata()
        Response.Redirect(NavigateURL())
    End Sub

#End Region

#Region " Private Methods"

    Private Sub LoadTemplates()
        If (Settings.Contains("YTVL_ItemHtmlTemplate")) Then
            txtTemplate.Text = Settings("YTVL_ItemHtmlTemplate")
        Else txtTemplate.Text = SharedFunctions.LoadTemplateFromFile("html")
        End If

        If (Settings.Contains("YTVL_ItemCssTemplate")) Then
            txtCss.Text = Settings("YTVL_ItemCssTemplate")
        Else txtCss.Text = SharedFunctions.LoadTemplateFromFile("css")
        End If

    End Sub

    Private Sub Savedata()
        Dim objModules As New Entities.Modules.ModuleController
        objModules.UpdateModuleSetting(ModuleId, "YTVL_ItemHtmlTemplate", txtTemplate.Text)
        objModules.UpdateModuleSetting(ModuleId, "YTVL_ItemCssTemplate", txtCss.Text)
    End Sub

#End Region

End Class