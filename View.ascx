<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="View.ascx.vb" Inherits="DnnC.Modules.YouTubeLibrary.View" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" FilePath="/DesktopModules/DnnC_YouTubeLibrary/assets/prettyPhoto/prettyPhoto.css" />
<dnn:DnnJsInclude runat="server" filepath="/DesktopModules/DnnC_YouTubeLibrary/assets/prettyPhoto/jquery.prettyPhoto.js" />

<asp:Panel ID="pnlError" runat="server" Visible="false">
    <div class="dnnFormMessage dnnFormValidationSummary"><asp:Label ID="lblError" runat="server"></asp:Label></div>
</asp:Panel>

<asp:Literal ID="ltlCss" runat="server"></asp:Literal>

<!-- Begin Video List -->
<div class="DnnC">
    <asp:DataList ID="dlList" runat="server">
        <ItemTemplate></ItemTemplate>
    </asp:DataList>
    <dnn:pagingcontrol id=ctlPagingControl runat="server"></dnn:pagingcontrol>
</div>
<!-- End Video List -->

<asp:Panel ID="panelAdmin" runat="server" Visible="false">
    <asp:LinkButton ID="btnAddNew" runat="server" resourcekey="cmdAdminAdd" CssClass="dnnPrimaryAction" />
    <asp:LinkButton ID="btnManage" runat="server" resourcekey="cmdAdminManage" CssClass="dnnPrimaryAction" />
    <asp:LinkButton ID="btnTemplate" runat="server" resourcekey="cmdAdminTemplate" CssClass="dnnPrimaryAction" />
</asp:Panel>

<asp:Literal ID="ltlVideoScript" runat="server"></asp:Literal>