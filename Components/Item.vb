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
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.ComponentModel.DataAnnotations
Imports System.Web.Caching
Imports System

Namespace Components

    'setup the primary key for table
    'configure caching using PetaPoco
    'scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    <TableName("DnnC_YouTubeLibrary_Items")> _
    <PrimaryKey("ItemId", AutoIncrement:=True)> _
    <Cacheable("Items", CacheItemPriority.Default, 20)> _
    <Scope("ModuleId")>
    Public Class Item

        Private _itemId As Integer
        Private _portalId As Integer
        Private _moduleId As Integer
        Private _videoId As String
        Private _videoOrder As Integer
        Private _videoTitle As String
        Private _videoDescription As String
        Private _isVisible As Boolean
        Private _createdByUserId As Integer
        Private _createdOnDate As DateTime

        Public Property ItemId() As Integer
            Get
                Return _itemId
            End Get
            Set(ByVal value As Integer)
                _itemId = value
            End Set
        End Property

        Public Property PortalId() As Integer
            Get
                Return _portalId
            End Get
            Set(ByVal value As Integer)
                _portalId = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property

        Public Property VideoId() As String
            Get
                Return _videoId
            End Get
            Set(ByVal value As String)
                _videoId = value
            End Set
        End Property

        Public Property VideoOrder() As Integer
            Get
                Return _videoOrder
            End Get
            Set(ByVal value As Integer)
                _videoOrder = value
            End Set
        End Property

        Public Property VideoTitle() As String
            Get
                Return _videoTitle
            End Get
            Set(ByVal value As String)
                _videoTitle = value
            End Set
        End Property

        Public Property VideoDescription() As String
            Get
                Return _videoDescription
            End Get
            Set(ByVal value As String)
                _videoDescription = value
            End Set
        End Property

        Public Property IsVisible() As Boolean
            Get
                Return _isVisible
            End Get
            Set(ByVal value As Boolean)
                _isVisible = value
            End Set
        End Property

        Public Overloads Property CreatedByUserId() As Integer
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime
            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property

    End Class

End Namespace