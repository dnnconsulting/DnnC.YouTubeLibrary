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
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Entities.Users
Imports System.Xml
Imports DnnC.Modules.YouTubeLibrary.Components
Imports DotNetNuke.Common.Globals
Imports DotNetNuke.Services.Localization
Imports System.Net
Imports System.IO

Imports System.Web.Script.Serialization

Public Class Edit
    Inherits DnnC_YouTubeLibraryModuleBase


    Public Class jsonWrapper
        Public Property kind As String
        Public Property etag As String
        Public Property pageInfo() As pageInfo
        Public Property items As List(Of items)
    End Class

    Public Class pageInfo
        Public Property totalResults As String
        Public Property resultsPerPage As String
    End Class

    Public Class items
        Public Property kind As String
        Public Property etag As String
        Public Property id As String
        Public Property snippet() As snippet
    End Class


    Public Class snippet
        Public Property publishedAt As String
        Public Property channelId As String
        Public Property title As String
        Public Property description As String
        Public Property thumbnails() As thumbnailsData
    End Class

    Public Class thumbnailsData
        Public Property medium() As thumbData
    End Class

    Public Class thumbData
        Public Property url As String
        Public Property width As String
        Public Property height As String
    End Class







#Region "Event Methods"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            pnlError.Visible = False
            If Not Page.IsPostBack Then

                If ItemId > 0 Then
                    Fill4Edit()
                    PanelList.Visible = False
                    PanelInput.Visible = True
                Else
                    If Action = "new" Then
                        PanelList.Visible = False
                        PanelInput.Visible = True
                    Else
                        BindGrid()
                    End If

                End If

            Else

                If Request("__EVENTARGUMENT") = "VideoOrder" Then
                    SetVideoOrder()
                End If

            End If
        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try

    End Sub

    Private Sub cmdReturn_Click(sender As Object, e As EventArgs) Handles cmdReturn.Click
        Response.Redirect(NavigateURL())
    End Sub

    Private Sub cmdAddVideo_Click(sender As Object, e As EventArgs) Handles cmdAddVideo.Click
        PanelList.Visible = False
        PanelInput.Visible = True
    End Sub

    Private Sub cmdGetVideoData_Click(sender As Object, e As EventArgs) Handles cmdGetVideoData.Click
        If Not txtVideoId.Text = String.Empty Then
            Try

                If Settings.Contains("YTVL_API") Then
                    Dim vidId As String = txtVideoId.Text.Trim
                    Dim objFeedUrl As Uri = Nothing
                    Dim strUrl As String = String.Empty
                    strUrl = String.Format("https://www.googleapis.com/youtube/v3/videos?id={0}&key={1}&part=snippet", vidId, Settings("YTVL_API"))
                    'NUgcygzQAwM

                    Dim client As New WebClient
                    Dim json As String = client.DownloadString(strUrl)
                    Dim ser As New System.Web.Script.Serialization.JavaScriptSerializer()
                    Dim results As jsonWrapper = ser.Deserialize(Of jsonWrapper)(json)

                    Try
                        If results.items.Count > 0 Then
                            txtVideoTitle.Text = results.items(0).snippet.title.ToString
                            txtDescription.Text = results.items(0).snippet.description.ToString

                            imgPreview.ImageUrl = results.items(0).snippet.thumbnails.medium.url
                            pnlVideoData.Visible = True
                        Else
                            ShowError("No video found with the videoId of <strong>" & vidId & "</strong>")
                        End If
                    Catch ex As Exception
                        ShowError("There was a problem retrieving some data!!!<br><br>" & ex.ToString)
                    End Try

                Else
                    ShowError("The Youtube video ID textbox was empty!")
                End If
            Catch exc As Exception
                Exceptions.ProcessModuleLoadException(Me, exc)
            End Try
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim t As New Item()
        Dim tc As New ItemController
        If ItemId > 0 Then
            t = tc.GetItem(ItemId, ModuleId)
            t.VideoId = txtVideoId.Text.Trim()
            t.VideoTitle = txtVideoTitle.Text.Trim()
            t.VideoDescription = txtDescription.Text.Trim()
            t.IsVisible = chkVisible.Checked

        Else
            t.VideoId = txtVideoId.Text.Trim()
            t.VideoTitle = txtVideoTitle.Text.Trim()
            t.VideoDescription = txtDescription.Text.Trim()
            t.IsVisible = chkVisible.Checked
            t.VideoOrder = GetOrder()

            t.PortalId = PortalId
            t.CreatedByUserId = UserId
            t.CreatedOnDate = DateTime.Now
        End If

        t.ModuleId = ModuleId

        If t.ItemId > 0 Then
            tc.UpdateItem(t)
        Else
            tc.CreateItem(t)
        End If
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))
    End Sub

#End Region

#Region " Private Methods"

    Private Sub ShowError(msg As String)
        lblError.Text = msg
        pnlError.Visible = True
    End Sub

    Private Sub BindGrid()
        Dim tc As New ItemController
        Try
            If Not tc.GetItems(ModuleId) Is Nothing Then
                Dim items = From t In tc.GetItems(ModuleId) Order By t.VideoOrder Ascending Select t
                grdVideos.DataSource = items
                grdVideos.DataBind()
            End If
        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    Private Sub ChangeItemOrder(itemIds As IEnumerable(Of Integer), moduleId As Integer)
        Dim i = 0
        For Each itemId As Integer In itemIds
            Dim tc As New ItemController
            Dim t As New Item
            t = tc.GetItem(itemId, moduleId)
            t.VideoOrder = i
            tc.UpdateItem(t)
            i = i + 1
        Next
    End Sub

    Private Sub ChangeVisiblity(ItemId As Integer)
        Dim tc As New ItemController
        Dim t As New Item
        t = tc.GetItem(ItemId, ModuleId)
        Dim isVisible As Boolean = t.IsVisible

        If isVisible Then
            t.IsVisible = False
        Else
            t.IsVisible = True
        End If
        tc.UpdateItem(t)
    End Sub

    Private Sub Fill4Edit()
        Dim tc As New ItemController
        Dim t As New Item
        t = tc.GetItem(ItemId, ModuleId)
        txtVideoId.Text = t.VideoId
        txtVideoTitle.Text = t.VideoTitle
        txtDescription.Text = t.VideoDescription
        chkVisible.Checked = t.IsVisible
        imgPreview.ImageUrl = "http://img.youtube.com/vi/" & t.VideoId & "/0.jpg"
        pnlVideoData.Visible = True
    End Sub

#End Region

#Region " Sort and Ordering methods"

     Private Function GetOrder() As Integer
        Dim tc As New ItemController
        Dim itemCount = tc.GetItems(ModuleId).Count

        Return itemCount + 1
    End Function

    Private Sub SetVideoOrder()
        Dim orderVal As String = Request.Form(VideoOrder.UniqueID)
        Dim iidString = Replace(orderVal, ",,", ",")
        Dim iids = iidString.Split(","c)
        Dim ids = iids.[Select](Function(iid) Integer.Parse(iid.Split("_"c)(1)))
        ChangeItemOrder(ids, ModuleId)
        BindGrid()
        VideoOrder.Value = String.Empty
    End Sub

#End Region

#Region " DataGrid Methods"

    Private Sub grdVideos_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles grdVideos.ItemCommand
        Dim tc As New ItemController

        Select Case e.CommandName.ToLower
            Case "cmdeditvideo" : Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId, "tId=" & e.CommandArgument))
            Case "cmddeletevideo" : tc.DeleteItem(CInt(e.CommandArgument), ModuleId)
            Case "cmdchangevisibility" : ChangeVisiblity(CInt(e.CommandArgument))

        End Select
        Response.Redirect(NavigateURL(Me.TabId, "edit", "mid=" & ModuleId))
    End Sub

    Private Sub grdVideos_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles grdVideos.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim id = String.Format("iid_{0}", DataBinder.Eval(e.Item.DataItem, "ItemId"))
            e.Item.Attributes.Add("id", id)

            Dim cmdDeleteVideo As ImageButton = DirectCast(e.Item.FindControl("cmdDeleteVideo"), ImageButton)
            cmdDeleteVideo.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("WarningDeleteVideoText", Me.LocalResourceFile) & "');")

            Dim imgVisible As ImageButton = DirectCast(e.Item.FindControl("imgVisible"), ImageButton)

            If CBool(DataBinder.Eval(e.Item.DataItem, "IsVisible")) Then
                imgVisible.ImageUrl = "~/icons/sigma/Checked_16x16_Standard.png"
            Else : imgVisible.ImageUrl = "~/icons/sigma/Unchecked_16x16_Standard.png"
            End If

        End If
    End Sub

#End Region

End Class