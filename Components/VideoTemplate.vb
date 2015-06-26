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
Imports DotNetNuke.Common.Globals
Imports System.Xml
Imports System.Reflection

Public Class VideoTemplate
    Implements ITemplate

#Region "Private Protects"
    Protected _aryTemplate As String()
    Protected _tabID As Integer
    Protected _moduleID As Integer
    Protected _portalId As Integer
    Protected _imageWidth As String
    Protected _videoSize As String
    Protected _suggestedVideos As Boolean
    Protected _showTitle As Boolean
    Protected _showControls As Boolean
    Protected _nestedLevel As ArrayList
#End Region

    Public Sub New(tabId As Integer, _
                   moduleId As Integer, _
                   portalId As Integer, _
                   templateText As String, _
                   imageWidth As String, _
                   videoSize As String, _
                   showTitle As Boolean, _
                   suggestedVideos As Boolean, _
                   ShowControls As Boolean)

        _aryTemplate = ParseTemplateText(templateText)
        _moduleID = moduleId
        _portalId = portalId
        _tabID = tabId
        _imageWidth = imageWidth
        _videoSize = videoSize
        _suggestedVideos = suggestedVideos
        _showTitle = showTitle
        _showControls = ShowControls
        _nestedLevel = New ArrayList
        _nestedLevel.Add(True)
    End Sub

    Public Sub InstantiateIn(container As Control) Implements ITemplate.InstantiateIn
        Dim lc As Literal
        Dim hyp As HyperLink
        Dim img As Image
        'Dim cmdB As ImageButton
        'Dim ddl As DropDownList
        'Dim rbl As RadioButtonList
        'Dim cmd As LinkButton
        'Dim chk As CheckBox
        'Dim txt As TextBox
        'Dim val As RangeValidator
        'Dim rval As RequiredFieldValidator
        'Dim hf As HiddenField
        'Dim lp As Integer

        For lp = 0 To _aryTemplate.GetUpperBound(0)
            If Not _aryTemplate(lp) Is Nothing Then

                Select Case _aryTemplate(lp).ToUpper

                    Case "TAG:ITEMID"
                        lc = New Literal
                        AddHandler lc.DataBinding, AddressOf ItemID_DataBinding
                        container.Controls.Add(lc)

                    Case "TAG:VIDEOID"
                        lc = New Literal
                        AddHandler lc.DataBinding, AddressOf VideoID_DataBinding
                        container.Controls.Add(lc)

                    Case "TAG:TITLE"
                        lc = New Literal
                        AddHandler lc.DataBinding, AddressOf VideoTitle_DataBinding
                        container.Controls.Add(lc)

                    Case "TAG:DESCRIPTION"
                        lc = New Literal
                        AddHandler lc.DataBinding, AddressOf VideoDescription_DataBinding
                        container.Controls.Add(lc)

                    Case "TAG:PREVIEWIMAGE"
                        img = New Image
                        AddHandler img.DataBinding, AddressOf PreviewImage_DataBinding
                        container.Controls.Add(img)

                    Case "TAG:EMBEDDEDVIDEO"
                        lc = New Literal
                        AddHandler lc.DataBinding, AddressOf EmbdeedVideo_DataBinding
                        container.Controls.Add(lc)

                    Case "TAG:VIDEOURL"
                        lc = New Literal
                        AddHandler lc.DataBinding, AddressOf VideoUrl_DataBinding
                        container.Controls.Add(lc)

                    Case "TAG:POPUPURL"
                        lc = New Literal
                        AddHandler lc.DataBinding, AddressOf PopUpUrl_DataBinding
                        container.Controls.Add(lc)

                    Case "TAG:ADMINEDITBUTTON"
                        hyp = New HyperLink
                        AddHandler hyp.DataBinding, AddressOf EditButton_DataBinding
                        container.Controls.Add(hyp)

                    Case Else
                        lc = New Literal
                        lc.Text = _aryTemplate(lp)
                        AddHandler lc.DataBinding, AddressOf VisibleMode_DataBinding
                        container.Controls.Add(lc)

                End Select

            End If
        Next
    End Sub

#Region " Bindings "

    Private Sub ItemID_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        Dim container As DataListItem
        container = CType(lc.NamingContainer, DataListItem)
        lc.Text = DataBinder.Eval(container.DataItem, "ItemId")
        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub VideoID_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        Dim container As DataListItem
        container = CType(lc.NamingContainer, DataListItem)
        lc.Text = DataBinder.Eval(container.DataItem, "VideoId")
        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub VideoTitle_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        Dim container As DataListItem
        container = CType(lc.NamingContainer, DataListItem)
        lc.Text = DataBinder.Eval(container.DataItem, "VideoTitle")
        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub VideoDescription_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        Dim container As DataListItem
        container = CType(lc.NamingContainer, DataListItem)
        lc.Text = System.Web.HttpUtility.HtmlDecode(DataBinder.Eval(container.DataItem, "VideoDescription"))
        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub PreviewImage_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ThumbW As String = _imageWidth

        Dim img As Image
        img = CType(sender, Image)
        Dim container As DataListItem
        container = CType(img.NamingContainer, DataListItem)
        img.ImageUrl = "http://img.youtube.com/vi/" & DataBinder.Eval(container.DataItem, "VideoId") & "/0.jpg"
        img.Width = ThumbW
        img.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub EmbdeedVideo_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        Dim container As DataListItem
        container = CType(lc.NamingContainer, DataListItem)

        Dim vStr As StringBuilder = New StringBuilder
        vStr.AppendLine("<div class=""videoWrapper"">")
        vStr.Append("<iframe type=""text/html"" width=""560"" height=""349"" ")
        vStr.Append("src=""http://www.youtube.com/embed/" & DataBinder.Eval(container.DataItem, "VideoId"))
        vStr.Append("?autoplay=0"" ")
        vStr.Append("frameborder=""0""></iframe>")
        vStr.AppendLine("</div>")

        lc.Text = vStr.ToString
        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub VideoUrl_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        Dim container As DataListItem
        container = CType(lc.NamingContainer, DataListItem)
        lc.Text = "http://www.youtube.com/embed/" & DataBinder.Eval(container.DataItem, "VideoId")
        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub PopUpUrl_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        Dim container As DataListItem
        container = CType(lc.NamingContainer, DataListItem)
        Dim ThumbW As String = _imageWidth

        Dim cnt As Integer = 0

        Dim vStr As StringBuilder = New StringBuilder
        vStr.Append("<a href=""http://www.youtube.com/watch?v=" & DataBinder.Eval(container.DataItem, "VideoId") & "")

        If Not _suggestedVideos Then
            vStr.Append("?rel=0")
            cnt = cnt + 1
        End If

        If Not _showControls Then
            If cnt > 0 Then
                vStr.Append("&amp;controls=0")
            Else : vStr.Append("?controls=0")
            End If
        End If

        If Not _showTitle Then
            If cnt > 0 Then
                vStr.Append("&amp;showinfo=0")
            Else : vStr.Append("?showinfo=0")
            End If
        End If
        vStr.Append("""")
        vStr.Append(" rel=""prettyPhoto[pp_gal]"">")
        vStr.AppendLine("     <img src=""http://img.youtube.com/vi/" & DataBinder.Eval(container.DataItem, "VideoId") & "/0.jpg"" width=""" & ThumbW & "px"">")
        vStr.AppendLine("</a>")
        lc.Text = vStr.ToString

        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub EditButton_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hyp As HyperLink
        hyp = CType(sender, HyperLink)
        Dim container As DataListItem
        container = CType(hyp.NamingContainer, DataListItem)

        hyp.ID = "cmdEditVideo"
        hyp.ImageUrl = "~/icons/sigma/Edit_16X16_Standard_2.png"
        hyp.NavigateUrl = NavigateURL(_tabID, "Edit", "mid=" & _moduleID, "tid=" & DataBinder.Eval(container.DataItem, "ItemId"))
        hyp.Enabled = False
        hyp.Visible = False
        hyp.CssClass = "btnEdit"
        hyp.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

    Private Sub VisibleMode_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lc As Literal
        lc = CType(sender, Literal)
        lc.Visible = CBool(_nestedLevel((_nestedLevel.Count - 1)))
    End Sub

#End Region

    Private Function ParseTemplateText(ByVal TemplText As String) As String()
        Dim strOUT As String()
        Dim ParamAry As Char() = {"[", "]"}
        Dim FoundEscapeChar As Boolean = False


        'use double sqr brqckets as escape char.
        FoundEscapeChar = False
        If InStr(TemplText, "[[") > 0 Or InStr(TemplText, "]]") > 0 Then
            TemplText = Replace(TemplText, "[[", "**SQROPEN**")
            TemplText = Replace(TemplText, "]]", "**SQRCLOSE**")
            FoundEscapeChar = True
        End If

        strOUT = TemplText.Split(ParamAry)

        If FoundEscapeChar Then
            For lp = 0 To strOUT.GetUpperBound(0)
                If strOUT(lp).Contains("**SQROPEN**") Then
                    strOUT(lp) = Replace(strOUT(lp), "**SQROPEN**", "[")
                End If
                If strOUT(lp).Contains("**SQRCLOSE**") Then
                    strOUT(lp) = Replace(strOUT(lp), "**SQRCLOSE**", "]")
                End If
            Next
        End If

        Return strOUT
    End Function

End Class
