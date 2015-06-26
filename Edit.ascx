<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="Edit.ascx.vb" Inherits="DnnC.Modules.YouTubeLibrary.Edit" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagName="TextEditor" TagPrefix="dnn" Src="~/controls/TextEditor.ascx" %>

<!-- Begin video list -->
<asp:Panel ID="PanelList" runat="server" Visible="true">   
    <asp:LinkButton ID="cmdReturn" runat="server" resourcekey="cmdReturn" CssClass="dnnSecondaryAction" />
    <asp:LinkButton ID="cmdAddVideo" runat="server" resourcekey="cmdAddVideo" CssClass="dnnPrimaryAction" />
        
    <!-- Begin List Panel -->
    <div class="DnnC_list-panel">
        <asp:hiddenfield ID="VideoOrder" runat="server" />
        <asp:datagrid id="grdVideos" 
            DataKeyField="ItemId"
            Width="100%" 
            AutoGenerateColumns="false" 
            runat="server" 
            BorderStyle="None" 
            GridLines="None" 
            ShowHeader="false"
            CssClass="Sortable">

            <AlternatingItemStyle  CssClass="dnnGridAltItem" />
            <ItemStyle  CssClass="dnnGridItem" />

            <columns>
                <asp:templatecolumn ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Wrap="False"></ItemStyle>
                    <itemtemplate>
                        <asp:ImageButton ID="cmdEditVideo" runat="server" CommandName="cmdEditVideo" CommandArgument='<%# Eval("ItemId")%>' ImageUrl="~/icons/sigma/Edit_16X16_Standard.png" />
                    </itemtemplate>
                </asp:templatecolumn>            

                <asp:templatecolumn>
                    <ItemStyle CssClass="Draggable"/>
                    <itemtemplate>
                        <asp:Label ID="lblVideoTitle" runat="server" Text='<%# Eval("VideoTitle")%>'></asp:Label>
                    </itemtemplate>
                </asp:templatecolumn>                 
                       
                <asp:templatecolumn ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                    <itemtemplate>
                        <asp:ImageButton ID="imgVisible" runat="server" CommandName="cmdChangeVisibility" CommandArgument='<%# Eval("ItemId")%>' />
                    </itemtemplate>
                </asp:templatecolumn>
       
                <asp:templatecolumn ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                    <itemtemplate>
                        <asp:ImageButton ID="cmdDeleteVideo" runat="server" CommandName="cmdDeleteVideo" CommandArgument='<%# Eval("ItemId")%>' ImageUrl="~/icons/sigma/Delete_16X16_Standard.png" />
                    </itemtemplate>
                </asp:templatecolumn>
            </columns>
        </asp:datagrid><!-- End DataGrid -->
    </div><!-- End List Panel -->
            
</asp:Panel><!-- End video list -->

<!-- Begin Video input -->
<asp:Panel ID="PanelInput" runat="server" Visible="false">

    <asp:Panel ID="pnlError" runat="server" Visible="false">
        <span class="dnnFormMessage dnnFormError"><asp:Label ID="lblError" runat="server"></asp:Label></span>
    </asp:Panel>

    <div class="dnnFormItem">
        <dnn:Label ID="lblVideoId" runat="server" controlname="txtPageSize" />
	    <asp:TextBox ID="txtVideoId" runat="server" Width="100px"></asp:TextBox>
        <asp:LinkButton ID="cmdGetVideoData" runat="server" resourcekey="cmdGetVideoData" CssClass="dnnSecondaryAction" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtVideoId"                
            Display="Dynamic" Text="*">
        </asp:RequiredFieldValidator>
    </div>

    <asp:Panel ID="pnlVideoData" runat="server" Visible="false">
        <div class="dnnFormItem">
            <dnn:Label ID="lblVideoVisible" runat="server" controlname="chkVisible" />
            <asp:CheckBox ID="chkVisible" runat="server" Checked="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblVideoTitle" runat="server" controlname="txtVideoTitle" />
            <asp:TextBox ID="txtVideoTitle" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblDescription" runat="server" controlname="txtDescription" />
            <dnn:TextEditor id="txtDescription" runat="server" width="100%" ValidationGroup="tabs" height="300px"></dnn:TextEditor>
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblPreviewImage" runat="server" controlname="txtDescription" />
            <asp:Image ID="imgPreview" runat="server" />
        </div>
    </asp:Panel>

    <asp:LinkButton ID="cmdSave" runat="server" CssClass="dnnPrimaryAction" ResourceKey="cmdSave"></asp:LinkButton>
    <asp:LinkButton ID="cmdCancel" runat="server" CssClass="dnnSecondaryAction" ResourceKey="cmdCancel" CausesValidation="false"></asp:LinkButton>
         

</asp:Panel><!-- End Video input -->

<!-- Begin Script -->
<script type="text/javascript">
    (function ($) {
        $(document).ready(function () {
            $(".Sortable tbody")
                .sortable({
                    items: 'tr:has([id])',
                    placeholder: 'ui-state-highlight',
                    helper: function (e, tr) {
                        var $originals = tr.children();
                        var $helper = tr.clone();
                        $helper.children().each(function (index) {
                            $(this).width($originals.eq(index).width());
                        });
                        return $helper;
                    },
                    update: function (event, ui) {
                        var serial = $(this).sortable('toArray');
                        $('#<%=VideoOrder.ClientID%>').val(serial);
                        __doPostBack('__Page', 'VideoOrder');
                    }
                })
                .disableSelection();
        });
    }(jQuery));
</script><!-- End Script -->