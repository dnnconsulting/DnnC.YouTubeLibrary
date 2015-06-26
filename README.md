# DnnC YouTubLibrary

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

##Setting up the DnnC YouTubeLibrary

To make this module work you will need to create an Api key in the Google Developer Console. To do this follow the steps below:

1. You need a Google Account to access the Google Developers Console, request an API key, and register your application. Google account link : https://www.google.com/accounts/NewAccount
2. Create a project in the Google Developers Console and obtain authorization credentials so your application can submit API requests.
Goole Developers Console : https://console.developers.google.com
Authorization Credentials : https://console.developers.google.com/youtube/registering_an_application
3. After creating your project, make sure the YouTube Data API is one of the services that your application is registered to use:
- Go to the Developers Console and select the project that you just registered.
- In the sidebar on the left, expand APIs & auth. Next, click APIs. In the list of APIs, make sure the status is ON for the YouTube Data API v3.

