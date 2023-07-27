namespace DataTemplates.Controls.Chats;

public partial class ReceivedMessage : MessageControl
{
	public ReceivedMessage()
	{
		InitializeComponent();
	}

    public ReceivedMessage(ContentView messageContent)
    {
        MessageContent = messageContent;

        InitializeComponent();
    }
}
