<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="TemplateManager.ascx.vb" Inherits="DnnC.Modules.YouTubeLibrary.TemplateManager" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" FilePath="/DesktopModules/DnnC_YouTubeLibrary/assets/codemirror-4.6/lib/codemirror.css" />
<dnn:DnnJsInclude runat="server" filepath="/DesktopModules/DnnC_YouTubeLibrary/assets/codemirror-4.6/lib/codemirror.js" priority="1" />
<dnn:DnnJsInclude runat="server" filepath="/DesktopModules/DnnC_YouTubeLibrary/assets/codemirror-4.6/mode/xml/xml.js" priority="2" />
<dnn:DnnJsInclude runat="server" filepath="/DesktopModules/DnnC_YouTubeLibrary/assets/codemirror-4.6/mode/javascript/javascript.js" priority="3" />
<dnn:DnnJsInclude runat="server" filepath="/DesktopModules/DnnC_YouTubeLibrary/assets/codemirror-4.6/mode/css/css.js" priority="4" />
<dnn:DnnJsInclude runat="server" filepath="/DesktopModules/DnnC_YouTubeLibrary/assets/codemirror-4.6/mode/htmlmixed/htmlmixed.js" priority="5" />
<dnn:DnnJsInclude runat="server" filepath="/DesktopModules/DnnC_YouTubeLibrary/assets/codemirror-4.6/addon/edit/closetag.js" priority="6" />

<asp:LinkButton ID="cmdReturn" runat="server" resourcekey="cmdReturn" CssClass="dnnSecondaryAction" />
<br />
<asp:LinkButton ID="cmdSave1" runat="server" CssClass="dnnPrimaryAction" ResourceKey="cmdSave" ValidationGroup="EditVideo"></asp:LinkButton>
<asp:LinkButton ID="cmdSaveReturn1" runat="server" CssClass="dnnPrimaryAction" ResourceKey="cmdSaveReturn" ValidationGroup="EditVideo"></asp:LinkButton>

<div class="dnnForm" id="panelsTemplates">
    <div class="dnnFormExpandContent"><a href="">Expand All</a></div>
    <div>
        <h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="#" class="dnnSectionExpanded"> <%=LocalizeString("dspHtmlTemplate")%></a></h2>
        <fieldset>
            <div style="border:solid 1px #ccc;"><asp:TextBox ID="txtTemplate" runat="server" Width="100%" Height="100%" TextMode="MultiLine" Visible="true"></asp:TextBox></div>

            <div class="Dnnc_TokensPanel">
                <h3>Tokens</h3>
                <ul>
                    <li>[TAG:Title]</li>
                    <li>[TAG:PopUpUrl]</li>
                    <li>[TAG:EmbeddedVideo]</li>
                    <li>[TAG:Description]</li>
                    <li>[TAG:ItemId]</li>
                    <li>[TAG:VideoId]</li>
                    <li>[TAG:VideoUrl]</li>
                    <li>[TAG:AdminEditButton]</li>
                </ul>
            </div>
            <asp:LinkButton ID="cmdLoadDefaultHtml" runat="server" CssClass="dnnTertiaryAction" ResourceKey="cmdLoadDefaultHtml"></asp:LinkButton>
        </fieldset>
    </div>


    <div>
        <h2 id="H2" class="dnnFormSectionHead"><a href="#" class="dnnSectionExpanded"> <%=LocalizeString("dspCssTemplate")%></a></h2>
        <fieldset>
            <div style="border:solid 1px #ccc;"><asp:TextBox ID="txtCss" runat="server" Width="100%" Height="100%" TextMode="MultiLine" Visible="true"></asp:TextBox></div>
            <asp:LinkButton ID="cmdLoadDefaultCss" runat="server" CssClass="dnnTertiaryAction" ResourceKey="cmdLoadDefaultCss"></asp:LinkButton>
        </fieldset>
    </div>

</div>


<asp:LinkButton ID="cmdSave2" runat="server" CssClass="dnnPrimaryAction" ResourceKey="cmdSave" ValidationGroup="EditVideo"></asp:LinkButton>
<asp:LinkButton ID="cmdSaveReturn2" runat="server" CssClass="dnnPrimaryAction" ResourceKey="cmdSaveReturn" ValidationGroup="EditVideo"></asp:LinkButton>

<script type="text/javascript">
    jQuery(function ($) {
        var setupModule = function () {
            $('#panelsTemplates').dnnPanels();
            $('#panelsTemplates .dnnFormExpandContent a').dnnExpandAll({
                targetArea: '#panelsTemplates'
            });
        };
        setupModule();

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            setupModule();
        });
    });
</script>

<script>
    jQuery(function ($) {
        var mixedMode = {
            name: "htmlmixed",
            scriptTypes: [{
                matches: /\/x-handlebars-template|\/x-mustache/i,
                mode: null
            },
            {
                matches: /(text|application)\/(x-)?vb(a|script)/i,
                mode: "vbscript"
            }]
        };
        var editorHtml = CodeMirror.fromTextArea($("textarea[id$='txtTemplate']")[0], {
            lineNumbers: true,
            styleActiveLine: true,
            matchBrackets: true,
            autoCloseTags: true,
            lineWrapping: true,
            mode: mixedMode
        });

        var editorCss = CodeMirror.fromTextArea($("textarea[id$='txtCss']")[0], {
            lineNumbers: true,
            styleActiveLine: true,
            matchBrackets: true,
            autoCloseTags: true,
            lineWrapping: true,
            mode: mixedMode
        });

        var charWidth = editorHtml.defaultCharWidth(), basePadding = 4;
        editorHtml.on("renderLine", function (cm, line, elt) {
            var off = CodeMirror.countColumn(line.text, null, cm.getOption("tabSize")) * charWidth;
            elt.style.textIndent = "-" + off + "px";
            elt.style.paddingLeft = (basePadding + off) + "px";
        });
        editorHtml.refresh();

        var charWidth = editor.defaultCharWidth(), basePadding = 4;
        editorCss.on("renderLine", function (cm, line, elt) {
            var off = CodeMirror.countColumn(line.text, null, cm.getOption("tabSize")) * charWidth;
            elt.style.textIndent = "-" + off + "px";
            elt.style.paddingLeft = (basePadding + off) + "px";
        });
        editorCss.refresh();   
    });
</script>

<script>
    $('#<%= cmdLoadDefaultHtml.ClientID%>').dnnConfirm({
        text: '<%= LocalizeString("txtAlertLoadDefaultHtml.Text") %>'
    });
    $('#<%= cmdLoadDefaultCss.ClientID%>').dnnConfirm({
        text: '<%= LocalizeString("txtAlertLoadDefaultCss.Text")%>'
    });
</script>