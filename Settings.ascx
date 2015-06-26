<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="Settings.ascx.vb" Inherits="DnnC.Modules.YouTubeLibrary.Settings" %>
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

<h2 id="dshApiSetting" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("dshApiSetting")%></a></h2>
<fieldset>
    <p>To make this module work you will need to create an Api key in the Google Developer Console. To do this follow the steps below:</p>
    <ol>
        <li>
            You need a <a href="https://www.google.com/accounts/NewAccount" target="_blank">Google Account</a> 
            to access the Google Developers Console, request an API key, and register your application.
        </li>
        <li>
            Create a project in the <a href="https://console.developers.google.com" target="_blank">Google 
            Developers Console</a> and <a href="https://console.developers.google.com/youtube/registering_an_application" target="_blank">
            obtain authorization credentials</a> so your application can submit API requests.
        </li>
        <li>
            After creating your project, make sure the YouTube Data API is one of the services that your application is registered to use:
            <ol>
                <li>Go to the <a href="https://console.developers.google.com" target="_blank">Developers Console</a> and select the project that you just registered.</li>
                <li>In the sidebar on the left, expand <strong>APIs & auth</strong>. Next, click APIs. In the list of <strong>APIs</strong>, make sure the status is <strong>ON</strong> for the <strong>YouTube Data API v3.</strong></li>
            </ol>
        </li>
        <li>
            Select a client library to simplify your API implementation.
        </li>
    </ol>

    <div class="dnnFormItem">
        <dnn:Label ID="lblApiKey" runat="server" controlname="txtPagerSize" />
	    <asp:TextBox ID="txtApiKey" runat="server" ValidationGroup="api"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqAPI" runat="server" ErrorMessage="Api key is required!" ControlToValidate="txtApiKey" ValidationGroup="api"></asp:RequiredFieldValidator>
    </div>
</fieldset>

<h2 id="dshBasicSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("dshBasicSettings")%></a></h2>
<fieldset>    
    <div class="dnnFormItem">
        <dnn:Label ID="lblPagerSize" runat="server" controlname="txtPagerSize" />
	    <asp:TextBox ID="txtPagerSize" runat="server" Width="50px"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblPageSize" runat="server" controlname="txtPageSize" />
	    <asp:TextBox ID="txtPageSize" runat="server" Width="50px"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblRepeatDirection" runat="server" controlname="ddlRepeatDirection" />
        <asp:DropDownList ID="ddlRepeatDirection" runat="server">
            <asp:ListItem Value="Horizontal" ResourceKey="optHorizontal" />
            <asp:ListItem Value="Vertical" ResourceKey="optVertical" />
        </asp:DropDownList>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblRepeatLayout" runat="server" controlname="ddlRepeatLayout" />
        <asp:DropDownList ID="ddlRepeatLayout" runat="server">
            <asp:ListItem Value="Table" ResourceKey="optTable" />
            <asp:ListItem Value="Flow" ResourceKey="optFlow" />
        </asp:DropDownList>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblColumns" runat="server" controlname="txtColumns" />
	    <asp:TextBox ID="txtColumns" runat="server" Width="50px"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblImageWidth" runat="server" controlname="txtImageWidth" />
	    <asp:TextBox ID="txtImageWidth" runat="server" Width="50px"></asp:TextBox> px
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblWidth" runat="server" controlname="txtWidth" />
	    <asp:TextBox ID="txtWidth" runat="server" Width="50px"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblPadding" runat="server" controlname="txtPadding" />
	    <asp:TextBox ID="txtPadding" runat="server" Width="50px"></asp:TextBox> px
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblSpacing" runat="server" controlname="txtSpacing" />
	    <asp:TextBox ID="txtSpacing" runat="server" Width="50px"></asp:TextBox> px
    </div>
</fieldset>

<h2 id="dshCssSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("dshCssSettings")%></a></h2>
<fieldset>
    <div class="dnnFormItem">
        <dnn:Label ID="lblListStyle" runat="server" controlname="txtListStyle" />
	    <asp:TextBox ID="txtListStyle" runat="server" ></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblListItemStyle" runat="server" controlname="txtListItemStyle" />
	    <asp:TextBox ID="txtListItemStyle" runat="server" ></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblListItemAltStyle" runat="server" controlname="txtListItemAltStyle" />
	    <asp:TextBox ID="txtListItemAltStyle" runat="server" ></asp:TextBox>
    </div>
</fieldset>

<h2 id="dshPopupSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("dshPopupSettings")%></a></h2>
<fieldset>
    <div class="dnnFormItem">
        <dnn:Label ID="lblPPTheme" runat="server" controlname="ddlPPTheme" />
        <asp:DropDownList ID="ddlPPTheme" runat="server">
            <asp:ListItem Value="default" Text="Default" />
            <asp:ListItem Value="dark_rounded" Text="Dark Rounded" />
            <asp:ListItem Value="dark_square" Text="Dark Square" />
            <asp:ListItem Value="facebook" Text="Facebook" />
            <asp:ListItem Value="light_rounded" Text="Light Rounded" />
            <asp:ListItem Value="light_square" Text="Light Square" />
        </asp:DropDownList>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblPPOpacity" runat="server" controlname="txtPPOpacity" />
	    <asp:TextBox ID="txtPPOpacity" runat="server" Width="50px" ></asp:TextBox>
    </div>


    <div class="dnnFormItem">
        <dnn:Label ID="lblPPVideoSize" runat="server" controlname="ddlVideoSize" />
        <asp:DropDownList ID="ddlPPVideoSize" runat="server">
            <asp:ListItem Value="1" Text="560 x 315" />
            <asp:ListItem Value="2" Text="600 x 360" />
            <asp:ListItem Value="3" Text="853 x 480" />
            <asp:ListItem Value="4" Text="1280 x 720" />
        </asp:DropDownList>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblPPShowSuggestedVideos" runat="server" controlname="chkSuggestedVideos" />
        <asp:CheckBox ID="chkSuggestedVideos" runat="server" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblPPPlayerControls" runat="server" controlname="chkPlayerControls" />
        <asp:CheckBox ID="chkPlayerControls" runat="server" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblPPShowTitle" runat="server" controlname="chkShowTitle" />
        <asp:CheckBox ID="chkShowTitle" runat="server" />
    </div>
</fieldset>


