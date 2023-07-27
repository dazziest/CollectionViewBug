namespace DataTemplates.Controls.Chats;

public partial class SentMessage : MessageControl
{
	public SentMessage()
	{
		InitializeComponent();
	}

    public SentMessage(ContentView messageContent)
    {
        MessageContent = messageContent;

        InitializeComponent();
    }
}
