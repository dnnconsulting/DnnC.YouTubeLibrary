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
Imports DotNetNuke.Services.Exceptions

Public Class Settings
    Inherits DnnC_YouTubeLibrarySettingsBase

#Region "Base Method Implementations"

    Public Overrides Sub LoadSettings()
        Try
            If Not Page.IsPostBack Then

                If Settings.Contains("YTVL_API") Then
                    txtApiKey.Text = Settings("YTVL_API").ToString()
                End If

                If Settings.Contains("YTVL_pagerSize") Then
                    txtPagerSize.Text = Settings("YTVL_pagerSize").ToString()
                Else : txtPagerSize.Text = "9"
                End If

                If Settings.Contains("YTVL_imageWidth") Then
                    txtImageWidth.Text = Settings("YTVL_imageWidth").ToString()
                Else : txtImageWidth.Text = "350"
                End If

                If Settings.Contains("YTVL_pageSize") Then
                    txtPageSize.Text = Settings("YTVL_pageSize").ToString()
                Else : txtPageSize.Text = "9"
                End If

                If Settings.Contains("YTVL_columns") Then
                    txtColumns.Text = Settings("YTVL_columns").ToString()
                Else : txtColumns.Text = "3"
                End If

                If Settings.Contains("YTVL_width") Then
                    txtWidth.Text = Settings("YTVL_width").ToString()
                Else : txtWidth.Text = "100%"
                End If

                If Settings.Contains("YTVL_padding") Then
                    txtPadding.Text = Settings("YTVL_padding").ToString()
                Else : txtPadding.Text = "3"
                End If

                If Settings.Contains("YTVL_spacing") Then
                    txtSpacing.Text = Settings("YTVL_spacing").ToString()
                Else : txtSpacing.Text = "3"
                End If


                If Settings.Contains("YTVL_listStyle") Then
                    txtListStyle.Text = Settings("YTVL_listStyle").ToString()
                Else : txtListStyle.Text = "dnnc_listStyle"
                End If

                If Settings.Contains("YTVL_listItemStyle") Then
                    txtListItemStyle.Text = Settings("YTVL_listItemStyle").ToString()
                Else : txtListItemStyle.Text = "dnnc_listItemStyle"
                End If

                If Settings.Contains("YTVL_listItemAltStyle") Then
                    txtListItemAltStyle.Text = Settings("YTVL_listItemAltStyle").ToString()
                Else : txtListItemAltStyle.Text = "dnnc_listItemAltStyle"
                End If

                If Settings.Contains("YTVL_RepeatDirection") Then
                    ddlRepeatDirection.SelectedValue = Settings("YTVL_RepeatDirection").ToString()
                Else : ddlRepeatDirection.SelectedValue = "Horizontal"
                End If

                If Settings.Contains("YTVL_RepeatLayout") Then
                    ddlRepeatLayout.SelectedValue = Settings("YTVL_RepeatLayout").ToString()
                Else : ddlRepeatLayout.SelectedValue = "Table"
                End If


                If Settings.Contains("YTVL_PPTheme") Then
                    ddlPPTheme.SelectedValue = Settings("YTVL_PPTheme").ToString()
                Else : ddlPPTheme.SelectedValue = "default"
                End If

                If Settings.Contains("YTVL_PPOpacity") Then
                    txtPPOpacity.Text = Settings("YTVL_PPOpacity").ToString()
                Else : txtPPOpacity.Text = "0.80"
                End If

                If Settings.Contains("YTVL_PPVideoSize") Then
                    ddlPPVideoSize.SelectedValue = Settings("YTVL_PPVideoSize").ToString()
                Else : ddlPPVideoSize.SelectedValue = "1"
                End If

                If Settings.Contains("YTVL_PPSuggestedVideos") Then
                    chkSuggestedVideos.Checked = Settings("YTVL_PPSuggestedVideos").ToString()
                Else : chkSuggestedVideos.Checked = False
                End If

                If Settings.Contains("YTVL_PPShowTitle") Then
                    chkShowTitle.Checked = Settings("YTVL_PPShowTitle").ToString()
                Else : chkShowTitle.Checked = True
                End If

                If Settings.Contains("YTVL_PPShowControls") Then
                    chkPlayerControls.Checked = Settings("YTVL_PPShowControls").ToString()
                Else : chkPlayerControls.Checked = False
                End If

            End If
        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    Public Overrides Sub UpdateSettings()
        Try
            Dim objModules As New Entities.Modules.ModuleController

            objModules.UpdateModuleSetting(ModuleId, "YTVL_API", txtApiKey.Text)

            objModules.UpdateModuleSetting(ModuleId, "YTVL_pagerSize", txtPagerSize.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_imageWidth", txtImageWidth.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_pageSize", txtPageSize.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_columns", txtColumns.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_width", txtWidth.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_padding", txtPadding.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_spacing", txtSpacing.Text)

            objModules.UpdateModuleSetting(ModuleId, "YTVL_listStyle", txtListStyle.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_listItemStyle", txtListItemStyle.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_listItemAltStyle", txtListItemAltStyle.Text)

            objModules.UpdateModuleSetting(ModuleId, "YTVL_RepeatDirection", ddlRepeatDirection.SelectedValue)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_RepeatLayout", ddlRepeatLayout.SelectedValue)

            objModules.UpdateModuleSetting(ModuleId, "YTVL_PPTheme", ddlPPTheme.SelectedValue)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_PPOpacity", txtPPOpacity.Text)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_PPVideoSize", ddlPPVideoSize.SelectedValue)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_PPSuggestedVideos", chkSuggestedVideos.Checked)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_PPShowTitle", chkShowTitle.Checked)
            objModules.UpdateModuleSetting(ModuleId, "YTVL_PPShowControls", chkPlayerControls.Checked)

        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

#End Region

End Class