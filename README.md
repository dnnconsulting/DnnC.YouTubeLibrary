﻿# DnnC YouTubLibrary

The DnnC YouTube Library makes it a breeze to build a library of YouTube videos for you DnnCMS website.

Fully template you can customize the look and feel of the module to fit with your own website. The template editing system uses CodeMirror for code tag coloring making it easy to edit the templates and Css.

The DnnC YouTube Library makes it easy to manage your videos with ‘drag and drop’ functionality to easily change the display order of you videos.

Adding a video to your library is also very easy, just copy the YouTube video ID, paste it into the input box and click ‘Retrieve video data’ then the module does the rest, by importing all the video data including the title, description, even a thumb of the video for you. When the data is imported you can then change the information about the video easily and save!

No more copying and pasting the embed code of your YouTube videos into a Text/Html module!

**Requirements** Dnn 06.02.00 and up

**Installation** The installation of the Module is the same as any other Dnn Module:
1. BackUp your Dnn install and database.
2. Login as 'Host' of your install.
3. Navigate to : Host > Extensions then clickthe 'Install Extension Wizard' button and follow the instructions.
4. Once the Module has been installed, you should see the new module when you want to insert it into a page.

##Setting up the DnnC YoouTubeLibrary














Demo of the SkinObject in action:

http://www.cmsxpress.nl

http://www.interschools.nl




#### Do I need to do anything else?
Simply telling users that your site uses cookies is the absolute bare minimum. Cookie Consent allows you to link to a cookie or privacy policy, if you have one. To comply with the law, we strongly recommend that you prepare a brief policy and link to it. Here’s [Silktides privacy policy](https://silktide.com/tools/cookie-consent/docs/compliance), as an example.





```html
<%@ Register TagPrefix="dnn" TagName="COOKIECONSENT" Src="~/DesktopModules/DnnC_CookieConsent/CookieConsent.ascx" %>
```

Next add the following to you skin:

```html
<dnn:CookieConsent runat="server" />
```

To link the CookieConsent bar to your cookie policy page, use the 'CookiePolicyLink' setting:

```html
<dnn:CookieConsent runat="server" CookiePolicyLink="http://www.mysite.com/cookiepolicy.aspx" />
```
(change www.mysite.com and page to corrispond to your website)

To change the look and position of the CookieConsent bar, use the 'CookieTheme' setting:

```html
<dnn:CookieConsent runat="server" CookieTheme="light-bottom" CookiePolicyLink="http://www.mysite.com/cookiepolicy.aspx" />
```

The builtin themes are as follows:
- dark-top (default)
- dark-floating
- dark-bottom
- light-floating
- light-top
- light-bottom

When you choose "light-floating" or "dark-floating" a cookieconsent logo appears, if you want to hide this just add the following piece of css to your style sheet:

```css
a.cc_logo { visibility:hidden; }
```
