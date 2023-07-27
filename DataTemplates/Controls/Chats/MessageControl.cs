using System;
using System.Runtime.CompilerServices;

namespace DataTemplates.Controls.Chats;

public class MessageControl : ContentView
{
    public bool layoutSet = false;
    private readonly static int _consecutiveMessageSpacing = 3;
    private readonly static int _nonConsecutiveMessageSpacing = 10;

    public MessageControl()
    {
        this.SetBinding(MessageControl.IsFirstNewMessageProperty, "IsFirstNewMessage");
        this.SetBinding(IsAfterPauseProperty, "IsAfterPause");
        this.SetBinding(MessageControl.IsSelectedProperty, "IsSelected");
        this.SetBinding(IsConversationStartProperty, "IsConversationStart");
        this.SetBinding(IsConversationEndProperty, "IsConversationEnd");
        //this.SetBinding(ContactProperty, "SenderDisplay.Contact");

        //this.SetBinding(BackgroundColorProperty, new Binding("IsSelected", BindingMode.Default, (IValueConverter)Application.Current!.Resources["BoolToColour"], new List<Color>() { Color.FromArgb(Constants.SelectedColour), Color.FromArgb(Constants.TransparentColour) }, null, null));

        LoadCMSData();
    }

    protected virtual void LayoutView()
    {

    }

    protected virtual void UpdateContact() { }

    protected virtual void InitStackLayout() { }


    protected async Task LoadCMSData()
    {
        //TODO This will result in a lot of calls...
        //var cmsService = App.Instance.Resolve<ICMSService>();

        //this.ForwardedText = cmsService!.GetCMSValue(Constants.MessageCenterTypes.ForwardedTextKey);
        //this.MessageReceivedSeparatorText = cmsService!.GetCMSValue(Constants.MessageCenterTypes.MessageReceivedSeparatorTextKey);
    }

    protected override void OnBindingContextChanged()
    {
        this.ScaleTo(1, 300);
        base.OnBindingContextChanged();

    }

    //protected string FormatDateTime(DateTime datetime)
    //{
    //    var ldt = datetime.ToLocalTime();
    //    // Log.TraceWithCaller($"({datetime:d/MM HH:mm:ss K}), ldt {ldt:d/MM HH:mm:ss K}");

    //    if (ldt.IsToday())
    //        return datetime.ToLocalOffsetTime().ToString("t");

    //    return datetime == DateTime.MinValue ? string.Empty : datetime.ToLocalOffsetTime().ToString("t");
    //}

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

    }

    protected int CalcFrameTopMargin() => IsConversationStart ? _nonConsecutiveMessageSpacing : _consecutiveMessageSpacing;
    protected static int CalcFrameTopMargin(bool IsConversationStart) => IsConversationStart ? _nonConsecutiveMessageSpacing : _consecutiveMessageSpacing;

    protected string ForwardedText { get; set; }
    protected string MessageReceivedSeparatorText { get; set; }


    #region MessageContent
    public static readonly BindableProperty MessageContentProperty = BindableProperty.Create(nameof(MessageContent), typeof(View), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is Label)) return;
        var oldMessageContent = (View)old;
        var newMessageContent = (View)newV;
        me?.MessageContentChanged(oldMessageContent, newMessageContent);
    });

    private void MessageContentChanged(View oldMessageContent, View newMessageContent)
    {
    }

    /// <summary>
    /// THe content to be displayed in this Message
    /// </summary>
    public View MessageContent
    {
        get
        {

            var storedContent = (View)GetValue(MessageContentProperty);

            if (storedContent == null)
                return new BoxView() { WidthRequest = 100, HeightRequest = 100 };
            else
                return storedContent;
        }

        set
        {
            SetValue(MessageContentProperty, value);
        }
    }
    #endregion

    #region IsAfterPause
    public static readonly BindableProperty IsAfterPauseProperty = BindableProperty.Create(nameof(IsAfterPause), typeof(bool), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is bool)) return;
        var oldIsAfterPause = (bool)old;
        var newIsAfterPause = (bool)newV;
        me?.IsAfterPauseChanged(oldIsAfterPause, newIsAfterPause);
    });

    private void IsAfterPauseChanged(bool oldIsAfterPause, bool newIsAfterPause)
    {
    }

    /// <summary>
    /// Is this message after a pause in the conversation
    /// </summary>
    public bool IsAfterPause
    {
        get => (bool)GetValue(IsAfterPauseProperty);
        set => SetValue(IsAfterPauseProperty, value);
    }
    #endregion

    #region IsSelected
    public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is bool)) return;
        var oldIsSelected = (bool)old;
        var newIsSelected = (bool)newV;
        me?.IsSelectedChanged(oldIsSelected, newIsSelected);
    });

    private void IsSelectedChanged(bool oldIsSelected, bool newIsSelected)
    {

    }

    /// <summary>
    /// Is this message selected in the conversation
    /// </summary>
    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }
    #endregion

    #region IsConversationStart
    public static readonly BindableProperty IsConversationStartProperty = BindableProperty.Create(nameof(IsConversationStart), typeof(bool), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is bool)) return;
        var oldIsConversationStart = (bool)old;
        var newIsConversationStart = (bool)newV;
        me?.IsConversationStartChanged(oldIsConversationStart, newIsConversationStart);
    });

    private void IsConversationStartChanged(bool oldIsConversationStart, bool newIsConversationStart)
    {
        if (oldIsConversationStart != newIsConversationStart)
            LayoutView();
    }

    /// <summary>
    /// Is this message the start of a conversation
    /// </summary>
    public bool IsConversationStart
    {
        get => (bool)GetValue(IsConversationStartProperty);
        set => SetValue(IsConversationStartProperty, value);
    }
    #endregion

    #region IsConversationEnd
    public static readonly BindableProperty IsConversationEndProperty = BindableProperty.Create(nameof(IsConversationEnd), typeof(bool), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is bool)) return;
        var oldIsConversationEnd = (bool)old;
        var newIsConversationEnd = (bool)newV;
        me?.IsConversationEndChanged(oldIsConversationEnd, newIsConversationEnd);
    });

    private void IsConversationEndChanged(bool oldIsConversationEnd, bool newIsConversationEnd)
    {  // if(oldIsConversationEnd != newIsConversationEnd)
       //   LayoutView();
    }

    /// <summary>
    /// Is this message the end of a conversation
    /// </summary>
    public bool IsConversationEnd
    {
        get => (bool)GetValue(IsConversationEndProperty);
        set => SetValue(IsConversationEndProperty, value);
    }
    #endregion

    #region IsGroup
    public static readonly BindableProperty IsGroupProperty = BindableProperty.Create(nameof(IsGroup), typeof(bool), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is bool)) return;
        var oldIsGroup = (bool)old;
        var newIsGroup = (bool)newV;
        me?.IsGroupChanged(oldIsGroup, newIsGroup);
    });

    private void IsGroupChanged(bool oldIsGroup, bool newIsGroup)
    {  // if(oldIsGroup != newIsGroup)
       //InitStackLayout();
    }

    /// <summary>
    /// Is this part of a group room
    /// </summary>
    public bool IsGroup
    {
        get => (bool)GetValue(IsGroupProperty);
        set => SetValue(IsGroupProperty, value);
    }
    #endregion

    #region Title
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is string)) return;
        var oldTitle = (string)old;
        var newTitle = (string)newV;
        me?.TitleChanged(oldTitle, newTitle);
    });

    private void TitleChanged(string oldTitle, string newTitle)
    {   //if(oldTitle != newTitle)
        //   LayoutView();
    }

    /// <summary>
    /// The title to be displayed on the message
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    #endregion

    //#region Contact
    //public static readonly BindableProperty ContactProperty = BindableProperty.Create(nameof(Contact), typeof(User), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    //{
    //    var me = obj as MessageControl;
    //    if (newV != null && !(newV is User)) return;
    //    var oldContact = (User)old;
    //    var newContact = (User)newV;
    //    me?.ContactChanged(oldContact, newContact);
    //});

    //private void ContactChanged(User oldContact, User newContact)
    //{
    //    if (oldContact != newContact)
    //        UpdateContact();
    //}

    ///// <summary>
    ///// The Contact who sent this message
    ///// </summary>
    //public User Contact
    //{
    //    get => (User)GetValue(ContactProperty);
    //    set => SetValue(ContactProperty, value);
    //}
    //#endregion

    #region IsForwarded
    public static readonly BindableProperty IsForwardedProperty = BindableProperty.Create(nameof(IsForwarded), typeof(bool), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is bool)) return;
        var oldIsForwarded = (bool)old;
        var newIsForwarded = (bool)newV;
        me?.IsForwardedChanged(oldIsForwarded, newIsForwarded);
    });

    private void IsForwardedChanged(bool oldIsForwarded, bool newIsForwarded)
    {

    }

    /// <summary>
    /// Indicating this message was forwarded
    /// </summary>
    public bool IsForwarded
    {
        get => (bool)GetValue(IsForwardedProperty);
        set => SetValue(IsForwardedProperty, value);
    }
    #endregion

    //#region MessageState
    //public static readonly BindableProperty MessageStateProperty = BindableProperty.Create(nameof(MessageState), typeof(MessageStatus), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    //{
    //    var me = obj as MessageControl;
    //    if (newV != null && !(newV is MessageStatus)) return;
    //    var oldMessageState = (MessageStatus)old;
    //    var newMessageState = (MessageStatus)newV;
    //    me?.MessageStateChanged(oldMessageState, newMessageState);
    //});

    //private void MessageStateChanged(MessageStatus oldMessageState, MessageStatus newMessageState)
    //{
    //}

    ///// <summary>
    ///// The current State of the message
    ///// </summary>
    //public MessageStatus MessageState
    //{
    //    get => (MessageStatus)GetValue(MessageStateProperty);
    //    set => SetValue(MessageStateProperty, value);
    //}
    //#endregion

    #region IsFirstNewMessage
    public static readonly BindableProperty IsFirstNewMessageProperty = BindableProperty.Create(nameof(IsFirstNewMessage), typeof(bool), typeof(MessageControl), propertyChanged: (obj, old, newV) =>
    {
        var me = obj as MessageControl;
        if (newV != null && !(newV is bool)) return;
        var oldIsFirstNewMessage = (bool)old;
        var newIsFirstNewMessage = (bool)newV;
        me?.IsFirstNewMessageChanged(oldIsFirstNewMessage, newIsFirstNewMessage);
    });

    private void IsFirstNewMessageChanged(bool oldIsFirstNewMessage, bool newIsFirstNewMessage)
    {
        if (oldIsFirstNewMessage != newIsFirstNewMessage)
            LayoutView();
    }

    /// <summary>
    /// Hightlight new messages
    /// </summary>
    public bool IsFirstNewMessage
    {
        get => (bool)GetValue(IsFirstNewMessageProperty);
        set => SetValue(IsFirstNewMessageProperty, value);
    }
    #endregion
}

