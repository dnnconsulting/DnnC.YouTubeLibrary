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
Imports DnnC.Modules.YouTubeLibrary.Components

Partial Class View
    Inherits DnnC_YouTubeLibraryModuleBase

    Private _CurrentPage As Integer = 1

#Region "Event methods"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            SetAdminButtons()
            _CurrentPage = 1
            If Not CurrentPage = -1 Then _CurrentPage = CurrentPage

            If Not Page.IsPostBack Then
                SetUpTemplate()
                BindList()
                ltlCss.Text = GetString("YTVL_ItemCssTemplate", SharedFunctions.LoadTemplateFromFile("css"))
                SetUpScript()
            End If

        Catch ex As Exception
            ShowError(ex.ToString)
            Exceptions.ProcessModuleLoadException(Me, ex)
        End Try
    End Sub

    Private Sub btnManage_Click(sender As Object, e As EventArgs) Handles btnManage.Click
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))
    End Sub

    Private Sub btnTemplate_Click(sender As Object, e As EventArgs) Handles btnTemplate.Click
        Response.Redirect(NavigateURL(Me.TabId, "templatemanager", "mid=" & ModuleId))
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId, "act=new"))
    End Sub

#End Region

#Region "Private Methods"

    Private Sub ShowError(errMessage As String)
        lblError.Text = errMessage
        pnlError.Visible = True
    End Sub

    Private Sub SetAdminButtons()
        Try
            If DotNetNuke.Security.Permissions.ModulePermissionController.CanEditModuleContent(Me.ModuleConfiguration) Then
                btnManage.Visible = True
                btnManage.Enabled = True
                btnAddNew.Visible = True
                btnAddNew.Enabled = True
                btnTemplate.Visible = True
                btnTemplate.Enabled = True
                panelAdmin.Visible = True
            Else
                btnManage.Visible = False
                btnManage.Enabled = False
                btnAddNew.Visible = False
                btnAddNew.Enabled = False
                btnTemplate.Visible = False
                btnTemplate.Enabled = False
                panelAdmin.Visible = False
            End If
        Catch ex As Exception
            ShowError(ex.ToString)
            Exceptions.ProcessModuleLoadException(Me, ex)
        End Try
    End Sub

    Private Sub SetUpTemplate()
        dlList.ItemTemplate = New VideoTemplate( _
        TabId, _
        ModuleId, _
        PortalId, _
        GetString("YTVL_ItemHtmlTemplate", SharedFunctions.LoadTemplateFromFile("html")), _
        GetString("YTVL_imageWidth", "350"), _
        GetString("YTVL_PPVideoSize", "1"), _
        GetBoolean("YTVL_PPShowTitle", False), _
        GetBoolean("YTVL_PPSuggestedVideos", False), _
        GetBoolean("YTVL_PPShowControls", False))

        dlList.CssClass = GetString("YTVL_listStyle", "dnnc_listStyle")
        dlList.ItemStyle.CssClass = GetString("YTVL_listItemStyle", "dnnc_listItemStyle")
        dlList.AlternatingItemStyle.CssClass = GetString("YTVL_listItemAltStyle", "dnnc_listItemAltStyle")
        dlList.Width = System.Web.UI.WebControls.Unit.Parse(GetString("YTVL_width", "100%"))
        dlList.CellPadding = GetInteger("YTVL_padding", 3)
        dlList.CellSpacing = GetInteger("YTVL_spacing", 3)

        dlList.RepeatColumns = GetInteger("YTVL_columns", 3)
        If GetString("YTVL_RepeatDirection", "Horizontal") = "Vertical" Then
            dlList.RepeatDirection = RepeatDirection.Vertical
        Else : dlList.RepeatDirection = RepeatDirection.Horizontal
        End If

        Select Case GetString("YTVL_RepeatLayout", "Table")
            Case "Table" : dlList.RepeatLayout = RepeatLayout.Table
            Case "Flow" : dlList.RepeatLayout = RepeatLayout.Flow
            Case Else : dlList.RepeatLayout = RepeatLayout.Table
        End Select

    End Sub

    Private Sub BindList()
        Dim tc As New ItemController
        Dim PageSize As Integer = GetInteger("YTVL_pagerSize", 12)
        Dim vCount As Integer = 0

        Try
            If Not tc.GetItems(ModuleId) Is Nothing Then
                Dim items = From t In tc.GetItems(ModuleId) Where t.IsVisible Order By t.VideoOrder Ascending Select t

                vCount = items.Count
                items = items.Skip((CurrentPage - 1) * PageSize).Take(PageSize)
                dlList.DataSource = items
                dlList.DataBind()

                ' ************ Setup Page bar ************
                ctlPagingControl.TotalRecords = vCount
                ctlPagingControl.PageSize = PageSize
                ctlPagingControl.TabID = PortalSettings.ActiveTab.TabID
                ctlPagingControl.CurrentPage = _CurrentPage
                ctlPagingControl.BorderWidth = 0

                If vCount <= PageSize Or PageSize = -1 Then
                    ctlPagingControl.Visible = False
                Else : ctlPagingControl.Visible = True
                End If
                ' ************ Setup Page bar ************

            End If
        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    Private Sub SetUpScript()
        Dim vsStr As New StringBuilder
        vsStr.AppendLine("<script type=""text/javascript"" charset=""utf-8"">")
        vsStr.AppendLine("    $(document).ready(function () {")
        vsStr.AppendLine("        $(""a[rel^='prettyPhoto']"").prettyPhoto({")
        vsStr.AppendLine("            theme: '" & GetString("YTVL_PPTheme", "default") & "',")
        vsStr.AppendLine("            opacity: " & GetString("YTVL_PPOpacity", "0.80") & ",")

        Select Case GetInteger("YTVL_PPVideoSize", 1)
            Case 1
                vsStr.AppendLine("            default_width: 560,")
                vsStr.AppendLine("            default_height: 315")
            Case 2
                vsStr.AppendLine("            default_width: 600,")
                vsStr.AppendLine("            default_height: 360")
            Case 3
                vsStr.AppendLine("            default_width: 835,")
                vsStr.AppendLine("            default_height: 480")
            Case 4
                vsStr.AppendLine("            default_width: 1280,")
                vsStr.AppendLine("            default_height: 720")
        End Select
        
        vsStr.AppendLine("        });")
        vsStr.AppendLine("    });")
        vsStr.AppendLine("</script>")

        ltlVideoScript.Text = vsStr.ToString
    End Sub

#End Region

#Region "Helpers "

    Private Function GetString(key As String, defaultValue As String) As String
        If (Settings.ContainsKey(key)) Then
            If Not String.IsNullOrEmpty(Settings(key).ToString()) Then
                Return Settings(key).ToString()
            End If
        End If
        Return defaultValue
    End Function

    Private Function GetInteger(key As String, defaultValue As String) As Integer
        If (Settings.ContainsKey(key)) Then
            If Not String.IsNullOrEmpty(Settings(key).ToString()) Then
                Return CInt(Settings(key).ToString())
            End If
        End If
        Return defaultValue
    End Function

    Private Function GetBoolean(key As String, defaultValue As Boolean) As Boolean
        If (Settings.ContainsKey(key)) Then
            If Not String.IsNullOrEmpty(Settings(key).ToString()) Then
                Return CType(Settings(key), Boolean)
            End If
        End If
        Return defaultValue
    End Function

#End Region

    Private Sub dlList_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dlList.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Try
                Dim cmdEditVideo As HyperLink = DirectCast(e.Item.FindControl("cmdEditVideo"), HyperLink)

                If DotNetNuke.Security.Permissions.ModulePermissionController.CanEditModuleContent(Me.ModuleConfiguration) Then
                    cmdEditVideo.Enabled = True
                    cmdEditVideo.Visible = True
                Else
                    cmdEditVideo.Enabled = False
                    cmdEditVideo.Visible = False
                End If
            Catch ex As Exception
                'ShowError(ex.ToString)
                'Exceptions.ProcessModuleLoadException(Me, ex)
            End Try
        End If
    End Sub

End Class